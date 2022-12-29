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
    public partial class ThemCanBo : Form
    {
        public ThemCanBo()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (HTTT db = new HTTT())
            {
                CanBo cb = new CanBo();
                cb.CapBac = txtCapBac.Text;
                cb.HoTen = txtTenCB.Text;
                cb.PhienHieuDonVi = comboPhienhieu.Text;
                cb.ChucVu = txtChucVu.Text;
                db.CanBoes.Add(cb);

                TaiKhoan tk = new TaiKhoan();
                tk.TenDangNhap = txtTenTK.Text;
                tk.MatKhau = txtMatKhau.Text;
                tk.role = 2;
                db.TaiKhoans.Add(tk);

                db.SaveChanges();
                MessageBox.Show("THêm Cán Bộ Thành Công");
            }
        }
        private void ThemCanBo_Load(object sender, EventArgs e)
        {

            using (HTTT db = new HTTT())
            {
                List<DonVi> list_dv = db.DonVis.Where(c => c.MaCap == 2).ToList();
                foreach (var item in list_dv)
                {
                    comboPhienhieu.Items.Add(item.PhienHieuDonVi);
                }
            }
        }
    }
}
