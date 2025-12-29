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
    public class RekeningRepository
    {
        private SQLiteConnection _conn;

        public RekeningRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int CreateRekening(RekeningModel rekening)
        {
            int result = 0;

            string sql = "INSERT INTO rekening (no_rekening, nasabah_id, jenis_rekening, saldo, tanggal_buka, status) " +
                         "VALUES (@NoRekening, @NasabahId, @JenisRekening, @Saldo, @TanggalBuka, @Status)";

            using (var cmd = new SQLiteCommand(sql, _conn))
             {
                cmd.Parameters.AddWithValue("@NoRekening", rekening.NomorRekening);
                cmd.Parameters.AddWithValue("@NasabahId", rekening.IdNasabah);
                cmd.Parameters.AddWithValue("@JenisRekening", rekening.JenisRekening);
                cmd.Parameters.AddWithValue("@Saldo", rekening.Saldo);
                cmd.Parameters.AddWithValue("@TanggalBuka", rekening.TanggalBuka);
                cmd.Parameters.AddWithValue("@Status", rekening.Status);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Rekening Error: {0}", ex.Message);
                }
            }
            return result;
        }

        public RekeningModel GetById(int rekeningId)
        {
            RekeningModel rekening = null;
            string sql = "SELECT rekening_id, no_rekening, nasabah_id, jenis_rekening, saldo, tanggal_buka, status " +
                         "FROM rekening WHERE rekening_id = @RekeningId";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@RekeningId", rekeningId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rekening = new RekeningModel
                        {
                            RekeningId = Convert.ToInt32(reader["rekening_id"]),
                            NomorRekening = reader["no_rekening"].ToString(),
                            IdNasabah = Convert.ToInt32(reader["nasabah_id"]),
                            JenisRekening = reader["jenis_rekening"].ToString(),
                            Saldo = Convert.ToDecimal(reader["saldo"]),
                            TanggalBuka = Convert.ToDateTime(reader["tanggal_buka"]),
                            Status = reader["status"].ToString()
                        };
                    }
                }
            }
            return rekening;
        }

        public List<RekeningModel> GetByNasabahId(int nasabahId)
        {
            var rekeningList = new List<RekeningModel>();
            RekeningModel rekening = null;
            string sql = "SELECT rekening_id, no_rekening, nasabah_id, jenis_rekening, saldo, tanggal_buka, status " +
                         "FROM rekening WHERE nasabah_id = @NasabahId";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@NasabahId", nasabahId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rekening = new RekeningModel
                        {
                            RekeningId = Convert.ToInt32(reader["rekening_id"]),
                            NomorRekening = reader["no_rekening"].ToString(),
                            IdNasabah = Convert.ToInt32(reader["nasabah_id"]),
                            JenisRekening = reader["jenis_rekening"].ToString(),
                            Saldo = Convert.ToDecimal(reader["saldo"]),
                            TanggalBuka = Convert.ToDateTime(reader["tanggal_buka"]),
                            Status = reader["status"].ToString()
                        };

                        rekeningList.Add(rekening);
                    }
                }
            }
            return rekeningList;

        }

        public int Update(int rekeningId, RekeningModel rekening)
        {
            int result = 0;
            string sql = "UPDATE rekening SET jenis_rekening = @JenisRekening, saldo = @Saldo, status = @Status " +
                         "WHERE rekening_id = @NomorRekening";

            
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@JenisRekening", rekening.JenisRekening);
                cmd.Parameters.AddWithValue("@Saldo", rekening.Saldo);
                cmd.Parameters.AddWithValue("@Status", rekening.Status);
                cmd.Parameters.AddWithValue("@NomorRekening", rekeningId);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update Rekening Error: {0}", ex.Message);
                }
            }
            return result;  
        }

        public int CloseRekening(int noRek)
        {
            int result = 0;

            string sql = "UPDATE rekening SET status = 'CLOSED' WHERE no_rekening = @NoRek";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@NoRek", noRek);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Close Rekening Error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int RestoreRekening(int noRek)
        {
            int result = 0;
            string sql = "UPDATE rekening SET status = 'ACTIVE' WHERE no_rekening = @NoRek";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@NoRek", noRek);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Restore Rekening Error: {0}", ex.Message);
                }
            }
            return result;
        }

        public string GenerateNomorRekening()
        {
            // Logic to generate account number can be added here
            string lastNumber = null;

            string sql = "SELECT no_rekening FROM rekening ORDER BY rekening_id DESC LIMIT 1";

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                var result = cmd.ExecuteScalar();
                if (result != null)
                    lastNumber = result.ToString();
            }

            int next = 1;

            if (!string.IsNullOrEmpty(lastNumber))
            {
                // REK-2025-000123
                var parts = lastNumber.Split('-');
                next = int.Parse(parts[2]) + 1;
            }

            return $"REK-{DateTime.Now.Year}-{next.ToString("D6")}";

        }


    }
}
