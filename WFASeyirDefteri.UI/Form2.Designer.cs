namespace WFASeyirDefteri.UI
{
    partial class FRMGonderim
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
            cmbSeferler = new ComboBox();
            cmbFirma = new ComboBox();
            txtUrun = new TextBox();
            txtKisi = new TextBox();
            mtxtKisiTelNo = new MaskedTextBox();
            nudTonaj = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lvGonderim = new ListView();
            btnUrunEkle = new Button();
            btnGec = new Button();
            ((System.ComponentModel.ISupportInitialize)nudTonaj).BeginInit();
            SuspendLayout();
            // 
            // cmbSeferler
            // 
            cmbSeferler.Font = new Font("Times New Roman", 12F);
            cmbSeferler.FormattingEnabled = true;
            cmbSeferler.Location = new Point(271, 39);
            cmbSeferler.Name = "cmbSeferler";
            cmbSeferler.Size = new Size(271, 30);
            cmbSeferler.TabIndex = 0;
            // 
            // cmbFirma
            // 
            cmbFirma.Font = new Font("Times New Roman", 12F);
            cmbFirma.FormattingEnabled = true;
            cmbFirma.Location = new Point(271, 146);
            cmbFirma.Name = "cmbFirma";
            cmbFirma.Size = new Size(271, 30);
            cmbFirma.TabIndex = 1;
            // 
            // txtUrun
            // 
            txtUrun.Font = new Font("Times New Roman", 12F);
            txtUrun.Location = new Point(271, 74);
            txtUrun.Name = "txtUrun";
            txtUrun.Size = new Size(271, 30);
            txtUrun.TabIndex = 2;
            // 
            // txtKisi
            // 
            txtKisi.Font = new Font("Times New Roman", 12F);
            txtKisi.Location = new Point(269, 182);
            txtKisi.Name = "txtKisi";
            txtKisi.Size = new Size(273, 30);
            txtKisi.TabIndex = 2;
            // 
            // mtxtKisiTelNo
            // 
            mtxtKisiTelNo.Font = new Font("Times New Roman", 12F);
            mtxtKisiTelNo.Location = new Point(269, 221);
            mtxtKisiTelNo.Mask = "(999) 000-0000";
            mtxtKisiTelNo.Name = "mtxtKisiTelNo";
            mtxtKisiTelNo.Size = new Size(273, 30);
            mtxtKisiTelNo.TabIndex = 3;
            // 
            // nudTonaj
            // 
            nudTonaj.Font = new Font("Times New Roman", 12F);
            nudTonaj.Location = new Point(271, 110);
            nudTonaj.Maximum = new decimal(new int[] { -402653185, -1613725636, 54210108, 0 });
            nudTonaj.Name = "nudTonaj";
            nudTonaj.Size = new Size(271, 30);
            nudTonaj.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.Location = new Point(101, 77);
            label1.Name = "label1";
            label1.Size = new Size(61, 22);
            label1.TabIndex = 5;
            label1.Text = "Ürün :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F);
            label2.Location = new Point(101, 42);
            label2.Name = "label2";
            label2.Size = new Size(63, 22);
            label2.TabIndex = 5;
            label2.Text = "Sefer :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F);
            label3.Location = new Point(101, 149);
            label3.Name = "label3";
            label3.Size = new Size(68, 22);
            label3.TabIndex = 5;
            label3.Text = "Firma :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F);
            label4.Location = new Point(101, 112);
            label4.Name = "label4";
            label4.Size = new Size(66, 22);
            label4.TabIndex = 5;
            label4.Text = "Tonaj :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F);
            label5.Location = new Point(101, 224);
            label5.Name = "label5";
            label5.Size = new Size(162, 22);
            label5.TabIndex = 5;
            label5.Text = "Telefon Numarası :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F);
            label6.Location = new Point(101, 185);
            label6.Name = "label6";
            label6.Size = new Size(55, 22);
            label6.TabIndex = 5;
            label6.Text = "Kişi :";
            // 
            // lvGonderim
            // 
            lvGonderim.Font = new Font("Times New Roman", 12F);
            lvGonderim.Location = new Point(12, 321);
            lvGonderim.Name = "lvGonderim";
            lvGonderim.Size = new Size(1120, 351);
            lvGonderim.TabIndex = 6;
            lvGonderim.UseCompatibleStateImageBehavior = false;
            // 
            // btnUrunEkle
            // 
            btnUrunEkle.BackColor = SystemColors.ButtonFace;
            btnUrunEkle.Font = new Font("Times New Roman", 12F);
            btnUrunEkle.Location = new Point(340, 259);
            btnUrunEkle.Name = "btnUrunEkle";
            btnUrunEkle.Size = new Size(202, 56);
            btnUrunEkle.TabIndex = 7;
            btnUrunEkle.Text = "Ürün Ekle";
            btnUrunEkle.UseVisualStyleBackColor = false;
            btnUrunEkle.Click += btnUrunEkle_Click;
            // 
            // btnGec
            // 
            btnGec.BackColor = SystemColors.ButtonFace;
            btnGec.Font = new Font("Times New Roman", 12F);
            btnGec.Location = new Point(134, 261);
            btnGec.Name = "btnGec";
            btnGec.Size = new Size(200, 54);
            btnGec.TabIndex = 8;
            btnGec.Text = "Geç";
            btnGec.UseVisualStyleBackColor = false;
            btnGec.Click += btnGec_Click;
            // 
            // FRMGonderim
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 684);
            Controls.Add(btnGec);
            Controls.Add(btnUrunEkle);
            Controls.Add(lvGonderim);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nudTonaj);
            Controls.Add(mtxtKisiTelNo);
            Controls.Add(txtKisi);
            Controls.Add(txtUrun);
            Controls.Add(cmbFirma);
            Controls.Add(cmbSeferler);
            Name = "FRMGonderim";
            Load += FRMGonderim_Load;
            ((System.ComponentModel.ISupportInitialize)nudTonaj).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSeferler;
        private ComboBox cmbFirma;
        private TextBox txtUrun;
        private TextBox txtKisi;
        private MaskedTextBox mtxtKisiTelNo;
        private NumericUpDown nudTonaj;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListView lvGonderim;
        private Button btnUrunEkle;
        private Button btnGec;
    }
}