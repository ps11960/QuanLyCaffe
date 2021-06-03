using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalKhachHang = new DAL_KhachHang();
        public DataTable getKhachHang()
        {
            return dalKhachHang.getKhachHang();
        }
        public DataTable TimKiemKhachHang(string sdt)
        {
            return dalKhachHang.TimKiemKhachHang(sdt);
        }
        public bool ThemKhachHang(DTO_KhachHang kh, string email)
        {
            return dalKhachHang.ThemKhachHang(kh, email);
        }
        public bool XoaKhachHang(string sdt)
        {
            return dalKhachHang.XoaKhachHang(sdt);
        }
        public bool SuaThongTinKhachHang(string sdt, string tenkhach, string diachi, string phai)
        {
            return dalKhachHang.SuaThongTinKhachHang(sdt, tenkhach, diachi, phai);
        }
    }
}
