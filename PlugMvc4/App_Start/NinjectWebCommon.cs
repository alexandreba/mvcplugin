[assembly: WebActivator.PreApplicationStartMethod(typeof(PlugMvc4.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(PlugMvc4.App_Start.NinjectWebCommon), "Stop")]

namespace PlugMvc4.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.IO;
    using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static StandardKernel kernel = new StandardKernel();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernelWithServicesForPlugin);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        public static void Reset()
        {
            kernel = null;
            bootstrapper.Initialize(CreateKernelWithServicesForPlugin);
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernelWithServicesForPlugin()
        {
            kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            RegisterServicesSpecific();
            return kernel;
        }

        private static IKernel CreateKernelWithoutPlugin()
        {
            kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Func http://msdn.microsoft.com/fr-fr/library/vstudio/bb549151(v=vs.110).aspx
            //Action
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            kernel.Bind(a => a.FromAssembliesInPath(path).IncludingNonePublicTypes().SelectAllClasses().BindDefaultInterface());
        }

        public static void RegisterServicesSpecific()
        {
            //Func http://msdn.microsoft.com/fr-fr/library/vstudio/bb549151(v=vs.110).aspx
            //Action
            var path = @"C:\temp\PluginASPNET\PlugMvc4\PlugMvc4\bin2";
            //.IncludingNonePublicTypes() 
            kernel.Bind(a => a.FromAssembliesInPath(path).IncludingNonePublicTypes().SelectAllClasses().BindDefaultInterface());            
        }    

        private static void CallOne(Ninject.Extensions.Conventions.Syntax.IFromSyntax iFromSyntax){
            IIncludingNonePublicTypesSelectSyntax ipss = iFromSyntax.FromAssembliesInPath(@"C:\temp\PluginASPNET\PlugMvc4\PlugMvc4\bin");
        }
    }
}
