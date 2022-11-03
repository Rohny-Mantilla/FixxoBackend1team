using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FixxoBackend.Data;
using FixxoBackend.Models;
using FixxoBackend.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FixxoBackend.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> Create(ProductRequest request)
        {
            try
            {
                var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId);
                if (categoryEntity == null)
                    return new BadRequestObjectResult("Category not found");

                _context.Add(new ProductEntity
                {
                    Name = request.Name,
                    Image = request.Image,
                    DescShort = request.DescShort,
                    DescLong = request.DescLong,
                    Price = request.Price,
                    CategoryId = categoryEntity.Id

                });
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            try
            {

            var products = new List<ProductResponse>();
            foreach (var item in await _context.Products.ToListAsync())
                products.Add(new ProductResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Image = item.Image,
                    DescShort = item.DescShort,
                    DescLong = item.DescLong,
                    Price = item.Price,
                    CategoryId = item.CategoryId


                });
                return new OkObjectResult(products);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                return new OkObjectResult(await _context.Products.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}

