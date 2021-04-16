using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolManagementSystem.ViewModel.ViewModel
{
	public class ParentViewModel
	{
		public string EncryptedParentId { get; set; }
		public int ParentId { get; set; }

		[Required(ErrorMessage = "Please enter first name.")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please.")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please enter last name.")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please.")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter your E-mail.")]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
		[Display(Name = "Email")]
		public string Email { get; set; }

		public string Password { get; set; }

		[Required(ErrorMessage = "Please select marital status.")]
		[Display(Name = "Marital Stauts")]
		public int MaritalStautsID { get; set; }

		[Required(ErrorMessage = "Please select gender.")]
		[Display(Name = "Gender")]
		public int GenderID { get; set; }

		[Required(ErrorMessage = "Please enter CNIC #.")]
		[Display(Name = "CNIC Number")]
		public string CNICNumber { get; set; }

		[Required(ErrorMessage = "Please select relationship.")]
		[Display(Name = "Relationship")]
		public int RelationShipID { get; set; }

		[Required(ErrorMessage = "Please select date of birth.")]
		[Display(Name = "Date Of Birth")]
		[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
		public DateTime? DateOfBirth { get; set; }

		[Required(ErrorMessage = "Please enter mailing address.")]
		[Display(Name = "Mailing Address")]
		public string MailingAddress { get; set; }

		[Required(ErrorMessage = "Please select country.")]
		[Display(Name = "Country")]
		public int CountryID { get; set; }

		[Required(ErrorMessage = "Please select state.")]
		[Display(Name = "State")]
		public int StateID { get; set; }

		[Required(ErrorMessage = "Please select city.")]
		[Display(Name = "City")]
		public int CityID { get; set; }

		[Required(ErrorMessage = "Please enter zip-code.")]
		[Display(Name = "Zip-Code")]
		public int ZipCode { get; set; }

		[Required(ErrorMessage = "Please enter cell number.")]
		[Display(Name = "Cell Number")]
		public string CellNumber { get; set; }

		[Display(Name = "Telephone-Residence")]
		public string TelephoneRes { get; set; }

		[Display(Name = "Telephone-Office")]
		public string TelephoneOffice { get; set; }

		[Display(Name = "Job Details")]
		public string JobDetail { get; set; }

		[Display(Name = "Is Active")]
		public bool IsActive { get; set; } = true;

		[Display(Name = "Select Profile Image")]
		[JsonIgnore]
		public HttpPostedFileBase ImagePath { get; set; }

		public string ProfilePicture { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public string IPAddress { get; set; }

		public bool IsDeleted { get; set; }

		public IEnumerable<GeneralLookups> FillMaritalStauts { get; set; }
		public IEnumerable<GeneralLookups> FillGender { get; set; }
		public IEnumerable<GeneralLookups> FillRelationShip { get; set; }
		public IEnumerable<GeneralLookups> FillCountries { get; set; }
		public IEnumerable<GeneralLookups> FillStates { get; set; }
		public IEnumerable<GeneralLookups> FillCites { get; set; }

	}


	public class GeneralLookups
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int? ExtraField { get; set; }
	}
}

