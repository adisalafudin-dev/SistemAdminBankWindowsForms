namespace SistemAdminBank.View.Transaksi
{
    partial class TransaksiCreate
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
            this.comboBoxJenis = new System.Windows.Forms.ComboBox();
            this.txtBoxJumlah = new System.Windows.Forms.TextBox();
            this.textBoxTujuan = new System.Windows.Forms.TextBox();
            this.textBoxKet = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.transaksiBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxJenis
            // 
            this.comboBoxJenis.FormattingEnabled = true;
            this.comboBoxJenis.Location = new System.Drawing.Point(221, 71);
            this.comboBoxJenis.Name = "comboBoxJenis";
            this.comboBoxJenis.Size = new System.Drawing.Size(304, 21);
            this.comboBoxJenis.TabIndex = 0;
            // 
            // txtBoxJumlah
            // 
            this.txtBoxJumlah.Location = new System.Drawing.Point(221, 110);
            this.txtBoxJumlah.Name = "txtBoxJumlah";
            this.txtBoxJumlah.Size = new System.Drawing.Size(304, 20);
            this.txtBoxJumlah.TabIndex = 1;
            // 
            // textBoxTujuan
            // 
            this.textBoxTujuan.Location = new System.Drawing.Point(221, 151);
            this.textBoxTujuan.Name = "textBoxTujuan";
            this.textBoxTujuan.Size = new System.Drawing.Size(304, 20);
            this.textBoxTujuan.TabIndex = 2;
            // 
            // textBoxKet
            // 
            this.textBoxKet.Location = new System.Drawing.Point(221, 235);
            this.textBoxKet.Name = "textBoxKet";
            this.textBoxKet.Size = new System.Drawing.Size(304, 20);
            this.textBoxKet.TabIndex = 4;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(221, 194);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(304, 20);
            this.dateTimePicker.TabIndex = 6;
            // 
            // transaksiBtn
            // 
            this.transaksiBtn.Location = new System.Drawing.Point(556, 341);
            this.transaksiBtn.Name = "transaksiBtn";
            this.transaksiBtn.Size = new System.Drawing.Size(75, 23);
            this.transaksiBtn.TabIndex = 7;
            this.transaksiBtn.Text = "Transaksi";
            this.transaksiBtn.UseVisualStyleBackColor = true;
            this.transaksiBtn.Click += new System.EventHandler(this.transaksiBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(138, 341);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 8;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Jenis Transaksi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Jumlah";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Rek. Tujuan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tgl Transaksi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Keterangan";
            // 
            // TransaksiCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.transaksiBtn);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.textBoxKet);
            this.Controls.Add(this.textBoxTujuan);
            this.Controls.Add(this.txtBoxJumlah);
            this.Controls.Add(this.comboBoxJenis);
            this.Name = "TransaksiCreate";
            this.Text = "TransaksiCreate";
            this.Load += new System.EventHandler(this.TransaksiCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxJenis;
        private System.Windows.Forms.TextBox txtBoxJumlah;
        private System.Windows.Forms.TextBox textBoxTujuan;
        private System.Windows.Forms.TextBox textBoxKet;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button transaksiBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}