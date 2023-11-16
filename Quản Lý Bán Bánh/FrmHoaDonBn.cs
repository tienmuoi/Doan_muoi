using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quản_Lý_Bán_Bánh.Class;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace Quản_Lý_Bán_Bánh
{
    public partial class FrmHoaDonBn : Form
    {

        DataTable tblCTHDB;
        public FrmHoaDonBn()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cbxSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaHang,SoLuong FROM tblChiTietHDBan WHERE MaHDBan = N'" + cboMaHoaDon.Text + "'";
                DataTable tblHang = Functions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM tblHang WHERE MaHang = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE tblHang SET SoLuong =" + slcon + " WHERE MaHang= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    Functions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE tblChiTietHDBan WHERE MaHDBan=N'" + cboMaHoaDon.Text + "'";
                Functions.RunSQL(sql);

                //Xóa hóa đơn
                sql = "DELETE tblHDBan WHERE MaHDBan=N'" + cboMaHoaDon.Text + "'";
                Functions.RunSQL(sql);
                ResetValues();
                LoadDataGridView();
                btnHuyHoaDon.Enabled = false;
                btnInHoaDon.Enabled = false;
            }
        }

        private void FrmHoaDonBn_Load(object sender, EventArgs e)
        {
            btnThemHoaDon.Enabled = true;
            btnLuuHoaDon.Enabled = false;
            btnHuyHoaDon.Enabled = false;
            btnInHoaDon.Enabled = false;
            cboMaHoaDon.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtTenKhachHang.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            mtbDienThoai.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtgiamGia.Text = "0";
            txtTongTien.Text = "0";
            Functions.FillCombo("SELECT MaKhach, TenKhach FROM tblKhach", cboMaKhach, "MaKhach", "TenKhach");
            cboMaHang.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien, TenNhanVien FROM tblNhanVien", cboMaNhanVien, "MaNhanVien", "TenNhanVien");
            cboMaNhanVien.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaHang, TenHang FROM tblHang", cboMaHang, "MaHang", "TenHang");
            cboMaHang.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (cboMaHD.Text != "")
            {
                LoadInfoHoaDon();
                btnHuyHoaDon.Enabled = true;
                btnInHoaDon.Enabled = true;
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaHang, b.TenHang, a.SoLuong, b.DonGiaBan, a.GiamGia,a.ThanhTien FROM tblChiTietHDBan AS a, tblHang AS b WHERE a.MaHDBan = N'" + cboMaHD.Text + "' AND a.MaHang=b.MaHang";
            tblCTHDB = Functions.GetDataToTable(sql);
            dgvHoaDonBanHang.DataSource = tblCTHDB;
            dgvHoaDonBanHang.Columns[0].HeaderText = "Mã hàng";
            dgvHoaDonBanHang.Columns[1].HeaderText = "Tên hàng";
            dgvHoaDonBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHoaDonBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHoaDonBanHang.Columns[4].HeaderText = "Giảm giá %";
            dgvHoaDonBanHang.Columns[5].HeaderText = "Thành tiền";
            dgvHoaDonBanHang.Columns[0].Width = 80;
            dgvHoaDonBanHang.Columns[1].Width = 130;
            dgvHoaDonBanHang.Columns[2].Width = 80;
            dgvHoaDonBanHang.Columns[3].Width = 90;
            dgvHoaDonBanHang.Columns[4].Width = 90;
            dgvHoaDonBanHang.Columns[5].Width = 90;
            dgvHoaDonBanHang.AllowUserToAddRows = false;
            dgvHoaDonBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM tblHDBan WHERE MaHDBan = N'" + cboMaHD.Text + "'";
            txtNgayBan.Value = DateTime.Parse( Functions.GetFieldValues(str));
            str = "SELECT MaNhanVien FROM tblHDBan WHERE MaHDBan = N'" + cboMaHD.Text + "'";
            cboMaNhanVien.Text = Functions.GetFieldValues(str);
            str = "SELECT MaKhach FROM tblHDBan WHERE MaHDBan = N'" + cboMaHD.Text + "'";
            cboMaHang.Text = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + cboMaHD.Text + "'";
            txtTongTien.Text = (String)Functions.GetFieldValues(str);
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongTien.Text);
        }
        private void ResetValues()
        {
            cboMaHD.Text = "";
            txtNgayBan.Text = DateTime.Now.ToShortDateString();
            cboMaNhanVien.Text = "";
            cboMaKhach.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtgiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            btnHuyHoaDon.Enabled = false;
            btnLuuHoaDon.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThemHoaDon.Enabled = false;
            ResetValues();
            cboMaHD.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
           
        }
        private void cboMaNhanVien_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void ResetValuesHang()
        {
           
        }

        private void dgvHoaDonBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
    }
}
