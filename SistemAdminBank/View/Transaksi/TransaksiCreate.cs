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

        public TransaksiCreate(string idAdmin, int nasabahId, int rekeningId)
        {
            InitializeComponent();
            _idAdmin = idAdmin;
            _nasabahId = nasabahId;
            _rekeningId = rekeningId;
        }


        private void TransaksiCreate_Load(object sender, EventArgs e)
        {

        }

        private void transaksiBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
