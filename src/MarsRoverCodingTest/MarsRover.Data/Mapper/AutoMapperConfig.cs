namespace MarsRover.Data.Mapper
{
    public class AutoMapperConfig
    {
        public static object _thisLock = new object();
        private static bool _initialized = false;
        // Centralize automapper initialize
        public static void Initialize()
        {
            // This will ensure one thread can access to this static initialize call
            // and ensure the mapper is reseted before initialized
            lock (_thisLock)
            {
                if (!_initialized)
                {
                    AutoMapper.Mapper.Reset();
                    AutoMapper.Mapper.Initialize(cfg => { cfg.AddProfile<RoverImageMappingProfile>(); });
                    _initialized = true;
                }

                ;
            }
        }
    }
}
