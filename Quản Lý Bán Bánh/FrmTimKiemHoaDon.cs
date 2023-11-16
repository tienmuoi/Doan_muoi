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

namespace Quản_Lý_Bán_Bánh
{
    public partial class FrmTimKiemHoaDon : Form
    {
        public FrmTimKiemHoaDon()
        {
            InitializeComponent();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {

        }

        private void FrmTimKiemHoaDon_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
