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
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >=0)
            {
                if(taikhoan.role == 3)
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
        }

       

        private void btnKeHoachCT_Click_1(object sender, EventArgs e)
        {
            KeHoachCV nhatKyCV = new KeHoachCV(/*taikhoan*/);
            this.Hide();
            nhatKyCV.Show();
        }
    }
}
