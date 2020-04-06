### AutoMapper Nedir?
AutoMapper 2 nesneyi birbirine eşleyen, bir nesneden başka bir nesneye kopyalama işlemi yapan, karmaşık koddan kurtulmak için belirli konfigürasyonlar oluşturarak, nesne kopyalama işini basite indirgeyen açık kaynak kodlu bir kütüphanedir.

### Data Transfer Object (DTO) Nedir?
Dto; Kısaca A noktasından B noktasına taşınan bir sınıfın içerisindeki gerekli olmayan bilgilerin çıkarılması ile oluşan yeni bir sınıftır. AutoMapper ise bu noktada devreye giren, belirtilen bir konfigüreasyona göre ana sınıftan dto sınıfına kopyalama işlemi yapan araçtır.

### AutoMapper Kurulumu Ve StartUp.cs Entegrasyonu

> PM> Install-Package AutoMapper

Yukarıdaki şekilde AutoMapper'ı projemize dahil edebiliriz ve aşağıdaki şekilde StartUp.cs içerisinden servis olarak ekleyebiliriz.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAutoMapper();
}
```

### AutoMapper Konsol Uygulaması Entegrasyonu

Startup.cs içerisinde AutoMapper servisini eklediğimizde, Profile sınıfını kalıtım alan tüm konfigürasyonlar otomatik olarak tanımlanır. Konsol uygulamasında StartUp.cs bulunmadığından bunu manuel olarak yapıyoruz.

```csharp
var config = new MapperConfiguration(cfg=> {
                    cfg.AddProfile<OrderProfile>();
                    //cfg.CreateMap<Order, OrderDTO>();
            });

IMapper mapper = config.CreateMapper();
```

### AutoMapper ile Nesne Üretimi

```csharp
OrderDTO dest = _mapper.Map<Order, OrderDTO>(new Order());
```

### AutoMapper Örnek Kullanım Kofigürasyonları

- Aşağıdaki kullanım isimleri aynı olan alanları otomatik eşleştirecektir.
```csharp
CreateMap<Order, OrderDTO>(); 
```

- Aşağıdaki kullanım isimleri aynı olanlara ek olarak isimleri farklı olan alanları da eşleştirecektir.
```csharp
 CreateMap<Order,OrderDTO>()
                .ForMember(x=>x.SiparisNumarasi,x=>x.MapFrom(y=>y.OrderId))
                .ForMember(x=>x.ToplamTutar,x=>x.MapFrom(y=>y.Fiyat));
```

- Aşağıdaki kullanım isimleri aynı olan bir alanı dahil etmemek için kullanılır.
```csharp
CreateMap<Order,OrderDTO>().ForMember(x=>x.SiparisTarihi,x=>x.Ignore());
```

- Aşağıdaki kullanım belirli bir kontrole göre atama işlemi yapar.
```csharp
CreateMap<Order, OrderDTO>()
                .ForMember(x => x.ToplamTutar, x =>
                {
                    x.PreCondition(y => y.Fiyat > 0);
                    x.MapFrom(y => y.Fiyat);
                });
```
