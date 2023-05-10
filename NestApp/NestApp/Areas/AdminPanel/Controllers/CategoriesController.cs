using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestApp.DAL;
using NestApp.Models;

namespace NestApp.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]

	public class CategoriesController : Controller
	{
		private readonly AppDbContext _context;
		public CategoriesController(AppDbContext context)
		{
			_context=context;
		}


		public async Task<IActionResult> Index()
		{
			return View(await _context.Categories.ToListAsync());
		}
		public async Task<IActionResult> Detail(int id)
		{
			return View(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
		}
		public IActionResult Create()
		{
			return View();
		}
	}
}
 
