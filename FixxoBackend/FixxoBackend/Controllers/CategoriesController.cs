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
    public class CategoriesController : Controller
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> Create(CategoryRequest request)
        {
            try
            {
                var categoryEntity = new CategoryEntity
                {
                    CategoryName = request.CategoryName
                };

                _context.Categories.Add(categoryEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(categoryEntity);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                return new OkObjectResult(await _context.Categories.ToListAsync());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                return new OkObjectResult(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}

