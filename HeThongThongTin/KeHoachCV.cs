using HeThongThongTin.Model;
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
    public partial class KeHoachCV : Form
    {
        string phienhieudonvi;
        TaiKhoan taikhoan = new TaiKhoan();
        public KeHoachCV(TaiKhoan tk)
        {
            this.taikhoan = tk;
            InitializeComponent();
            btnKeHoachCT.FillColor = Color.Purple;
            AddButton();
            //using (HTTT httt = new HTTT())
            //{
            //    var DV = httt.DonVis.Where(p => p.MaCap == 2).ToList();
            //    foreach (var tendv in DV)
            //    {
            //        CboDonvi.Items.Add(tendv.PhienHieuDonVi);
            //    }
            //}
        }

     private void loaddtgv( string query)
        {
            try
            {
                using (HTTT httt = new HTTT())
                {
                    var listPC = httt.Database.SqlQuery<viewKeHoach>(query).ToList();
                    dtgDSUser.DataSource = listPC;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void KeHoachCV_Load(object sender, EventArgs e)
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

                        break;
                    case 2:
                        CanBo canbo = db.CanBoes.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        phienhieudonvi = canbo.PhienHieuDonVi;
                        label_Title.Text = "Đại Đội " + canbo.PhienHieuDonVi.ToString().Substring(1);
                        lableDonVi.Visible = false;
                        CboDonvi.Visible = false;
                        loaddtgv("exec hienthikehoach " + phienhieudonvi);

                        break;
                    case 1:
                        CanBo cb = db.CanBoes.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        string dv2 = cb.PhienHieuDonVi.ToString().Substring(1);
                        label_Title.Text = "Tiểu Đoàn " + dv2;
                        List<DonVi> list_dv = db.DonVis.Where(c => c.MaCap == 2).ToList();
                        foreach (var item in list_dv)
                        {
                            CboDonvi.Items.Add(item.PhienHieuDonVi);
                        }
                        break;
                }
            }

           

        }

        private void CboDonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddtgv("exec hienthikehoach " + CboDonvi.Text);
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            Form F = new TaoKeHoach(taikhoan,phienhieudonvi);
            F.ShowDialog();
            loaddtgv("exec hienthikehoach " + CboDonvi.Text);
        }
        private void AddButton()
        {
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
            btnDetail.HeaderText = "";
            btnDetail.Text = "Xem Nhật Xét";
            btnDetail.Name = "btnNhanxet";
            btnDetail.UseColumnTextForButtonValue = true;
            btnDetail.FillWeight = 100;
            dtgDSUser.Columns.Add(btnDetail);
        }
        private void dtgDSUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine(e.RowIndex);
            //Console.WriteLine(e.ColumnIndex);
            if(dtgDSUser.Rows[e.RowIndex].Cells["pheduyet"].Value.ToString() == "Chưa phê duyệt")
            {
                //Console.WriteLine(dtgDSUser.Rows[e.RowIndex].Cells["nguoichutri"].Value.ToString());
                //using (HTTT db = new HTTT())
                //{
                //    KeHoachCongTac khct = db.KeHoachCongTacs.FirstOrDefault(k =>k.ma )
                //}
            }
        }
    }
}
