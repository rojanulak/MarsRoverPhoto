using System.Linq;
using Microsoft.Practices.Unity;
using Serilog;
using MarsRover.Core;

namespace MarsRover.Unity
{
    public static class UnitySetup
    {
        public static IUnityContainer Container;

        public static void RegisterComponents()
        {
            Container = new UnityContainer();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile("log-{Date}.txt")
                .WriteTo.ColoredConsole().CreateLogger();



            Container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath().Where(x => x.GetInterfaces().Contains(typeof(ISingletonDependency))),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled
            );


        }

        public static void RegisterWebApiComponents()
        {
            Container = new UnityContainer();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile("log-{Date}.txt")
                .CreateLogger();



            Container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(x => x.GetInterfaces().Contains(typeof(ISingletonDependency))),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled
            );

            Container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(x => x.GetInterfaces().Contains(typeof(ITransientDependency))),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient
            );


        }

        public static IUnityContainer GetContainer()
        {
            return Container;
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
