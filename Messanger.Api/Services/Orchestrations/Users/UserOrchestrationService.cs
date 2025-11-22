using System.Security.Claims;
using Messanger.Api.Models.Foundations.Users;
using Messanger.Api.Services.Foundations.Files;
using Messanger.Api.Services.Foundations.Users;
using Microsoft.IdentityModel.Tokens;

namespace Messanger.Api.Services.Orchestrations.Users
{
    public class UserOrchestrationService : IUserOrchestrationService
    {
        private readonly IUserService userService;
        private readonly IFileService fileService;

        public UserOrchestrationService(IUserService userService, IFileService fileService)
        {
            this.userService = userService;
            this.fileService = fileService;
        }

        public ValueTask<User> ModifyUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<string> ModifyUserImageAsync(Guid userId, MemoryStream memoryStream)
        {
            string fileName = Guid.NewGuid().ToString() + ".WebP";

            var uploadsFolder =
                 Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imageFiles");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var user = await this.userService.RetrieveUserByIdAsync(userId);

            if (user != null)
            {
                var imageFilePath = await this.fileService.SaveFileAsync(memoryStream, fileName, uploadsFolder);
                user.image = imageFilePath;
                await this.userService.ModifyUserAsync(user);
                return imageFilePath;
            }
            else
                throw new Exception("User Not Found");
        }

        public async ValueTask<User> RemoveUserAsync(Guid id)
        {
            var user = await this.userService.RetrieveUserByIdAsync(id);

            if (user.image.IsNullOrEmpty())
                await this.fileService.DeleteImageFile(user.image);

            return await this.userService.RemoveUserAsync(user);
        }

        public IQueryable<User> RetrieveAllUsers() =>
            this.userService.RetrieveAllUsers();

        public async ValueTask<User> RetrieveUserByIdAsync(Guid userId) =>
            await this.userService.RetrieveUserByIdAsync(userId);

        public async ValueTask<User> RetrieveUserProfileAsync(ClaimsPrincipal user)
        {
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == "UserId");
            Guid.TryParse(userIdClaim.Value, out Guid userId);

            return await this.userService.RetrieveUserByIdAsync(userId);
        }
    }
}
