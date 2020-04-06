using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ObjectMappingWithAutoMapper
{
    public class OrderEngine
    {
        private readonly IMapper _mapper;
        public OrderEngine(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Run()
        {
            Order order = new Order()
            {
                OrderId = 123,
                UrunAdi = "Telefon",
                UrunGrubu = "Teknoloji",
                FabrikaNo = 556265,
                Agirlik = 0.2,
                IslemNo = new Guid(),
                Fiyat = 5000,
                SiparisTarihi = DateTime.Today,
                GonderimTarihi = DateTime.Today
            };

            OrderDTO dest = _mapper.Map<Order, OrderDTO>(order);

            Console.WriteLine(dest.ToString());
        }
    }
}
