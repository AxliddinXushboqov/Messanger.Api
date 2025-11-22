using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Messanger.Api.Brokers.Files
{
    public class FileBroker : IFileBroker
    {
        public async ValueTask<string> SaveFileAsync(
            MemoryStream memoryStream, string fileName, string uploadsFolder)
        {
            string filePath = Path.Combine(uploadsFolder, fileName);
            var relativePath = Path.Combine("imageFiles", fileName);

            try
            {
                using (var resizedStream = ResizeAndConvertToWebP(memoryStream))
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        resizedStream.Seek(0, SeekOrigin.Begin);
                        await resizedStream.CopyToAsync(fileStream);
                    }
                }

                return relativePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save the file.", ex);
            }
        }

        public async Task DeleteImageFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    throw new FileNotFoundException("File not found.", filePath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete file '{filePath}'.", ex);
            }
        }


        public MemoryStream ResizeAndConvertToWebP(MemoryStream memoryStream)
        {

            using (Image image = Image.Load(memoryStream))
            {
                double aspectRatio = (double)image.Width / image.Height;
                int maxHeight = (int)(600 / aspectRatio);
                int maxWidth = 600;
                image.Mutate(x => x.Resize(maxWidth, maxHeight));
                MemoryStream resultStream = new MemoryStream();
                image.SaveAsWebp(resultStream);
                resultStream.Position = 0;

                return resultStream;
            }
        }
    }
}