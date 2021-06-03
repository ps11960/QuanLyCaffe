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
    public class DAL_Nhanvien : DbConnect
    {
        public bool Nhanviendangnhap(DTO_Nhanvien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DangNhap";
                cmd.Parameters.AddWithValue("email", nv.EmailNV);
                cmd.Parameters.AddWithValue("matkhau", nv.MatKhau);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch (Exception) { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool Nhanvienquenmatkhau(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "QuenMatKhau";
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch (Exception) { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool UpdateMatkhau(string email, string matkhauCu, string matkhauMoi)
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "chgpwd";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@opwd", matkhauCu);
                cmd.Parameters.AddWithValue("@npwd", matkhauMoi);
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
        public bool Taomatkhau(string email, string matkhauMoi)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TaoMatKhauMoi";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@matkhau", matkhauMoi);
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
        public string Vaitronhanvien(string email)
        {
            string vt = "";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayVaiTroNV";
                cmd.Parameters.AddWithValue("@email", email);
                vt = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return vt;
        }
        public DataSet Danhsachnv()
        {
            DataSet datads = new DataSet();
            try
            {
                _conn.Open();
                SqlDataAdapter cn = new SqlDataAdapter("exec DanhSachNV", _conn);
                cn.Fill(datads, "tblNhanVien");
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return datads;
        }
        public bool Delnhanvien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataFromtblNhanvien";
                cmd.Parameters.AddWithValue("email", email);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception) { }
            finally { _conn.Close(); }
            return false;
        }
        public bool Insnhanvien(DTO_Nhanvien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDataIntoTblNhanVien";
                cmd.Parameters.AddWithValue("email", nv.EmailNV);
                cmd.Parameters.AddWithValue("tennv", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("diachi", nv.DiaChi);
                cmd.Parameters.AddWithValue("vaitro", nv.VaiTro);
                cmd.Parameters.AddWithValue("tinhtrang", nv.TinhTrang);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception) { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool Upnhanvien(DTO_Nhanvien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDataIntoTblNhanvien";
                cmd.Parameters.AddWithValue("email", nv.EmailNV);
                cmd.Parameters.AddWithValue("tennv", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("diachi", nv.DiaChi);
                cmd.Parameters.AddWithValue("vaitro", nv.VaiTro);
                cmd.Parameters.AddWithValue("tinhtrang", nv.TinhTrang);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception) { }
            finally { _conn.Close(); }
            return false;
        }
        public DataTable Searchnhanvien(string tennv)
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC SearchNhanVien '" + tennv + "'", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
