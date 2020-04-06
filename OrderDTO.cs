using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectMappingWithAutoMapper
{
    class OrderDTO
    {
        public int SiparisNumarasi { get; set; }
        public decimal ToplamTutar { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public override string ToString()
        {
            return "Siparis No: " + SiparisNumarasi + ", Tarih : " + SiparisTarihi + ", Tutar : " + ToplamTutar;
        }   
    }
}
