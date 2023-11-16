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

namespace Quản_Lý_Bán_Bánh
{
    public partial class FrmDanhMucHangHoa : Form
    {
        DataTable tblHH;
        public FrmDanhMucHangHoa()
        {
            InitializeComponent();
        }

        private void dgvDanhMucChatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            sql = "SELECT MaHang, TenHang FROM tblHang";
            tblHH = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvDanhMuHangHoa.DataSource = tblHH; //Nguồn dữ liệu            
            dgvDanhMuHangHoa.Columns[0].HeaderText = "Mã chất liệu";
            dgvDanhMuHangHoa.Columns[1].HeaderText = "Tên chất liệu";
            dgvDanhMuHangHoa.Columns[0].Width = 100;
            dgvDanhMuHangHoa.Columns[1].Width = 300;
            dgvDanhMuHangHoa.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvDanhMuHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void FrmDanhMucHangHoa_Load(object sender, EventArgs e)
        {
            
            txtMaHangHoa.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng tblChatLieu
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaChatLieu, TenChatLieu FROM tblChatLieu";
            tblHH = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvDanhMuHangHoa.DataSource = tblHH; //Nguồn dữ liệu            
            dgvDanhMuHangHoa.Columns[0].HeaderText = "Mã Hàng Hóa";
            dgvDanhMuHangHoa.Columns[1].HeaderText = "Tên Hàng Hóa";
            dgvDanhMuHangHoa.Columns[0].Width = 100;
            dgvDanhMuHangHoa.Columns[1].Width = 300;
            dgvDanhMuHangHoa.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvDanhMuHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void dgvDanhMucChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHangHoa.Focus();
                return;
            }
            if (tblHH.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHangHoa.Text = dgvDanhMuHangHoa.CurrentRow.Cells["MaChatLieu"].Value.ToString();
            txtTenHangHoa.Text = dgvDanhMuHangHoa.CurrentRow.Cells["TenChatLieu"].Value.ToString();
            btnsua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaHangHoa.Enabled = true; //cho phép nhập mới
            txtMaHangHoa.Focus();
        }
        private void ResetValue()
        {
            txtMaHangHoa.Text = "";
            txtTenHangHoa.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaHangHoa.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHangHoa.Focus();
                return;
            }
            if (txtTenHangHoa.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHangHoa.Focus();
                return;
            }
            sql = "Select MaChatLieu From tblChatLieu where MaChatLieu=N'" + txtMaHangHoa.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHangHoa.Focus();
                return;
            }

            sql = "INSERT INTO tblChatLieu VALUES(N'" +
                txtMaHangHoa.Text + "',N'" + txtTenHangHoa.Text + "')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnsua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHangHoa.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblHH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHangHoa.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenHangHoa.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE tblChatLieu SET TenChatLieu=N'" +
                txtTenHangHoa.Text.ToString() +
                "' WHERE MaChatLieu=N'" + txtMaHangHoa.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHangHoa.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblChatLieu WHERE MaChatLieu=N'" + txtMaHangHoa.Text + "'";
                Class.Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnsua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaHangHoa.Enabled = false;
        }
        private void txtMaChatLieu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
