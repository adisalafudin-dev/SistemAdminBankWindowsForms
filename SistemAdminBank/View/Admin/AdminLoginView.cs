using SistemAdminBank.Controller;
using SistemAdminBank.Model.Entity;
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

namespace SistemAdminBank.View.Admin
{
    public partial class AdminLoginView : Form
    {
        public AdminLoginView()
        {
            InitializeComponent();
        }

        private AdminController _adminController = new AdminController();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AdminBank requestAdmin = new AdminBank
            {
                Username = boxUsername.Text,
                Password = boxPassword.Text
            };
            int result = _adminController.Login(requestAdmin);

            if (result > 0)
            {
                MessageBox.Show(
                    "Login berhasil!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                NasabahView nasabahView = new NasabahView(requestAdmin.IdAdmin);
                nasabahView.Show();
                this.Hide();
            }
            else if (result == -2)
            {
                MessageBox.Show(
                    "Username dan Password wajib diisi!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show(
                    "Username atau Password salah!",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AdminLoginView_Load(object sender, EventArgs e)
        {

        }
    }
}
