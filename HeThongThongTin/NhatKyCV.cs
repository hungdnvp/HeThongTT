using HeThongThongTin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongThongTin
{
    public partial class NhatKyCV : Form
    {
        string phienhieudonvi;
        TaiKhoan taikhoan = new TaiKhoan();
        public NhatKyCV(TaiKhoan tk)
        {
            this.taikhoan = tk;
            InitializeComponent();
            comboSX.Items.Add("Ngày");
            comboSX.Items.Add("Trạng Thái");
            btnNhatKyCV.FillColor = Color.Purple;
        }

        public void ShowNhatKy()
        {
            using (HTTT db = new HTTT())
            {
                List<ViewNhatKy> list_nk = db.Database.SqlQuery<ViewNhatKy>("View_NhatKy " + phienhieudonvi).ToList();
                dtGV.DataSource = list_nk;
            }
        }
        private void NhatKyCV_Load(object sender, EventArgs e)
        {
            using (HTTT db = new HTTT())
            {
                switch (taikhoan.role)
                {
                    case 3:
                        HocVien hocvien = db.HocViens.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        phienhieudonvi = hocvien.PhienHieuDonVi;
                        label_Title.Text = "Đại Đội " + hocvien.PhienHieuDonVi.ToString().Substring(1);
                        lableDonVi.Visible = false;
                        CboDonvi.Visible = false;
                        ShowNhatKy();
                        break;
                    case 2:
                        CanBo canbo = db.CanBoes.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        phienhieudonvi = canbo.PhienHieuDonVi;
                        label_Title.Text = "Đại Đội " + canbo.PhienHieuDonVi.ToString().Substring(1);
                        lableDonVi.Visible = false;
                        CboDonvi.Visible = false;
                        ShowNhatKy();
                        break;
                    case 1:
                        CanBo cb = db.CanBoes.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        string dv2 = cb.PhienHieuDonVi.ToString().Substring(1);
                        label_Title.Text = "Tiểu Đoàn " + dv2;
                        List<DonVi> list_dv = db.DonVis.Where(c => c.MaCap == 2).ToList();
                        foreach(var item in list_dv)
                        {
                            CboDonvi.Items.Add(item.TenDonVi);
                        }
                        break;
                }
                
            }
                

        }

        private void CboDonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboDonvi.Items.Count != 0)
            {
                string tenDV = CboDonvi.Text;

                phienhieudonvi = "c" + tenDV.Substring(tenDV.Length - 3);
                ShowNhatKy();
            }
        }

        private void dtGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex].Name == "NhanXet" && e.RowIndex >=0)
            {
                if(taikhoan.role == 3|| taikhoan.role == 2)
                {
                    MessageBox.Show("Bạn Không có quyền xem phần chức năng này", "Thông báo");
                }
                else
                {
                    string MaNK = dtGV.Rows[e.RowIndex].Cells["MaNK"].Value.ToString();
                    ViewNhanXetNhatKy view = new ViewNhanXetNhatKy(MaNK);
                    view.Show();
                }
            }
            if(senderGrid.Columns[e.ColumnIndex].Name == "ThemNX" && e.RowIndex >= 0)
            {
                if(taikhoan.role == 3 || taikhoan.role == 2)
                {
                    MessageBox.Show("Bạn Không có quyền xem phần chức năng này", "Thông báo");
                }
                else
                {
                    string MaNK = dtGV.Rows[e.RowIndex].Cells["MaNK"].Value.ToString();
                    ThemNX themNX = new ThemNX(MaNK,taikhoan.MaTK);
                    themNX.Show();
                }
            }
        }

        private void dateimePicker_ValueChanged(object sender, EventArgs e)
        {
            string date = dateimePicker.Value.Date.ToString("yyyy-MM-dd");
            using (HTTT db = new HTTT())
            {
                List<ViewNhatKy> list_nk = db.Database.SqlQuery<ViewNhatKy>("ViewNhatKy2 " + phienhieudonvi+", '" + date+"'").ToList();
                dtGV.DataSource = list_nk;
            }
        }
        


        private void btnKeHoachCT_Click_1(object sender, EventArgs e)
        {
            KeHoachCV kehoach = new KeHoachCV(taikhoan);
            this.Hide();
            DialogResult result = kehoach.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void btnTTGiamSat_Click(object sender, EventArgs e)
        {
            TTGiamSat tt = new TTGiamSat(taikhoan);
            this.Hide();
            tt.Show();

        }

        private void comboSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboSX.Text == "Ngày")
            {
                ShowNhatKy();
            }
            else
            {
                using (HTTT db = new HTTT())
                {
                    List<ViewNhatKy> list_nk = db.Database.SqlQuery<ViewNhatKy>("View_NhatKySX " + phienhieudonvi).ToList();
                    dtGV.DataSource = list_nk;
                }
            }
        }

        private void btnPhanCongCV_Click(object sender, EventArgs e)
        {
            PhanCongCV pc = new PhanCongCV(taikhoan);
            this.Hide();
            pc.Show();
        }
    }
}
