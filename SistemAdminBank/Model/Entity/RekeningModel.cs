using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemAdminBank.Model.Entity
{
    public class RekeningModel
    {
        public int RekeningId { get; set; }
        public string NomorRekening { get; set; }
        public string IdNasabah { get; set; }
        public decimal Saldo { get; set; }
        public string JenisRekening { get; set; }
        public DateTime TanggalBuka { get; set; }
        public string Status { get; set; }
    }
}
