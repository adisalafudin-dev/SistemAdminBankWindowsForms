namespace SistemAdminBank.View.Nasabah
{
    partial class NasabahCreate
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
            this.namaBox = new System.Windows.Forms.TextBox();
            this.nikBox = new System.Windows.Forms.TextBox();
            this.alamatBox = new System.Windows.Forms.TextBox();
            this.noTelpBox = new System.Windows.Forms.TextBox();
            this.tglDaftarPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addNasabahBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namaBox
            // 
            this.namaBox.Location = new System.Drawing.Point(150, 94);
            this.namaBox.Name = "namaBox";
            this.namaBox.Size = new System.Drawing.Size(237, 20);
            this.namaBox.TabIndex = 0;
            // 
            // nikBox
            // 
            this.nikBox.Location = new System.Drawing.Point(404, 94);
            this.nikBox.Name = "nikBox";
            this.nikBox.Size = new System.Drawing.Size(228, 20);
            this.nikBox.TabIndex = 1;
            // 
            // alamatBox
            // 
            this.alamatBox.Location = new System.Drawing.Point(150, 144);
            this.alamatBox.Name = "alamatBox";
            this.alamatBox.Size = new System.Drawing.Size(237, 20);
            this.alamatBox.TabIndex = 2;
            // 
            // noTelpBox
            // 
            this.noTelpBox.Location = new System.Drawing.Point(404, 144);
            this.noTelpBox.Name = "noTelpBox";
            this.noTelpBox.Size = new System.Drawing.Size(228, 20);
            this.noTelpBox.TabIndex = 4;
            // 
            // tglDaftarPicker
            // 
            this.tglDaftarPicker.Location = new System.Drawing.Point(150, 215);
            this.tglDaftarPicker.Name = "tglDaftarPicker";
            this.tglDaftarPicker.Size = new System.Drawing.Size(482, 20);
            this.tglDaftarPicker.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nama Lengkap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "NIK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Alamat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "No. Telp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tanggal Daftar";
            // 
            // addNasabahBtn
            // 
            this.addNasabahBtn.Location = new System.Drawing.Point(557, 321);
            this.addNasabahBtn.Name = "addNasabahBtn";
            this.addNasabahBtn.Size = new System.Drawing.Size(75, 23);
            this.addNasabahBtn.TabIndex = 11;
            this.addNasabahBtn.Text = "Tambah";
            this.addNasabahBtn.UseVisualStyleBackColor = true;
            this.addNasabahBtn.Click += new System.EventHandler(this.addNasabahBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NasabahCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addNasabahBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tglDaftarPicker);
            this.Controls.Add(this.noTelpBox);
            this.Controls.Add(this.alamatBox);
            this.Controls.Add(this.nikBox);
            this.Controls.Add(this.namaBox);
            this.Name = "NasabahCreate";
            this.Text = "NasabahCreate";
            this.Load += new System.EventHandler(this.NasabahCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox namaBox;
        private System.Windows.Forms.TextBox nikBox;
        private System.Windows.Forms.TextBox alamatBox;
        private System.Windows.Forms.TextBox noTelpBox;
        private System.Windows.Forms.DateTimePicker tglDaftarPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addNasabahBtn;
        private System.Windows.Forms.Button button1;
    }
}