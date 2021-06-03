using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class GiaoDienChinh : Form
    {
        public static int session = 0;
        public static int profile = 0;
        public static string vaitro;
        public static string mail;

        
        
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if(frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        public GiaoDienChinh()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Resetvalue()
        {
            if (session == 1)
            {
                Welcome.Text = "Chào " + GiaoDienChinh.mail;
                quảnLýNhânViênToolStripMenuItem.Visible = true;
                danhMụcToolStripMenuItem.Visible = true;
                đăngXuấtToolStripMenuItem.Visible = true;
                sảnPhẩmTồnKhoToolStripMenuItem.Visible = true;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = true;
                hồSơNhânViênToolStripMenuItem.Visible = true;
                đăngNhậpToolStripMenuItem.Visible = false;
                if (vaitro != "0")
                {
                    VaitroNv();
                }
                else
                {
                    quảnLýNhânViênToolStripMenuItem.Visible = true;
                    hồSơNhânViênToolStripMenuItem.Visible = true;
                    thốngKêToolStripMenuItem.Visible = true;
                }
            }
            else
            {
                Welcome.Text = "" ;
                quảnLýNhânViênToolStripMenuItem.Visible = false;
                danhMụcToolStripMenuItem.Visible = false;
                đăngXuấtToolStripMenuItem.Visible = false;
                sảnPhẩmTồnKhoToolStripMenuItem.Visible = false;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = false;
                hồSơNhânViênToolStripMenuItem.Visible = false;
                đăngNhậpToolStripMenuItem.Visible = true;
            }
        }
        private void VaitroNv()
        {
            quảnLýNhânViênToolStripMenuItem.Visible = false;
            hồSơNhânViênToolStripMenuItem.Visible = false;
            thốngKêToolStripMenuItem.Visible = false;
        }
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien frmttnv = new NhanVien(GiaoDienChinh.mail);
            //if (!CheckExistForm("NhanVien"))
            //{
            //    frmttnv.MdiParent = this;
            //    frmttnv.FormClosed += new FormClosedEventHandler(frmttnv.Frmthongtin_close);
                frmttnv.Show();
            //}
            //else ActiveChildForm("NhanVien");
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            if (!CheckExistForm("DangNhap"))
            {
                dn.MdiParent = this;
                dn.Show();
                dn.FormClosed += new FormClosedEventHandler(FrmDangnhap_closed);
            }
            else ActiveChildForm("DangNhap");
        }
        void FrmDangnhap_closed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            GiaoDienChinh_Load(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
             SanPham sp = new SanPham(GiaoDienChinh.mail);
             sp.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang sp = new KhachHang(GiaoDienChinh.mail);
            sp.Show();
        }

        private void thốngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sảnPhẩmTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hướngDẫnSửDụngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Tai lieu huong dan su dung phan mem");
                System.Diagnostics.Process.Start(path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file is not found in the specified location");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Welcome_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            session = 0;
            GiaoDienChinh_Load(sender, e);
        }

        public void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            this.Refresh();
            //vaitro = "0";
            //session = 1;
            Resetvalue();
            if (profile == 1)
            {
                quảnLýNhânViênToolStripMenuItem.Text = null;
                profile = 0;
            }
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
