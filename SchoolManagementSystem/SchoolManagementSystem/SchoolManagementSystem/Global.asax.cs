using SchoolManagementSystem.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SchoolManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
		protected void Application_Start()
		{
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new RazorViewEngine());

			//AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			//AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
			UnityConfig.Run();
		}
	}
}
