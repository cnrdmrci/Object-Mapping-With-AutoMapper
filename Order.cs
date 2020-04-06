using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectMappingWithAutoMapper
{
    class Order
    {
        public int OrderId { get; set; }
        public string UrunAdi { get; set; }
        public string UrunGrubu { get; set; }
        public int FabrikaNo { get; set; }
        public double Agirlik { get; set; }    
        public Guid IslemNo { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime GonderimTarihi { get; set; }
    }
}
