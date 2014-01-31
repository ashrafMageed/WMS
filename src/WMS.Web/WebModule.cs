using Ninject.Modules;
using Ninject.Web.Common;
using WMS.DataStore;
using WMS.Web.Controllers;

namespace WMS.Web
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IMapper>().To<AutoMapperMapper>().InSingletonScope();
            Kernel.Bind<IRepository>().To<Repository>().InRequestScope().WithConstructorArgument("database", DataStore.Bootstrapper.Initialise("TestDB"));
        }
    }
}