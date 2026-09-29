using System;

namespace QuanLySanPham
{
    /// <summary>
    /// Interface để tính giá bán
    /// </summary>
    public interface ITinhGia
    {
        double TinhGiaBan();
    }

    /// <summary>
    /// Lớp cơ sở SanPham
    /// </summary>
    public abstract class SanPham : ITinhGia
    {
        private string maSP;
        private string tenSP;
        private string mauSac;
        private double giaCoBan;

        // Properties
        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }

        public string MauSac
        {
            get { return mauSac; }
            set { mauSac = value; }
        }

        public double GiaCoBan
        {
            get { return giaCoBan; }
            set { giaCoBan = value; }
        }

        // Constructor mặc định
        public SanPham()
        {
            maSP = "";
            tenSP = "";
            mauSac = "";
            giaCoBan = 0;
        }

        // Constructor có tham số
        public SanPham(string ma, string ten, string mau, double gia)
        {
            maSP = ma;
            tenSP = ten;
            mauSac = mau;
            giaCoBan = gia;
        }

        // Destructor
        ~SanPham()
        {
            Console.WriteLine($"Xóa sản phẩm: {tenSP}");
        }

        // Abstract method - bắt buộc phải implement ở lớp dẫn xuất
        public abstract double TinhGiaBan();

        // Hàm nhập dữ liệu
        public virtual void Nhap()
        {
            Console.Write("Nhập mã sản phẩm: ");
            maSP = Console.ReadLine();

            Console.Write("Nhập tên sản phẩm: ");
            tenSP = Console.ReadLine();

            Console.Write("Nhập màu sắc: ");
            mauSac = Console.ReadLine();

            Console.Write("Nhập giá cơ bản: ");
            giaCoBan = double.Parse(Console.ReadLine());
        }

        // Hàm xuất dữ liệu
        public virtual void Xuat()
        {
            Console.WriteLine($"Mã SP: {maSP}");
            Console.WriteLine($"Tên SP: {tenSP}");
            Console.WriteLine($"Màu sắc: {mauSac}");
            Console.WriteLine($"Giá cơ bản: {giaCoBan:C}");
        }
    }
}
