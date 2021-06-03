using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL 
{
    public class DAL_SanPham : DbConnect
    {
        public DataTable getSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("DanhSachHang", _conn); // Thực thi Procedure tên "DanhSachNV" trong SQL Sever
            DataTable dtHangHoa = new DataTable(); // Tạo bảng mới
            da.Fill(dtHangHoa); // Fill dữ liệu vào bảng
            return dtHangHoa; // Trả kết quả về bảng
        }
        public bool ThemHangHoa(DTO_Hang hang, string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDataIntoTblHang";
                cmd.Parameters.AddWithValue("tenHang", hang.tenHang);
                cmd.Parameters.AddWithValue("soLuong", hang.soLuong);
                cmd.Parameters.AddWithValue("donGiaNhap", hang.donGiaNhap);
                cmd.Parameters.AddWithValue("donGiaBan", hang.donGiaXuat);
                cmd.Parameters.AddWithValue("hinhAnh", hang.hinhAnh);
                cmd.Parameters.AddWithValue("ghiChu", hang.ghiChu);
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable TimKiemHang(string tenhang)
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC SearchHang '" + tenhang + "'", _conn);
            DataTable dtHang = new DataTable();
            da.Fill(dtHang);
            return dtHang;
        }
        public bool Xoahang(string mahang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataFromtblHang";
                cmd.Parameters.AddWithValue("maHang", mahang);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool SuaThongTinHang(int mahang, string tenhang, int soluong, string dongianhap, string dongiaban, string hinhanh, string ghichu)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDataIntoTblHang";
                cmd.Parameters.AddWithValue("maHang", mahang);
                cmd.Parameters.AddWithValue("tenHang", tenhang);
                cmd.Parameters.AddWithValue("soLuong", soluong);
                cmd.Parameters.AddWithValue("donGiaNhap", dongianhap);
                cmd.Parameters.AddWithValue("donGiaBan", dongiaban);
                cmd.Parameters.AddWithValue("hinhAnh", hinhanh);
                cmd.Parameters.AddWithValue("ghiChu", ghichu);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable ThongKeHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeSP";
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable TKho()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeTonKho";
                DataTable dtTonKho = new DataTable();
                dtTonKho.Load(cmd.ExecuteReader());
                return dtTonKho;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
