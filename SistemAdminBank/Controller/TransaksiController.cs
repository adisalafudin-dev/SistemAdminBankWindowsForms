using SistemAdminBank.Model.Context;
using SistemAdminBank.Model.Entity;
using SistemAdminBank.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemAdminBank.Controller
{
    public class TransaksiController
    {
        private DbContext _context;
        private TransaksiRepository _repository;
        private RekeningController _rekeningController;

        public TransaksiController()
        {
            _context = new DbContext();
            _repository = new TransaksiRepository(_context);
        }

        public int CreateTransaksiTransfer(TransaksiModel transaksi)
        {
            if (transaksi == null)
                return 0;
            if (string.IsNullOrWhiteSpace(transaksi.JenisTransaksi))
                return 0;
            var rekeningAsal = _rekeningController.GetById(transaksi.RekeningId);

            bool saldoCukup = _repository.ValidasiSaldoCukup(rekeningAsal.NomorRekening, transaksi.Jumlah);

            if (!saldoCukup)
            {
                return 0;
            }

            return _repository.CreateTransaksiTransfer(transaksi, rekeningAsal.NomorRekening);
        }

        public int CreateTransaksiSetor(TransaksiModel transaksi)
        {
            if (transaksi == null)
                return 0;
            if (string.IsNullOrWhiteSpace(transaksi.JenisTransaksi))
                return 0;
            return _repository.CreateTransaksiSetorTunai(transaksi);

        }

        public int CreateTransaksiTarik(TransaksiModel transaksi)
        {
            if (transaksi == null)
                return 0;
            if (string.IsNullOrWhiteSpace(transaksi.JenisTransaksi))
                return 0;
            var rekeningAsal = _rekeningController.GetById(transaksi.RekeningId);
            bool saldoCukup = _repository.ValidasiSaldoCukup(rekeningAsal.NomorRekening, transaksi.Jumlah);
            if (!saldoCukup)
            {
                return 0;
            }
            return _repository.CreateTransaksiTarikTunai(transaksi);
        }

        public List<TransaksiModel> GetByRekeningId(int rekeningId)
        {
            return _repository.GetAllTransaksi(rekeningId);
        }
    }
}
