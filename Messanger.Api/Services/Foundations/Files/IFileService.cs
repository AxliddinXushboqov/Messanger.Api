namespace Messanger.Api.Services.Foundations.Files
{
    public interface IFileService
    {
        ValueTask<string> SaveFileAsync(MemoryStream memoryStream, string fileName, string uploadsFolder);
        Task DeleteImageFile(string filePath);
    }
}