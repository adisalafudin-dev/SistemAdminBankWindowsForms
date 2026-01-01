namespace SistemAdminBank.View.Rekening
{
    partial class RekeningViewById
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
            this.noRekBox = new System.Windows.Forms.TextBox();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.saldoBox = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.updtBtn = new System.Windows.Forms.Button();
            this.dltBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.btnTransaksi = new System.Windows.Forms.Button();
            this.comboBoxJenis = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // noRekBox
            // 
            this.noRekBox.Location = new System.Drawing.Point(200, 78);
            this.noRekBox.Name = "noRekBox";
            this.noRekBox.ReadOnly = true;
            this.noRekBox.Size = new System.Drawing.Size(424, 20);
            this.noRekBox.TabIndex = 0;
            // 
            // statusBox
            // 
            this.statusBox.Enabled = false;
            this.statusBox.Location = new System.Drawing.Point(200, 151);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(186, 20);
            this.statusBox.TabIndex = 2;
            // 
            // saldoBox
            // 
            this.saldoBox.Location = new System.Drawing.Point(438, 114);
            this.saldoBox.Name = "saldoBox";
            this.saldoBox.Size = new System.Drawing.Size(186, 20);
            this.saldoBox.TabIndex = 6;
            // 
            // dateBox
            // 
            this.dateBox.Enabled = false;
            this.dateBox.Location = new System.Drawing.Point(200, 194);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(424, 20);
            this.dateBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "No. Rek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Jenis Rek";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Saldo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tgl Buka";
            // 
            // updtBtn
            // 
            this.updtBtn.Location = new System.Drawing.Point(549, 309);
            this.updtBtn.Name = "updtBtn";
            this.updtBtn.Size = new System.Drawing.Size(75, 23);
            this.updtBtn.TabIndex = 13;
            this.updtBtn.Text = "Update";
            this.updtBtn.UseVisualStyleBackColor = true;
            this.updtBtn.Click += new System.EventHandler(this.updtBtn_Click);
            // 
            // dltBtn
            // 
            this.dltBtn.Location = new System.Drawing.Point(468, 309);
            this.dltBtn.Name = "dltBtn";
            this.dltBtn.Size = new System.Drawing.Size(75, 23);
            this.dltBtn.TabIndex = 14;
            this.dltBtn.Text = "Delete";
            this.dltBtn.UseVisualStyleBackColor = true;
            this.dltBtn.Click += new System.EventHandler(this.dltBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(143, 309);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.Location = new System.Drawing.Point(468, 35);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(156, 23);
            this.btnTransaksi.TabIndex = 16;
            this.btnTransaksi.Text = "Buat Transaksi";
            this.btnTransaksi.UseVisualStyleBackColor = true;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // comboBoxJenis
            // 
            this.comboBoxJenis.FormattingEnabled = true;
            this.comboBoxJenis.Location = new System.Drawing.Point(201, 112);
            this.comboBoxJenis.Name = "comboBoxJenis";
            this.comboBoxJenis.Size = new System.Drawing.Size(185, 21);
            this.comboBoxJenis.TabIndex = 17;
            // 
            // RekeningViewById
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxJenis);
            this.Controls.Add(this.btnTransaksi);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.dltBtn);
            this.Controls.Add(this.updtBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.saldoBox);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.noRekBox);
            this.Name = "RekeningViewById";
            this.Text = "RekeningViewById";
            this.Load += new System.EventHandler(this.RekeningViewById_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox noRekBox;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.TextBox saldoBox;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button updtBtn;
        private System.Windows.Forms.Button dltBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button btnTransaksi;
        private System.Windows.Forms.ComboBox comboBoxJenis;
    }
}