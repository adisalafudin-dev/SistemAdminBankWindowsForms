namespace SistemAdminBank.View.Rekening
{
    partial class RekekningView
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
            this.lvRekening = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClosedRek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvRekening
            // 
            this.lvRekening.HideSelection = false;
            this.lvRekening.Location = new System.Drawing.Point(12, 54);
            this.lvRekening.Name = "lvRekening";
            this.lvRekening.Size = new System.Drawing.Size(776, 355);
            this.lvRekening.TabIndex = 0;
            this.lvRekening.UseCompatibleStateImageBehavior = false;
            this.lvRekening.SelectedIndexChanged += new System.EventHandler(this.lvRekening_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(649, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buat Rekening";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 415);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(139, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Kembali";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClosedRek
            // 
            this.btnClosedRek.Location = new System.Drawing.Point(12, 25);
            this.btnClosedRek.Name = "btnClosedRek";
            this.btnClosedRek.Size = new System.Drawing.Size(139, 23);
            this.btnClosedRek.TabIndex = 3;
            this.btnClosedRek.Text = "Closed Rekening";
            this.btnClosedRek.UseVisualStyleBackColor = true;
            this.btnClosedRek.Click += new System.EventHandler(this.btnClosedRek_Click);
            // 
            // RekekningView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClosedRek);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvRekening);
            this.Name = "RekekningView";
            this.Text = "RekekningView";
            this.Load += new System.EventHandler(this.RekekningView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRekening;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClosedRek;
    }
}