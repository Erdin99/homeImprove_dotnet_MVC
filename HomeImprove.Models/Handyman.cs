using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeImpr.Models
{
	public class Handyman
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		public string Description { get; set; }
		
		[Required]
		public string Name { get; set; }

		[Required]
		[Range(1, 5000, ErrorMessage = "Price must be between 1 and 5000")]
		public double Price { get; set; }

		public int CategoryId { get; set; }
		
		[ForeignKey("CategoryId")]
		[ValidateNever]
		public Category Category { get; set; }

		[ValidateNever]
		public string ImageUrl { get; set; }
	}
}
