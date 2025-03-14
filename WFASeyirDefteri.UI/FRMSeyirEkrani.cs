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
              "�stanbul Sar�yer Yat Liman�, T�rkiye",
              "�stanbul Be�ikta� Liman�, T�rkiye",
              "�stanbul Haydarpa�a Liman�, T�rkiye",
              "�stanbul Kad�k�y Liman�, T�rkiye",
              "�stanbul Karak�y Liman�, T�rkiye",
              "�stanbul Ambarl� Liman�, T�rkiye",
              "�stanbul Bak�rk�y Liman�, T�rkiye",
              "�zmir Alsancak Liman�, T�rkiye",
              "�zmir �e�me Liman�, T�rkiye",
               "�zmir Kar��yaka Liman�, T�rkiye",
              "�zmir Alia�a Liman�, T�rkiye",
              "Mersin Liman�, T�rkiye",
              "Antalya Liman�, T�rkiye",
              "Bodrum Liman�, T�rkiye",
              "G�cek Liman�, T�rkiye",
              "Fethiye Liman�, T�rkiye",
              "Ku�adas� Liman�, T�rkiye",
              "Trabzon Liman�, T�rkiye",
              "Samsun Liman�, T�rkiye",
              "Hopa Liman�, T�rkiye",
              "Port of Piraeus, Yunanistan",
              "Port of Thessaloniki, Yunanistan",
              "Port of Heraklion, Yunanistan",
              "Port of Patras, Yunanistan",
              "Port of Volos, Yunanistan",
              "Port of Genoa, �talya",
              "Port of Naples, �talya",
              "Port of Livorno, �talya",
              "Port of Civitavecchia, �talya",
              "Port of Venice, �talya",
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
            lvSeferler.View = View.Details; //View ��elerin nas�l g�sterilece�ini belirler. View.Details detayl� g�r�n�m demek.
            lvSeferler.GridLines = true;  //sat�r s�tun aralar�nda �izgilerin g�r�n�rl���n� aktif ettik.
            lvSeferler.Columns.Add("ID", 40, HorizontalAlignment.Center);  //Kolonlar ekledik
            lvSeferler.Columns.Add("Gemi", 180, HorizontalAlignment.Center); //HorizontalAlignment.Center ile kolona yaz�lan yaz�lar� ortala dedik.
            lvSeferler.Columns.Add("��k�� Liman�", 220, HorizontalAlignment.Center);
            lvSeferler.Columns.Add("U�rad��� Liman", 220, HorizontalAlignment.Center);
            lvSeferler.Columns.Add("Var�� Liman�", 220, HorizontalAlignment.Center);
            lvSeferler.Columns.Add("��k�� Tarihi", 120, HorizontalAlignment.Center);
            lvSeferler.Columns.Add("Var�� Tarihi", 120, HorizontalAlignment.Center);

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
                MessageBox.Show("Sefer s�ras�nda girilen duraklar farkl� olmak zorundad�r");
                return;
            }
            //Yeni bir seyir kayd� olu�turduk.
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
            //static listemize sayir kayd�n� ekliyoruz.
            SeyirKayitlari.Add(seyirKaydi);
            Temizle();
        }

        private void dtpCikisTarihi_ValueChanged(object sender, EventArgs e)  //Var�� tarihinin ��k�� tarihinden daha erken se�ilememesini sa�lad�k.
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
                MessageBox.Show("L�tfen seyirlerinizi listeye ekleyiniz.");
            }
        }
    }
}
