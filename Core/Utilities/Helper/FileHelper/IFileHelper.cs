using Core.Entites.Concrete;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        IDataResult<Doc> Upload(IFormFile file, string[] root);
        IDataResult<Doc> Update(IFormFile file, string[] root, string oldPath);
        IResult Delete(string path);
        IDataResult<string> ConvertFileToBase64(string path);
        IDataResult<Doc> ConvertFileToBytes(IFormFile file);
        IResult IsFileSizeValid(IFormFile file, int maxSizeInMB);
        IResult IsFileTypeValid(IFormFile file, Dictionary<string, string> allowedFileTypes);
    }
}
