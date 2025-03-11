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
    public partial class FRMGonderim : Form
    {
        public FRMGonderim(List<SeyirKaydi> seyirKayitlari) : this()
        {
            foreach (SeyirKaydi seyirKaydi in seyirKayitlari)
            {
                cmbSeferler.Items.Add(seyirKaydi);
            }
        }

        public void Temizle()
        {
            cmbSeferler.SelectedItem = null;
            cmbFirma.SelectedItem = null;
            txtKisi.Text = txtUrun.Text = mtxtKisiTelNo.Text = string.Empty;
            nudTonaj.Value = 0;
        }

        public void FirmaEkle()
        {
            List<Firma> firmalar = new List<Firma>()
            {
               new Firma { FirmaId = 1, FirmaAdi = " Maersk Line " },
               new Firma { FirmaId = 2, FirmaAdi = " MSC Mediterranean Shipping Company " },
               new Firma { FirmaId = 3, FirmaAdi = " CMA CGM Group " },
               new Firma { FirmaId = 4, FirmaAdi = " Hapag-Lloyd " },
               new Firma { FirmaId = 5, FirmaAdi = " COSCO Shipping Lines " },
               new Firma { FirmaId = 6, FirmaAdi = " Evergreen Marine Corporation " },
               new Firma { FirmaId = 7, FirmaAdi = " Ocean Network Express (ONE) " },
               new Firma { FirmaId = 8, FirmaAdi = " Yang Ming Marine Transport " },
               new Firma { FirmaId = 9, FirmaAdi = " HMM Co., Ltd. " },
               new Firma { FirmaId = 10, FirmaAdi = " ZIM Integrated Shipping Services " },
               new Firma { FirmaId = 11, FirmaAdi = " Wan Hai Lines " },
               new Firma { FirmaId = 12, FirmaAdi = " PIL (Pacific International Lines) " },
               new Firma { FirmaId = 13, FirmaAdi = " NYK Line " },
               new Firma { FirmaId = 14, FirmaAdi = " K Line (Kawasaki Kisen Kaisha) " },
               new Firma { FirmaId = 15, FirmaAdi = " MOL (Mitsui O.S.K. Lines) " },
               new Firma { FirmaId = 16, FirmaAdi = " X-Press Feeders " },
               new Firma { FirmaId = 17, FirmaAdi = " Arkas Line " },
               new Firma { FirmaId = 18, FirmaAdi = " Sinotrans Container Lines " },
               new Firma { FirmaId = 19, FirmaAdi = " Grimaldi Group " },
               new Firma { FirmaId = 20, FirmaAdi = " Seaboard Marine " },
               new Firma { FirmaId = 21, FirmaAdi = " Matson, Inc. " },
               new Firma { FirmaId = 22, FirmaAdi = " ACL (Atlantic Container Line) " },
               new Firma { FirmaId = 23, FirmaAdi = " Crowley Maritime Corporation " },
               new Firma { FirmaId = 24, FirmaAdi = " Yangtze River Express " },
               new Firma { FirmaId = 25, FirmaAdi = " Hyundai Glovis " },
               new Firma { FirmaId = 26, FirmaAdi = " Bahri (The National Shipping Company of Saudi Arabia) " },
               new Firma { FirmaId = 27, FirmaAdi = " Unifeeder " },
               new Firma { FirmaId = 28, FirmaAdi = " Samskip " },
               new Firma { FirmaId = 29, FirmaAdi = " Eimskip " },
               new Firma { FirmaId = 30, FirmaAdi = " Swire Shipping " }

            };
            foreach (var item in firmalar)
            {
                cmbFirma.Items.Add(item);
            }

        }

        public FRMGonderim()
        {
            InitializeComponent();
        }

        private void FRMGonderim_Load(object sender, EventArgs e)
        {
            FirmaEkle();
            ListVieweSutunEkle();
        }

        private void ListVieweSutunEkle()
        {
            lvGonderim.View = View.Details;
            lvGonderim.GridLines = true;

            lvGonderim.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvGonderim.Columns.Add("Tonaj ", 100, HorizontalAlignment.Center);
            lvGonderim.Columns.Add("Ürün ", 100, HorizontalAlignment.Center);
            lvGonderim.Columns.Add("Firma ", 150, HorizontalAlignment.Center);
            lvGonderim.Columns.Add("Kişi Adı", 150, HorizontalAlignment.Center);
            lvGonderim.Columns.Add("İletişim", 150, HorizontalAlignment.Center);

        }
        int id = 0;
        int urunId = 1;
        int ilgilenenKisiId = 0;
        private Gemi seciliGemi;

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            Gonderim gonderim = new Gonderim();
            if (cmbSeferler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen sefer seçiniz.");
                return;
            }
            if (cmbFirma.SelectedItem == null)
            {
                MessageBox.Show("Lütfen firma seçiniz.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUrun.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz.");
                return;
            }
            SeyirKaydi seciliSeyir = cmbSeferler.SelectedItem as SeyirKaydi;

            seciliGemi = seciliSeyir.Gemi;

            if (nudTonaj.Value < 0 || seciliGemi.Tonaji < nudTonaj.Value)
            {
                MessageBox.Show("Geminin tonajı büyük bir değer giremez");
                return;
            }
            gonderim.SeyirKaydi = cmbSeferler.SelectedItem as SeyirKaydi;
            gonderim.Urun = new Urun();
            gonderim.Urun.UrunId = urunId;
            gonderim.Urun.UrunAdi = txtUrun.Text;
            gonderim.Tonaj = nudTonaj.Value;

            gonderim.IlgilenenKisi = new IlgilenenKisi();
            gonderim.IlgilenenKisi.KisininAdi = txtKisi.Text;
            gonderim.IlgilenenKisi.KisininTelefonu = mtxtKisiTelNo.Text;
            gonderim.IlgilenenKisi.IlgilenenKisiId = ilgilenenKisiId++;
            gonderim.IlgilenenKisi.BagliOlduguFirma = cmbFirma.SelectedItem as Firma;

            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = (++id).ToString();
            listViewItem.SubItems.Add(gonderim.Tonaj.ToString());
            listViewItem.SubItems.Add(gonderim.Urun.UrunAdi.ToString());
            listViewItem.SubItems.Add(gonderim.IlgilenenKisi.BagliOlduguFirma.FirmaAdi.ToString());
            listViewItem.SubItems.Add(gonderim.IlgilenenKisi.KisininAdi.ToString());
            listViewItem.SubItems.Add(gonderim.IlgilenenKisi.KisininTelefonu.ToString());

            //to do
            //burada herbir list item ımın tag kontrolüne gönderim nesnesini gizledim.
            
            listViewItem.Tag = gonderim;

            //burada list itemlarımı listview içerisine ekleme yaptım.
            lvGonderim.Items.Add(listViewItem);
            Temizle();





        }

        private void btnGec_Click(object sender, EventArgs e)
        {
            if(lvGonderim.Items.Count>0)
            {
                //bir gönderim listesi oluşturduk.
                List<Gonderim> gonderimler = new List<Gonderim>();
                //burada daha önce eklediğim list itemlarımı listview içinde dönerek her list itemin tagine ulaştım orada gönderim nesnesi vardı ben de bunları bir gönderim listesine ekledim. 

                foreach (ListViewItem item in lvGonderim.Items)
                {
                    gonderimler.Add((Gonderim)item.Tag);
                }


                //eklediğim gönderim listesini form3te çağırdım.
                FRMZRaporu fRMZRaporu = new FRMZRaporu(gonderimler);
                fRMZRaporu.Show();
            }
        }
    }
}
