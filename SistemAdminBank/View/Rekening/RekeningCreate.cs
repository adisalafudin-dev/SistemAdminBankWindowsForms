using SistemAdminBank.Controller;
using SistemAdminBank.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemAdminBank.View.Rekening
{
    public partial class RekeningCreate : Form
    {
        private string _idAdmin;
        private string _nasabahId;
        private RekeningController _controller = new RekeningController();

        public RekeningCreate(string idAdmin, string nasabahId)
        { 
            this._idAdmin = idAdmin;
            this._nasabahId = nasabahId;
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void createBtn_Click(object sender, EventArgs e)
        {
            string noRekening = _controller.GenerateNomorRekening();
            RekeningModel rekening = new RekeningModel
            {
                NomorRekening = noRekening,
                IdNasabah = _nasabahId,
                JenisRekening = jenisComboBox.SelectedItem.ToString(),
                Saldo = decimal.Parse(saldoTextBox.Text),
                TanggalBuka = dateTimeTglBuka.Value,
                Status = "ACTIVE"
            };

            int result = _controller.CreateRekening(rekening);
            if (result > 0)
            {
                MessageBox.Show("Rekening berhasil dibuat", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                var rekeningView = new RekekningView(_idAdmin, _nasabahId);
                rekeningView.Show();
            }
            else
            {
                MessageBox.Show("Gagal membuat rekening", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RekekningView rekeningView = new RekekningView(_idAdmin, _nasabahId);
            rekeningView.Show();
            this.Hide();
        }

        private void RekeningCreate_Load(object sender, EventArgs e)
        {

            string noRekening = _controller.GenerateNomorRekening();
            noRekBox.Text = noRekening;
            noRekBox.Enabled = false;

        }
    }
}
