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
    public partial class NasbahViewById : Form
    {
        private int _nasabahId;
        NasabahController _controller = new NasabahController();
        public NasbahViewById(int nasabahId)
        {
            InitializeComponent();
            this._nasabahId = nasabahId;
            LoadDataNasabah();
        
        }

        private void LoadDataNasabah()
        {
           NasabahModel nasabah = _controller.GetById(_nasabahId.ToString());
          if (nasabah != null)
              {
                namaBox.Text = nasabah.Nama;
                nikBox.Text = nasabah.Nik;
                alamatBox.Text = nasabah.Alamat;
                noTelpBox.Text = nasabah.NoTelepon;
                tglDaftarPicker.Value = nasabah.TanggalDaftar;
                btnStatus.Text = nasabah.Status;
            }

          if(nasabah.Status == "ACTIVE")
            {
                dltBtn.Enabled = true;
                dltBtn.Text = "Delete Nasabah";
            }else if(nasabah.Status == "INACTIVE")
            {
                tglDaftarPicker.Enabled = true;
                dltBtn.Enabled = true;
                dltBtn.Text = "Restore Nasabah";
            }
        }

        private void NasbahViewById_Load(object sender, EventArgs e)
        {

        }

        private void dltBtn_Click(object sender, EventArgs e)
        {
            NasabahModel nasabah = _controller.GetById(_nasabahId.ToString());

            if (nasabah.Status == "ACTIVE")
            {
                _controller.Delete(_nasabahId.ToString());
            }
            else if (nasabah.Status == "INACTIVE")
            {
                _controller.Restore(_nasabahId.ToString());
            }
            LoadDataNasabah(); 
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            NasabahModel nasabah = _controller.GetById(_nasabahId.ToString());

            if (!string.IsNullOrWhiteSpace(namaBox.Text))
            {
                nasabah.Nama = namaBox.Text;
            }

            if (!string.IsNullOrWhiteSpace(nikBox.Text))
                nasabah.Nik = nikBox.Text;

            if (!string.IsNullOrWhiteSpace(alamatBox.Text))
                nasabah.Alamat = alamatBox.Text;

            if (!string.IsNullOrWhiteSpace(noTelpBox.Text))
                nasabah.NoTelepon = noTelpBox.Text;

            nasabah.TanggalDaftar = tglDaftarPicker.Value;

            int result = _controller.Update(nasabah);

            if (result > 0)
            {
                MessageBox.Show("Data nasabah berhasil diupdate", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Gagal update data nasabah", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadDataNasabah(); 
        }

        private void tglDaftarPicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
