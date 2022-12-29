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
    public partial class PhanCongDetail : Form
    {
        string MaKH;
        TaiKhoan taikhoan;
        List<HocVien> Lhv;
        public PhanCongDetail(TaiKhoan tk, string MaKH)
        {
            this.MaKH = MaKH;
            taikhoan = tk;
            InitializeComponent();
        }

        private void PhanCongDetail_Load(object sender, EventArgs e)
        {
            Lhv = new List<HocVien>();
            using (HTTT db = new HTTT())
            {
                CanBo cb = db.CanBoes.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                List<HocVien> list_hv = db.HocViens.Where(c => c.PhienHieuDonVi == cb.PhienHieuDonVi).ToList();
                foreach(HocVien hv in list_hv)
                {
                    comboBox.Items.Add(hv.TenHV);
                }
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string current = txtHocvien.Text;
            txtHocvien.Text = comboBox.Text + ";" + current;
            using (HTTT db = new HTTT())
            {
                try
                {
                    HocVien hv = db.HocViens.Where(c => c.TenHV == comboBox.Text).FirstOrDefault();
                    Lhv.Add(hv);
                }
                catch { }
                
            }
                
        }

        private void btPhanCong_Click(object sender, EventArgs e)
        {
            using (HTTT db = new HTTT())
            {
                foreach (var item in Lhv)
                {
                    try
                    {
                        PhanCong pc = new PhanCong();
                        pc.MaHV = item.MaHV;
                        pc.MaKH = int.Parse(MaKH);
                        pc.NoiDungCV = richTextBox1.Text;

                        db.PhanCongs.Add(pc);
                        db.SaveChanges();
                    }
                    catch { MessageBox.Show("Phân công " + item.TenHV + " trùng lặp", "Thông Báo", MessageBoxButtons.OK); }
                    
                }
                MessageBox.Show("Đã Phân Công", "Thông Báo", MessageBoxButtons.OK);
                Lhv.Clear();
                txtHocvien.Clear();
            }
        }

        private void PhanCongDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (HTTT db = new HTTT())
            {
                KeHoachCongTac kh = db.KeHoachCongTacs.Find(int.Parse(MaKH));
                kh.TrangThai = "3";
                db.SaveChanges();

            }
        }
    }
}
