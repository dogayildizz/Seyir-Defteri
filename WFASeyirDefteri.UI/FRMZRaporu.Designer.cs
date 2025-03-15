namespace WFASeyirDefteri.UI
{
    partial class FRMZRaporu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtpBaslangic = new DateTimePicker();
            dtpBitis = new DateTimePicker();
            lvZRaporu = new ListView();
            btnMailAt = new Button();
            btnPDFOlustur = new Button();
            btnExcelOlustur = new Button();
            txtMailAdresi = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Font = new Font("Times New Roman", 12F);
            dtpBaslangic.Location = new Point(81, 49);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(250, 30);
            dtpBaslangic.TabIndex = 0;
            dtpBaslangic.ValueChanged += dtpBaslangic_ValueChanged;
            // 
            // dtpBitis
            // 
            dtpBitis.Font = new Font("Times New Roman", 12F);
            dtpBitis.Location = new Point(802, 49);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(250, 30);
            dtpBitis.TabIndex = 0;
            dtpBitis.ValueChanged += dtpBitis_ValueChanged;
            // 
            // lvZRaporu
            // 
            lvZRaporu.Font = new Font("Times New Roman", 12F);
            lvZRaporu.Location = new Point(81, 112);
            lvZRaporu.Name = "lvZRaporu";
            lvZRaporu.Size = new Size(971, 390);
            lvZRaporu.TabIndex = 1;
            lvZRaporu.UseCompatibleStateImageBehavior = false;
            // 
            // btnMailAt
            // 
            btnMailAt.BackColor = SystemColors.ButtonFace;
            btnMailAt.Font = new Font("Times New Roman", 12F);
            btnMailAt.Location = new Point(827, 595);
            btnMailAt.Name = "btnMailAt";
            btnMailAt.Size = new Size(225, 56);
            btnMailAt.TabIndex = 2;
            btnMailAt.Text = "Excel Dosyasını Mail At";
            btnMailAt.UseVisualStyleBackColor = false;
            btnMailAt.Click += btnMailAt_Click;
            // 
            // btnPDFOlustur
            // 
            btnPDFOlustur.BackColor = SystemColors.ButtonFace;
            btnPDFOlustur.Font = new Font("Times New Roman", 12F);
            btnPDFOlustur.Location = new Point(81, 523);
            btnPDFOlustur.Name = "btnPDFOlustur";
            btnPDFOlustur.Size = new Size(202, 56);
            btnPDFOlustur.TabIndex = 2;
            btnPDFOlustur.Text = "PDF Oluştur";
            btnPDFOlustur.UseVisualStyleBackColor = false;
            btnPDFOlustur.Click += btnPDFOlustur_Click;
            // 
            // btnExcelOlustur
            // 
            btnExcelOlustur.BackColor = SystemColors.ButtonFace;
            btnExcelOlustur.Font = new Font("Times New Roman", 12F);
            btnExcelOlustur.Location = new Point(81, 595);
            btnExcelOlustur.Name = "btnExcelOlustur";
            btnExcelOlustur.Size = new Size(202, 56);
            btnExcelOlustur.TabIndex = 2;
            btnExcelOlustur.Text = "Excel Oluştur";
            btnExcelOlustur.UseVisualStyleBackColor = false;
            btnExcelOlustur.Click += btnExcelOlustur_Click;
            // 
            // txtMailAdresi
            // 
            txtMailAdresi.Location = new Point(731, 562);
            txtMailAdresi.Name = "txtMailAdresi";
            txtMailAdresi.Size = new Size(321, 27);
            txtMailAdresi.TabIndex = 3;
            txtMailAdresi.Text = "example@gmail.com";
            txtMailAdresi.Click += txtMailAdresi_Click;
            // 
            // label1
            // 
            label1.Location = new Point(731, 503);
            label1.Name = "label1";
            label1.Size = new Size(321, 56);
            label1.TabIndex = 4;
            label1.Text = "Göndermek istediğiniz mail adresini giriniz : (Yalnızca gmail)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FRMZRaporu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 684);
            Controls.Add(label1);
            Controls.Add(txtMailAdresi);
            Controls.Add(btnExcelOlustur);
            Controls.Add(btnPDFOlustur);
            Controls.Add(btnMailAt);
            Controls.Add(lvZRaporu);
            Controls.Add(dtpBitis);
            Controls.Add(dtpBaslangic);
            Name = "FRMZRaporu";
            Text = "Sefer Kaydı Belge Oluştur";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
        private ListView lvZRaporu;
        private Button btnMailAt;
        private Button btnPDFOlustur;
        private Button btnExcelOlustur;
        private TextBox txtMailAdresi;
        private Label label1;
    }
}