using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lý_Bán_Bánh
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect(); 
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect(); 
            Application.Exit();
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            FrmDanhMucChatLieu FrmChatLieu    = new FrmDanhMucChatLieu(); 
            FrmChatLieu.ShowDialog(); //Hiển thị
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            FrmDanhMucNhanVien FrmNhanVien = new FrmDanhMucNhanVien();
            FrmNhanVien.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            FrmDMKhachHang FrmKhachHang = new FrmDMKhachHang();
            FrmKhachHang.Show();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            FrmHoaDonBn FrmHoaDon = new FrmHoaDonBn();
            FrmHoaDon.Show();
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            FrmTimKiemHoaDon FrmTimKiem = new FrmTimKiemHoaDon();
            FrmTimKiem.Show();
        }

        private void mnuBaoCao_Click(object sender, EventArgs e)
        {

        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            FrmDanhMucHangHoa FrmHangHoa = new FrmDanhMucHangHoa();
            FrmHangHoa.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FORMDANGNHAP fORMDANGNHAP = new FORMDANGNHAP();
            fORMDANGNHAP.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmBanhMuoi frmBanh = new FrmBanhMuoi();
            frmBanh.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmBanhMi frmBanhMi = new FrmBanhMi();
            frmBanhMi.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmBanhKem frmBanhKem = new FrmBanhKem();
            frmBanhKem.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmBanhSinhNhat frmBanhSinhNhat = new FrmBanhSinhNhat();
            frmBanhSinhNhat.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmBanhLo frmBanhLo = new FrmBanhLo();
            frmBanhLo.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmBanhQuy frmBanhQuy = new FrmBanhQuy();
            frmBanhQuy.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FrmBanhNgot frmBanhNgot = new FrmBanhNgot();
            frmBanhNgot.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FrmKhongBietTen frmKhongBietTen = new FrmKhongBietTen();
            frmKhongBietTen.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void mnuDanhMuc_Click(object sender, EventArgs e)
        {

        }
    }
}
