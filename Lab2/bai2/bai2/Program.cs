using System;
using System.Collections.Generic;

struct MatHang
{
    public int MaMH;
    public string TenMH;
    public int SoLuong;
    public float DonGia;

    public MatHang(int maMH, string tenMH, int soLuong, float donGia)
    {
        MaMH = maMH;
        TenMH = tenMH;
        SoLuong = soLuong;
        DonGia = donGia;
    }

    public float ThanhTien()
    {
        return SoLuong * DonGia;
    }

    public override string ToString()
    {
        return $"Ma: {MaMH}, Ten: {TenMH}, SL: {SoLuong}, Gia: {DonGia}, Thanh Tien: {ThanhTien()}";
    }
}

class Program
{
    static List<MatHang> danhSachMH = new List<MatHang>();

    static void Main()
    {
        while (true)
        {
            Console.Write("Nhap ma mat hang: ");
            int maMH = int.Parse(Console.ReadLine());

            Console.Write("Nhap ten mat hang: ");
            string tenMH = Console.ReadLine();

            Console.Write("Nhap so luong: ");
            int soLuong = int.Parse(Console.ReadLine());

            Console.Write("Nhap don gia: ");
            float donGia = float.Parse(Console.ReadLine());

            danhSachMH.Add(new MatHang(maMH, tenMH, soLuong, donGia));

            Console.Write("Ban co muon tiep tuc nhap (y/n)? ");
            if (Console.ReadLine().ToLower() != "y") break;
        }

        Console.WriteLine("\nDanh sach mat hang:");
        InDanhSach();

        Console.Write("\nNhap ma mat hang can tim/xoa: ");
        int maCanXoa = int.Parse(Console.ReadLine());

        if (XoaMatHang(maCanXoa))
        {
            Console.WriteLine("\nDanh sach sau khi xoa:");
            InDanhSach();
        }
        else
        {
            Console.WriteLine("Khong tim thay mat hang!");
        }
    }

    static void InDanhSach()
    {
        foreach (var mh in danhSachMH)
        {
            Console.WriteLine(mh);
        }
    }

    static bool XoaMatHang(int maMH)
    {
        int count = danhSachMH.RemoveAll(mh => mh.MaMH == maMH);
        return count > 0;
    }
}