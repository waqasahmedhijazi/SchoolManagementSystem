using SchoolManagementSystem.ViewModel.ViewModel;
using SchoolManagementSystem.Model.Entities.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BL.Parent
{
	/// <summary>
	/// This is the parent entity class that contain all curd operations.
	/// </summary>
	public static class ParentClass
	{
		public static List<ParentViewModel> GetAllParents()
		{
			var result = Domain.Common.WebAPIHelper<List<ParentViewModel>>.Get(Domain.Common.CommonMethods.WebAPIUrl, "api/parent");
			return result;
		}

		public static ParentModelEntity GetParentDetailByParentId(int Id)
		{
			var result = Domain.Common.WebAPIHelper<ParentModelEntity>.Get("http://192.168.18.23:8086/", "api/parent/GetParentDetailByParentId?id=" + Id);
			return result;
		}
		public static ParentViewModel GetParentByParentId(int Id)
		{
			//var result = Domain.Common.WebAPIHelper<ParentViewModel>.Get("http://192.168.18.23:8086/", "api/parent?id=" + Id);
			var result = Domain.Common.WebAPIHelper<ParentViewModel>.Get(Domain.Common.CommonMethods.WebAPIUrl, "api/parent/GetParentByParentId?id=" + Id);

			return result;
		}
		public static ParentViewModel FillParentDropDowns()
		{
			var result = Domain.Common.WebAPIHelper<ParentViewModel>.Get(Domain.Common.CommonMethods.WebAPIUrl, "api/parent/" + 0);
			return result;
		}

		public static ParentViewModel CreateParent(ParentViewModel objParentViewModel)
		{
			var result = Domain.Common.WebAPIHelper<ParentViewModel>.PostRequest(Domain.Common.CommonMethods.WebAPIUrl, "api/parent", objParentViewModel);
			return null;
		}

		public static int DeleteParent(int id)
		{
			var result = Domain.Common.WebAPIHelper<ParentViewModel>.Get("http://192.168.18.23:8086/", "api/parent/DeleteParentById?id=" + id);
			return 1;
		}
	}
}
