using System;
using System.Threading;

class DongHo
{
    public event EventHandler MoiGiayTroiQua; 
    public DateTime ThoiGian { get; private set; }

    public void BatDau()
    {
        while (true)
        {
            ThoiGian = DateTime.Now;
            MoiGiayTroiQua?.Invoke(this, EventArgs.Empty); 

            Thread.Sleep(1000); 
        }
    }
}

class HienThiThoiGian
{
    public void XuLyMoiGiay(object sender, EventArgs e)
    {
        DongHo dongHo = sender as DongHo;
        Console.WriteLine("Thoi gian hien tai: " + dongHo.ThoiGian);
    }
}

class Program
{
    static void Main()
    {
        DongHo dongHo = new DongHo();
        HienThiThoiGian hienThi = new HienThiThoiGian();

        dongHo.MoiGiayTroiQua += hienThi.XuLyMoiGiay;

        dongHo.BatDau(); 
    }
}