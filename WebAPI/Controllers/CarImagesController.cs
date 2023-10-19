using Business.Abstract;
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
        public IActionResult Add([FromForm]CreateCarImageDto createCarImage)
        {
            _carImageService.Add(createCarImage);

            return Ok("İşlem Başarılı");
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] UpdateCarImageDto updateCarImage)
        {
            _carImageService.Update(updateCarImage);

            return Ok("İşlem Başarılı");
        }
        [HttpPost("delete")]
        public IActionResult Delete(string path)
        {
            _carImageService.Delete(path);

            return Ok("İşlem Başarılı");
        }
    }
}
