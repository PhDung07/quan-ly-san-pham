using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLySanPham
{
    // Interface: dùng để khuyến khích tính đa hình và trừu tượng hóa hành vi tính giá bán
    public interface ITinhGia
    {
        double TinhGiaBan();
    }

    // Lớp cha abstract: đóng gói + kế thừa + đa hình + static
    public abstract class SanPham : ITinhGia
    {
        private string maSP;
        private string tenSP;
        private string mauSac;
        private double giaCoBan;

        // Static field - dùng chung cho tất cả đối tượng
        private static int soLuongSanPham = 0;

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

        // Static property
        public static int SoLuongSanPham
        {
            get { return soLuongSanPham; }
        }

        public SanPham()
        {
            maSP = "";
            tenSP = "";
            mauSac = "";
            giaCoBan = 0;
            soLuongSanPham++;
        }

        public SanPham(string maSP, string tenSP, string mauSac, double giaCoBan)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.mauSac = mauSac;
            this.giaCoBan = giaCoBan;
            soLuongSanPham++;
        }

        ~SanPham()
        {
            soLuongSanPham--;
            Console.WriteLine($"[Destructor] Xóa sản phẩm: {tenSP}");
        }

        // Abstract method - đa hình
        public abstract double TinhGiaBan();

        // Static method - dùng chung cho tất cả đối tượng
        public static void HienThiSoLuong()
        {
            Console.WriteLine($"Tổng số sản phẩm hiện có: {soLuongSanPham}");
        }

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

        public virtual void Xuat()
        {
            Console.WriteLine($"Mã SP: {maSP}");
            Console.WriteLine($"Tên SP: {tenSP}");
            Console.WriteLine($"Màu sắc: {mauSac}");
            Console.WriteLine($"Giá cơ bản: {giaCoBan:N0} VNĐ");
            Console.WriteLine($"Giá bán: {TinhGiaBan():N0} VNĐ");
        }
    }

    // Lớp dẫn xuất TiVi - kế thừa SanPham
    public class TiVi : SanPham
    {
        private double kichThuoc;

        public double KichThuoc
        {
            get { return kichThuoc; }
            set { kichThuoc = value; }
        }

        public TiVi() : base()
        {
            kichThuoc = 0;
        }

        public TiVi(string maSP, string tenSP, string mauSac, double giaCoBan, double kichThuoc)
            : base(maSP, tenSP, mauSac, giaCoBan)
        {
            this.kichThuoc = kichThuoc;
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập kích thước TV (inch): ");
            kichThuoc = double.Parse(Console.ReadLine());
        }

        // Đa hình: Tính giá bán riêng cho TiVi
        // Giá bán Ti vi = giá cơ bản + Kích thước * 0.1
        public override double TinhGiaBan()
        {
            return GiaCoBan + kichThuoc * 0.1;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Kích thước: {kichThuoc} inch");
        }
    }

    // Lớp dẫn xuất DienThoai - kế thừa SanPham
    public class DienThoai : SanPham
    {
        private double boNho;

        public double BoNho
        {
            get { return boNho; }
            set { boNho = value; }
        }

        public DienThoai() : base()
        {
            boNho = 0;
        }

        public DienThoai(string maSP, string tenSP, string mauSac, double giaCoBan, double boNho)
            : base(maSP, tenSP, mauSac, giaCoBan)
        {
            this.boNho = boNho;
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập b�� nhớ điện thoại (GB): ");
            boNho = double.Parse(Console.ReadLine());
        }

        // Đa hình: Tính giá bán riêng cho Điện thoại
        // Giá điện thoại = giá cơ bản + Bộ nhớ * 0.2
        public override double TinhGiaBan()
        {
            return GiaCoBan + boNho * 0.2;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Bộ nhớ: {boNho} GB");
        }
    }

    // Lớp dẫn xuất MayLanh - kế thừa SanPham
    public class MayLanh : SanPham
    {
        private double congSuat;

        public double CongSuat
        {
            get { return congSuat; }
            set { congSuat = value; }
        }

        public MayLanh() : base()
        {
            congSuat = 0;
        }

        public MayLanh(string maSP, string tenSP, string mauSac, double giaCoBan, double congSuat)
            : base(maSP, tenSP, mauSac, giaCoBan)
        {
            this.congSuat = congSuat;
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập công suất máy lạnh (HP): ");
            congSuat = double.Parse(Console.ReadLine());
        }

        // Đa hình: Tính giá bán riêng cho Máy lạnh
        // Giá máy lạnh = giá cơ bản + công suất * 0.1
        public override double TinhGiaBan()
        {
            return GiaCoBan + congSuat * 0.1;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Công suất: {congSuat} HP");
        }
    }

    // Lớp CongTy - chứa danh sách sản phẩm
    public class CongTy
    {
        private string tenCongTy;
        private List<SanPham> danhSachSanPham;

        // Static field - đếm tổng số công ty
        private static int soLuongCongTy = 0;

        public string TenCongTy
        {
            get { return tenCongTy; }
            set { tenCongTy = value; }
        }

        public List<SanPham> DanhSachSanPham
        {
            get { return danhSachSanPham; }
            set { danhSachSanPham = value; }
        }

        // Static property
        public static int SoLuongCongTy
        {
            get { return soLuongCongTy; }
        }

        public CongTy()
        {
            tenCongTy = "";
            danhSachSanPham = new List<SanPham>();
            soLuongCongTy++;
        }

        public CongTy(string tenCongTy)
        {
            this.tenCongTy = tenCongTy;
            danhSachSanPham = new List<SanPham>();
            soLuongCongTy++;
        }

        ~CongTy()
        {
            Console.WriteLine($"[Destructor] Xóa công ty: {tenCongTy}");
        }

        public void ThemSanPham(SanPham sp)
        {
            danhSachSanPham.Add(sp);
            Console.WriteLine($"Đã thêm sản phẩm: {sp.TenSP}");
        }

        public void NhapDanhSach()
        {
            Console.Write("\nNhập tên công ty: ");
            tenCongTy = Console.ReadLine();

            Console.Write("Nhập số lượng sản phẩm: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Sản phẩm thứ {i + 1} ---");
                Console.WriteLine("Chọn loại sản phẩm:");
                Console.WriteLine("1. TiVi");
                Console.WriteLine("2. Điện thoại");
                Console.WriteLine("3. Máy lạnh");
                Console.Write("Lựa chọn (1-3): ");

                int chon = int.Parse(Console.ReadLine());

                SanPham sp = null;

                switch (chon)
                {
                    case 1:
                        sp = new TiVi();
                        break;
                    case 2:
                        sp = new DienThoai();
                        break;
                    case 3:
                        sp = new MayLanh();
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        i--;
                        continue;
                }

                sp.Nhap();
                danhSachSanPham.Add(sp);
            }
        }

        public void XuatDanhSach()
        {
            Console.WriteLine($"\n╔════════════════════════════════════════╗");
            Console.WriteLine($"║  CÔNG TY: {tenCongTy,-30} ║");
            Console.WriteLine($"╚════════════════════════════════════════╝");
            Console.WriteLine($"Số lượng sản phẩm: {danhSachSanPham.Count}");

            if (danhSachSanPham.Count == 0)
            {
                Console.WriteLine("Danh sách sản phẩm trống!");
                return;
            }

            foreach (var sp in danhSachSanPham)
            {
                Console.WriteLine("\n───────────────────────────────────────");
                sp.Xuat();
            }
            Console.WriteLine("═══════════════════════════════════════");
        }

        // Instance method - sắp xếp danh sách của công ty này
        public void SapXepTheoGiaBan()
        {
            danhSachSanPham = danhSachSanPham.OrderBy(sp => sp.TinhGiaBan()).ToList();
            Console.WriteLine("Danh sách đã được sắp xếp theo giá bán (tăng dần)");
        }

        // Static method - sắp xếp danh sách tĩnh được truyền vào
        public static void SapXepTheoGiaBan(List<SanPham> ds)
        {
            var dsSorted = ds.OrderBy(sp => sp.TinhGiaBan()).ToList();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║  DANH SÁCH SẢN PHẨM (Sắp xếp theo giá) ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            foreach (var sp in dsSorted)
            {
                Console.WriteLine($"{sp.TenSP,-20} - {sp.TinhGiaBan():N0} VNĐ");
            }
        }

        // Static method - hiển thị tổng số công ty
        public static void HienThiSoLuongCongTy()
        {
            Console.WriteLine($"Tổng số công ty: {soLuongCongTy}");
        }

        // Static method - tính giá trung bình của danh sách sản phẩm
        public static double TinhGiaTriBinhQuanTinh(List<SanPham> ds)
        {
            if (ds.Count == 0) return 0;
            return ds.Sum(sp => sp.TinhGiaBan()) / ds.Count;
        }

        // Tìm sản phẩm có giá bán cao nhất
        public SanPham TimSanPhamGiaCaoNhat()
        {
            if (danhSachSanPham.Count == 0) return null;
            return danhSachSanPham.OrderByDescending(sp => sp.TinhGiaBan()).FirstOrDefault();
        }

        // Static method - tìm sản phẩm có giá bán thấp nhất
        public static SanPham TimSanPhamGiaThapNhat(List<SanPham> ds)
        {
            if (ds.Count == 0) return null;
            return ds.OrderBy(sp => sp.TinhGiaBan()).FirstOrDefault();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║  CHƯƠNG TRÌNH QUẢN LÝ SẢN PHẨM         ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            CongTy congTy = new CongTy();
            congTy.NhapDanhSach();

            Console.WriteLine("\n\n╔════════════════════════════════════════╗");
            Console.WriteLine("║  DANH SÁCH SẢN PHẨM (Trước sắp xếp)    ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            congTy.XuatDanhSach();

            // Sắp xếp danh sách
            congTy.SapXepTheoGiaBan();

            Console.WriteLine("\n\n╔═════════════��══════════════════════════╗");
            Console.WriteLine("║  DANH SÁCH SẢN PHẨM (Sau sắp xếp)      ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            congTy.XuatDanhSach();

            // Gọi static method - hiển thị số lượng sản phẩm
            Console.WriteLine("\n");
            SanPham.HienThiSoLuong();
            CongTy.HienThiSoLuongCongTy();

            // Gọi static method - sắp xếp danh sách
            CongTy.SapXepTheoGiaBan(congTy.DanhSachSanPham);

            // Gọi static method - tính giá trị bình quân
            Console.WriteLine($"\nGiá trị bình quân sản phẩm: {CongTy.TinhGiaTriBinhQuanTinh(congTy.DanhSachSanPham):N0} VNĐ");

            // Tìm sản phẩm có giá cao nhất
            var spCaoNhat = congTy.TimSanPhamGiaCaoNhat();
            if (spCaoNhat != null)
            {
                Console.WriteLine($"Sản phẩm có giá cao nhất: {spCaoNhat.TenSP} - {spCaoNhat.TinhGiaBan():N0} VNĐ");
            }

            // Gọi static method - tìm sản phẩm có giá thấp nhất
            var spThapNhat = CongTy.TimSanPhamGiaThapNhat(congTy.DanhSachSanPham);
            if (spThapNhat != null)
            {
                Console.WriteLine($"Sản phẩm có giá thấp nhất: {spThapNhat.TenSP} - {spThapNhat.TinhGiaBan():N0} VNĐ");
            }

            Console.WriteLine("\n═══════════════════════════════════════");
            Console.WriteLine("Kết thúc chương trình!");
        }
    }
}
