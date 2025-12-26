using SistemAdminBank.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemAdminBank.Model.Repository
{
    public class AdminRepository
    {
        private SQLiteConnection _conn;

        public AdminRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public  int Login(string username, string password)
        {
            int adminId = -1;
            using (var cmd = new SQLiteCommand(_conn))
            {
                cmd.CommandText = "SELECT Id FROM admin WHERE username = @username AND password = @password";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    adminId = Convert.ToInt32(result);
                }
            }
   
            return adminId;
        }

    }
}
