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

        public RekeningController()
        {
            _context = new DbContext();
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

        public List<RekeningModel> GetByNasabahId(int nasabahId)
        {
            return _repository.GetByNasabahId(nasabahId);
        }

        public List<RekeningModel> GetByNasabahIdClosed(int nasabahId)
        {
            return _repository.GetByNasabahIdClosed(nasabahId);
        }

        public int UpdateRekening(string noRek, RekeningModel rekening)
        {
            if (rekening == null)
                return 0;

            return _repository.Update(noRek, rekening);
        }

        public int CloseRekening(string noRek)
        {
            return _repository.CloseRekening(noRek);
        }

        public int RestoreRekening(string noRek)
        {
            return _repository.RestoreRekening(noRek);
        }

        public string GenerateNomorRekening()
        {
            return _repository.GenerateNomorRekening();
        }
    }

}



