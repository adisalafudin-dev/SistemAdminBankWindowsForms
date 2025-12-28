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
    public class RekeningController
    {
        private DbContext _context;
        private RekeningRepository _repository;

        public RekeningController(DbContext context)
        {
            _context = context;
            _repository = new RekeningRepository(_context);
        }

        public int CreateRekening(RekeningModel rekening)
        {
            if (rekening == null)
                return 0;

            if (string.IsNullOrWhiteSpace(rekening.NomorRekening))
                return 0;

            return _repository.CreateRekening(rekening);
        }


        public RekeningModel GetById(int rekeningId)
        {
            return _repository.GetById(rekeningId);
        }

        public RekeningModel GetByNomorRekening(int noRek)
        {
            return _repository.GetByNomorRek(noRek);
        }

        public List<RekeningModel> GetByNasabahId(int nasabahId)
        {
            return _repository.GetByNasabahId(nasabahId);
        }

        public int UpdateRekening(int rekeningId, RekeningModel rekening)
        {
            if (rekening == null)
                return 0;

            return _repository.Update(rekeningId, rekening);
        }

        public int CloseRekening(int noRek)
        {
            return _repository.CloseRekening(noRek);
        }

        public int RestoreRekening(int noRek)
        {
            return _repository.RestoreRekening(noRek);
        }
    }


}
}
