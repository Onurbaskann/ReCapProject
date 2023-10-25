using Core.Utilities.Helper.GuidHelper;
using Core.Utilities.Messages;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public IResult Delete(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    return new SuccessResult(FileMessages.FileDeletionSuccessMessage);
                }
                catch (Exception ex)
                {
                    return new ErrorResult($"{FileMessages.FileDeletionFailureMessage} Hata: {ex.Message}");
                }
            }
            return new ErrorResult(FileMessages.FilePathNotFoundMessage);
        }
        public IDataResult<string> Update(IFormFile newFile, string oldPath)
        {
            try
            {
                var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                string fileName = newFile.FileName;
                string uniqueFileName = GuildHelper.GetCustomGuid(fileName);
                string newFilePath = Path.Combine(uploadDirectory, uniqueFileName);

                using (var newFileStream = new FileStream(newFilePath, FileMode.Create))
                {
                    newFile.CopyTo(newFileStream);
                }

                if (File.Exists(oldPath))
                {
                    try
                    {
                        File.Delete(oldPath);
                    }
                    catch (Exception ex)
                    {
                        return new ErrorDataResult<string>($"{FileMessages.OldFileDeletionFailureMessage} Hata: {ex.Message}");
                    }
                }
                else
                {
                    return new ErrorDataResult<string>(FileMessages.FilePathNotFoundMessage);
                }
                return new SuccessDataResult<string>(newFilePath, FileMessages.FileUpdateSuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>($"{FileMessages.FileUpdateFailureMessage} Hata: {ex.Message}");
            }
        }
        public IDataResult<string> Upload(IFormFile file)
        {
            string uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            string fileName = file.FileName;
            string uniqueFileName = GuildHelper.GetCustomGuid(fileName);
            string filePath = Path.Combine(uploadDirectory, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return new SuccessDataResult<string>(filePath, FileMessages.FileUploadSuccessMessage);
        }
        public IDataResult<string> ConvertFileToBase64(string path)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(path); // Dosyayı byte dizisine oku
                string base64String = Convert.ToBase64String(fileBytes); // Base64 formatına dönüştür
                return new SuccessDataResult<string>(base64String, FileMessages.FileRetrievalSuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(FileMessages.FileRetrievalFailureMessage + ex.Message); // Hata durumunda null değeri döndürülebilir veya hata yönetimi yapılabilir
            }
        }
    }
}
