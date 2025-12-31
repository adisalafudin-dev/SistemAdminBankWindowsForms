CREATE TABLE admin (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    username VARCHAR(50),
    password VARCHAR(50)
);

CREATE TABLE nasabah (
    nasabah_id INTEGER PRIMARY KEY  AUTOINCREMENT,
    nama_lengkap VARCHAR(100),
    nik VARCHAR(20),
    alamat text,
    no_telp VARCHAR(20),
    tanggal_daftar DATETIME,
    status TEXT DEFAULT 'ACTIVE',
    jenis_kelamin VARCHAR(255)
);

CREATE TABLE rekening (
    rekening_id INTEGER PRIMARY KEY AUTOINCREMENT,
    no_rekening VARCHAR(20),
    jenis_rekening VARCHAR(20),
    saldo DECIMAL(15, 2),
    tanggal_buka DATETIME,
    status VARCHAR(20) DEFAULT ACTIVE,
    nasabah_id INTEGER,

    CONSTRAINT fk_nasabah
    FOREIGN KEY  (nasabah_id)
    REFERENCES nasabah(nasabah_id)
);

CREATE TABLE  transaksi (
    transaksi_id INTEGER PRIMARY KEY AUTOINCREMENT,
    jenis_transaksi VARCHAR(20),
    jumlah DECIMAL(15, 2),
    rekening_tujuan VARCHAR(20),
    tanggal_transaksi DATETIME,
    keterangan TEXT NULL,
    admin_id INTEGER,
    rekening_id INTEGER,
    nasabah_id INTEGER,


    CONSTRAINT fk_admin
    FOREIGN KEY (admin_id)
    REFERENCES admin(id),

    CONSTRAINT fk_rekening
    FOREIGN KEY (rekening_id)
    REFERENCES rekening(rekening_id),

    CONSTRAINT fk_nasabah
    FOREIGN KEY (nasabah_id)
    REFERENCES nasabah(nasabah_id)

);
