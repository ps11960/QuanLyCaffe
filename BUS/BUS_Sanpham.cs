using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_SanPham
    {
        DAL_SanPham dalSanPham = new DAL_SanPham();
        public DataTable getSanPham()
        {
            return dalSanPham.getSanPham();
        }
        public bool ThemHangHoa(DTO_Hang hang, string email)
        {
            return dalSanPham.ThemHangHoa(hang, email);
        }
        public DataTable TimKiemHang(string tenhang)
        {
            return dalSanPham.TimKiemHang(tenhang);
        }
        public bool XoaHang(string mahang)
        {
            return dalSanPham.Xoahang(mahang);
        }
        public bool SuaThongTinHang(int mahang, string tenhang, int soluong, string dongianhap, string dongiaban, string hinhanh, string ghichu)
        {
            return dalSanPham.SuaThongTinHang(mahang, tenhang, soluong, dongianhap, dongiaban, hinhanh, ghichu);
        }
        public DataTable TKho()
        {
            return dalSanPham.TKho();
        }
        public DataTable ThongKeHang()
        {
            return dalSanPham.ThongKeHang();
        }
    }
}
