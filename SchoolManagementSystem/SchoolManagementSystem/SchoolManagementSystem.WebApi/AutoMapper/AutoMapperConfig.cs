using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;
using SchoolManagementSystem.Model.Context.Database;
using SchoolManagementSystem.Model.Entities.ModelEntities;
using SchoolManagementSystem.ViewModel.ViewModel;

namespace SchoolManagementSystem.WebApi.AutoMapper
{
	public static class AutoMapperConfig
	{
		public static void Configure()
		{
			MapperWrapper.Initialize(cfg =>
			{

				cfg.CreateMap<ParentViewModel, TblParent>()
					.ForMember(dest => dest.TblGenCountry, opt => opt.Ignore())
					.ForMember(dest => dest.TblGenState, opt => opt.Ignore())
					.ForMember(dest => dest.TblGenCity, opt => opt.Ignore())
					.ForMember(dest => dest.TblGenGender, opt => opt.Ignore())
					.ForMember(dest => dest.TblGenMaritalStaut, opt => opt.Ignore())
					.ForMember(dest => dest.TblGenRelationShip, opt => opt.Ignore());

				cfg.CreateMap<TblParent,ParentViewModel>()
					.ForMember(dest => dest.FillCountries, opt => opt.Ignore())
					.ForMember(dest => dest.FillStates, opt => opt.Ignore())
					.ForMember(dest => dest.FillCites, opt => opt.Ignore())
					.ForMember(dest => dest.FillGender, opt => opt.Ignore())
					.ForMember(dest => dest.FillMaritalStauts, opt => opt.Ignore())
					.ForMember(dest => dest.FillRelationShip, opt => opt.Ignore())
					.ForMember(dest => dest.EncryptedParentId, opt => opt.Ignore())
					.ForMember(dest => dest.ImagePath, opt => opt.Ignore())
					;

				cfg.CreateMap<SP_GetParentByParentID_Result,ParentModelEntity > ();

			});




			MapperWrapper.AssertConfigurationIsValid();
		}
	}
}