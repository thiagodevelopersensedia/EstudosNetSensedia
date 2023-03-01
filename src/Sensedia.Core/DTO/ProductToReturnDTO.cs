using Sensedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensedia.Core.DTO
{
    public class ProductToReturnDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProducDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}
