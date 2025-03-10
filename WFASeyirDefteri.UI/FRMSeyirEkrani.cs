using CLSeyirDefteri.Core.Data;
using System.Collections.Generic;

namespace WFASeyirDefteri.UI
{
    public partial class FRMSeyirEkrani : Form
    {

        public static List<SeyirKaydi> SeyirKayitlari = new List<SeyirKaydi>();
        int id = 0;
        public void GemiEkle()
        {
            List<Gemi> gemilerListesi = new List<Gemi>()
            {
                new Gemi { GemiId = 1, GemiAdi = "Titanic", Tonaji = 46000m },
                new Gemi { GemiId = 2, GemiAdi = "Queen Mary 2", Tonaji = 148528m },
                new Gemi { GemiId = 3, GemiAdi = "Oasis of the Seas", Tonaji = 226838m },
                new Gemi { GemiId = 4, GemiAdi = "Harmony of the Seas", Tonaji = 226963m },
                new Gemi { GemiId = 5, GemiAdi = "Symphony of the Seas", Tonaji = 228081m },
                new Gemi { GemiId = 6, GemiAdi = "MSC Meraviglia", Tonaji = 171598m },
                new Gemi { GemiId = 7, GemiAdi = "Norwegian Escape", Tonaji = 165300m },
                new Gemi { GemiId = 8, GemiAdi = "Costa Smeralda", Tonaji = 185010m },
                new Gemi { GemiId = 9, GemiAdi = "AIDAnova", Tonaji = 183900m },
                new Gemi { GemiId = 10, GemiAdi = "Mardi Gras", Tonaji = 180000m },
                new Gemi { GemiId = 11, GemiAdi = "Regal Princess", Tonaji = 142714m },
                new Gemi { GemiId = 12, GemiAdi = "Majestic Princess", Tonaji = 143700m },
                new Gemi { GemiId = 13, GemiAdi = "Celebrity Edge", Tonaji = 130818m },
                new Gemi { GemiId = 14, GemiAdi = "MSC Seaview", Tonaji = 154000m },
                new Gemi { GemiId = 15, GemiAdi = "Carnival Vista", Tonaji = 133500m }
            };

            foreach (Gemi gemi in gemilerListesi)
            {
                cmbGemi.Items.Add(gemi);
            }
        }

        public void LimanEkle()
        {
            List<string> limanlar = new List<string>
            {
              "Ýstanbul Sarýyer Yat Limaný, Türkiye",
              "Ýstanbul Beþiktaþ Limaný, Türkiye",
              "Ýstanbul Haydarpaþa Limaný, Türkiye",
              "Ýstanbul Kadýköy Limaný, Türkiye",
              "Ýstanbul Karaköy Limaný, Türkiye",
              "Ýstanbul Ambarlý Limaný, Türkiye",
              "Ýstanbul Bakýrköy Limaný, Türkiye",
              "Ýzmir Alsancak Limaný, Türkiye",
              "Ýzmir Çeþme Limaný, Türkiye",
               "Ýzmir Karþýyaka Limaný, Türkiye",
              "Ýzmir Aliaða Limaný, Türkiye",
              "Mersin Limaný, Türkiye",
              "Antalya Limaný, Türkiye",
              "Bodrum Limaný, Türkiye",
              "Göcek Limaný, Türkiye",
              "Fethiye Limaný, Türkiye",
              "Kuþadasý Limaný, Türkiye",
              "Trabzon Limaný, Türkiye",
              "Samsun Limaný, Türkiye",
              "Hopa Limaný, Türkiye",
              "Port of Piraeus, Yunanistan",
              "Port of Thessaloniki, Yunanistan",
              "Port of Heraklion, Yunanistan",
              "Port of Patras, Yunanistan",
              "Port of Volos, Yunanistan",
              "Port of Genoa, Ýtalya",
              "Port of Naples, Ýtalya",
              "Port of Livorno, Ýtalya",
              "Port of Civitavecchia, Ýtalya",
              "Port of Venice, Ýtalya",
              "Port of Marseille, Fransa",
              "Port of Le Havre, Fransa"
            };

            foreach (string liman in limanlar)
            {
                cmbCikisLimani.Items.Add(liman);
                cmbUgradigiLiman.Items.Add(liman);
                cmbVarisLimani.Items.Add(liman);
            }
        }

