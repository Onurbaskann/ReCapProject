using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CreateCarImageDto createCarImage);
        IResult Update(UpdateCarImageDto updateCarImage);
        IResult Delete(string path);
    }
}
