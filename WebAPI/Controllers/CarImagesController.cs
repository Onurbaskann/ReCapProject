using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] CreateCarImageDto createCarImage)
        {
            var Result = _carImageService.Add(createCarImage);
            if (Result.Success)
            {
                return Ok("İşlem Başarılı");
            }
            return BadRequest(Result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] UpdateCarImageDto updateCarImage)
        {
            var Result = _carImageService.Update(updateCarImage);
            if (Result.Success)
            {
                return Ok("İşlem Başarılı");
            }
            return BadRequest(Result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var Result = _carImageService.Delete(id);
            if (Result.Success)
            {
                return Ok("İşlem Başarılı");
            }
            return BadRequest(Result.Message);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var Result = _carImageService.GetByCarId(id);
            if (Result.Success)
            {
                return Ok(Result.Data);
            }
            return BadRequest(Result.Message);
        }
    }
}
