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
    public partial class RekekningView : Form
    {
        private string _idAdmin;
        private string _nasabahId;
        private RekeningController _controller = new RekeningController();

        public RekekningView(string idAdmin, string nasabahId)
        {
            _idAdmin = idAdmin;
            _nasabahId = nasabahId;
            InitializeComponent();
            InisialisasiRekeningView();
            LoadRekeningData();
        }

        public void InisialisasiRekeningView()
        {
            lvRekening.Clear(); // bersihkan kolom & item

            lvRekening.View = System.Windows.Forms.View.Details;
            lvRekening.FullRowSelect = true;
            lvRekening.GridLines = true;
            lvRekening.MultiSelect = false;
            lvRekening.HideSelection = false;

            lvRekening.Columns.Add("No. Rekening", 50, HorizontalAlignment.Center);
            lvRekening.Columns.Add("Jenis", 150, HorizontalAlignment.Left);
            lvRekening.Columns.Add("Saldo", 120, HorizontalAlignment.Center);
            lvRekening.Columns.Add("Tgl Buka", 200, HorizontalAlignment.Left);
            lvRekening.Columns.Add("Status", 120, HorizontalAlignment.Right);
        }

        private void LoadRekeningData()
        {
            var rekeningList = _controller.GetByNasabahId(_nasabahId);

            if(rekeningList.Count > 0)
            {
                lvRekening.Items.Clear();
                return;
            }

            lvRekening.Items.Clear();
            foreach (var rekening in rekeningList)
            {
                var item = new ListViewItem(rekening.NomorRekening.ToString());
                item.SubItems.Add(rekening.JenisRekening);
                item.SubItems.Add(rekening.Saldo.ToString("C"));
                item.SubItems.Add(rekening.TanggalBuka.ToShortDateString());
                item.SubItems.Add(rekening.Status);
                lvRekening.Items.Add(item);
            }
        }

        private void RekekningView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RekeningCreate nasabahCreate = new RekeningCreate(this._idAdmin, this._nasabahId);
            nasabahCreate.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            NasbahViewById nasabahViewById = new NasbahViewById(this._nasabahId, this._idAdmin);
            nasabahViewById.Show();
            this.Hide();

        }

        private void lvRekening_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRekening.SelectedItems.Count == 0)
                return;

            string idRekening = lvRekening.SelectedItems[0].SubItems[0].Text;
            RekeningViewById rekeningViewById = new RekeningViewById(idRekening, _idAdmin, _nasabahId);
            rekeningViewById.Show();
            this.Hide();
        }
    }
}
