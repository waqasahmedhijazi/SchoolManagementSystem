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
                cfg.CreateMap<ParentViewModel, TblParent>();
            });

            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}