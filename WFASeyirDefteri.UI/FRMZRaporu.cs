using ClosedXML.Excel;
using CLSeyirDefteri.Core.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
            ListeyiGuncelle();
            dtpBitis.MinDate = dtpBaslangic.Value;
        }
        public FRMZRaporu()
        {
            InitializeComponent();
            ListViewTaslakOlustur();

        }

        decimal kalanTonaj;

        public void ListViewTaslakOlustur()
        {

            lvZRaporu.View = View.Details;
            lvZRaporu.GridLines = true;

            lvZRaporu.Columns.Add("Gemi", 250, HorizontalAlignment.Center);
            lvZRaporu.Columns.Add("Çıkış Tarihi", 120, HorizontalAlignment.Center);
            lvZRaporu.Columns.Add("Varış Tarihi", 120, HorizontalAlignment.Center);
            lvZRaporu.Columns.Add("Ürün", 100, HorizontalAlignment.Center);
            lvZRaporu.Columns.Add("Firma", 150, HorizontalAlignment.Center);
            lvZRaporu.Columns.Add("Ürün Yükü", 100, HorizontalAlignment.Center);
            lvZRaporu.Columns.Add("Kalan Tonaj", 130, HorizontalAlignment.Center);
        }

        public void ListeyiGuncelle()
        {
            //dtp ile olan değeri aldık.
            DateTime baslangicTarihi = dtpBaslangic.Value.Date;
            DateTime bitisTarihi = dtpBitis.Value.Date;


            decimal toplamKullanilanTonaj = 0;
            decimal gemiTonaji = 0;

            foreach (Gonderim gonderim in Gonderimler)
            {
                DateTime limandanCikisTarihi = gonderim.SeyirKaydi.LimandanCikisTarihi.Date;
                DateTime limanaVarisTarihi = gonderim.SeyirKaydi.LimanaVarisTarihi.Date;
                if (limandanCikisTarihi >= baslangicTarihi && limanaVarisTarihi <= bitisTarihi)
                {
                    if (gemiTonaji == 0)
                    {
                        gemiTonaji = gonderim.SeyirKaydi.Gemi.Tonaji;
                    }
                    toplamKullanilanTonaj += gonderim.Tonaj;
                    kalanTonaj = gemiTonaji - toplamKullanilanTonaj;

                    ListViewItem listViewItem = new ListViewItem();

                    listViewItem.Text = gonderim.SeyirKaydi.Gemi.GemiAdi;
                    listViewItem.SubItems.Add(gonderim.SeyirKaydi.LimandanCikisTarihi.ToString("dd/MM/yyyy"));
                    listViewItem.SubItems.Add(gonderim.SeyirKaydi.LimanaVarisTarihi.ToString("dd/MM/yyyy"));
                    listViewItem.SubItems.Add(gonderim.Urun.UrunAdi);
                    listViewItem.SubItems.Add(gonderim.IlgilenenKisi.BagliOlduguFirma.FirmaAdi);
                    listViewItem.SubItems.Add(gonderim.Tonaj.ToString());

                    if (kalanTonaj >= 0)
                    {
                        listViewItem.SubItems.Add(kalanTonaj.ToString());
                    }
                    else
                    {
                        listViewItem.SubItems.Add("Gemi tonajından fazla yük yüklenmiştir.");
                    }
                    lvZRaporu.Items.Add(listViewItem);

                }
            }




        }



        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {
            dtpBitis.MinDate = dtpBaslangic.Value;
            ListeyiGuncelle();
        }

        private void dtpBitis_ValueChanged(object sender, EventArgs e)
        {
            ListeyiGuncelle();
        }

        private void btnExcelOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime baslangicTarihi = dtpBaslangic.Value.Date;
                DateTime bitisTarihi = dtpBitis.Value.Date;
                ListeyiGuncelle();

                //using, farklı namespace'lerdeki sınıfları ve fonksiyonları projemize dahil etmek için kullanılır.

                //Excel çalışma kitabı oluşturur ve işlem tamamlandıktan sonra otomatik temizlenmesini sağlar.
                using (var workbook = new XLWorkbook())
                {
                    //Worksheet, Excel dosyası (Workbook) içindeki tek bir sayfayı (sheet) ifade eder. AddWorksheet ile "Z Raporu" adında yeni bir sayfa(sheet) ekledik.
                    var workSheet = workbook.AddWorksheet("Seyir Kaydı");

                    workSheet.Cell(1, 1).Value = "Gemi"; // Cell(satır,sütun) ==> excelde belirtilen konuma yazı yazdık.
                    workSheet.Cell(1, 2).Value = "Çıkış Tarihi";
                    workSheet.Cell(1, 3).Value = "Varış Tarihi";
                    workSheet.Cell(1, 4).Value = "Ürün";
                    workSheet.Cell(1, 5).Value = "Firma";
                    workSheet.Cell(1, 6).Value = "Ürün Yükü";
                    workSheet.Cell(1, 7).Value = "Kalan Tonaj";

                    workSheet.Columns().AdjustToContents(); //sütun genişliklerini otomatik ayarlamak için AdjustToContents() metodunu kullandık. Bu metod, sütundaki en uzun içeriğe göre genişliği ayarlar.

                    int satir = 2;
                    foreach (ListViewItem item in lvZRaporu.Items)
                    {
                        //ListViewItem dan bilgileri alıyoruz, excele yazdırıyoruz.
                        workSheet.Cell(satir, 1).Value = item.SubItems[0].Text; //SubItems[0] ==> 2. satırdaki ilk öğe.
                        workSheet.Cell(satir, 2).Value = item.SubItems[1].Text;
                        workSheet.Cell(satir, 3).Value = item.SubItems[2].Text;
                        workSheet.Cell(satir, 4).Value = item.SubItems[3].Text;
                        workSheet.Cell(satir, 5).Value = item.SubItems[4].Text;
                        satir++;
                    }

                    //SaveFileDialog, kullanıcının bir dosyayı kaydetmek için dosya adı ve konumu seçmesini sağlayan bir Windows bileşenidir.
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";   //Dosya türü
                        saveFileDialog.Title = "Excel Dosyasını Kaydet"; //Pencere başlığı
                        saveFileDialog.FileName = "SeyirKaydi.xlsx";    //Seçilen dosya adı ve yolu

                        if (saveFileDialog.ShowDialog() == DialogResult.OK) //Kullanıcı açılan pencerede OK(tamam,evet,vs.. bir onay tuşuna) basarsa: (DialogResult.OK bu anlama geliyor. Zıttı ise(onaylamama durumu)  DialogResult.Cancel)
                        {
                            string filePath = saveFileDialog.FileName;
                            workbook.SaveAs(filePath); //Oluşturduğumuz workbook u (excel dosyasını), kullanıcının belirlediği konuma kaydet.
                            MessageBox.Show("Excel başarıyla oluşturuldu.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPDFOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter= "PDF Dosyaları (*.pdf)|*.pdf"; //Dosya türü
                saveFileDialog.Title = "PDF Dosyası Kaydet"; //Pencere başlığı

                if(saveFileDialog.ShowDialog() == DialogResult.OK) //Kullanıcı açılan pencerede OK(tamam,evet,vs.. bir onay tuşuna) basarsa: (DialogResult.OK bu anlama geliyor. Zıttı ise(onaylamama durumu)  DialogResult.Cancel)
                {
                    Document document = new Document(); //Document sınıfı, iTextSharp kütüphanesinde bir PDF belgesini temsil eder.
                    PdfWriter.GetInstance(document,new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    PdfPTable table = new PdfPTable(lvZRaporu.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (ColumnHeader column in lvZRaporu.Columns)
                    {
                        PdfPCell pdfPCell = new PdfPCell(new Phrase(column.Text));
                        pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(pdfPCell);
                    }
                    foreach(ListViewItem item in lvZRaporu.Items)
                    {
                        foreach(ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            table.AddCell(subItem.Text);
                        }
                    }

                    document.Add(table);
                    document.Close();
                    MessageBox.Show("PDF başarıyla oluşturuldu.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
