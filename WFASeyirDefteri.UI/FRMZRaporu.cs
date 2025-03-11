using CLSeyirDefteri.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFASeyirDefteri.UI
{
    public partial class FRMZRaporu : Form
    {
        private List<Gonderim> Gonderimler;
        public FRMZRaporu(List<Gonderim> gonderimler) : this()
        {
            Gonderimler = gonderimler;
        }
        public FRMZRaporu()
        {
            InitializeComponent();
        }
    }
}
