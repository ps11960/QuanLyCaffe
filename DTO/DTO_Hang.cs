using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Hang
    {
        private int MaHang;
        private string TenHang;
        private int SoLuong;
        private float DonGiaNhap;
        private float DonGiaXuat;
        private string HinhAnh;
        private string GhiChu;
        private string MaNV;

        public int maHang { get => MaHang; set => MaHang = value; }
        public string tenHang { get => TenHang; set => TenHang = value; }
        public int soLuong { get => SoLuong; set => SoLuong = value; }
        public float donGiaNhap { get => DonGiaNhap; set => DonGiaNhap = value; }
        public float donGiaXuat { get => DonGiaXuat; set => DonGiaXuat = value; }
        public string hinhAnh { get => HinhAnh; set => HinhAnh = value; }
        public string ghiChu { get => GhiChu; set => GhiChu = value; }
        public string maNV { get => MaNV; set => MaNV = value; }
    }
}
