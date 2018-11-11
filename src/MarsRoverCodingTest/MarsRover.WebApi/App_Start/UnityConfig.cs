using System.Web.Http;
using Unity.WebApi;
using MarsRover.Unity;

namespace MarsRover.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {

            UnitySetup.RegisterWebApiComponents();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(UnitySetup.GetContainer());
        }
    }
}