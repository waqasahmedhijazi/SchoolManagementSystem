
using Autofac;
using Autofac.Builder;
using System.Reflection;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

//using SchoolManagementSystem.Model.Pattern.Interfaces;
//using SchoolManagementSystem.Model.Pattern.Repositories;

namespace SchoolManagementSystem.App_Start
{
	public static class UnityConfig
	{

		public static void Run()
		{
			RegisterComponents();
		}
		public static void RegisterComponents()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(Assembly.GetExecutingAssembly());
			//builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
			builder.RegisterModule<AutoFacModule>();
			builder.RegisterFilterProvider();
			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}