using Core.Utilities.Messages;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public IResult Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);

                return new SuccessResult(FileMessages.FileDeletionSuccessMessage);
            }
            return new ErrorResult(FileMessages.FileDeletionFailureMessage);
        }
        public IDataResult<string> Update(IFormFile file, string oldPath)
        {
            var isDelete = Delete(oldPath);

            if (isDelete.Success)
            {
                var newFilePath = Upload(file).Data;

                return new SuccessDataResult<string>(newFilePath, FileMessages.FileUpdateSuccessMessage);
            }
            return new ErrorDataResult<string>(FileMessages.FileUpdateFailureMessage);
        }
        public IDataResult<string> Upload(IFormFile file)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cars/");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string FileName = file.FileName;

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;

            string filePath = Path.Combine(folderPath, uniqueFileName);

            file.CopyTo(new FileStream(filePath, FileMode.Create));

            return new SuccessDataResult<string>(filePath, FileMessages.FileUploadSuccessMessage);
        }
        public IDataResult<string> ConvertFileToBase64(string filePath)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(filePath); // Dosyayı byte dizisine oku
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
