using SistemAdminBank.Controller;
using SistemAdminBank.Model.Entity;
using SistemAdminBank.View.Rekening;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemAdminBank.View.Transaksi
{
    public partial class TransaksiView : Form
    {

        TransaksiController _controller = new TransaksiController();
        private int _rekeningId;
        private string _idAdmin;
        private int _nasabahId;
        public TransaksiView(int rekeningId, string idAdmin, int nasabahId)
        {
            InitializeComponent();
            _rekeningId = rekeningId;
            _idAdmin = idAdmin;
            _nasabahId = nasabahId;
            InialisasiListView();
            LoadDataTransaksi();
        }

        public void InialisasiListView()
        {
            lvTransaksi.View = System.Windows.Forms.View.Details;
            lvTransaksi.FullRowSelect = true;
            lvTransaksi.GridLines = true;
            lvTransaksi.Columns.Add("ID Transaksi", 100);
            lvTransaksi.Columns.Add("Jenis Transaksi", 150);
            lvTransaksi.Columns.Add("Jumlah", 100);
            lvTransaksi.Columns.Add("No. Rekening Tujuan", 150);
            lvTransaksi.Columns.Add("Tanggal Transaksi", 150);
            lvTransaksi.Columns.Add("Keterangan", 200);
        }

        public void LoadDataTransaksi()
        {
            var listTransaksi = _controller.GetByRekeningId(_rekeningId);

            lvTransaksi.Items.Clear();
            foreach (var transaksi in listTransaksi)
            {
                ListViewItem item = new ListViewItem(transaksi.IdTransaksi.ToString());
                item.SubItems.Add(transaksi.JenisTransaksi);
                item.SubItems.Add(transaksi.Jumlah.ToString("N2"));
                item.SubItems.Add(transaksi.NomorRekeningTujuan);
                item.SubItems.Add(transaksi.TanggalTransaksi.ToString("dd/MM/yyyy HH:mm:ss"));
                item.SubItems.Add(transaksi.Keterangan);
                lvTransaksi.Items.Add(item);

            }


        }

        private void TransaksiView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RekeningViewById rekeningView = new RekeningViewById(_rekeningId, _idAdmin, _nasabahId);
            rekeningView.Show();
            this.Hide();

        }
    }
}
