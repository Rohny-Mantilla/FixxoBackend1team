using System;
using FixxoBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixxoBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<ProductEntity> Products { get; set; }
    }
}

