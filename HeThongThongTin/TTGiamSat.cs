using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongThongTin
{
    public partial class TTGiamSat : Form
    {
        string phienhieudonvi;
        TaiKhoan taikhoan = new TaiKhoan();
        public TTGiamSat(TaiKhoan tk)
        {
            this.taikhoan = tk;
            InitializeComponent();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
            //sanH4 h4 = new sanH4();
            //this.Hide();
            //DialogResult result = h4.ShowDialog();
            //if (result == DialogResult.Cancel)
            //{
            //    this.Show();
            //}
          
        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TTGiamSat_Load(object sender, EventArgs e)
        {
            using (HTTT db = new HTTT())
            {
                switch (taikhoan.role)
                {
                    case 3:
                        HocVien hocvien = db.HocViens.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        phienhieudonvi = hocvien.PhienHieuDonVi;
                        //label_Title.Text = "Đại Đội " + hocvien.PhienHieuDonVi.ToString().Substring(1);
                        //lableDonVi.Visible = false;
                        //CboDonvi.Visible = false;

                        break;
                    case 2:
                        CanBo canbo = db.CanBoes.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        phienhieudonvi = canbo.PhienHieuDonVi;
                        label_Title.Text = "Đại Đội " + canbo.PhienHieuDonVi.ToString().Substring(1);
                        guna2Paneltang2.Visible = false;
                        guna2Paneltang3.Visible = false;
                        guna2Paneltang4.Visible = false;
                        guna2Paneltang7.Visible = false;
                        guna2Paneltang8.Visible = false; ;
                        guna2Paneltang9.Visible = false;
                        break;
                    case 1:
                        CanBo cb = db.CanBoes.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        string dv2 = cb.PhienHieuDonVi.ToString().Substring(1);
                        label_Title.Text = "Tiểu Đoàn " + dv2;

                        break;
                }
            }
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
