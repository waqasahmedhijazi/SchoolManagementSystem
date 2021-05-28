using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModel.ViewModel
{
	public class CountryViewModel
	{
		public string EncryptedCountryID { get; set; }
		public int CountryID { get; set; }

		[Required(ErrorMessage = "Please enter country name.")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please.")]
		[Display(Name = "Country Name")]
		public string CountryName { get; set; }

		[Required(ErrorMessage = "Please enter country code.")]
		[Display(Name = "Country Code")]
		public string CountryCode { get; set; }

		[Required(ErrorMessage = "Please enter country language.")]
		[Display(Name = "Country Language")]
		public string CountryLanguage { get; set; }

		[Display(Name = "Is Active")]
		public bool IsActive { get; set; } = true;
	}
}
