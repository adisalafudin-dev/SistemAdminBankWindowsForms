using SistemAdminBank.Controller;
using SistemAdminBank.Model.Entity;
using SistemAdminBank.View.Transaksi;
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
    public partial class RekeningViewById : Form
    {
        private string _idAdmin;
        private int _nasabahId;
        private int _rekeningId;
        private RekeningController _controller = new RekeningController();
        public RekeningViewById(int _rekeningId, string idAdmin, int nasabahId)
        {
            InitializeComponent();
            this._nasabahId = nasabahId;
            this._idAdmin = idAdmin;
            this._rekeningId = _rekeningId;
            InisialisasiRekeningViewById();
        }

        public void InisialisasiRekeningViewById()
        {
            RekeningModel rekening = _controller.GetById(_rekeningId);
            noRekBox.Text = rekening.NomorRekening.ToString();
            comboBoxJenis.SelectedItem = rekening.JenisRekening;
            saldoBox.Text = rekening.Saldo.ToString();
            dateBox.Text = rekening.TanggalBuka.ToString();
            statusBox.Text = rekening.Status;

            comboBoxJenis.ValueMember = rekening.JenisRekening;

            if (rekening.Status == "CLOSED")
            {
                comboBoxJenis.Enabled = false;
                saldoBox.Enabled = false;
                dateBox.Enabled = false;
                statusBox.Enabled = false;
                updtBtn.Enabled = false;
                dltBtn.Enabled = true;
                dltBtn.Text = "Restore";
            }

            else if (rekening.Status == "ACTIVE")
            {
                comboBoxJenis.Enabled = true;
                saldoBox.Enabled = true;
                dateBox.Enabled = true;
                statusBox.Enabled = true;
                updtBtn.Enabled = true;
                dltBtn.Enabled = true;
                dltBtn.Text = "Delete";
            }

            }

        private void RekeningViewById_Load(object sender, EventArgs e)
        {
            comboBoxJenis.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxJenis.DisplayMember = "Text";
            comboBoxJenis.ValueMember = "Value";

            comboBoxJenis.Items.Add("Tabungan");
            comboBoxJenis.Items.Add("Giro");
            comboBoxJenis.Items.Add("Deposito");



        }

        private void updtBtn_Click(object sender, EventArgs e)
        {
            RekeningModel newRekening = new RekeningModel
            {
                JenisRekening = comboBoxJenis.SelectedItem.ToString(),
                Saldo = decimal.Parse(saldoBox.Text),
                TanggalBuka = DateTime.Parse(dateBox.Text),
                Status = statusBox.Text
            };

            string noRekening = noRekBox.Text;

            int result = _controller.UpdateRekening(noRekening, newRekening);
            if (result > 0)
            {
                MessageBox.Show("Rekening berhasil diupdate", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                RekekningView rekeningView = new RekekningView(_idAdmin, _nasabahId);
                rekeningView.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Gagal mengupdate rekening", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            RekekningView rekeningView = new RekekningView(_idAdmin, _nasabahId);
            rekeningView.Show();
            this.Hide();
        }

        private void dltBtn_Click(object sender, EventArgs e)
        {
            RekeningModel rekening = _controller.GetById(_rekeningId);

            if (rekening.Status == "ACTIVE")
            {
                int result = _controller.CloseRekening(rekening.NomorRekening);
                if (result > 0)
                {
                    MessageBox.Show("Rekening berhasil dihapus", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RekekningView rekeningView = new RekekningView(_idAdmin, _nasabahId);
                    rekeningView.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus rekening", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rekening.Status == "CLOSED")
            {
                int result = _controller.RestoreRekening(rekening.NomorRekening);
                if (result > 0)
                {
                    MessageBox.Show("Rekening berhasil direstore", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RekekningView rekeningView = new RekekningView(_idAdmin, _nasabahId);
                    rekeningView.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Gagal merestore rekening", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            TransaksiCreate transaksiCreate = new TransaksiCreate(_idAdmin, _nasabahId, _rekeningId);
            transaksiCreate.Show();
            this.Hide();

        }
    }
}
