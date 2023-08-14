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
		[Required(ErrorMessage = "Naslov je neophodno unijeti!")]
		[Display(Name="Naslov")]
		public string Title { get; set; }
		[Display(Name="Opis")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Ime je neophodno unijeti!")]
		[Display(Name="Ime")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Cijenu je neophodno unijeti!")]
		[Display(Name ="Cijena")]
		[Range(1, 5000, ErrorMessage = "Cijena mora biti između 1 i 5000")]
		public double Price { get; set; }

		[Display(Name="Id kategorije")]
		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		[ValidateNever]
		public Category Category { get; set; }

		[ValidateNever]
		public string ImageUrl { get; set; }
	}
}
