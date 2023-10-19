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

                return new SuccessResult("Belge başarıyla silinmiştir.");
            }
            return new ErrorResult();
        }
        public IDataResult<string> Update(IFormFile file, string oldPath)
        {
            var isDelete = Delete(oldPath);

            if (isDelete.Success)
            {
                var newFilePath = Upload(file).Data;

                return new SuccessDataResult<string>(newFilePath, "Belge başarıyla güncellenmiştir.");
            }
            return new ErrorDataResult<string>();
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

            return new SuccessDataResult<string>(filePath, "Belge başarıyla yüklenmiştir.");
        }
    }
}
