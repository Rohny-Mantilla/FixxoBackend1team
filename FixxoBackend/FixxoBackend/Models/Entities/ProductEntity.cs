using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixxoBackend.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { set; get; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { set; get; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string DescShort { set; get; }

        [Required]
        [Column(TypeName = "nvarchar(200)")] // ???
        public string DescLong { set; get; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { set; get; }

        [Required]
        public int CategoryId { set; get; }

        public virtual CategoryEntity Category { get; set; } // 1 P - 1 C
    }
}

