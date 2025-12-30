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

        public int CreateTransaksiTransfer(TransaksiModel transaksi)
        {
            int result = 0;
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
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Transaksi Error: {0}", ex.Message);

                }

                return result;
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
