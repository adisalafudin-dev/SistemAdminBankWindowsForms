using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemAdminBank.Model.Entity
{
    public class NasabahModel
    {
        public string IdNasabah { get; set; }
        public string Nama { get; set; }
        public string Nik { get; set; }
        public string Alamat { get; set; }
        public string NoTelepon { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime TanggalDaftar { get; set; }
    }
}
