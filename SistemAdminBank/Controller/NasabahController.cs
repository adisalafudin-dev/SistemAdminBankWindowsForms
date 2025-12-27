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
    public class NasabahController
    {
        private DbContext _context;
        private readonly NasabahRepository _repository;

        public NasabahController()
        {
            _context = new DbContext();
            _repository = new NasabahRepository(_context);
        }

        public int Create(NasabahModel nasabah)
        {
            int result = 0;
            result = _repository.Create(nasabah);
            return result;
        }

        public List<NasabahModel> GetAll()
        {
            var nasabahList = new List<NasabahModel>();
            nasabahList = _repository.GetAll();
            return nasabahList;
        }

        public int Update(NasabahModel nasabah)
        {
            int result = 0;
            result = _repository.Update(nasabah);
            return result;
        }

        public int Delete(string IdNasabah)
        {
            int result = 0;
            result = _repository.Delete(IdNasabah);
            return result;
        }

        public int Restore(string IdNasabah)
        {
            int result = 0;
            result = _repository.Restore(IdNasabah);
            return result;
        }

        public NasabahModel GetById(string idNasabah)
        {
            NasabahModel nasabah = null;
            nasabah = _repository.GetById(idNasabah);
            return nasabah;
        }

        public List<NasabahModel> GetByName(string namaNasabah)
        {
            List<NasabahModel> nasabah = null;
            nasabah = _repository.SearchByName(namaNasabah);
            return nasabah;
        }
    }
}
