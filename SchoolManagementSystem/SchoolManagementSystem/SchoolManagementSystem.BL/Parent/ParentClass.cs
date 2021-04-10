﻿
using SchoolManagementSystem.ViewModel.ViewModel;
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
			var result = Domain.Common.WebAPIHelper<List<ParentViewModel>>.Get("http://192.168.18.23:8086/", "api/parent");
			return result;
		}
		public static ParentViewModel FillParentDropDowns()
		{
			var result = Domain.Common.WebAPIHelper<ParentViewModel>.Get("http://192.168.18.23:8086/", "api/parent/" + 0);
			return result;
		}

		public static ParentViewModel CreateParent(ParentViewModel objParentViewModel)
		{
			var result = Domain.Common.WebAPIHelper<ParentViewModel>.PostRequest("http://192.168.18.23:8086/api/parent/", objParentViewModel);
			return result.Result;
		}
	}
}
