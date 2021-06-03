using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Nhanvien
    {
        private string tenNhanvien;
        private string diachi;
        private int vaitro;
        private string emailnv;
        private string matkhau;
        private int tinhtrang;
        public string TenNhanVien
        {
            get { return tenNhanvien; }
            set { tenNhanvien = value; }
        }
        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public int VaiTro
        {
            get { return vaitro; }
            set { vaitro = value; }
        }
        public string EmailNV
        {
            get { return emailnv; }
            set { emailnv = value; }
        }
        public string MatKhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }
        public int TinhTrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }

        public DTO_Nhanvien() { }

        public DTO_Nhanvien(string emailnv, string tennv, string diachi, int vaitro, int tinhtrang)
        {
            this.tenNhanvien = tennv;
            this.diachi = diachi;
            this.vaitro = vaitro;
            this.emailnv = emailnv;
            this.tinhtrang = tinhtrang;
        }
    }
}
