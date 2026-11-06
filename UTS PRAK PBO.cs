using System;
class Agen
{
    public string idAgen;
    public string namaAgen;
    public int stokAgen;
    public Agen(string idAgen, string namaAgen, int stokAgen)
    {
        idAgen = idAgen;
        namaAgen = namaAgen;
        stokAgen = stokAgen;
    }
    public void TampilInfo()
    {
        Console.WriteLine("ID Agen : " + idAgen);
        Console.WriteLine("Nama Agen : " + namaAgen);
        Console.WriteLine("Stok Agen : " + stokAgen);
    }
}
abstract class ProdukGalon
{
    private string idProduk;
    private string namaProduk;
    private int stokGudang;

    public string IdProduk
    {
        get { return idProduk; }
        set { idProduk = value; }
    }
    public string NamaProduk
    {
        get { return namaProduk; }
        set { namaProduk = value; }
    }
    public int StokGudang
    {
        get { return stokGudang; }
        set
        {
            if (value >= 0)
                stokGudang = value;
            else
                Console.WriteLine("Stok tidak boleh negatif");
        }
    }
    public ProdukGalon(string idProduk, string namaProduk, int stokGudang)
    {
        idProduk = idProduk;
        namaProduk = namaProduk;
        stokGudang = stokGudang;
    }

    public void KurangiStok(int jumlah)
    {
        if (jumlah > 0 = jumlah < stokGudang)
        {
            stokGudang -= jumlah;
        }
        else
        {
            Console.WriteLine("Pengurangan stok tidak valid");
        }
    }
    public abstract int HitungBiaya(int jumlah);
}
class GalonAkua : ProdukGalon
{
    public GalonAkua(string id, string nama, int stok): base(id, nama, stok){}
    public override int HitungBiaya(int jumlah)
    {
        return jumlah * 20000;
    }
}
class GalonBerkeran : ProdukGalon
{
    public GalonBerkeran(string id, string nama, int stok): base(id, nama, stok){}
    public override int HitungBiaya(int jumlah)
    {
        return jumlah * 12000;
    }
}
interface DapatDidistribusikan
{
    void KirimPaket();
}
class DistribusiGalon : DapatDidistribusikan
{
    private Agen agen;
    private ProdukGalon produk;
    private int jumlah;

    public DistribusiGalon(Agen agen, ProdukGalon produk, int jumlah)
    {
        agen = agen;
        produk = produk;
        jumlah = jumlah;
    }
    public void KirimGalon()
    {
        Console.WriteLine("\n--- PROSES DISTRIBUSI ---");
        if (jumlah <= 0)
        {
            Console.WriteLine("Gagal: Jumlah pengiriman harus lebih dari 0.");
            return;
        }
        if (jumlah > produk.StokGudang)
        {
            Console.WriteLine("Gagal: Stok gudang tidak cukup.");
            return;
        }

        Console.WriteLine("Paket berhasil dikirim!");
        Console.WriteLine("Agen : " + agen.namaAgen);
        Console.WriteLine("Produk : " + produk.NamaProduk);
        Console.WriteLine("Jumlah Kiriman : " + jumlah);
        Console.WriteLine("Total Biaya : Rp" + totalBiaya);
        Console.WriteLine("Stok Gudang : " + produk.StokGudang);
        Console.WriteLine("Stok Agen : " + agen.stokAgen);
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("SISTEM DISTRIBUSI GALON");

        Agen agen1 = new Agen("A1", "Andi", 10);
        Agen agen2 = new Agen("A2", "Budi", 5);

        ProdukGalon produk1 = new GalonAkua(
            "PG1", "Galon Akua", 100);

        ProdukGalon produk2 = new GalonBerkeran(
            "PG2", "Galon Berkeran", 80);

        Console.WriteLine("\n===== PERHITUNGAN BIAYA =====");

        ProdukGalon[] daftarProduk = { produk1, produk2 };
        DistribusiGalon distribusi1 =
            new DistribusiGalon(agen1, produk1, 20);

        distribusi1.KirimGalon();
        DistribusiGalon distribusi2 =
            new DistribusiGalon(agen2, produk2, 100);

        distribusi2.KirimGalon();
    }
}
