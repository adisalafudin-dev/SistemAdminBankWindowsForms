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
    public class TransaksiRepository
    {
        private SQLiteConnection _conn;

        public TransaksiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int CreateTransaksiTransfer(TransaksiModel transaksi, string NomorRekening)
        {
            int result = 0;
            using (var dbTransaction = _conn.BeginTransaction())
            {
                try
                {
                    string updateSaldoSql = "UPDATE rekening SET saldo = saldo - @Jumlah WHERE no_rekening = @NoRekening AND status = 'ACTIVE'";

                    using (var updateCmd = new SQLiteCommand(updateSaldoSql, _conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Jumlah", transaksi.Jumlah);
                        updateCmd.Parameters.AddWithValue("@NoRekening", NomorRekening);
                        updateCmd.ExecuteNonQuery();
                    }

                    string sql = "INSERT INTO transaksi (jenis_transaksi,  jumlah, rekening_tujuan, tanggal_transaksi, keterangan, admin_id, rekening_id, nasabah_id) " +
                    "VALUES (@JenisTransaksi, @Jumlah, @RekeningTujuan, @TanggalTransaksi, @Keterangan, @AdminId, @RekeningId, @NasabahId)";
                    using (var cmd = new SQLiteCommand(sql, _conn))
                    {
                        cmd.Parameters.AddWithValue("@JenisTransaksi", transaksi.JenisTransaksi);
                        cmd.Parameters.AddWithValue("@Jumlah", transaksi.Jumlah);
                        cmd.Parameters.AddWithValue("@RekeningTujuan", transaksi.NomorRekeningTujuan);
                        cmd.Parameters.AddWithValue("@TanggalTransaksi", transaksi.TanggalTransaksi);
                        cmd.Parameters.AddWithValue("@Keterangan", transaksi.Keterangan);
                        cmd.Parameters.AddWithValue("@AdminId", transaksi.AdminId);
                        cmd.Parameters.AddWithValue("@RekeningId", transaksi.RekeningId);
                        cmd.Parameters.AddWithValue("@NasabahId", transaksi.NasabahId);
                        cmd.ExecuteNonQuery();
                    }

                    string updateSaldoPenerimaSql = "UPDATE rekening SET saldo = saldo + @Jumlah WHERE no_rekening = @NoRekeningTujuan AND status = 'ACTIVE'";
                    using (var updateCmdPenerima = new SQLiteCommand(updateSaldoPenerimaSql, _conn))
                    {
                        updateCmdPenerima.Parameters.AddWithValue("@Jumlah", transaksi.Jumlah);
                        updateCmdPenerima.Parameters.AddWithValue("@NoRekeningTujuan", transaksi.NomorRekeningTujuan);
                        updateCmdPenerima.ExecuteNonQuery();
                    }
                    dbTransaction.Commit();
                    result = 1;

                }
                catch
                {
                    dbTransaction.Rollback();
                    throw;
                }
            }


            return result;
         }

        public int CreateTransaksiSetorTunai(TransaksiModel transaksi)
        {
            int result = 0;

            using (var dbTransaction = _conn.BeginTransaction())
            {
                try
                {
                    string updateSaldoSql = "UPDATE rekening SET saldo = saldo + @Jumlah WHERE no_rekening = @NoRekening AND status = 'ACTIVE'";

                    using (var updateCmd = new SQLiteCommand(updateSaldoSql, _conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Jumlah", transaksi.Jumlah);
                        updateCmd.Parameters.AddWithValue("@NoRekening", transaksi.NomorRekeningTujuan);
                        updateCmd.ExecuteNonQuery();
                    }

                    string insertTransaksiSql = "INSERT INTO transaksi (jenis_transaksi, jumlah, rekening_tujuan, tanggal_transaksi, keterangan, admin_id, rekening_id, nasabah_id) " +
                                                "VALUES (@JenisTransaksi, @Jumlah, @RekeningTujuan, @TanggalTransaksi, @Keterangan, @AdminId, @RekeningId, @NasabahId)";
                    using (var insertCmd = new SQLiteCommand(insertTransaksiSql, _conn))
                    {
                        insertCmd.Parameters.AddWithValue("@JenisTransaksi", transaksi.JenisTransaksi);
                        insertCmd.Parameters.AddWithValue("@Jumlah", transaksi.Jumlah);
                        insertCmd.Parameters.AddWithValue("@RekeningTujuan", transaksi.NomorRekeningTujuan);
                        insertCmd.Parameters.AddWithValue("@TanggalTransaksi", transaksi.TanggalTransaksi);
                        insertCmd.Parameters.AddWithValue("@Keterangan", transaksi.Keterangan);
                        insertCmd.Parameters.AddWithValue("@AdminId", transaksi.AdminId);
                        insertCmd.Parameters.AddWithValue("@RekeningId", transaksi.RekeningId);
                        insertCmd.Parameters.AddWithValue("@NasabahId", transaksi.NasabahId);
                        insertCmd.ExecuteNonQuery();

                    }

                    dbTransaction.Commit();
                    result = 1;
                }
                catch
                {
                    dbTransaction.Rollback();
                    throw;
                }
            }


            return result;
        }

        public int CreateTransaksiTarikTunai(TransaksiModel transaksi)
        {
            int result = 0;
            using (var dbTransaction = _conn.BeginTransaction())
            {
                try
                {
                    string updateSaldoSql = "UPDATE rekening SET saldo = saldo - @Jumlah WHERE no_rekening = @NoRekening AND status = 'ACTIVE'";
                    using (var updateCmd = new SQLiteCommand(updateSaldoSql, _conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Jumlah", transaksi.Jumlah);
                        updateCmd.Parameters.AddWithValue("@NoRekening", transaksi.NomorRekeningTujuan);
                        updateCmd.ExecuteNonQuery();
                    }
                    string insertTransaksiSql = "INSERT INTO transaksi (jenis_transaksi, jumlah, rekening_tujuan, tanggal_transaksi, keterangan, admin_id, rekening_id, nasabah_id) " +
                                                "VALUES (@JenisTransaksi, @Jumlah, @RekeningTujuan, @TanggalTransaksi, @Keterangan, @AdminId, @RekeningId, @NasabahId)";
                    using (var insertCmd = new SQLiteCommand(insertTransaksiSql, _conn))
                    {
                        insertCmd.Parameters.AddWithValue("@JenisTransaksi", transaksi.JenisTransaksi);
                        insertCmd.Parameters.AddWithValue("@Jumlah", transaksi.Jumlah);
                        insertCmd.Parameters.AddWithValue("@RekeningTujuan", transaksi.NomorRekeningTujuan);
                        insertCmd.Parameters.AddWithValue("@TanggalTransaksi", transaksi.TanggalTransaksi);
                        insertCmd.Parameters.AddWithValue("@Keterangan", transaksi.Keterangan);
                        insertCmd.Parameters.AddWithValue("@AdminId", transaksi.AdminId);
                        insertCmd.Parameters.AddWithValue("@RekeningId", transaksi.RekeningId);
                        insertCmd.Parameters.AddWithValue("@NasabahId", transaksi.NasabahId);
                        insertCmd.ExecuteNonQuery();
                    }
                    dbTransaction.Commit();
                    result = 1;
                }
                catch
                {
                    dbTransaction.Rollback();
                    throw;
                }
            }
            return result;
        }

        public List<TransaksiModel> GetAllTransaksi(int idRekening) {
            List<TransaksiModel> list = new List<TransaksiModel>();
            string sql = @"SELECT id_transaksi, jenis_transaksi, jumlah, rekening_tujuan, tanggal_transaksi, keterangan, rekening_id, nasabah_id
                   FROM transaksi
                   WHERE rekening_id = @RekeningId";

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@RekeningId", idRekening);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TransaksiModel transaksi = new TransaksiModel
                        {
                            IdTransaksi = Convert.ToInt32(reader["transaksi_id"]),
                            JenisTransaksi = reader["jenis_transaksi"].ToString(),
                            Jumlah = Convert.ToDecimal(reader["jumlah"]),
                            NomorRekeningTujuan = Convert.ToInt32(reader["rekening_tujuan"]),
                            TanggalTransaksi = Convert.ToDateTime(reader["tanggal_transaksi"]),
                            Keterangan = reader["keterangan"].ToString(),
                            AdminId = Convert.ToInt32(reader["admin_id"]),
                            RekeningId = Convert.ToInt32(reader["rekening_id"]),

                        };
                    list.Add(transaksi);
                    }

                    return list;
                }
            }
        }



        public bool ValidasiSaldoCukup(string noRekening, decimal jumlah)
        {

            string sql = @"SELECT saldo FROM rekening
                   WHERE no_rekening = @NoRekening
                   AND status = 'ACTIVE'
                   AND saldo >= @Jumlah";

            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@NoRekening", noRekening);
                cmd.Parameters.AddWithValue("@Jumlah", jumlah);
                var result  = cmd.ExecuteScalar();
                return result != null;
            }
        }








    }
}
