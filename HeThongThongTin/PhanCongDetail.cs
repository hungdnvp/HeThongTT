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
                        pc.HoanThanh = 0;
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

        private void bt_PCtudong_Click(object sender, EventArgs e)
        {
            using (HTTT db = new HTTT())
            {
                Lhv = db.HocViens.ToList();
                int makh = int.Parse(MaKH);
                int sl = int.Parse(txtSoLuong.Text.Trim());
                if(sl > Lhv.Count()) { MessageBox.Show("Số lượng không hợp lệ", "Thông Báo", MessageBoxButtons.OK); return; }
                // tim hoc vien co so phan cong it nhat
                var descendingComparer = Comparer<int>.Create((z, y) => y.CompareTo(z));
                SortedList<int, int> descSortedList = new SortedList<int, int>(descendingComparer);
                foreach (HocVien item in Lhv)
                {
                    if (db.PhanCongs.Where(c => c.MaKH == makh && c.MaHV == item.MaHV).Count() > 0) continue;
                    int k = db.PhanCongs.Where(c => c.MaHV == item.MaHV).Count();
                    descSortedList.Add(item.MaHV,k);
                }
                for(int pc =0; pc < sl; pc++)
                {
                    try
                    {
                        PhanCong phancong = new PhanCong();
                        phancong.MaHV = descSortedList.Keys[pc];
                        phancong.MaKH = int.Parse(MaKH);
                        phancong.NoiDungCV = richTextBox1.Text;
                        db.PhanCongs.Add(phancong);
                    }
                    catch { MessageBox.Show("Phân công trùng lặp", "Thông Báo", MessageBoxButtons.OK); }
                }
                db.SaveChanges();
                MessageBox.Show("Đã Phân Công", "Thông Báo", MessageBoxButtons.OK);
                Lhv.Clear();
                txtHocvien.Clear();

            }
        }
    }
}
