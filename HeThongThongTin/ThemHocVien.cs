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
    public partial class ThemHocVien : Form
    {
        string phienhieu;
        public ThemHocVien(string phienhieu)
        {
            this.phienhieu = phienhieu;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bool fail = false;
            using(HTTT db = new HTTT())
            {
                try
                {
                    HocVien hv = new HocVien();
                    hv.TenHV = txtTenHV.Text;
                    hv.CapBac = txtCapBac.Text;
                    hv.PhienHieuDonVi = phienhieu;
                    db.HocViens.Add(hv);
                    db.SaveChanges();
                }
                catch { MessageBox.Show("THêm Học Viên Lỗi"); fail = true; }

                try
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk.TenDangNhap = txtTenTK.Text;
                    tk.MatKhau = txtMatKhau.Text;
                    tk.role = 3;
                    db.TaiKhoans.Add(tk);
                    db.SaveChanges();

                }
                catch { MessageBox.Show("THêm Tai Khoan Lỗi"); fail = true; }
            }
            if (!fail)
            {
                MessageBox.Show("Thêm Thành Công");
                this.Close();
            }
        }
    }
}
