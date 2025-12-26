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

        public int Create(Nasabah nasabah)
        {
            int result = 0;
            result = _repository.Create(nasabah);
            return result;
        }

        public List<Nasabah> GetAll()
        {
            var nasabahList = new List<Nasabah>();
            nasabahList = _repository.GetAll();
            return nasabahList;
        }

        public int Update(Nasabah nasabah)
        {
            int result = 0;
            result = _repository.Update(nasabah);
            return result;
        }

        public int Delete(Nasabah nasabah)
        {
            int result = 0;
            result = _repository.Delete(nasabah.IdNasabah);
            return result;
        }

        public Nasabah GetById(string idNasabah)
        {
            Nasabah nasabah = null;
            nasabah = _repository.GetById(idNasabah);
            return nasabah;
        }

        public List<Nasabah> GetByName(string namaNasabah)
        {
            List<Nasabah> nasabah = null;
            nasabah = _repository.SearchByName(namaNasabah);
            return nasabah;
        }
    }
}
