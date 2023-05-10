using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestApp.DAL;

namespace NestApp.Areas.AdminPanel.Controllers
{
    [Area("AdminPAnel")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductImages)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(p => p.Id)
                .Take(10).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
    }
    }
