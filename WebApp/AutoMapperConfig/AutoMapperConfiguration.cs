using AutoMapper;

namespace WebApp.AutoMapperConfig
{
    public static class AutoMapperConfiguration
    {
        public static  void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MapperConfig.MapProfile>();
            });
        }
    }
}