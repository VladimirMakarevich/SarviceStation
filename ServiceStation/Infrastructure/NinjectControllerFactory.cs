using Ninject;
using ServiceStation.Authentication;
using ServiceStation.Domain.Abstract;
using ServiceStation.Domain.Concrete;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ServiceStation.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBinding();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)kernel.Get(controllerType);
        }

        private void AddBinding()
        {
            kernel.Bind<IRepository>().To<EfRepository>();
            kernel.Bind<IAuthProvider>().To<AuthProvider>();
        }
    }
}