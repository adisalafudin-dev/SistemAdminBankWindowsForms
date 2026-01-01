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
        private int _nasabahId;
        private RekeningController _controller = new RekeningController();

        public RekeningCreate(string idAdmin, int nasabahId)
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

            if (jenisComboBox.SelectedItem == null)
            {
                MessageBox.Show("Silakan pilih jenis rekening!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(saldoTextBox.Text) || !decimal.TryParse(saldoTextBox.Text, out _))
            {
                MessageBox.Show("Silakan masukkan saldo awal yang valid!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


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
            jenisComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            jenisComboBox.DisplayMember = "Text";
            jenisComboBox.ValueMember = "Value";

            jenisComboBox.Items.Add("Tabungan");
            jenisComboBox.Items.Add("Giro");
            jenisComboBox.Items.Add("Deposito");    

            jenisComboBox.SelectedIndex = 0;

            jenisComboBox.SelectedIndex = 0;
            string noRekening = _controller.GenerateNomorRekening();
            noRekBox.Text = noRekening;
            noRekBox.Enabled = false;

        }
    }
}
