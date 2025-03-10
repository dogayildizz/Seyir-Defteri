using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLSeyirDefteri.Core.Data
{
    public class Gonderim
    {
        public int GonderimId { get; set; }
        public Urun Urun { get; set; }
        public IlgilenenKisi IlgilenenKisi { get; set; }
        public SeyirKaydi SeyirKaydi { get; set; }
        public decimal Tonaj { get; set; }
        public override string ToString()
        {
            return SeyirKaydi.Gemi.GemiAdi+" "+SeyirKaydi.LimanaVarisTarihi+" "+SeyirKaydi.LimandanCikisTarihi+" "+Urun.UrunAdi+" "+IlgilenenKisi.BagliOlduguFirma.FirmaAdi+" "+Tonaj;
        }
    }
}
