using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NestApp.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Logo { get; set; }
		public string? Photo { get; set; }
		[NotMapped]
		public IFormFile PhotoFile { get; set; }
		public bool IsDeleted { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
