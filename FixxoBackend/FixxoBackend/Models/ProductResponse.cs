using System;
namespace FixxoBackend.Models
{
    public class ProductResponse
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public string Image { set; get; }

        public string DescShort { set; get; }

        public string DescLong { set; get; }

        public decimal Price { set; get; }

        public int CategoryId { get; set; }
    }
}

