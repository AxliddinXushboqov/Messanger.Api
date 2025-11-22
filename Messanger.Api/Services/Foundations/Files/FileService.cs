using Messanger.Api.Brokers.Files;

namespace Messanger.Api.Services.Foundations.Files
{
    public class FileService : IFileService
    {
        private readonly IFileBroker fileBroker;

        public FileService(IFileBroker fileBroker)
        {
            this.fileBroker = fileBroker;
        }

        public async ValueTask<string> SaveFileAsync(MemoryStream memoryStream, string fileName, string uploadsFolder) =>
            await fileBroker.SaveFileAsync(memoryStream, fileName, uploadsFolder);

        public async Task DeleteImageFile(string filePath) =>
            await fileBroker.DeleteImageFile(filePath);
    }
}