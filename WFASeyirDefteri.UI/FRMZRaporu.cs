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
using System.Net;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFASeyirDefteri.UI
{
    public partial class FRMZRaporu : Form
    {
        decimal kalanTonaj;
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

       
        /// <summary>
        /// ListView in sütunları ve sütunlarının başlıkları oluşturuldu.
        /// </summary>
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

            //where -> benim dtp içindeki zaman aralığım ile seferlerimin zaman aralığının uyuşması lazım, onun için burada where sorgusu yazdık.
            //groupby -> gemileri kendi içlerinde grupladım( her seferdeki seçilen gemi sadece kendi içinde gruplandı yani titanic 5 ürün taşıyorsa sadece titanik olarak alındı eklenen diğer gemiler de 
            //bunları birer listeye dönüştürdük -> tolist -> burada gruplara yani 5 tane aynı gemiye ürün varsa her birini listeledik

            var gemiBazliGonderimler = Gonderimler
                .Where(g => g.SeyirKaydi.LimandanCikisTarihi.Date >= baslangicTarihi && g.SeyirKaydi.LimanaVarisTarihi.Date <= bitisTarihi)
                .GroupBy(g => g.SeyirKaydi.Gemi.GemiAdi)
                .ToList();

            lvZRaporu.Items.Clear();
            foreach (var grup in gemiBazliGonderimler)
            {
                //yukarıda listelediğimiz gemileri kendi içinde de gönderim olarak ayrıştırdık.

                //grup.First() ilk itemi al demek
                // ?. (null conditional operator), SeyirKaydi.Gemi nesnesinin null olup olmadığını kontrol eder.
                //Eğer SeyirKaydi veya Gemi null ise, Tonaji özelliğine erişmeye çalışırken hata vermez, doğrudan null döner.
                //?? ise eğer ki SeyirKaydi.Gemi null ise sağındaki değeri(0) al demek.
                decimal gemiTonaji = grup.First().SeyirKaydi.Gemi?.Tonaji ?? 0;

                decimal toplamKullanilanTonaj = 0;

                foreach (Gonderim gonderim in grup)
                {
                    //burada kalan tonajı hesapladık
                    toplamKullanilanTonaj += gonderim.Tonaj;
                    decimal kalanTonaj = gemiTonaji - toplamKullanilanTonaj;

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
                        listViewItem.SubItems.Add("Gemi battı!");
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

                    // exceldeki sütunların genişliğini belirledim.
                    workSheet.Column(1).Width = 26;
                    workSheet.Column(2).Width = 15;
                    workSheet.Column(3).Width = 15;
                    workSheet.Column(4).Width = 22;
                    workSheet.Column(5).Width = 65;
                    workSheet.Column(6).Width = 13;
                    workSheet.Column(7).Width = 15;


                    int satir = 2;
                    foreach (ListViewItem item in lvZRaporu.Items)
                    {
                        //ListViewItem dan bilgileri alıyoruz, excele yazdırıyoruz.
                        workSheet.Cell(satir, 1).Value = item.SubItems[0].Text; //SubItems[0] ==> 2. satırdaki ilk öğe.
                        workSheet.Cell(satir, 2).Value = item.SubItems[1].Text;
                        workSheet.Cell(satir, 3).Value = item.SubItems[2].Text;
                        workSheet.Cell(satir, 4).Value = item.SubItems[3].Text;
                        workSheet.Cell(satir, 5).Value = item.SubItems[4].Text;
                        workSheet.Cell(satir, 6).Value = item.SubItems[5].Text;
                        workSheet.Cell(satir, 7).Value = item.SubItems[6].Text;
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
                saveFileDialog.Filter = "PDF Dosyası|*.pdf"; //Dosya türü
                saveFileDialog.Title = "PDF Dosyası Kaydet"; //Pencere başlığı

                if (saveFileDialog.ShowDialog() == DialogResult.OK) //Kullanıcı açılan pencerede OK(tamam,evet,vs.. bir onay tuşuna) basarsa: (DialogResult.OK bu anlama geliyor. Zıttı ise(onaylamama durumu)  DialogResult.Cancel)
                {
                    Document document = new Document(); //Document sınıfı, iTextSharp kütüphanesinde bir PDF belgesini temsil eder.
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    PdfPTable table = new PdfPTable(lvZRaporu.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (ColumnHeader column in lvZRaporu.Columns)
                    {
                        PdfPCell pdfPCell = new PdfPCell(new Phrase(column.Text));
                        pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(pdfPCell);
                    }
                    foreach (ListViewItem item in lvZRaporu.Items)
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
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

        private void btnMailAt_Click(object sender, EventArgs e)
        {
            string gonderimYapilacakMailAdresi = txtMailAdresi.Text;
            if(!gonderimYapilacakMailAdresi.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Yalnızca gmail uzantılı mail adresi girmelisiniz!");
                txtMailAdresi.Text = "example@gmail.com";
                return;
            }

            try
            {
                string excelDosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GönderimZRaporu.xlsx");
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sefer Listesi"); 
                    for (int col = 0; col < lvZRaporu.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = lvZRaporu.Columns[col].Text;
                    }
                    int row = 2;
                    foreach (ListViewItem item in lvZRaporu.Items)
                    {
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            worksheet.Cell(row, i + 1).Value = item.SubItems[i].Text;
                        }
                        row++;
                    }
                    workbook.SaveAs(excelDosyaYolu);
                }
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                mailMessage.From = new MailAddress("dogayildizyzl@gmail.com");  //gönderen kişinin mail adresi
                mailMessage.To.Add(txtMailAdresi.Text);  //gönderdiğim kişinin mail adresi
                mailMessage.Subject = "Gönderimin Z Raporu";
                mailMessage.Body = "Merhaba iyi çalışmalar, \nEkteki dosya gönderimin z raporudur.";

                mailMessage.Attachments.Add(new Attachment(excelDosyaYolu));

                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("dogayildizyzl@gmail.com", "rrfnaejkrnpkwwlq"); //gönderen eposta, uygulama şifresi google hesaplardan
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                MessageBox.Show("E posta başarıyla gönderildi!");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtMailAdresi_Click(object sender, EventArgs e)
        {
            txtMailAdresi.Clear();            
        }
    }
}
