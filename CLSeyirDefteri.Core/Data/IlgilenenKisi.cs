﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLSeyirDefteri.Core.Data
{
    public class IlgilenenKisi
    {
        public int IlgilenenKisiId { get; set; }
        public string KisininAdi { get; set; }
        public string KisininTelefonu { get; set; }
        public Firma BagliOlduguFirma { get; set; }

        public override string ToString()
        {
            return KisininAdi+" "+;
        }
    }
}
