using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ObjectMappingWithAutoMapper
{
    //Proje ayağa kalktığında Profile sınıfnı kalıtım alan tüm sınıflar taranır ve işleme sokulur.
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //Aşağıdaki kullanım isimleri aynı olan alanları otomatik eşleştirecektir.
            CreateMap<Order, OrderDTO>();

            //Aşağıdaki kullanım isimleri aynı olanlara ek olarak isimleri farklı olan alanları da eşleştirecektir.
            CreateMap<Order, OrderDTO>()
                .ForMember(x => x.SiparisNumarasi, x => x.MapFrom(y => y.OrderId));

            ////Aşağıdaki kullanım isimleri aynı olan bir alanı dahil etmemek için kullanılır.
            CreateMap<Order, OrderDTO>().ForMember(x => x.SiparisTarihi, x => x.Ignore());

            //Aşağıdaki kullanım belirli bir kontrole göre atama işlemi yapar.
            CreateMap<Order, OrderDTO>()
                .ForMember(x => x.ToplamTutar, x =>
                {
                    x.PreCondition(y => y.Fiyat > 0);
                    x.MapFrom(y => y.Fiyat);
                });

            //Aşağıdaki kod tüm eşleşmeleri iptal eder.
            CreateMap<Order, OrderDTO>().ForAllMembers(x=>x.Ignore());
        }
    }
}
