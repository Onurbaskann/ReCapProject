using Core.Entites;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class UpdateCarImageDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public IFormFile File { get; set; }
    }
}
