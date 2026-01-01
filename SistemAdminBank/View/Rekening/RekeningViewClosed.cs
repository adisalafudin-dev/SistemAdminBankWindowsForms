using SistemAdminBank.Controller;
using SistemAdminBank.View.Nasabah;
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
    public partial class RekeningViewClosed : Form
    {

        private string _idAdmin;
        private int _nasabahId;
        private RekeningController _controller = new RekeningController();
        public RekeningViewClosed(string _idAdmin, int _nasabahId)
        {
            InitializeComponent();
            this._idAdmin = _idAdmin;
            this._nasabahId = _nasabahId;
            InisialisasiRekeningViewClosed();
            LoadRekeningData();
        }

        public void InisialisasiRekeningViewClosed()
        {
            lvRekening.Clear(); // bersihkan kolom & item
            lvRekening.View = System.Windows.Forms.View.Details;
            lvRekening.FullRowSelect = true;
            lvRekening.GridLines = true;
            lvRekening.MultiSelect = false;
            lvRekening.HideSelection = false;
            lvRekening.Columns.Add("No.", 50, HorizontalAlignment.Center);
            lvRekening.Columns.Add("No. Rekening", 50, HorizontalAlignment.Center);
            lvRekening.Columns.Add("Jenis", 150, HorizontalAlignment.Left);
            lvRekening.Columns.Add("Saldo", 120, HorizontalAlignment.Center);
            lvRekening.Columns.Add("Tgl Buka", 200, HorizontalAlignment.Left);
            lvRekening.Columns.Add("Status", 120, HorizontalAlignment.Right);
        }

        private void lvRekening_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Validasi: Pastikan ada item yang dipilih
                if (lvRekening.SelectedItems.Count == 0)
                    return;

                // Ambil nomor rekening dari kolom pertama
                var idRekening = Convert.ToInt32(lvRekening.SelectedItems[0].Text);



                // Buka form RekeningViewById
                RekeningViewById rekeningViewById = new RekeningViewById(idRekening, _idAdmin, _nasabahId);
                rekeningViewById.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            NasbahViewById nasabahViewById = new NasbahViewById(this._nasabahId, this._idAdmin);
            nasabahViewById.Show();
            this.Hide();
        }

        private void LoadRekeningData()
        {
            var rekeningList = _controller.GetByNasabahIdClosed(_nasabahId);

            lvRekening.Items.Clear();
            foreach (var rekening in rekeningList)
            {
                var item = new ListViewItem(rekening.RekeningId.ToString());
                item.SubItems.Add(rekening.NomorRekening);
                item.SubItems.Add(rekening.JenisRekening);
                item.SubItems.Add(rekening.Saldo.ToString(""));
                item.SubItems.Add(rekening.TanggalBuka.ToShortDateString());
                item.SubItems.Add(rekening.Status);
                lvRekening.Items.Add(item);
            }
        }
    }
}
