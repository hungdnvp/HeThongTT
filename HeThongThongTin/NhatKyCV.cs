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
        TaiKhoan taikhoan = new TaiKhoan();
        public NhatKyCV(TaiKhoan tk)
        {
            this.taikhoan = tk;
            InitializeComponent();
        }

        public void ShowNhatKy(string phienhieu)
        {
            using (HTTT db = new HTTT())
            {
                List<ViewNhatKy> list_nk = db.Database.SqlQuery<ViewNhatKy>("View_NhatKy " + phienhieu).ToList();
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
                        string donvi = hocvien.PhienHieuDonVi.ToString().Substring(1);
                        label_Title.Text = "Đại Đội " + donvi;
                        lableDonVi.Visible = false;
                        CboDonvi.Visible = false;
                        ShowNhatKy(hocvien.PhienHieuDonVi);
                        break;
                    case 2:
                        CanBo canbo = db.CanBoes.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        string dv = canbo.PhienHieuDonVi.ToString().Substring(1);
                        label_Title.Text = "Đại Đội " + dv;
                        lableDonVi.Visible = false;
                        CboDonvi.Visible = false;
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

                string phienhieu = "c" + tenDV.Substring(tenDV.Length - 3);
                ShowNhatKy(phienhieu);
            }
        }

    }
}
