using Identikit.Controllers;
using Identikit.DAL.Repositories;
using Identikit.DAL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identikit.Utils
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ILoginService>().To<LoginService>();
            kernel.Bind<ICookie>().To<Cookie>();
        }
    }
}