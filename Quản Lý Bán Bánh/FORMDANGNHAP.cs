﻿using System;
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
    public partial class FORMDANGNHAP : Form
    {
        String tentaikhoan = "muoi";
        string matkhau = "1";
        public FORMDANGNHAP()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if(kiemtradangnhap(textBox1.Text,textBox2.Text))
            {
                FrmMain f = new FrmMain();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Dang Nhap Thanh Cong");
                textBox2.Focus();
            }
        }
        bool kiemtradangnhap(string tentaikhoa,string matkhau)
        {
            if( tentaikhoan == this.tentaikhoan && matkhau ==this.matkhau)
            {
                return true;
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
