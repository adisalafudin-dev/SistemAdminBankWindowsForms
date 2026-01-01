using SistemAdminBank.Model.Context;
using SistemAdminBank.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemAdminBank.Model.Repository
{
    public class NasabahRepository
    {
        private SQLiteConnection _conn;

        public NasabahRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(NasabahModel nasabah)
        {
            int result = 0;
            if (_conn.State != ConnectionState.Open)
                _conn.Open();


            string sql = @"INSERT INTO nasabah 
    (nama_lengkap, nik, alamat, no_telp, tanggal_daftar)
    VALUES (@Nama, @Nik, @Alamat, @NoTelepon, @TanggalDaftar)";

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Nama", nasabah.Nama);
                cmd.Parameters.AddWithValue("@Nik", nasabah.Nik);
                cmd.Parameters.AddWithValue("@Alamat", nasabah.Alamat);
                cmd.Parameters.AddWithValue("@NoTelepon", nasabah.NoTelepon);
                cmd.Parameters.AddWithValue("@TanggalDaftar",
                    nasabah.TanggalDaftar.ToString("yyyy-MM-dd"));

                try
                {
                    if (_conn.State == ConnectionState.Closed)
                        _conn.Open();

                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // tampilkan error asli
                }
            }

            return result;
        }


        public List<NasabahModel> GetAll()
        {
            var nasabahList = new List<NasabahModel>();
    

            try
            {
                string sql = @"select nasabah_id, nama_lengkap, nik, alamat, no_telp, tanggal_daftar, status from nasabah";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var nasabah = new NasabahModel
                            {
                                IdNasabah = reader.GetInt32(reader.GetOrdinal("nasabah_id")),
                                Nama = reader["nama_lengkap"].ToString(),
                                Nik = reader["nik"].ToString(),
                                Alamat = reader["alamat"].ToString(),
                                NoTelepon = reader["no_telp"].ToString(),
                                TanggalDaftar = Convert.ToDateTime(reader["tanggal_daftar"]),
                                Status = reader["status"].ToString()
                            };
                            nasabahList.Add(nasabah);
                        }
                    }
                }

            }catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return nasabahList;
        }


        public int Update(NasabahModel nasabah)
        {
            var result = 0;

            string sql = "UPDATE nasabah SET nama_lengkap = @Nama, nik = @Nik, alamat = @Alamat, no_telp = @NoTelepon, tanggal_daftar = @TanggalDaftar " +
                         "WHERE nasabah_id = @IdNasabah";
            if (_conn.State != ConnectionState.Open)
                _conn.Open();

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdNasabah", nasabah.IdNasabah);
                cmd.Parameters.AddWithValue("@Nama", nasabah.Nama);
                cmd.Parameters.AddWithValue("@Nik", nasabah.Nik);
                cmd.Parameters.AddWithValue("@Alamat", nasabah.Alamat);
                cmd.Parameters.AddWithValue("@NoTelepon", nasabah.NoTelepon);
                cmd.Parameters.AddWithValue("@TanggalDaftar", nasabah.TanggalDaftar);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Nasabah Error: {0}", ex.Message);

                }

                return result;

            }
        }

        public int Delete(string IdNasabah)
        {
            int result = 0;
            if (_conn.State != ConnectionState.Open)
                _conn.Open();


            string sql = @"
        UPDATE nasabah
        SET status = 'INACTIVE'
        WHERE nasabah_id = @IdNasabah";

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdNasabah", IdNasabah);
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }



        public int Restore(string IdNasabah)
        {
            int result = 0;
            if (_conn.State != ConnectionState.Open)
                _conn.Open();


            string sql = @"
        UPDATE nasabah
        SET status = 'ACTIVE'
        WHERE nasabah_id = @IdNasabah";

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdNasabah", IdNasabah);
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public NasabahModel GetById(int IdNasabah)
        {
            NasabahModel nasabah = null;

            string sql = @"
        SELECT nasabah_id, nama_lengkap, nik, alamat, no_telp, tanggal_daftar, status
        FROM nasabah
        WHERE nasabah_id = @IdNasabah";

            try
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@IdNasabah", IdNasabah);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nasabah = new NasabahModel
                            {
                                IdNasabah = Convert.ToInt32(reader["nasabah_id"]),
                                Nama = reader["nama_lengkap"].ToString(),
                                Nik = reader["nik"].ToString(),
                                Alamat = reader["alamat"].ToString(),
                                NoTelepon = reader["no_telp"].ToString(),
                                TanggalDaftar = Convert.ToDateTime(reader["tanggal_daftar"]),
                                Status = reader["status"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return nasabah;
        }


        public List<NasabahModel> SearchByName(string NamaNasabah)
        {
            var nasabahList = new List<NasabahModel>();
            if (_conn.State != ConnectionState.Open)
                _conn.Open();

            try
            {
                string sql = @"select nasabah_id, nama_lengkap, nik, alamat, no_telp, tanggal_daftar from nasabah WHERE nama_lengkap LIKE @NamaNasabah COLLATE NOCASE";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@NamaNasabah", "%" + NamaNasabah + "%");

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var nasabah = new NasabahModel
                            {
                                IdNasabah = reader.GetInt32(reader.GetOrdinal("nasabah_id")),
                                Nama = reader["nama_lengkap"].ToString(),
                                Nik = reader["nik"].ToString(),
                                Alamat = reader["alamat"].ToString(),
                                NoTelepon = reader["no_telp"].ToString(),
                                TanggalDaftar = Convert.ToDateTime(reader["tanggal_daftar"])
                            };
                            nasabahList.Add(nasabah);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return nasabahList;
        }

    }
}
