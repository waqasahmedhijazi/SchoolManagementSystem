using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagementSystem.Model.Context.Database;
using SchoolManagementSystem.ViewModel.ViewModel;

namespace SchoolManagementSystem.WebApi.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {

                cfg.CreateMap<ParentViewModel, TblParent>().ForMember(dest => dest.TblGenCountry, opt => opt.Ignore())
                .ForMember(dest => dest.TblGenState, opt => opt.Ignore())
                .ForMember(dest => dest.TblGenCity, opt => opt.Ignore())
                .ForMember(dest => dest.TblGenGender, opt => opt.Ignore())
                .ForMember(dest => dest.TblGenMaritalStaut, opt => opt.Ignore())
                .ForMember(dest => dest.TblGenRelationShip, opt => opt.Ignore());
            });

           


            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}