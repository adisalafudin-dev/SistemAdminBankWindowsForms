using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemAdminBank.Model.Entity
{
    public class TransaksiModel
    {
        public int IdTransaksi { get; set; }
        public string JenisTransaksi { get; set; }
        public decimal Jumlah { get; set; }
        public int NomorRekeningTujuan { get; set; }
        public DateTime TanggalTransaksi { get; set;}
        public string Keterangan { get; set; }
        public int AdminId { get; set; }
        public int RekeningId { get; set; }
        public int NasabahId { get; set; }

    }
}
