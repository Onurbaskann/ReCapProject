using Core.Entites.Concrete;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        IDataResult<Document> Upload(IFormFile file, string[] root);
        IDataResult<Document> Update(IFormFile file, string[] root, string oldPath);
        IResult Delete(string path);
        IDataResult<string> ConvertFileToBase64(string path);
        IDataResult<Document> ConvertFileToBytes(IFormFile file);
        IResult IsFileSizeValid(IFormFile file, int maxSizeInMB);
        IResult IsFileTypeValid(IFormFile file, Dictionary<string, string> allowedFileTypes);
    }
}
