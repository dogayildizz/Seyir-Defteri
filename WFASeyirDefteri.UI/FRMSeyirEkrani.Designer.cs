namespace WFASeyirDefteri.UI
{
    partial class FRMSeyirEkrani
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cmbGemi = new ComboBox();
            dtpCikisTarihi = new DateTimePicker();
            btnSeferOlustur = new Button();
            lvSeferler = new ListView();
            dtpVarisTarihi = new DateTimePicker();
            cmbCikisLimani = new ComboBox();
            cmbUgradigiLiman = new ComboBox();
            cmbVarisLimani = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.Location = new Point(65, 45);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(198, 22);
            label1.TabIndex = 0;
            label1.Text = "Limandan Çıkış Tarihi :";
            // 
            // cmbGemi
            // 
            cmbGemi.Font = new Font("Times New Roman", 12F);
            cmbGemi.FormattingEnabled = true;
            cmbGemi.Location = new Point(271, 108);
            cmbGemi.Margin = new Padding(4, 3, 4, 3);
            cmbGemi.Name = "cmbGemi";
            cmbGemi.Size = new Size(312, 30);
            cmbGemi.TabIndex = 1;
            // 
            // dtpCikisTarihi
            // 
            dtpCikisTarihi.Font = new Font("Times New Roman", 12F);
            dtpCikisTarihi.Location = new Point(271, 39);
            dtpCikisTarihi.Margin = new Padding(4, 3, 4, 3);
            dtpCikisTarihi.Name = "dtpCikisTarihi";
            dtpCikisTarihi.Size = new Size(312, 30);
            dtpCikisTarihi.TabIndex = 2;
            dtpCikisTarihi.ValueChanged += dtpCikisTarihi_ValueChanged;
            // 
            // btnSeferOlustur
            // 
            btnSeferOlustur.BackColor = SystemColors.ButtonFace;
            btnSeferOlustur.Font = new Font("Times New Roman", 12F);
            btnSeferOlustur.Location = new Point(324, 259);
            btnSeferOlustur.Margin = new Padding(4, 3, 4, 3);
            btnSeferOlustur.Name = "btnSeferOlustur";
            btnSeferOlustur.Size = new Size(202, 56);
            btnSeferOlustur.TabIndex = 3;
            btnSeferOlustur.Text = "Sefer Oluştur";
            btnSeferOlustur.UseVisualStyleBackColor = false;
            btnSeferOlustur.Click += btnSeferOlustur_Click;
            // 
            // lvSeferler
            // 
            lvSeferler.Font = new Font("Times New Roman", 12F);
            lvSeferler.Location = new Point(16, 334);
            lvSeferler.Margin = new Padding(4, 3, 4, 3);
            lvSeferler.Name = "lvSeferler";
            lvSeferler.Size = new Size(1124, 340);
            lvSeferler.TabIndex = 4;
            lvSeferler.UseCompatibleStateImageBehavior = false;
            // 
            // dtpVarisTarihi
            // 
            dtpVarisTarihi.Font = new Font("Times New Roman", 12F);
            dtpVarisTarihi.Location = new Point(271, 74);
            dtpVarisTarihi.Margin = new Padding(4, 3, 4, 3);
            dtpVarisTarihi.Name = "dtpVarisTarihi";
            dtpVarisTarihi.Size = new Size(312, 30);
            dtpVarisTarihi.TabIndex = 2;
            // 
            // cmbCikisLimani
            // 
            cmbCikisLimani.Font = new Font("Times New Roman", 12F);
            cmbCikisLimani.FormattingEnabled = true;
            cmbCikisLimani.Location = new Point(271, 142);
            cmbCikisLimani.Margin = new Padding(4, 3, 4, 3);
            cmbCikisLimani.Name = "cmbCikisLimani";
            cmbCikisLimani.Size = new Size(312, 30);
            cmbCikisLimani.TabIndex = 1;
            // 
            // cmbUgradigiLiman
            // 
            cmbUgradigiLiman.Font = new Font("Times New Roman", 12F);
            cmbUgradigiLiman.FormattingEnabled = true;
            cmbUgradigiLiman.Location = new Point(271, 176);
            cmbUgradigiLiman.Margin = new Padding(4, 3, 4, 3);
            cmbUgradigiLiman.Name = "cmbUgradigiLiman";
            cmbUgradigiLiman.Size = new Size(312, 30);
            cmbUgradigiLiman.TabIndex = 1;
            // 
            // cmbVarisLimani
            // 
            cmbVarisLimani.Font = new Font("Times New Roman", 12F);
            cmbVarisLimani.FormattingEnabled = true;
            cmbVarisLimani.Location = new Point(271, 210);
            cmbVarisLimani.Margin = new Padding(4, 3, 4, 3);
            cmbVarisLimani.Name = "cmbVarisLimani";
            cmbVarisLimani.Size = new Size(312, 30);
            cmbVarisLimani.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F);
            label2.Location = new Point(65, 80);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(178, 22);
            label2.TabIndex = 0;
            label2.Text = "Limana Varış Tarihi :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F);
            label3.Location = new Point(65, 117);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 22);
            label3.TabIndex = 0;
            label3.Text = "Gemi :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F);
            label4.Location = new Point(65, 151);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(123, 22);
            label4.TabIndex = 0;
            label4.Text = "Çıkış Limanı :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F);
            label5.Location = new Point(65, 185);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(144, 22);
            label5.TabIndex = 0;
            label5.Text = "Uğradığı Liman :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F);
            label6.Location = new Point(65, 219);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(122, 22);
            label6.TabIndex = 0;
            label6.Text = "Varış Limanı :";
            // 
            // FRMSeyirEkrani
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1144, 684);
            Controls.Add(lvSeferler);
            Controls.Add(btnSeferOlustur);
            Controls.Add(dtpVarisTarihi);
            Controls.Add(dtpCikisTarihi);
            Controls.Add(cmbVarisLimani);
            Controls.Add(cmbUgradigiLiman);
            Controls.Add(cmbCikisLimani);
            Controls.Add(cmbGemi);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FRMSeyirEkrani";
            Text = "Form1";
            Load += FRMSeyirEkrani_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbGemi;
        private DateTimePicker dtpCikisTarihi;
        private Button btnSeferOlustur;
        private ListView lvSeferler;
        private DateTimePicker dtpVarisTarihi;
        private ComboBox cmbCikisLimani;
        private ComboBox cmbUgradigiLiman;
        private ComboBox cmbVarisLimani;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
