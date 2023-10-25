using Core.Entites.Concrete;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        IDataResult<Doc> Upload(IFormFile file);
        IDataResult<Doc> Update(IFormFile file, string oldPath);
        IResult Delete(string path);
        IDataResult<string> ConvertFileToBase64(string path);
        IDataResult<Doc> ConvertFileToBytes(IFormFile file);
    }
}
