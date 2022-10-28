using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixxoBackend.Models.Entities
{
    //Bygger databasen tabell
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductEntity> Products  { get; set; } // 1 C - N p
    }
}

