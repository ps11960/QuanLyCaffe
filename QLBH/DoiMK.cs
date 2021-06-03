using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QLBH
{
    public partial class DoiMK : Form
    {
        BUS_Nhanvien busNhanvien = new BUS_Nhanvien();
        public DoiMK()
        {
            InitializeComponent();
        }

        private void btnDoimk_Click(object sender, EventArgs e)
        {
            if (txtMkcu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMkcu.Focus();
                return;
            }
            else
            {
                if (txtMkmoi1.Text == txtMkmoi2.Text)
                {
                    DangNhap frmdn = new DangNhap();
                    string matkhaumoi = busNhanvien.encryption(txtMkmoi1.Text);
                    string matkhaucu = busNhanvien.encryption(txtMkcu.Text);
                    if (busNhanvien.UpdateMatkhau(txtEmail.Text, matkhaucu, matkhaumoi))
                    {
                        GiaoDienChinh.profile = 1;
                        GiaoDienChinh.session = 0;
                        frmdn.Sendmail(txtEmail.Text, txtMkmoi2.Text);
                        MessageBox.Show("Cập nhật mật khẩu thành công, bạn cần phải đăng nhập lại!");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập lại mật khẩu không chính xác, vui lòng kiểm tra lại!");
                }
            }
        }

    }
}
