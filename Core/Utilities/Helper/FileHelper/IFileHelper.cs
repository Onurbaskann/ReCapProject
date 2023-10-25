using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        IDataResult<string> Upload(IFormFile file);
        IDataResult<string> Update(IFormFile file, string oldPath);
        IResult Delete(string path);
        IDataResult<string> ConvertFileToBase64(string path);
    }
}
