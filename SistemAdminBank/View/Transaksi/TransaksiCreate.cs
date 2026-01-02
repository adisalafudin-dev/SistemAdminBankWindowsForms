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
    public partial class TransaksiCreate : Form
    {
        private string _idAdmin;
        private int _nasabahId;
        private int _rekeningId;

        TransaksiController _controller = new TransaksiController();

        public TransaksiCreate(string idAdmin, int nasabahId, int rekeningId)
        {
            InitializeComponent();
            _idAdmin = idAdmin;
            _nasabahId = nasabahId;
            _rekeningId = rekeningId;
        }


        private void TransaksiCreate_Load(object sender, EventArgs e)
        {
            comboBoxJenis.Items.Add("Transfer");
            comboBoxJenis.Items.Add("Setoran");
            comboBoxJenis.Items.Add("Penarikan");

            comboBoxJenis.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void transaksiBtn_Click(object sender, EventArgs e)
        {
            if (comboBoxJenis.SelectedItem == null)
            {
                MessageBox.Show("Jenis transaksi harus dipilih.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxJenis.SelectedIndex == 0)
            {
                TransaksiModel transaksi = new TransaksiModel();


                string jenisTransaksi = comboBoxJenis.SelectedItem.ToString();
                var jumlah = txtBoxJumlah.Text;
                DateTime tanggalTransaksi = dateTimePicker.Value;
                string keterangan = textBoxKet.Text;
                string rekeningTujuan = textBoxTujuan.Text;


                transaksi.Jumlah = decimal.Parse(jumlah);
                transaksi.TanggalTransaksi = tanggalTransaksi;
                transaksi.Keterangan = keterangan;
                transaksi.JenisTransaksi = jenisTransaksi;
                transaksi.RekeningId = _rekeningId;
                transaksi.AdminId = int.Parse(_idAdmin);


                _controller.CreateTransaksiTransfer(transaksi);
                MessageBox.Show("Transaksi berhasil dibuat.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            RekeningViewById rekeningViewById = new RekeningViewById(_rekeningId, _idAdmin, _nasabahId);
            rekeningViewById.Show();
            this.Close();

        }
    }
}
