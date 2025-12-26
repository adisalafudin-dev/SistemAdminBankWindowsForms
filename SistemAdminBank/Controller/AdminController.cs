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
    public class AdminController
    {
        private DbContext _context;
        private readonly AdminRepository _repository;

        public AdminController()
        {
            _context = new DbContext();
            _repository = new AdminRepository(_context);
           
        }

        public int Login(AdminBank admin)
        {
            int result = 0;


            result = _repository.Login(admin.Username, admin.Password);

            return result;
        }
    }
}
