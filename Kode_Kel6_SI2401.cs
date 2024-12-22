// Catatan:
// Harap AddNuget MYSQL Data dan MYSQL Connector;
// Harap Install Extension MYSQL;
// Terlebih Dahulu!
namespace TUBES{
// Kelas : S1SI-KJ-24-01
// Kelompok : 6
// Anggota kelompok:
// - Andhika Presario Achmad 102042430022
// - Intan Nurfathriah 102042400044
// - Dhimas Aqillah Syah 102042400070
// - Mauly Aditia 102042400014
    using System;
    using System.Diagnostics;
    using MySql.Data.MySqlClient;
    class Challenge{
        static void Main(string[] args){
            bool Menu = false;
            while (!Menu){
                try{
                    // Start Header
                    static void header(){
                        Console.WriteLine("\n===========================================================================================================================================");
                        Console.WriteLine($"| Id Asset  | Bidang Asset    | Jenis Asset     | Nama Asset      | Warna Asset     | Kuantitas Asset | Harga Asset     | Tanggal         |");
                        Console.WriteLine("===========================================================================================================================================");
                    }
                    // Start Header2
                    static void header2(){
                        Console.WriteLine("\n=============================================================================");
                        Console.WriteLine($"| Id Peminjaman | Nama Peminjam        | Jumlah Kuantitas | Tanggal         |");
                        Console.WriteLine("=============================================================================");
                    }
                    // Start Invalid
                    static void invalid(){
                        int panjang = 137;
                        string pesan = " Data dari kata kunci tidak ditemukan";
                        int panjangPesan = pesan.Length;
                        int jumlahSpasi = (panjang - panjangPesan)/2;
                        string spasi = new String(' ', jumlahSpasi);
                        Console.WriteLine($"|{spasi}{pesan}{spasi}|");
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                    }
                    // Start Lihat Data Asset
                    static void LihatDataAsset(){
                    string connectionString = "Server=localhost;Database=inventaris;Uid=root;Pwd=;"; //1
                        try{
                            using (MySqlConnection conn = new MySqlConnection(connectionString)){ //2
                                conn.Open(); // 3

                                header();

                                string query = "SELECT * FROM data"; //4
                                MySqlCommand cmd = new MySqlCommand(query, conn); //5
                                MySqlDataReader reader = cmd.ExecuteReader(); //6

                                while (reader.Read()){ //7
                                    // double harga = Consolereader["Harga"];
                                    // double hargaFornatted = harga.ToString("#,##0");
                                    Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp. {reader["Harga"], -11} | {reader["Tanggal"],-15} |");
                                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                reader.Close(); // 8
                            }
                        }
                        catch (Exception ex){ //9
                            Console.WriteLine("\nTerjadi kesalahan: " + ex.Message);
                        }
                    }
                    // Start Riwayat
                    static void riwayat(){
                        string riwayatData2 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;"; //1
                        try{
                            using (MySqlConnection conn = new MySqlConnection(riwayatData2)){ //2
                                conn.Open(); // 3

                                header2();

                                string query = "SELECT * FROM data2"; //4
                                MySqlCommand cmd = new MySqlCommand(query, conn); //5
                                MySqlDataReader reader = cmd.ExecuteReader(); //6

                                while (reader.Read()){ //7

                                    Console.WriteLine($"| {reader["id"],-13} | {reader["Nama"],-20} | {reader["Kuantitas"],-16} | {reader["Tanggal"],-15} |");
                                    Console.WriteLine("-----------------------------------------------------------------------------");
                                }
                                reader.Close(); // 8
                            }
                        }
                        catch (Exception ex){ //9
                            Console.WriteLine("\nTerjadi kesalahan: " + ex.Message);
                        }
                    }
                    // Start static void Main:
                    Console.WriteLine("\n======= APLIKASI MANAJEMEN INVENTARIS ========");
                    Console.WriteLine("\n1. Lihat Data Asset");
                    Console.WriteLine("2. Edit Data Asset");
                    Console.WriteLine("3. Tambah Data Asset");
                    Console.WriteLine("4. Hapus Data Asset");
                    Console.WriteLine("5. Penggunaan Asset");
                    Console.WriteLine("0. Keluar\n");

                    Console.Write("Masukan Pilihan Anda : ");
                    int main = int.Parse(Console.ReadLine());

                    switch (main){
                        case 1: // Operasi Data Asset
                            // Start OperasiDataAsset
                            bool keluar = false;
                            while (!keluar){
                
                                Console.WriteLine("\n========= Fitur Lihat Data Asset ========");
                                Console.WriteLine("\nPilih mode edit:");
                                Console.WriteLine("1. Lihat Seluruh Data Asset");
                                Console.WriteLine("2. Lihat Data Tertentu");
                                Console.WriteLine("3. Kembali ke Menu Utama");
                                Console.Write("\nMasukkan Pilihan: ");
                                int pilihan = int.Parse(Console.ReadLine());

                                switch(pilihan){
                                    case 1: // Lihat Seluruh Data
                                    LihatDataAsset();
                                    // keluar=false;
                                    break;
                                    case 2: // Lihat Data Tertentu
                                        bool keluar2 = false;
                                        while (!keluar2){
                                            Console.WriteLine("\n========= Fitur Lihat Data Asset Tertentu ========");
                                            Console.WriteLine("\nPilih Opsi Lihat Data Tertentu: ");
                                            Console.WriteLine("1. Cari Asset");
                                            Console.WriteLine("2. Filter Asset");
                                            Console.WriteLine("3. Sortir Berdasarkan Kolom");
                                            Console.WriteLine("4. Kembali Ke Menu Awal");
                                            Console.Write("\nMasukkan Pilihan: ");
                                            int pilihan1 = int.Parse(Console.ReadLine());

                                            switch(pilihan1){
                                                case 1: // Cari Data Asset
                                                Console.WriteLine("\n========= Fitur Cari Data Asset ========");
                                                Console.Write("\nMasukkan Kata Kunci: ");
                                                string pilihan2 = Console.ReadLine();
                                                
                                                string connectionString1 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                try{
                                                    using (MySqlConnection conn = new MySqlConnection(connectionString1)){
                                                        conn.Open();
                                                        header();
                                                        
                                                        string query = $"SELECT * FROM `inventaris`.`data` WHERE LOWER(Bidang) LIKE '%{pilihan2}%' OR LOWER(Jenis) LIKE '%{pilihan2}%' OR LOWER(Nama) LIKE '%{pilihan2}%' OR LOWER(Warna) LIKE '%{pilihan2}%' OR LOWER(Kuantitas) LIKE '%{pilihan2}%' OR LOWER(harga) LIKE '%{pilihan2}%'";

                                                        MySqlCommand cmd = new MySqlCommand(query, conn);
                                                        MySqlDataReader reader = cmd.ExecuteReader();

                                                        // Tampilkan hasil
                                                        bool cekdata = false; 
                                                        while (reader.Read()){
                                                            cekdata = true;
                                                            Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                        }
                                                        if (!cekdata){
                                                            invalid();
                                                        }
                                                    }
                                                }
                                                catch (Exception ex){
                                                    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                }
                                                break;
                                                case 2: // Filter Data Asset
                                                    bool keluar3 = false;
                                                    while (!keluar3){
                                                        Console.WriteLine("\n========= Fitur Filter Dan Sortir Data Asset ========");
                                                        Console.WriteLine("\nPilih Opsi Lihat Data Tertentu: ");
                                                        Console.WriteLine("1. Filter Bidang Asset");
                                                        Console.WriteLine("2. Filter Jenis Asset");
                                                        Console.WriteLine("3. Filter Nama Asset");
                                                        Console.WriteLine("4. Filter Warna Asset");
                                                        Console.WriteLine("5. Kembali Ke Menu Awal");
                                                        Console.Write("\nMasukkam Kata Kunci: ");
                                                        int pilihan3 = int.Parse(Console.ReadLine());

                                                        switch (pilihan3){
                                                            case 1: // Filter Bidang
                                                                LihatDataAsset();
                                                                Console.Write("\nMasukkan Bidang Assset Yang Ingin Difilter: ");
                                                                string bidang1 = Console.ReadLine();

                                                                string connectionString2 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                try{
                                                                    using (MySqlConnection conn = new MySqlConnection(connectionString2)){
                                                                        conn.Open();
                                                                        string query = $"SELECT * FROM `inventaris`.`data` WHERE LOWER(Bidang) LIKE '%{bidang1}%'";
                                                                        MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                        MySqlDataReader reader = cmd.ExecuteReader();
                                                                        bool cekdata = false;
                                                                        // Tampilkan hasil
                                                                        header();
                                                                        while (reader.Read()){
                                                                            cekdata = true;
                                                                            Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                        }
                                                                        if (!cekdata){
                                                                            invalid();
                                                                        }
                                                                    }
                                                                }
                                                                catch (Exception ex){
                                                                    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                }
                                                            break;
                                                            case 2: // Filter Jenis
                                                                LihatDataAsset();
                                                                Console.Write("\nMasukkan Jenis Asset Yang Ingin Difilter: ");
                                                                string jenis1 = Console.ReadLine();

                                                                string connectionString3 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                try{
                                                                    using (MySqlConnection conn = new MySqlConnection(connectionString3)){
                                                                        conn.Open();
                                                                        string query = $"SELECT * FROM `inventaris`.`data` WHERE LOWER(Jenis) LIKE '%{jenis1}%'";
                                                                        MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                        MySqlDataReader reader = cmd.ExecuteReader();
                                                                        bool cekdata = false;
                                                                        // Tampilkan hasil
                                                                        header();
                                                                        while (reader.Read()){
                                                                            cekdata = true;
                                                                            Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                        }
                                                                        if (!cekdata){
                                                                            Console.WriteLine($"Data dari kata kunci {jenis1} tidak ditemukan");
                                                                        }
                                                                    }
                                                                }
                                                                catch (Exception ex){
                                                                    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                }
                                                            break;
                                                            case 3: // Filter Nama
                                                                LihatDataAsset();
                                                                Console.Write("\nMasukkan Nama Asset Yang Ingin Difilter: ");
                                                                string nama1 = Console.ReadLine();

                                                                string connectionString4 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                try{
                                                                    using (MySqlConnection conn = new MySqlConnection(connectionString4)){
                                                                        conn.Open();
                                                                        string query = $"SELECT * FROM `inventaris`.`data` WHERE LOWER(Nama) LIKE '%{nama1}%'";
                                                                        MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                        MySqlDataReader reader = cmd.ExecuteReader();
                                                                        bool cekdata = false;
                                                                        // Tampilkan hasil
                                                                        header();
                                                                        while (reader.Read()){
                                                                            cekdata = true;
                                                                            Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                        }
                                                                        if (!cekdata){
                                                                            invalid();
                                                                        }
                                                                        conn.Close();
                                                                    }
                                                                }
                                                                catch (Exception ex){
                                                                    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                }
                                                            break;
                                                            case 4: // Filter Warna
                                                                LihatDataAsset();
                                                                Console.Write("\nMasukkan Warna Asset Yang Ingin Difilter: ");
                                                                string warna1 = Console.ReadLine();

                                                                string connectionString5 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                try{
                                                                    using (MySqlConnection conn = new MySqlConnection(connectionString5)){
                                                                        conn.Open();
                                                                        string query = $"SELECT * FROM `inventaris`.`data` WHERE LOWER(Warna) LIKE '%{warna1}%'";
                                                                        MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                        MySqlDataReader reader = cmd.ExecuteReader();
                                                                        bool cekdata = false;
                                                                        // Tampilkan hasil
                                                                        header();
                                                                        while (reader.Read()){
                                                                            cekdata = true;
                                                                            Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                        }
                                                                        if (!cekdata){
                                                                            invalid();
                                                                        }
                                                                        conn.Close();
                                                                    }
                                                                }
                                                                catch (Exception ex){
                                                                    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                }
                                                            break;
                                                            case 5: // Keluar
                                                                keluar2 = true;
                                                            break;
                                                            default:
                                                                Console.WriteLine("\nPilihan tidak valid!");
                                                            break;
                                                        }
                                                    }
                                                break;
                                                case 3: // Sortir Data Asset
                                                    bool keluar4 = false;
                                                    while (!keluar4){
                                                        Console.WriteLine("\n========= Fitur Sortir Kolom ========");
                                                        Console.WriteLine("\nPilihan Kolom Sortir: ");
                                                        Console.WriteLine("1. Kuantitas Seluruh Asset");
                                                        Console.WriteLine("2. Harga Seluruh Asset");
                                                        Console.WriteLine("3. Tanggal Seluruh Asset") ;
                                                        Console.WriteLine("4. Kembali ke Menu Awal");
                                                        Console.Write("\nKetikkan Nama Kolom: ");
                                                        int pilihan4 = int.Parse(Console.ReadLine());
                            
                                                        switch(pilihan4){
                                                            case 1: // Sortir Kuantitas
                                                                Console.WriteLine("\nUrutkan Berdasarkan: ");
                                                                Console.WriteLine("1. Kuantitas Ter-sedikit (ASC)");
                                                                Console.WriteLine("2. Kuantitas Ter-banyak (DESC)");
                                                                Console.Write("\nMasukkan Pilihan: ");
                                                                int pilihan5 = int.Parse(Console.ReadLine());
                                                                switch(pilihan5){
                                                                    case 1:
                                                                    string connectionString6 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                    try{
                                                                        using (MySqlConnection conn = new MySqlConnection(connectionString6)){
                                                                            conn.Open();
                                                                            string query = $"SELECT * FROM `inventaris`.`data` ORDER BY `Kuantitas` ASC";
                                                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                            MySqlDataReader reader = cmd.ExecuteReader();
                                                                            bool cekdata = false;
                                                                            // Tampilkan hasil
                                                                            header();
                                                                            while (reader.Read()){
                                                                                cekdata = true;
                                                                                Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                            }
                                                                            if (!cekdata){
                                                                                invalid();
                                                                            }
                                                                            conn.Close();
                                                                        }
                                                                    }
                                                                    catch (Exception ex){
                                                                        Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                    }
                                                                    break;
                                                                    case 2:
                                                                    string connectionString7 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                        try{
                                                                            using (MySqlConnection conn = new MySqlConnection(connectionString7)){
                                                                                conn.Open();
                                                                                string query = $"SELECT * FROM `inventaris`.`data` ORDER BY `Kuantitas` DESC";
                                                                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                                MySqlDataReader reader = cmd.ExecuteReader();
                                                                                bool cekdata = false;
                                                                                // Tampilkan hasil
                                                                                header();
                                                                                while (reader.Read()){
                                                                                    cekdata = true;
                                                                                    Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                                }
                                                                                if (!cekdata){
                                                                                    invalid();
                                                                                }
                                                                                conn.Close();
                                                                            }
                                                                        }
                                                                        catch (Exception ex){
                                                                            Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                        }
                                                                    break;
                                                                }
                                                            break;
                                                            case 2: // Sortir Harga
                                                                Console.WriteLine("\nUrutkan Berdasarkan: ");
                                                                Console.WriteLine("1. Kuantitas Ter-sedikit (ASC)");
                                                                Console.WriteLine("2. Kuantitas Ter-banyak (DESC)");
                                                                Console.Write("\nMasukkan Pilihan: ");
                                                                int pilihan6 = int.Parse(Console.ReadLine());
                                                                switch(pilihan6){
                                                                    case 1:
                                                                    string connectionString8 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                    try{
                                                                        using (MySqlConnection conn = new MySqlConnection(connectionString8)){
                                                                            conn.Open();
                                                                            string query = $"SELECT * FROM `inventaris`.`data` ORDER BY `Harga` ASC";
                                                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                            MySqlDataReader reader = cmd.ExecuteReader();
                                                                            bool cekdata = false;
                                                                            // Tampilkan hasil
                                                                            header();
                                                                            while (reader.Read()){
                                                                                cekdata = true;
                                                                                Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                            }
                                                                            if (!cekdata){
                                                                                invalid();
                                                                            }
                                                                            conn.Close();
                                                                        }
                                                                    }
                                                                    catch (Exception ex){
                                                                        Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                    }
                                                                    break;
                                                                    case 2:
                                                                    string connectionString9 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                        try{
                                                                            using (MySqlConnection conn = new MySqlConnection(connectionString9)){
                                                                                conn.Open();
                                                                                string query = $"SELECT * FROM `inventaris`.`data` ORDER BY `Harga` DESC";
                                                                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                                MySqlDataReader reader = cmd.ExecuteReader();
                                                                                bool cekdata = false;
                                                                                // Tampilkan hasil
                                                                                header();
                                                                                while (reader.Read()){
                                                                                    cekdata = true;
                                                                                    Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                                }
                                                                                if (!cekdata){
                                                                                    invalid();
                                                                                }
                                                                                conn.Close();
                                                                            }
                                                                        }
                                                                        catch (Exception ex){
                                                                            Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                        }
                                                                    break;
                                                                }
                                                            break;
                                                            case 3: // Sortir Tanggal
                                                                Console.WriteLine("\nUrutkan Berdasarkan: ");
                                                                Console.WriteLine("1. Tanggal Terlama (ASC)");
                                                                Console.WriteLine("2. Tanggal Terbaru (DESC)");
                                                                Console.Write("\nMasukkan Pilihan: ");
                                                                int pilihan7 = int.Parse(Console.ReadLine());
                                                                switch(pilihan7){
                                                                    case 1:
                                                                    string connectionString10 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                    try{
                                                                        using (MySqlConnection conn = new MySqlConnection(connectionString10)){
                                                                            conn.Open();
                                                                            string query = $"SELECT * FROM `inventaris`.`data` ORDER BY `Tanggal` ASC";
                                                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                            MySqlDataReader reader = cmd.ExecuteReader();
                                                                            bool cekdata = false;
                                                                            // Tampilkan hasil
                                                                            header();
                                                                            while (reader.Read()){
                                                                                cekdata = true;
                                                                                Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                            }
                                                                            if (!cekdata){
                                                                                invalid();
                                                                            }
                                                                            conn.Close();
                                                                        }
                                                                    }
                                                                    catch (Exception ex){
                                                                        Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                    }
                                                                    break;
                                                                    case 2:
                                                                    string connectionString11 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                                        try{
                                                                            using (MySqlConnection conn = new MySqlConnection(connectionString11)){
                                                                                conn.Open();
                                                                                string query = $"SELECT * FROM `inventaris`.`data` ORDER BY `Tanggal` DESC";
                                                                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                                                                MySqlDataReader reader = cmd.ExecuteReader();
                                                                                bool cekdata = false;
                                                                                // Tampilkan hasil
                                                                                header();
                                                                                while (reader.Read()){
                                                                                    cekdata = true;
                                                                                    Console.WriteLine($"| {reader["id"],-9} | {reader["Bidang"],-15} | {reader["Jenis"],-15} | {reader["Nama"],-15} | {reader["Warna"],-15} | {reader["Kuantitas"],-15} | Rp.{reader["Harga"],-12} | {reader["Tanggal"],-15} |");
                                                                                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                                                                                }
                                                                                if (!cekdata){
                                                                                    invalid();
                                                                                }
                                                                                conn.Close();
                                                                            }
                                                                        }
                                                                        catch (Exception ex){
                                                                            Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                                                        }
                                                                    break;
                                                                }
                                                            break;
                                                            case 4: // Keluar
                                                                keluar3 = true;
                                                            break;
                                                            default:
                                                                Console.WriteLine("\nPilihan tidak valid!");
                                                            break;
                                                        }
                                                    }
                                                break;
                                                case 4: // Kembali Ke Menu Awal
                                                keluar2=true;
                                                break;
                                                default:
                                                Console.WriteLine("\nPilihan tidak valid!");
                                                break;
                                            }
                                        }
                                    break;
                                    case 3: // Kembali Ke Menu Awal
                                    keluar = true;
                                    break;
                                    default:
                                    Console.WriteLine("\nPilihan tidak valid!");
                                    break;
                                }
                            }
                        break;
                        case 2: // Edit Data Asset
                            // Start Edit Data Asset
                            bool keluar1 = false;
                            while (!keluar1){

                                Console.WriteLine("\n============ Fitur Edit Data Asset ============");
                                Console.WriteLine("\nPilih mode edit:");
                                Console.WriteLine("1. Edit Isi Dari Kolom Tertentu");
                                Console.WriteLine("2. Edit Seluruh Isi Kolom");
                                Console.WriteLine("3. Kembali Ke Menu Utama");

                                Console.Write("\nMasukkan Pilihan: ");
                                int pilihan = int.Parse(Console.ReadLine());

                                switch(pilihan){
                                    case 1:
                                    Pilihan1();
                                    keluar1=true;
                                    break;

                                    case 2:
                                    Pilihan2();
                                    keluar1=true;
                                    break;

                                    case 3:
                                    keluar=true;
                                    break;
                                default:
                                    Console.WriteLine("\nPilihan tidak valid!");
                                    break;  
                                }
                            }
                        
                            static MySqlConnection GetConnection(){
                            string connectionString = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                            MySqlConnection connection = new MySqlConnection(connectionString);
                            return connection;
                            }
                            
                            static void Pilihan1(){
                                Console.WriteLine("\n=== Fitur Edit Isi Kolom Tertentu ===");

                                LihatDataAsset();

                                Console.Write("\nMasukkan ID Asset yang ingin diedit: ");
                                int id = int.Parse(Console.ReadLine());

                                Console.WriteLine("\nApa yang ingin diubah?");
                                Console.WriteLine("1. Bidang");
                                Console.WriteLine("2. Jenis"); 
                                Console.WriteLine("3. Nama");
                                Console.WriteLine("4. Warna");
                                Console.WriteLine("5. Kuantitas");
                                Console.WriteLine("6. Harga");
                                Console.Write("Masukkan pilihan (1-6): ");
                                int kolom = int.Parse(Console.ReadLine());

                                string query = "UPDATE data SET "; //bidang = @Bidang, jenis = @Jenis, nama = @Nama, warna = @Warna, kuantitas = @Kuantitas, Harga = @Harga, Tanggal = @Tanggal WHERE id = @id";
                                
                                string bidangBaru="";
                                string jenisBaru="";
                                string namaBaru="";
                                string warnaBaru="";
                                int kuantitasBaru=0;
                                int hargaBaru=0;
                                
                                switch (kolom){
                                    case 1:
                                    Console.Write("Masukkan Bidang Asset Baru: ");
                                    bidangBaru = Console.ReadLine();
                                    query += $" bidang = '{bidangBaru}'";
                                    break;
                                    case 2:
                                    Console.Write("Masukkan Jenis Asset Baru: ");
                                    jenisBaru = Console.ReadLine();
                                    query += $" jenis = '{jenisBaru}'";
                                    break;
                                    case 3:
                                    Console.Write("Masukkan Nama Asset Baru: ");
                                    namaBaru = Console.ReadLine();
                                    query += $" nama = '{namaBaru}'";
                                    break;
                                    case 4:
                                    Console.Write("Masukkan Warna Asset Baru: ");
                                    warnaBaru = Console.ReadLine();
                                    query += $" warna = '{warnaBaru}'";
                                    break;
                                    case 5:
                                    Console.Write("Masukkan kuantitas asset baru: ");
                                    kuantitasBaru = InputAngka();
                                    query += $" kuantitas = {kuantitasBaru}";
                                    break;
                                    case 6:
                                    Console.Write("Masukkan harga asset baru: ");
                                    hargaBaru = InputAngka();
                                    query += $" harga = {hargaBaru}";
                                    break;
                                }

                                static int InputAngka(){
                                    while (true){
                                        if (int.TryParse(Console.ReadLine(), out int nilai)){
                                            return nilai;
                                        }
                                        Console.WriteLine("\nInput tidak valid. Harap masukkan angka.");
                                    }
                                }     

                                query += " WHERE id = @id";
                                using (MySqlConnection connection = GetConnection()){
                                    connection.Open();

                                    // string query = $"UPDATE data SET bidang = @Bidang, jenis = @Jenis, nama = @Nama, warna = @Warna, kuantitas = @Kuantitas, Harga = @Harga, Tanggal = @Tanggal WHERE id = @id";
                                    using (MySqlCommand command = new MySqlCommand(query, connection)){
                                        command.Parameters.AddWithValue("@id", id);
                                        if(kolom == 1){
                                            command.Parameters.AddWithValue("@bidangBaru", bidangBaru);
                                        }
                                        if(kolom == 2){
                                            command.Parameters.AddWithValue("@jenisBaru", jenisBaru);
                                        }
                                        if(kolom == 3){
                                            command.Parameters.AddWithValue("@namaBaru", namaBaru);    
                                        }
                                        if(kolom == 4){
                                            command.Parameters.AddWithValue("@warnaBaru", warnaBaru);    
                                        }
                                        if(kolom == 5){
                                            command.Parameters.AddWithValue("@kuantitasBaru", kuantitasBaru);    
                                        }
                                        if(kolom == 6){
                                            command.Parameters.AddWithValue("@hargaBaru", hargaBaru);
                                        }
                                        try{
                                        int rowsAffected = command.ExecuteNonQuery();
                                        if (rowsAffected > 0){
                                            Console.WriteLine("\nData berhasil diubah!\n");
                                        }
                                        else{
                                            Console.WriteLine("\nData tidak ditemukan atau gagal diubah.\n");
                                        }
                                        LihatDataAsset();
                                        }
                                        catch (Exception ex){
                                            Console.WriteLine("\nTerjadi kesalahan: " + ex.Message);
                                        }
                                    }   
                                }
                            } 
                            static void Pilihan2(){

                                LihatDataAsset();

                                Console.Write("\nMasukkan ID yang ingin diedit: ");
                                int id = int.Parse(Console.ReadLine());

                                Console.WriteLine($"\n============ Update Seluruh Data Asset ID {id} ============");

                                // Meminta input data baru untuk asset
                                Console.Write("Masukkan bidang baru:            ");
                                string bidang = Console.ReadLine();

                                Console.Write("Masukkan jenis asset baru:       ");
                                string jenis = Console.ReadLine();

                                Console.Write("Masukkan nama asset baru:        ");
                                string nama = Console.ReadLine();

                                Console.Write("Masukkan warna asset baru:       ");
                                string warna = Console.ReadLine();

                                Console.Write("Masukkan kuantitas asset baru:   ");
                                int kuantitas = int.Parse(Console.ReadLine());

                                Console.Write("Masukkan harga asset baru:       ");
                                double harga = double.Parse(Console.ReadLine());

                                Console.Write("Masukkan tanggal asset baru:     ");
                                string tanggal = Console.ReadLine();

                                // Koneksi ke database
                                string connectionString = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";

                                try{
                                    // Menggunakan koneksi untuk membuka dan mengedit data asset
                                    using (MySqlConnection conn = new MySqlConnection(connectionString)){
                                        // Membuat query untuk mengupdate data asset berdasarkan ID
                                        string query = "UPDATE data SET bidang = @Bidang, jenis = @Jenis, nama = @Nama, warna = @Warna, kuantitas = @Kuantitas, Harga = @Harga, Tanggal = @Tanggal WHERE id = @id";

                                        // Menyiapkan perintah SQL dengan parameter yang sesuai
                                        MySqlCommand cmd = new MySqlCommand(query, conn);
                                        cmd.Parameters.AddWithValue("@Bidang", bidang);
                                        cmd.Parameters.AddWithValue("@Jenis", jenis);
                                        cmd.Parameters.AddWithValue("@Nama", nama);
                                        cmd.Parameters.AddWithValue("@Warna", warna);
                                        cmd.Parameters.AddWithValue("@Kuantitas", kuantitas);
                                        cmd.Parameters.AddWithValue("@Harga",harga);
                                        cmd.Parameters.AddWithValue("@Tanggal", tanggal);
                                        cmd.Parameters.AddWithValue("@id", id);

                                        // Membuka koneksi dan mengeksekusi perintah
                                        conn.Open();
                                        int result = cmd.ExecuteNonQuery();

                                        // Mengecek apakah data berhasil diperbarui
                                        if (result > 0){
                                            Console.WriteLine("\nData asset berhasil diperbarui.\n");
                                        }
                                        else{
                                            Console.WriteLine("\nGagal memperbarui data asset. Pastikan ID asset asset.\n");
                                        }
                                    }
                                    LihatDataAsset();
                                }
                                catch (Exception ex){
                                    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                                }
                            }
                        break;
                        case 3: // Tambah Data Asset
                            // Start Tambah Data Asset
                               LihatDataAsset();

                            int data = 1;
                            int[] id = new int[data];
                            string[] bidang = new string[data];
                            string[] jenis = new string[data];
                            string[] nama = new string[data];
                            string[] warna = new string[data];
                            int[] kuantitas = new int[data];
                            double[] harga = new double[data];
                            string[] tanggal = new string[data];

                            Console.WriteLine("\n============ Tambahkan Data Asset Baru ============");
                            Console.Write("\nMasukkan ID baru              : ");
                            id[0] = int.Parse(Console.ReadLine());
                            
                            Console.Write("Masukkan bidang baru          : ");
                            bidang[0] = Console.ReadLine();

                            Console.Write("Masukkan jenis asset baru     : ");
                            jenis[0] = Console.ReadLine();

                            Console.Write("Masukkan nama asset baru      : ");
                            nama[0] = Console.ReadLine();

                            Console.Write("Masukkan warna asset baru     : ");
                            warna[0] = Console.ReadLine();

                            Console.Write("Masukkan kuantitas asset baru : ");
                            kuantitas[0] = int.Parse(Console.ReadLine());

                            Console.Write("Masukkan harga asset baru     : ");
                            harga[0] = double.Parse(Console.ReadLine());

                            Console.Write("Masukkan tanggal asset baru   : ");
                            tanggal[0] = Console.ReadLine();

                            // Upload Data Input Array ke Elemen
                            SimpanKeDatabase(id, bidang, jenis, nama, warna, kuantitas, harga, tanggal);
                            
                            static void SimpanKeDatabase(int[] id, string[] bidang, string[] jenis, string[] nama, string[] warna, int[] kuantitas, double[] harga, string[] tanggal){
                                string connectionString = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                using (MySqlConnection conn = new MySqlConnection(connectionString)){
                                    conn.Open();

                                    string query = "INSERT INTO data (id, Bidang, Jenis, Nama, Warna, Kuantitas, Harga, Tanggal) VALUES (@id, @bidang, @jenis, @nama, @warna, @kuantitas, @harga, @tanggal)";

                                    using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                                        for (int i = 0; i < nama.Length; i++){
                                            cmd.Parameters.Clear();
                                            cmd.Parameters.AddWithValue("@Bidang", bidang[i]);
                                            cmd.Parameters.AddWithValue("@Jenis", jenis[i]);
                                            cmd.Parameters.AddWithValue("@Nama", nama[i]);
                                            cmd.Parameters.AddWithValue("@Warna", warna[i]);
                                            cmd.Parameters.AddWithValue("@Kuantitas", kuantitas[i]);
                                            cmd.Parameters.AddWithValue("@Harga",harga[i]);
                                            cmd.Parameters.AddWithValue("@Tanggal", tanggal[i]);
                                            cmd.Parameters.AddWithValue("@id", id[i]);
                                            int result = cmd.ExecuteNonQuery();

                                            // Mengecek apakah data berhasil diperbarui
                                            if (result > 0){
                                                Console.WriteLine("\nData Asset Baru Berhasil Ditambahkan");
                                            }
                                            else{
                                                Console.WriteLine("\nGagal memperbarui data asset. Pastikan ID asset benar.");
                                            }
                                            LihatDataAsset();
                                        }
                                    }
                                }
                            }
                        break;
                        case 4: // Hapus Data Asset
                            // Start Hapus Data Asset
                            LihatDataAsset();

                            bool keluar5 = false;
                            while (!keluar5){
                                Console.WriteLine("\n============ Fitur Hapus Data Asset ============");
                                Console.Write("\nMasukkan ID Asset Yang Ingin Dihapus: ");
                                int idHapus = int.Parse(Console.ReadLine());

                                Console.WriteLine("\nApakah Anda Yakin Untuk Menghapus Data Asset Nomor " + idHapus + "?");
                                Console.WriteLine("1. Ya");
                                Console.WriteLine("2. Tidak");
                                Console.WriteLine("3. Kembali Ke Menu Utama");
                                Console.Write("\nMasukkan Pilihan: ");
                                int jawaban = int.Parse(Console.ReadLine());

                                switch(jawaban){
                                    case 1: // Ya
                                    try{
                                        string connectionString = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                        using (MySqlConnection conn = new MySqlConnection(connectionString)){
                                            conn.Open();
                                            string query = "DELETE FROM data WHERE id = @id";
                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                            cmd.Parameters.AddWithValue("@id", idHapus);
                                            int result = cmd.ExecuteNonQuery();
                                            if (result > 0){
                                                Console.WriteLine("\nData Asset berhasil dihapus!\n");
                                            }
                                            else{
                                                Console.WriteLine("\nGagal Menghapus Data Asset. Pastikan ID Data Asset Benar.\n");
                                            }
                                            conn.Close();
                                        }
                                    }
                                    catch (Exception ex){
                                        Console.WriteLine("\nTerjadi kesalahan: " + ex.Message);
                                    }
                                    LihatDataAsset();
                                    keluar5=true;
                                    break;
                                    case 2: // Tidak
                                    Console.WriteLine("\nData Asset " + idHapus + " Tidak dihapus.");
                                    LihatDataAsset();
                                    keluar5=false;
                                    break;
                                    case 3: // keluar
                                    keluar5=true;
                                    break;
                                }
                            }
                        break;
                        case 5: // Penggunaan Asset
                            // Start Penggunaan Assset
                            bool kembali = false;
                            while(!kembali){
                                Console.WriteLine("\n============ Fitur Penggunaan Asset ============");
                                Console.WriteLine("\nPilih Aksi: ");
                                Console.WriteLine("1. Peminjaman Asset");
                                Console.WriteLine("2. Pengembalian Asset");
                                Console.WriteLine("3. Cek Riwayat Peminjaman");
                                Console.WriteLine("4. Kembali ke Menu Utama");
                                Console.Write("\nMasukkan Pilihan Aksi: ");
                                int aksi = int.Parse(Console.ReadLine());

                                switch(aksi){
                                    case 1: // Peminjaman Asset
                                        bool keluar6 = false;
                                        while (!keluar6){
                                            LihatDataAsset();
                                            Console.WriteLine("\n============ Fitur Peminjaman Asset ============");
                                            Console.Write("\nMasukkan Id Asset Yang Ingin Dipinjam Untuk Digunakan: ");
                                            int idPinjam = int.Parse(Console.ReadLine());

                                            Console.WriteLine($"\nApakah Anda ingin Meminjam Asset dari Id {idPinjam}?");
                                            Console.WriteLine("1. Ya");
                                            Console.WriteLine("2. Tidak");
                                            Console.WriteLine("3. Kembali Ke Menu Awal");
                                            Console.Write("\nMasukkan Pilihan: ");
                                            int jawaban = int.Parse(Console.ReadLine());

                                            // PILIHAN BERDASARKAN INPUT USER
                                            switch(jawaban){
                                                // JIKA USER MENGINPUT 1
                                                case 1: // Ya
                                                    static MySqlConnection GetConnection1(){ // Connection Update data
                                                    string connectionString = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                    MySqlConnection connection = new MySqlConnection(connectionString);
                                                    return connection;
                                                    }

                                                    static MySqlConnection GetConnection2(){ // Connection Add data2
                                                    string connectionString1 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                                    MySqlConnection connection1 = new MySqlConnection(connectionString1);
                                                    return connection1;
                                                    }

                                                    int jumlahPinjam = 0;
                                                    string tanggalPinjam = "";
                                                    string namaPinjam = "";

                                                    Console.WriteLine($"\nId Asset Dipilih: {idPinjam}");
                                                    Console.Write("Masukkan Nama Peminjam: ");
                                                    namaPinjam = Console.ReadLine();
                                                    Console.Write("Masukkan Jumlah Asset Yang Ingin Dipinjam: ");
                                                    jumlahPinjam = int.Parse(Console.ReadLine());
                                                    Console.Write("Masukkan Tanggal Peminjaman (dd-mm-yyyy): ");
                                                    tanggalPinjam = Console.ReadLine();

                                                    string query = "UPDATE data SET Kuantitas = kuantitas - @jumlahPinjam, tanggal = @tanggalPinjam WHERE id = @id"; 
                                                    string query1 = "INSERT INTO data2 (Id_Barang, Nama, Kuantitas, Tanggal) VALUES (@id, @namaPinjam, @jumlahPinjam, @tanggalPinjam)";

                                                    using (MySqlConnection connection = GetConnection1()){ //query update data (utama)
                                                        connection.Open();
                                                        using(var update = connection.BeginTransaction()){
                                                            try{
                                                                using (MySqlCommand command = new MySqlCommand(query, connection, update)){
                                                                    command.Parameters.AddWithValue("@id", idPinjam);
                                                                    command.Parameters.AddWithValue("@jumlahPinjam",jumlahPinjam);
                                                                    command.Parameters.AddWithValue("@tanggalPinjam", tanggalPinjam);
                                                                    try{
                                                                        int rowsAffected = command.ExecuteNonQuery();
                                                                        if (rowsAffected > 0){
                                                                            Console.Write("\nData asset berhasil diupdate dan ");
                                                                        }
                                                                        else{
                                                                            Console.WriteLine("\nData tidak ditemukan atau gagal diubah.\n");
                                                                        }
                                                                        // LihatDataAsset();
                                                                    }
                                                                    catch (Exception ex){
                                                                        Console.WriteLine("\nTerjadi kesalahan: " + ex.Message);
                                                                    }
                                                                }
                                                                update.Commit();
                                                            }
                                                            catch(Exception ex){
                                                                update.Rollback();
                                                                Console.WriteLine("\nTerjadi kesalahan: " + ex.Message);
                                                            }
                                                        }
                                                    }
                                                    using (MySqlConnection connection1 = GetConnection2()){ //query add data2 (riwayat)
                                                            connection1.Open();
                                                            using(var update1 = connection1.BeginTransaction()){
                                                                try{
                                                                    using (MySqlCommand command1 = new MySqlCommand(query1, connection1, update1)){
                                                                        command1.Parameters.AddWithValue("@id", idPinjam);
                                                                        command1.Parameters.AddWithValue("@namaPinjam",namaPinjam);
                                                                        command1.Parameters.AddWithValue("@jumlahPinjam",jumlahPinjam);
                                                                        command1.Parameters.AddWithValue("@tanggalPinjam", tanggalPinjam);
                                                                        try{
                                                                            int rowsAffected = command1.ExecuteNonQuery(); 
                                                                            if (rowsAffected > 0){
                                                                                Console.WriteLine("\ntelah ditambahkan ke riwayat!");
                                                                            }
                                                                            else{
                                                                                Console.WriteLine("\nData tidak ditemukan atau gagal diubah.\n");
                                                                            }
                                                                            // LihatDataAsset();
                                                                        }
                                                                        catch (Exception ex){
                                                                            Console.WriteLine("\nTerjadi kesalahan: " + ex.Message);
                                                                        }
                                                                    }
                                                                    update1.Commit();
                                                                }
                                                                catch(Exception ex){
                                                                    update1.Rollback();
                                                                    Console.WriteLine("\nTerjadi kesalahan: " + ex.Message);
                                                                }
                                                            }
                                                        }
                                                    keluar5 = true;
                                                break;
                                                case 2: // Tidak
                                                    Console.WriteLine($"\nPeminjaman Asset ID {idPinjam} tidak dilakukan.");
                                                    keluar5 = false;
                                                break;
                                                case 3: // Keluar
                                                    keluar5 = true;
                                                break;
                                            }
                                        }
                                    break;
                                    case 2: // Pengembalian asset
                                        static MySqlConnection GetConnection3(){ // Connection Update data
                                            string connectionString = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                            MySqlConnection connection = new MySqlConnection(connectionString);
                                            return connection;
                                        }
                                        static MySqlConnection GetConnection4(){ // Connection Update data
                                            string connectionString1 = "Server=localhost;Database=inventaris;Uid=root;Pwd=;";
                                            MySqlConnection connection1 = new MySqlConnection(connectionString1);
                                            return connection1;
                                        }
                                        bool keluar7 = false;
                                        while (!keluar7){
                                            riwayat();
                                            Console.WriteLine("\n============ Fitur Pengembalian Asset ============");

                                            Console.Write("\nMasukkan Id Peminjaman Asset: ");
                                            int idPeminjaman = int.Parse(Console.ReadLine());
                                            Console.Write("Masukkan Tanggal Hari Ini: ");
                                            string tanggalKembali = Console.ReadLine();

                                            Console.WriteLine($"\nApakah Anda yakin ingin mengembalikan Asset dengan Id Peminjaman {idPeminjaman}?");
                                            Console.WriteLine("1. Ya");
                                            Console.WriteLine("2. Tidak");
                                            Console.WriteLine("3. kembali Ke Menu Awal");
                                            Console.Write("Masukkan Pilihan: ");
                                            int jawaban = int.Parse(Console.ReadLine());

                                            switch (jawaban){
                                                case 1:
                                                    // Get details of the asset being returned from "data2"
                                                    string queryPeminjaman = "SELECT Id, Id_Barang, Kuantitas FROM data2 WHERE id = @idPeminjaman";
                                                    int idAssetDikembalikan = 0;
                                                    int jumlahDikembalikan = 0;

                                                    using (MySqlConnection connection5 = GetConnection3()){
                                                        connection5.Open();
                                                        using (MySqlCommand command3 = new MySqlCommand(queryPeminjaman, connection5))
                                                        {
                                                            command3.Parameters.AddWithValue("@idPeminjaman", idPeminjaman);

                                                            using (var reader = command3.ExecuteReader())
                                                            {
                                                                if (reader.HasRows)
                                                                {
                                                                    reader.Read();
                                                                    idAssetDikembalikan = (int)reader["Id_Barang"];
                                                                    jumlahDikembalikan = (int)reader["Kuantitas"];
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine($"\nId Peminjaman {idPeminjaman} tidak ditemukan di data peminjaman.");
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }

                                                    // Update quantity in "data" table
                                                    string queryUpdate = "UPDATE data SET Kuantitas = kuantitas + @jumlahDikembalikan, Tanggal = @tanggalKembali WHERE id = @idAssetDikembalikan";

                                                    using (MySqlConnection connection = GetConnection4())
                                                    {
                                                        connection.Open();
                                                        using (var update = connection.BeginTransaction())
                                                        {
                                                            try
                                                            {
                                                                using (MySqlCommand command = new MySqlCommand(queryUpdate, connection, update))
                                                                {
                                                                    command.Parameters.AddWithValue("@idAssetDikembalikan", idAssetDikembalikan);
                                                                    command.Parameters.AddWithValue("@jumlahDikembalikan", jumlahDikembalikan);
                                                                    command.Parameters.AddWithValue("@tanggalKembali", tanggalKembali);

                                                                    int rowsAffected = command.ExecuteNonQuery();
                                                                    if (rowsAffected > 0)
                                                                    {
                                                                        Console.WriteLine($"\nAsset dengan Id Asset {idAssetDikembalikan} berhasil dikembalikan.");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine($"\nGagal mengembalikan Asset dengan Id Barang {idAssetDikembalikan}.");
                                                                    }
                                                                }

                                                                // Delete record from "data2" table
                                                                string queryDelete = "DELETE FROM data2 WHERE id = @idPeminjaman";
                                                                using (MySqlCommand command = new MySqlCommand(queryDelete, connection, update))
                                                                {
                                                                    command.Parameters.AddWithValue("@idPeminjaman", idPeminjaman);
                                                                    command.ExecuteNonQuery();
                                                                }

                                                                update.Commit();
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                update.Rollback();
                                                                Console.WriteLine($"\nTerjadi kesalahan: {ex.Message}\n{ex.StackTrace}");
                                                            }
                                                        }
                                                    }
                                                    keluar7 = true;
                                                break;
                                                case 2:
                                                    Console.WriteLine($"\nPengembalian Asset dengan Id Peminjaman {idPeminjaman} dibatalkan.");
                                                    keluar7 = false;
                                                break;
                                                case 3:
                                                    keluar7 = true;
                                                break;
                                                
                                                default:
                                                    Console.WriteLine("\nInput tidak valid. Silahkan masukkan pilihan yang tersedia.");
                                                break;
                                            }
                                        }
                                    break;
                                    case 3: // Cek riwayat
                                        riwayat();
                                    break;
                                    case 4: // Kembali Ke Menu Awal
                                        kembali = true;
                                    break;
                                }
                            }
                            break;
                        case 0:
                            Console.WriteLine("\nTerima kasih sudah menggunakan Aplikasi Kami!");
                            Menu=true;
                            break;
                        default:
                            Console.WriteLine("\nPilihan tidak valid!");
                            break;
                    }
                }
                catch(FormatException e){
                    Console.WriteLine("\nInput Tidak Valid, Silahkan Coba Lagi!");
                }
                catch(OverflowException e){
                    Console.WriteLine("\nInput Terlalu Banyak Karakter, Silahkan Coba Lagi!");
                }
            }
        }
        //Dibawah ini kurawal tetap, tidak perlu ada yang diubah 
    }
}