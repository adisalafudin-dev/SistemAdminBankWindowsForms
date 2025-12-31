using SistemAdminBank.Controller;
using SistemAdminBank.Model.Entity;
using SistemAdminBank.View.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SistemAdminBank.View.Nasabah
{
    public partial class NasabahView : Form
    {
        private string _idAdmin;
        private NasabahController _controller = new NasabahController();
        public NasabahView(string idAdmin)
        {
            this._idAdmin = idAdmin;
            InitializeComponent();
            InitListViewNasabah();
        }

        private void InitListViewNasabah()
        {
            lvNasabah.Clear(); // bersihkan kolom & item

            lvNasabah.View = System.Windows.Forms.View.Details;
            lvNasabah.FullRowSelect = true;
            lvNasabah.GridLines = true;
            lvNasabah.MultiSelect = false;
            lvNasabah.HideSelection = false;

            lvNasabah.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvNasabah.Columns.Add("Nama", 150, HorizontalAlignment.Left);
            lvNasabah.Columns.Add("Nik", 120, HorizontalAlignment.Center);
            lvNasabah.Columns.Add("Alamat", 200, HorizontalAlignment.Left);
            lvNasabah.Columns.Add("No Telp", 120, HorizontalAlignment.Right);
            lvNasabah.Columns.Add("Tanggal Daftar", 80, HorizontalAlignment.Center);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AdminLoginView adminLoginView = new AdminLoginView();
            adminLoginView.Show();
            this.Hide();
        }

        private void LoadNasabahData()
        {
            var nasabahList = _controller.GetAll();
            lvNasabah.Items.Clear();
            foreach (var nasabah in nasabahList)
            {
                var item = new ListViewItem(nasabah.IdNasabah);
                item.SubItems.Add(nasabah.Nama);
                item.SubItems.Add(nasabah.Nik);
                item.SubItems.Add(nasabah.Alamat);
                item.SubItems.Add(nasabah.NoTelepon);
                item.SubItems.Add(nasabah.TanggalDaftar.ToString());
                lvNasabah.Items.Add(item);
            }
        }

        private void LoadSearchByName()
        {
            var searchName = searchBox.Text;
            var nasabahList = _controller.GetByName(searchName);
            lvNasabah.Items.Clear();

            if (string.IsNullOrWhiteSpace(searchName))
            {
                lvNasabah.Items.Clear();
                LoadNasabahData();
            }
            
            foreach (var nasabah in nasabahList)
            {
                var item = new ListViewItem(nasabah.IdNasabah);
                item.SubItems.Add(nasabah.Nama);
                item.SubItems.Add(nasabah.Nik);
                item.SubItems.Add(nasabah.Alamat);
                item.SubItems.Add(nasabah.NoTelepon);
                item.SubItems.Add(nasabah.TanggalDaftar.ToString());
                lvNasabah.Items.Add(item);
            }
        }


        private void NasabahView_Load(object sender, EventArgs e)
        {
            LoadNasabahData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNasabahData();
        }

        private void addNasabahBtn_Click(object sender, EventArgs e)
        {
            NasabahCreate nasabahCreate = new NasabahCreate(this._idAdmin);
            nasabahCreate.Show();
            this.Hide();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadSearchByName();
        }

        private void lvNasabah_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNasabah.SelectedItems.Count == 0) return;

            string idNasabah = lvNasabah.SelectedItems[0].Text;

            var detailForm = new NasbahViewById(
                idNasabah,
                this._idAdmin
            );

            detailForm.Show();
            this.Hide();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
