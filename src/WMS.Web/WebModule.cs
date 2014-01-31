using System.Configuration;
using AutoMapper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using WMS.Common;
using WMS.Common.Mappers;
using WMS.DataStore;
using WMS.Web.Mappers;

namespace WMS.Web
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.LoadMappingProfiles<WebModule>();
            Kernel.Bind<IMapper>().To<AutoMapperMapper>().InSingletonScope().WithConstructorArgument("profiles", context => context.Kernel.GetAll<Profile>());
            Kernel.Bind<IRepository>().To<Repository>().InRequestScope().WithConstructorArgument("database", DataStore.Bootstrapper.Initialise(ConfigurationManager.AppSettings["DataStore"]));
        }
    }
}