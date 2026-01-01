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

namespace SistemAdminBank.View.Nasabah
{
    public partial class NasbahViewById : Form
    {
        private int _nasabahId;
        private string _idAdmin; 
        NasabahController _controller = new NasabahController();
        public NasbahViewById(int nasabahId, string idAdmin)
        {
            InitializeComponent();
            if (int.Equals(nasabahId, ""))
            {
                MessageBox.Show("ID Nasabah tidak valid!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Initialize fields
            this._nasabahId = nasabahId;
            this._idAdmin = idAdmin;

            // ← PENTING: Initialize controller!
            this._controller = new NasabahController();
            LoadDataNasabah();


        }

        private void LoadDataNasabah()
        {
            try
            {
                // Debug log
                System.Diagnostics.Debug.WriteLine($"Loading data for Nasabah ID: {_nasabahId}");

                // Line 42: Cek controller tidak null
                if (_controller == null)
                {
                    MessageBox.Show("Controller tidak terinisialisasi!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Ambil data dari database
                var nasabah = _controller.GetById(_nasabahId);

                // Cek apakah data ditemukan
                if (nasabah == null)
                {
                    MessageBox.Show($"Data nasabah dengan ID '{_nasabahId}' tidak ditemukan!",
                                    "Data Tidak Ditemukan",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                namaBox.Text = nasabah.Nama;
                nikBox.Text = nasabah.Nik;
                btnStatus.Text = nasabah.Status == "ACTIVE" ? "Active" : "Inactive";
                alamatBox.Text = nasabah.Alamat;
                noTelpBox.Text = nasabah.NoTelepon;
                tglDaftarPicker.Value = nasabah.TanggalDaftar;
                dltBtn.Text = nasabah.Status == "ACTIVE" ? "Delete" : "Restore";


                // Debug: Cek data yang diterima
                System.Diagnostics.Debug.WriteLine($"Nasabah found: {nasabah.Nama}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data nasabah:\n\n{ex.Message}\n\n{ex.StackTrace}",
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"LoadDataNasabah Error: {ex.Message}\n{ex.StackTrace}");
                this.Close();
            }
        }

        private void NasbahViewById_Load(object sender, EventArgs e)
        {

        }

        private void dltBtn_Click(object sender, EventArgs e)
        {
            NasabahModel nasabah = _controller.GetById(_nasabahId);

            if (nasabah.Status == "ACTIVE")
            {
                _controller.Delete(_nasabahId.ToString());
         

                MessageBox.Show("Data nasabah berhasil dihapus", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            if (nasabah.Status == "INACTIVE")
            {
                _controller.Restore(_nasabahId.ToString());
                MessageBox.Show("Data nasabah berhasil dikembalikan", "Success",

    
                MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }
            LoadDataNasabah(); 
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            NasabahModel nasabah = _controller.GetById(_nasabahId);

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

        private void backBtn_Click(object sender, EventArgs e)
        {
            NasabahView view = new NasabahView(_idAdmin);
            view.Show();
            this.Hide();
        }

        private void cekRekBtn_Click(object sender, EventArgs e)
        {
            RekekningView rekekningView = new RekekningView(_idAdmin, _nasabahId);
            rekekningView.Show();
            this.Hide();

        }
    }
}
