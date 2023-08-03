using AutoMapper;

namespace AuthServer.Core.Service
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => _mapper.Value;
    }
}