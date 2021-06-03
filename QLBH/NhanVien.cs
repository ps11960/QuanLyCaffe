using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLBH
{
    public partial class NhanVien : Form
    {
        GiaoDienChinh frmain = new GiaoDienChinh();
        BUS_Nhanvien busNhanvien = new BUS_Nhanvien();
        public NhanVien( string email)
        {
            InitializeComponent();
        }
        private void loaddata()
        {
            DataSet dts = new DataSet();
            dts = busNhanvien.Danhsachnv();
            dataGridView1.DataSource = dts.Tables["tblNhanvien"];
        }
        private void Resetvalue()
        {
            txtTimkiem.Text = "Nhập tên nhân viên";
            txtEmail.Text = null;
            txtTennv.Text = null;
            txtDiachi.Text = null;
            txtEmail.Enabled = false;
            txtTennv.Enabled = false;
            txtDiachi.Enabled = false;
            rbNhanvien.Enabled = false;
            rbQuantri.Enabled = false;
            rbHoatdong.Enabled = false;
            rbNgunghd.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = true;
        }
        public bool Isvalid(string emailadd)
        {
            try
            {
                MailAddress m = new MailAddress(emailadd);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtEmail.Text = null;
            txtTennv.Text = null;
            txtDiachi.Text = null;
            txtEmail.Enabled = true;
            txtTennv.Enabled = true;
            txtDiachi.Enabled = true;
            rbNhanvien.Enabled = true;
            rbQuantri.Enabled = true;
            rbHoatdong.Enabled = true;
            rbNgunghd.Enabled = true;
            btnLuu.Enabled = true;
            btnDong.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            rbNhanvien.Checked = false;
            rbQuantri.Checked = false;
            rbHoatdong.Checked = false;
            rbNgunghd.Checked = false;
            txtEmail.Focus();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            loaddata();
            Resetvalue();
        }

        public void Frmthongtin_close(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            frmain.GiaoDienChinh_Load(sender, e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if(MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busNhanvien.Delnhanvien(email))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    Resetvalue();
                    loaddata();
                }
                else { MessageBox.Show("Xóa không thành công"); }
            }
            else { Resetvalue(); }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int role = 1;
            if (rbQuantri.Checked) role = 0;
            int tt = 0;
            if (rbHoatdong.Checked) tt = 1;
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email!");
                txtEmail.Focus();
                return;
            }
            else if (!Isvalid(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email không hợp lệ");
                txtEmail.Focus();
                return;
            }
            if (txtTennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên!");
                txtTennv.Focus();
                return;
            }
            else if (txtDiachi.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ!");
                txtDiachi.Focus();
                return;
            }
            if (rbQuantri.Checked == false && rbNhanvien.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn chức vụ!");
                return;
            }
            if (rbHoatdong.Checked == false && rbNgunghd.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn trạng thái!");
                return;
            }
            else
            {
                DTO_Nhanvien nv = new DTO_Nhanvien(txtEmail.Text,txtTennv.Text,txtDiachi.Text,role,tt);
                if (busNhanvien.Insnhanvien(nv))
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    Resetvalue();
                    loaddata();
                    //SendMailnv(nv.EmailNV);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvNhanvien_click(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                btnLuu.Enabled = false;
                txtTennv.Enabled = true;
                txtDiachi.Enabled = true;
                rbQuantri.Enabled = true;
                rbNhanvien.Enabled = true;
                rbHoatdong.Enabled = true;
                rbNgunghd.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
                txtTennv.Text = dataGridView1.CurrentRow.Cells["Tennv"].Value.ToString();
                txtDiachi.Text = dataGridView1.CurrentRow.Cells["diachi"].Value.ToString();
                if (int.Parse(dataGridView1.CurrentRow.Cells["vaitro"].Value.ToString()) == 1)
                    rbQuantri.Checked = true;
                else 
                    rbNhanvien.Checked = false;
                if (int.Parse(dataGridView1.CurrentRow.Cells["tinhtrang"].Value.ToString()) == 1)
                    rbHoatdong.Checked = true;
                else
                    rbNgunghd.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên!");
                txtTennv.Focus();
                return;
            }
            else if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ!");
                txtDiachi.Focus();
                return;
            }
            else
            {
                int role = 1;
                if (rbQuantri.Checked) role = 0;
                int tt = 0;
                if (rbHoatdong.Checked) tt = 1;
                DTO_Nhanvien nv = new DTO_Nhanvien(txtEmail.Text, txtTennv.Text, txtDiachi.Text, role, tt);
                if (MessageBox.Show("Bạn có chắc muốn sửa", "Comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busNhanvien.Upnhanvien(nv))
                    {
                        MessageBox.Show("Sửa thành công!");
                        Resetvalue();
                        loaddata();
                    }
                    else { MessageBox.Show("Sửa ko thành công"); }
                }
                else { Resetvalue(); }
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            Resetvalue();
            loaddata();
        }

        private void btnDanhsach_Click(object sender, EventArgs e)
        {
            Resetvalue();
            loaddata();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (txtTimkiem.Text == "")
            {
                MessageBox.Show("Chưa nhập tên nhân viên!");
            }
            else
            {
                dataGridView1.DataSource = busNhanvien.Searchnhanvien(txtTimkiem.Text);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
