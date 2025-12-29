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
    public partial class RekeningViewById : Form
    {
        private string _idAdmin;
        private int _nasabahId;
        private string _rekeningId;
        private RekeningController _controller = new RekeningController();
        public RekeningViewById(string _rekeningId, string idAdmin, int nasabahId)
        {
            this._nasabahId = nasabahId;
            this._idAdmin = idAdmin;
            this._rekeningId = _rekeningId;
            InisialisasiRekeningViewById();
            InitializeComponent();
        }

        public void InisialisasiRekeningViewById()
        {
            RekeningModel rekening = _controller.GetById(int.Parse(_rekeningId));
            noRekBox.Text = rekening.NomorRekening.ToString();
            jenisBox.Text = rekening.JenisRekening;
            saldoBox.Text = rekening.Saldo.ToString();
            dateBox.Text = rekening.TanggalBuka.ToString();
            statusBox.Text = rekening.Status;

            if (rekening.Status == "CLOSED")
            {
                jenisBox.Enabled = false;
                saldoBox.Enabled = false;
                dateBox.Enabled = false;
                statusBox.Enabled = false;
                updtBtn.Enabled = false;
                dltBtn.Enabled = true;
                dltBtn.Text = "Restore";
            }

            else if (rekening.Status == "ACTIVE")
            {
                jenisBox.Enabled = true;
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

        }

        private void updtBtn_Click(object sender, EventArgs e)
        {
            RekeningModel newRekening = new RekeningModel
            {
                JenisRekening = jenisBox.Text,
                Saldo = decimal.Parse(saldoBox.Text),
                TanggalBuka = DateTime.Parse(dateBox.Text),
                Status = statusBox.Text
            };

            int result = _controller.UpdateRekening(int.Parse(_rekeningId), newRekening);
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
            RekeningModel rekening = _controller.GetById(int.Parse(_rekeningId));

            if (rekening.Status == "ACTIVE")
            {
                int result = _controller.CloseRekening(int.Parse(_rekeningId));
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
                int result = _controller.RestoreRekening(int.Parse(_rekeningId));
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
    }
}
