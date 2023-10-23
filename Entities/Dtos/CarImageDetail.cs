using Core.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CarImageDetail : IDto
    {
        public int CarId { get; set; }
        public string Base64EncodedImage { get; set; }
    }
}
