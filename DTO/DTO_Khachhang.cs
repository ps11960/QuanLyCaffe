using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        private string DienThoai;
        private string TenKH;
        private string DiaChi;
        private string Phai;
        private string MaNV;

        public string dienThoai { get => DienThoai; set => DienThoai = value; }
        public string tenKH { get => TenKH; set => TenKH = value; }
        public string diaChi { get => DiaChi; set => DiaChi = value; }
        public string phai { get => Phai; set => Phai = value; }
        public string maNV { get => MaNV; set => MaNV = value; }
    }
}
