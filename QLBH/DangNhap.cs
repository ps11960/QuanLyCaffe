using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLBH
{
    public partial class DangNhap : Form
    {
        BUS_Nhanvien busNhanvien = new BUS_Nhanvien();
        //public string vaitro { get; set; }
        public string matkhau { get; set; }

        public string RandomString(int size, bool lowercase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowercase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public int RandomNumber(int min,int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void Sendmail(string email, string matkhau)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                NetworkCredential cred = new NetworkCredential("maitheanhtt@gmail.com", "gokuala123");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("maitheanhtt@gmail.com");
                msg.To.Add(email);
                msg.Subject = "Ban da su dung tinh nang quen mat khau";
                msg.Body = "Chào anh/chị. Mật khẩu mới truy cập phần mềm là: " + matkhau;
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(msg);
                MessageBox.Show("Một mail phục hồi đã được gửi tới bạn!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(txtEmail.Text != "")
            {
                if (busNhanvien.Nhanvienquenmatkhau(txtEmail.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(4, true));
                    builder.Append(RandomNumber(1000, 9999));
                    builder.Append(RandomString(2, false));
                    MessageBox.Show(builder.ToString());
                    string matkhaumoi = busNhanvien.encryption(builder.ToString());
                    busNhanvien.Taomatkhau(txtEmail.Text, matkhaumoi);
                    Sendmail(txtEmail.Text, builder.ToString());

                }
                else { MessageBox.Show("Email khong ton tai, vui long nhap email"); }
            }
            else
            {
                MessageBox.Show("Vui long nhap email muon khoi phuc!");
                txtEmail.Focus();
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btDangnhap_Click(object sender, EventArgs e)
        {
            DTO_Nhanvien nv = new DTO_Nhanvien();
            nv.EmailNV = txtEmail.Text;
            nv.MatKhau = busNhanvien.encryption(txtMatkhau.Text);
            if (busNhanvien.Nhanviendangnhap(nv))
            {
                GiaoDienChinh.mail = nv.EmailNV;
                GiaoDienChinh.session = 1;
                string dt = busNhanvien.Vaitronhanvien(nv.EmailNV);
                //vaitro = dt;
                GiaoDienChinh.vaitro = dt;
                MessageBox.Show("Đăng nhập thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công, hãy kiểm tra lại");
                txtEmail.Text = null;
                txtMatkhau.Text = null;
                txtEmail.Focus();
            }
        }

        public void Dangnhap_closed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
