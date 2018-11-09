namespace MarsRover.IntegrationTest
{
    public class TestBase
    {
        protected IUnityContainer container;
        protected void RegisterAutoMapper()
        {
            AutoMapperConfig.Initiazlie();
        }
        public void Setup()
        {
            
            RegisterAutoMapper();
            RegisterContainer();
        }
      
        public void RegisterContainer()
        {

            container = new UnityContainer();
            container.RegisterTypes(
                       AllClasses.FromLoadedAssemblies().Where(x => x.GetInterfaces().Contains(typeof(ISingletonDependency))),
                       WithMappings.FromMatchingInterface,
                       WithName.Default,
                       WithLifetime.ContainerControlled
                       );

            container.RegisterTypes(
           AllClasses.FromLoadedAssemblies().Where(x => x.GetInterfaces().Contains(typeof(ITransientDependency))),
           WithMappings.FromMatchingInterface,
           WithName.Default,
           WithLifetime.Transient
           );
           

        }
        protected T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