        private void FRMSeyirEkrani_Load(object sender, EventArgs e)
        {

            GemiEkle();
            LimanEkle();
            ListViewTasarimOlustur();
            dtpVarisTarihi.MinDate = dtpCikisTarihi.Value;
        }
        public FRMSeyirEkrani()
        {
            InitializeComponent();

        }
        public void ListViewTasarimOlustur()
        {
            lvSeferler.View = View.Details; //View öðelerin nasýl gösterileceðini belirler. View.Details detaylý görünüm demek.
            lvSeferler.GridLines = true;  //satýr sütun aralarýnda çizgilerin görünürlüðünü aktif ettik.
            lvSeferler.Columns.Add("ID", 40, HorizontalAlignment.Center);  //Kolonlar ekledik
            lvSeferler.Columns.Add("Gemi", 180, HorizontalAlignment.Center); //HorizontalAlignment.Center ile kolona yazýlan yazýlarý ortala dedik.
            lvSeferler.Columns.Add("Çýkýþ Limaný", 220, HorizontalAlignment.Center);
            lvSeferler.Columns.Add("Uðradýðý Liman", 220, HorizontalAlignment.Center);
            lvSeferler.Columns.Add("Varýþ Limaný", 220, HorizontalAlignment.Center);
            lvSeferler.Columns.Add("Çýkýþ Tarihi", 120, HorizontalAlignment.Center);
            lvSeferler.Columns.Add("Varýþ Tarihi", 120, HorizontalAlignment.Center);

        }
        private void btnSeferOlustur_Click(object sender, EventArgs e)
        {
            if (cmbGemi.SelectedItem == null)
            {
                MessageBox.Show("Gemi girilmesi zorunludur!!");
                return;
            }
            if (cmbCikisLimani.SelectedItem == cmbUgradigiLiman.SelectedItem || cmbUgradigiLiman.SelectedItem == cmbVarisLimani.SelectedItem || cmbVarisLimani.SelectedItem == cmbCikisLimani.SelectedItem)
            {
                MessageBox.Show("Sefer sýrasýnda girilen duraklar farklý olmak zorundadýr");
                return;
            }
            //Yeni bir seyir kaydý oluþturduk.
            SeyirKaydi seyirKaydi = new SeyirKaydi()
            {
                LimandanCikisTarihi = dtpCikisTarihi.Value,
                LimanaVarisTarihi = dtpVarisTarihi.Value,
                CikisLimani = cmbCikisLimani.SelectedItem.ToString(),
                UgrayacagiLiman = cmbUgradigiLiman.SelectedItem.ToString(),
                VarisLimani = cmbVarisLimani.SelectedItem.ToString(),
                Gemi = cmbGemi.SelectedItem as Gemi

            };

            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = (++id).ToString();
            listViewItem.SubItems.Add(seyirKaydi.Gemi.ToString());
            listViewItem.SubItems.Add(seyirKaydi.CikisLimani.ToString());
            listViewItem.SubItems.Add(seyirKaydi.UgrayacagiLiman.ToString());
            listViewItem.SubItems.Add(seyirKaydi.VarisLimani.ToString());
            listViewItem.SubItems.Add(seyirKaydi.LimandanCikisTarihi.ToShortDateString());
            listViewItem.SubItems.Add(seyirKaydi.LimanaVarisTarihi.ToShortDateString());

            lvSeferler.Items.Add(listViewItem);
            //static listemize sayir kaydýný ekliyoruz.
            SeyirKayitlari.Add(seyirKaydi);
            Temizle();
        }

        private void dtpCikisTarihi_ValueChanged(object sender, EventArgs e)  //Varýþ tarihinin çýkýþ tarihinden daha erken seçilememesini saðladýk.
        {
            dtpVarisTarihi.MinDate = dtpCikisTarihi.Value;
        }
        public void Temizle()
        {
            cmbGemi.SelectedItem = null;
            cmbCikisLimani.SelectedItem = null;
            cmbUgradigiLiman.SelectedItem = null;
            cmbVarisLimani.SelectedItem = null;
            dtpCikisTarihi.Value = DateTime.Today;
            dtpVarisTarihi.Value = DateTime.Today;
        }

        private void btnGec_Click(object sender, EventArgs e)
        {
            if(SeyirKayitlari.Count>0)
            {
                FRMGonderim fRMGonderim = new FRMGonderim(SeyirKayitlari);
                fRMGonderim.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen seyirlerinizi listeye ekleyiniz.");
            }
        }
    }
}
