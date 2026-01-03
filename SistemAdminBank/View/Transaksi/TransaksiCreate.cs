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
        RekeningController _rekeningController = new RekeningController();

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
                MessageBox.Show("Jenis transaksi harus dipilih.");
                return;
            }

            if (!decimal.TryParse(txtBoxJumlah.Text, out decimal jumlah))
            {
                MessageBox.Show("Jumlah tidak valid.");
                return;
            }

            TransaksiModel transaksi = new TransaksiModel
            {
                JenisTransaksi = comboBoxJenis.SelectedItem.ToString(),
                Jumlah = jumlah,
                TanggalTransaksi = dateTimePicker.Value,
                Keterangan = textBoxKet.Text,
                RekeningId = _rekeningId,
                NomorRekeningTujuan = textBoxTujuan.Text
            };

            switch (comboBoxJenis.SelectedIndex)
            {
                case 0:
                    _controller.CreateTransaksiTransfer(transaksi);
                    break;
                case 1:
                    _controller.CreateTransaksiSetor(transaksi);
                    break;
                case 2:
                    _controller.CreateTransaksiTarik(transaksi);
                    break;
            }

            MessageBox.Show("Transaksi berhasil dibuat.");
        }


        private void backBtn_Click(object sender, EventArgs e)
        {
            RekeningViewById rekeningViewById = new RekeningViewById(_rekeningId, _idAdmin, _nasabahId);
            rekeningViewById.Show();
            this.Close();

        }

        private void textBoxTujuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxJenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxJenis.SelectedIndex == 0) 
            {
                textBoxTujuan.Text = "";
                textBoxTujuan.Enabled = true;
            }
            else 
            {
                RekeningModel rekening = _rekeningController.GetById(_rekeningId);
                textBoxTujuan.Text = rekening.NomorRekening;
                textBoxTujuan.Enabled = false;
            }
        }
    }
}
