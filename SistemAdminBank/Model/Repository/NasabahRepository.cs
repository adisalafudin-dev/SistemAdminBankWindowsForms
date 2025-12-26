using SistemAdminBank.Model.Context;
using SistemAdminBank.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemAdminBank.Model.Repository
{
    public class NasabahRepository
    {
        private SQLiteConnection _conn;

        public NasabahRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Nasabah nasabah)
        {
            var result = 0;

            string sql = "INSERT INTO nasabah (IdNasabah, Nama, Nik, Alamat, NoTelepon, Email, TanggalDaftar) " +
                         "VALUES (@IdNasabah, @Nama, @Nik, @Alamat, @NoTelepon, @Email, @TanggalDaftar)";

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdNasabah", nasabah.IdNasabah);
                cmd.Parameters.AddWithValue("@Nama", nasabah.Nama);
                cmd.Parameters.AddWithValue("@Nik", nasabah.Nik);
                cmd.Parameters.AddWithValue("@Alamat", nasabah.Alamat);
                cmd.Parameters.AddWithValue("@NoTelepon", nasabah.NoTelepon);
                cmd.Parameters.AddWithValue("@Email", nasabah.Email);
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

        public List<Nasabah> GetAll()
        {
            var nasabahList = new List<Nasabah>();

            try
            {
                string sql = @"select nasabah_id, nama_lengkap, nik, alamat, no_telp, tanggal_daftar from nasabah";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var nasabah = new Nasabah
                            {
                                IdNasabah = reader["nasabah_id"].ToString(),
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

            }catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return nasabahList;
        }


        public int Update(Nasabah nasabah)
        {
            var result = 0;

            string sql = "UPDATE nasabah SET Nama = @Nama, Nik = @Nik, Alamat = @Alamat, NoTelepon = @NoTelepon, Email = @Email, TanggalDaftar = @TanggalDaftar " +
                         "WHERE IdNasabah = @IdNasabah";

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdNasabah", nasabah.IdNasabah);
                cmd.Parameters.AddWithValue("@Nama", nasabah.Nama);
                cmd.Parameters.AddWithValue("@Nik", nasabah.Nik);
                cmd.Parameters.AddWithValue("@Alamat", nasabah.Alamat);
                cmd.Parameters.AddWithValue("@NoTelepon", nasabah.NoTelepon);
                cmd.Parameters.AddWithValue("@Email", nasabah.Email);
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
            var result = 0;

            var nasabah = GetById(IdNasabah);

            if (nasabah == null) return 0;

            string sql = "DELETE FROM nasabah " +
                         "WHERE IdNasabah = @IdNasabah";

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdNasabah", IdNasabah);
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




        public Nasabah GetById(string IdNasabah)
        {
            Nasabah nasabah = null;

            string sql = "SELECT * FROM nasabah WHERE IdNasabah = @IdNasabah";

            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nasabah = new Nasabah
                            {
                                IdNasabah = reader["nasabah_id"].ToString(),
                                Nama = reader["nama_lengkap"].ToString(),
                                Nik = reader["nik"].ToString(),
                                Alamat = reader["alamat"].ToString(),
                                NoTelepon = reader["no_telp"].ToString(),
                                TanggalDaftar = Convert.ToDateTime(reader["tanggal_daftar"])
                            };
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetById Error: {0}", ex.Message);
            }

            return nasabah;
        }


        public List<Nasabah> SearchByName(string NamaNasabah)
        {
            var nasabahList = new List<Nasabah>();

            try
            {
                string sql = @"select nasabah_id, nama_lengkap, nik, alamat, no_telp, tanggal_daftar from nasabah WHERE nama_lengkap LIKE '@NamaNasabah'";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@NamaNasabah", "%" + NamaNasabah + "%");

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var nasabah = new Nasabah
                            {
                                IdNasabah = reader["nasabah_id"].ToString(),
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
