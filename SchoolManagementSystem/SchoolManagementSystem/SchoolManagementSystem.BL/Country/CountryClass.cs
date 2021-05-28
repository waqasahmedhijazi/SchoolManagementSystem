using SchoolManagementSystem.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BL.Country
{
	public static class CountryClass
	{
		public static List<CountryViewModel> GetAllCountries()
		{
			var result = Domain.Common.WebAPIHelper<List<CountryViewModel>>.Get(Domain.Common.CommonMethods.WebAPIUrl, "api/Country");
			return result;
		}

		public static CountryViewModel CreateCountry(CountryViewModel objCountryViewModel)
		{
			var result = Domain.Common.WebAPIHelper<CountryViewModel>.PostRequest(Domain.Common.CommonMethods.WebAPIUrl, "api/Country", objCountryViewModel);
			return null;
		}
	}
}
