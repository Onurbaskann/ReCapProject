using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        IDataResult<string> Upload(IFormFile file);
        IDataResult<string> Update(IFormFile file, string oldPath);
        IResult Delete(string path);
    }
}
