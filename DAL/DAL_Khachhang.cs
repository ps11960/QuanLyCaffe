using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachHang : DbConnect
    {
        // Lấy toàn bộ khách hàng
        public DataTable getKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("DanhSachKhach", _conn);
            DataTable dtKhachHang = new DataTable();
            da.Fill(dtKhachHang);
            return dtKhachHang;
        }
        public DataTable TimKiemKhachHang(string sdt)
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC SearchKhach '" + sdt + "'", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool ThemKhachHang(DTO_KhachHang kh, string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDataIntoTblKhach";
                cmd.Parameters.AddWithValue("dienThoai", kh.dienThoai);
                cmd.Parameters.AddWithValue("tenKhach", kh.tenKH);
                cmd.Parameters.AddWithValue("diaChi", kh.diaChi);
                cmd.Parameters.AddWithValue("phai", kh.phai);
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
        public bool XoaKhachHang(string sdt)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataFromtblKhach";
                cmd.Parameters.AddWithValue("dienthoai", sdt);
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
        public bool SuaThongTinKhachHang(string sdt, string tenkhach, string diachi, string phai)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDataIntoTblKhach";
                cmd.Parameters.AddWithValue("dienThoai", sdt);
                cmd.Parameters.AddWithValue("tenKhach", tenkhach);
                cmd.Parameters.AddWithValue("diaChi", diachi);
                cmd.Parameters.AddWithValue("phai", phai);
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
    }
}
