using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace SistemAdminBank.Model.Context
{
    public class DbContext : IDisposable
    {
        private SQLiteConnection _conn;
        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }
        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null; // deklarasi objek connection
            try // penggunaan blok try-catch untuk penanganan error
            {
                // atur ulang lokasi database yang disesuaikan dengan
                // lokasi database perpustakaan Anda
                //string dbName = @"C:\Users\LENOVO\Documents\Project\SistemAdminBankWindowsForms\SistemPerbankan.db";

                string dbName = @"D:\Project\DesktopSistemBank\SistemAdminBank\SistemPerbankan.db";
                string connectionString = string.Format("DataSource ={0}; FailIfMissing = True", dbName);
            conn = new SQLiteConnection(connectionString); 
            conn.Open(); // buka koneksi ke database
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}",
                ex.Message);
            }
            
            return conn;


        }

        public SQLiteConnection CreateConnection()
        {
            SQLiteConnection conn = null; // deklarasi objek connection
                // atur ulang lokasi database yang disesuaikan dengan
                // lokasi database perpustakaan Anda
                //string dbName = @"C:\Users\LENOVO\Documents\Project\SistemAdminBankWindowsForms\SistemPerbankan.db";

                string dbName = @"D:\Project\DesktopSistemBank\SistemAdminBank\SistemPerbankan.db";
                string connectionString = string.Format("DataSource ={0}; FailIfMissing = True", dbName);
                conn = new SQLiteConnection(connectionString);
                conn.Open(); // buka koneksi ke database
                return conn;
        }


        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
