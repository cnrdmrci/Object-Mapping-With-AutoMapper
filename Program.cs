using System;
using AutoMapper;

namespace ObjectMappingWithAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            IMapper mapper = InitializeAutoMapperForConsoleApp();
            OrderEngine orderEngine = new OrderEngine(mapper);
            orderEngine.Run();
        }

        private static IMapper InitializeAutoMapperForConsoleApp()
        {
            var config = new MapperConfiguration(cfg=> {
                    cfg.AddProfile<OrderProfile>();
                    //cfg.CreateMap<Order, OrderDTO>();
            });

            IMapper mapper = config.CreateMapper();
            //of
            mapper = new Mapper(config);
            return mapper;
        }
    }
}
