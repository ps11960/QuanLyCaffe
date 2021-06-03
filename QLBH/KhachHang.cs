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
using DTO;

namespace QLBH
{
    public partial class KhachHang : Form
    {
        BUS_KhachHang buskhachhang = new BUS_KhachHang();
        string stremail;
        public KhachHang(string email)
        {
            stremail = email;
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void resetvalue()
        {
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void KhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = buskhachhang.getKhachHang();
            resetvalue();
        }

        public void Frmkhachhang_close(object sender, FormClosedEventArgs e)
        {
            GiaoDienChinh mainload = new GiaoDienChinh();
            this.Refresh();
            mainload.GiaoDienChinh_Load(sender, e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtSodt.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTennv.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            string gender = dataGridView1.Rows[i].Cells[3].Value.ToString();
            if (gender == "1")
            {
                rabtnBoy.Checked = true;
            }
            else raBtnGirl.Checked = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (txtTimkiem.Text == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại khách hàng!");
            }
            else
            {
                dataGridView1.DataSource = buskhachhang.TimKiemKhachHang(txtTimkiem.Text);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DTO_KhachHang kh = new DTO_KhachHang();
            kh.dienThoai = txtSodt.Text;
            kh.tenKH = txtTennv.Text;
            kh.diaChi = textBox1.Text;
            string gender;
            if (rabtnBoy.Checked)
            {
                gender = "1";
            }
            else
            {
                gender = "0";
            }
            kh.phai = gender;
            buskhachhang.ThemKhachHang(kh, stremail);
            MessageBox.Show("Đã thêm khách hàng thành công!");
            resetvalue();
        }

        private void btnDanhsach_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = buskhachhang.getKhachHang();
            resetvalue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            buskhachhang.XoaKhachHang(txtSodt.Text);
            MessageBox.Show("Đã xóa khách hàng");
            resetvalue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gender;
            if (rabtnBoy.Checked)
            {
                gender = "1";
            }
            else gender = "0";
            buskhachhang.SuaThongTinKhachHang(txtSodt.Text, txtTennv.Text, textBox1.Text, gender);
            MessageBox.Show("Đã sửa thông tin khách hàng");
            resetvalue();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            resetvalue();
        }
    }
}
