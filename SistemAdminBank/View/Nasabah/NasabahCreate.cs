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

namespace SistemAdminBank.View.Nasabah
{
    public partial class NasabahCreate : Form
    {
   
        private string _idAdmin;
        private NasabahController _controller = new NasabahController();
        public NasabahCreate(string idAdmin)
        {
            this._idAdmin = idAdmin;
            InitializeComponent();
        }

        private void addNasabahBtn_Click(object sender, EventArgs e)
        {
            var nama = namaBox.Text;
            var nik = nikBox.Text;
            var alamat = alamatBox.Text;
            var noTelp = noTelpBox.Text;
            var tglDaftar = tglDaftarPicker.Value;

            NasabahModel nasabah = new NasabahModel
            {
                Nama = nama,
                Nik = nik,
                Alamat = alamat,
                NoTelepon = noTelp,
                TanggalDaftar = tglDaftar
            };

            var result = _controller.Create(nasabah);

            if (result == 1)
            {
                MessageBox.Show(
                    "Nasabah berhasil ditambahkan!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                NasabahView nasabahView2 = new NasabahView(this._idAdmin);
                nasabahView2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Gagal menambahkan nasabah!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NasabahView nasabahView = new NasabahView(this._idAdmin);
            nasabahView.Show();
            this.Hide();
        }

        private void NasabahCreate_Load(object sender, EventArgs e)
        {

        }
    }
}
