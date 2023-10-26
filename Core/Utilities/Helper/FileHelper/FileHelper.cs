using Core.Entites.Concrete;
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
        public IDataResult<Doc> Update(IFormFile newFile, string[] root, string oldPath)
        {
            try
            {
                var uploadDirectory = Path.Combine(root);

                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                string datePath = DateTime.Now.ToString("yyyy-MM-dd");
                string[] dateArray = datePath.Split('-');

                string yearPath = Path.Combine(uploadDirectory, dateArray[0]);
                string monthPath = Path.Combine(yearPath, dateArray[1]);
                string dayPath = Path.Combine(monthPath, dateArray[2]);

                if (!Directory.Exists(yearPath))
                {
                    Directory.CreateDirectory(yearPath);
                }
                if (!Directory.Exists(monthPath))
                {
                    Directory.CreateDirectory(monthPath);
                }
                if (!Directory.Exists(dayPath))
                {
                    Directory.CreateDirectory(dayPath);
                }

                string fileName = newFile.FileName;
                string uniqueFileName = GuildHelper.GetCustomGuid(fileName);
                string newFilePath = Path.Combine(dayPath, uniqueFileName);

                using (var newFileStream = new FileStream(newFilePath, FileMode.Create))
                {
                    newFile.CopyTo(newFileStream);
                }

                var doc = new Doc
                {
                    fileContent = null,
                    fileName = uniqueFileName,
                    fileType = newFile.ContentType,
                    path = newFilePath
                };
                if (File.Exists(oldPath))
                {
                    try
                    {
                        File.Delete(oldPath);
                    }
                    catch (Exception ex)
                    {
                        return new ErrorDataResult<Doc>($"{FileMessages.OldFileDeletionFailureMessage} Hata: {ex.Message}");
                    }
                }
                else
                {
                    return new ErrorDataResult<Doc>(FileMessages.FilePathNotFoundMessage);
                }
                return new SuccessDataResult<Doc>(doc, FileMessages.FileUpdateSuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Doc>($"{FileMessages.FileUpdateFailureMessage} Hata: {ex.Message}");
            }
        }
        public IDataResult<Doc> Upload(IFormFile file, string[] root)
        {
            string uploadDirectory = Path.Combine(root);

            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            string datePath = DateTime.Now.ToString("yyyy-MM-dd");
            string[] dateArray = datePath.Split('-');

            string yearPath = Path.Combine(uploadDirectory, dateArray[0]);
            string monthPath = Path.Combine(yearPath, dateArray[1]);
            string dayPath = Path.Combine(monthPath, dateArray[2]);

            if (!Directory.Exists(yearPath))
            {
                Directory.CreateDirectory(yearPath);
            }
            if (!Directory.Exists(monthPath))
            {
                Directory.CreateDirectory(monthPath);
            }
            if (!Directory.Exists(dayPath))
            {
                Directory.CreateDirectory(dayPath);
            }

            string fileName = file.FileName;
            string uniqueFileName = GuildHelper.GetCustomGuid(fileName);
            string filePath = Path.Combine(dayPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var doc = new Doc
            {
                fileContent = null,
                fileName = uniqueFileName,
                fileType = file.ContentType,
                path = filePath
            };
            return new SuccessDataResult<Doc>(doc, FileMessages.FileUploadSuccessMessage);
        }
        public IDataResult<string> ConvertFileToBase64(string path)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(path);
                string base64String = Convert.ToBase64String(fileBytes);
                return new SuccessDataResult<string>(base64String, FileMessages.FileRetrievalSuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(FileMessages.FileRetrievalFailureMessage + ex.Message);
            }
        }
        public IDataResult<Doc> ConvertFileToBytes(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                var fileContent = memoryStream.ToArray();
                var newFileName = GuildHelper.GetCustomGuid(file.FileName);

                var doc = new Doc
                {
                    fileContent = fileContent,
                    fileName = newFileName,
                    fileType = file.ContentType,
                    path = null
                };
                return new SuccessDataResult<Doc>(doc, FileMessages.FileSuccessMessage);
            }
        }
        public IResult IsFileTypeValid(IFormFile file, Dictionary<string, string> allowedFileTypes)
        {
            var fileType = file.ContentType;

            if (allowedFileTypes.TryGetValue(fileType, out var ext) && !string.IsNullOrEmpty(ext))
            {
                return new SuccessResult();
            }
            return new ErrorResult(FileMessages.InvalidFileTypeMessage);
        }
        public IResult IsFileSizeValid(IFormFile file, int maxSizeInMB)
        {
            var maxSizeInBytes = maxSizeInMB * 1024 * 1024;

            if (file.Length <= maxSizeInBytes)
            {
                return new SuccessResult();
            }
            return new ErrorResult(string.Format(FileMessages.FileSizeExceededMessage, maxSizeInMB));
        }
    }
}
