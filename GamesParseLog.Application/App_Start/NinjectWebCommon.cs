[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GamesParseLog.Application.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(GamesParseLog.Application.App_Start.NinjectWebCommon), "Stop")]

namespace GamesParseLog.Application.App_Start
{
    using GamesParseLog.Domain.Interfaces.Repositories;
    using GamesParseLog.Infrastructure.Contexts;
    using GamesParseLog.Infrastructure.Repositories;
    using GamesParseLog.Service.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ContextDb>().ToSelf().InRequestScope();

            kernel.Bind<IService>().To<GamesParseLog.Service.Services.Service>().InRequestScope();

            kernel.Bind<IRepositoryFileParse>().To<RepositoryFileParse>().InRequestScope();
            kernel.Bind<IRepositoryKill>().To<RepositoryKill>().InRequestScope();
            kernel.Bind<IRepositoryPlayer>().To<RepositoryPlayer>().InRequestScope();
            kernel.Bind<IRepositoryGame>().To<RepositoryGame>().InRequestScope();
        }
    }
}