using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Nhanvien
    {
        DAL_Nhanvien dalNhanvien = new DAL_Nhanvien();
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
        public bool Nhanviendangnhap(DTO_Nhanvien nv)
        {
            return dalNhanvien.Nhanviendangnhap(nv);
        }
        public bool Nhanvienquenmatkhau(string email)
        {
            return dalNhanvien.Nhanvienquenmatkhau(email);
        }
        public bool UpdateMatkhau(string email, string matkhauCu, string matkhauMoi)
        {
            return dalNhanvien.UpdateMatkhau(email, matkhauCu, matkhauMoi);
        }
        public string Vaitronhanvien(string email)
        {
            return dalNhanvien.Vaitronhanvien(email);
        }
        public bool Taomatkhau(string email, string matkhau)
        {
            return dalNhanvien.Taomatkhau(email, matkhau);
        }
        public DataSet Danhsachnv()
        {
            return dalNhanvien.Danhsachnv();
        }
        public bool Delnhanvien(string email)
        {
            return dalNhanvien.Delnhanvien(email);
        }
        public bool Insnhanvien(DTO_Nhanvien nv)
        {
            return dalNhanvien.Insnhanvien(nv);
        }
        public bool Upnhanvien(DTO_Nhanvien nv)
        {
            return dalNhanvien.Upnhanvien(nv);
        }
        public DataTable Searchnhanvien(string tennv)
        {
            return dalNhanvien.Searchnhanvien(tennv);
        }
    }
}
