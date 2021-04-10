using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolManagementSystem.Domain.Common
{
	public static class FileUpload
	{
		public static string UploadParentProfileImage(HttpPostedFileBase File)
		{
			try
			{
				string _path = "";
				string _FileName = "";
				if (File.ContentLength > 0)
				{
					string Guid = System.Guid.NewGuid().ToString();
					_FileName = Guid + "_" + Path.GetFileName(File.FileName);
					_path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Uploads/Images/Parent_Profile_Images/"), _FileName);
					File.SaveAs(_path);
				}
				return _FileName;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
