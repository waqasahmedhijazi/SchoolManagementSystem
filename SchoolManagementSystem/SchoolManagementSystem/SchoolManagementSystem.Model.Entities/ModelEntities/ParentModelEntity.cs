using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model.Entities.ModelEntities
{
	public class ParentModelEntity
	{
		public int ParentId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string MaritalStauts { get; set; }
		public string Gender { get; set; }
		public string CNICNumber { get; set; }
		public string RelationShip { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string MailingAddress { get; set; }
		public string CountryName { get; set; }
		public string CountryCode { get; set; }
		public string StateName { get; set; }
		public string CityName { get; set; }
		public string ZipCode { get; set; }
		public string CellNumber { get; set; }
		public string TelephoneRes { get; set; }
		public string TelephoneOffice { get; set; }
		public string JobDetail { get; set; }
		public string ProfilePicture { get; set; }
		public bool IsActive { get; set; } = true;
		public DateTime? CreatedDate { get; set; }
		public string IPAddress { get; set; }
	}
}
