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
    public partial class PhanCongCV : Form

    {
        string phienhieudonvi;
        TaiKhoan taikhoan = new TaiKhoan();
        public PhanCongCV(TaiKhoan tk)
        {
            this.taikhoan = tk;
            InitializeComponent();
            btnPhanCongCV.FillColor = Color.Purple;


            //using (HTTT httt = new HTTT())
            //{
            //    var DV = httt.DonVis.Where(p =>p.MaCap == 2).ToList();
            //    foreach(var tendv in DV)
            //    {
            //        CboDonvi.Items.Add(tendv.TenDonVi);
            //    }    
            //}    
        }

        private void PhanCongCV_Load(object sender, EventArgs e)
        {
            using (HTTT db = new HTTT())
            {
                switch (taikhoan.role)
                {
                    case 3:
                        HocVien hocvien = db.HocViens.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        phienhieudonvi = hocvien.PhienHieuDonVi;
                        label_Title.Text = "Đại Đội " + hocvien.PhienHieuDonVi.ToString().Substring(1);
                        CboDonvi.Visible = false;
                        loadDTGV("exec phancongCV_hv  " + "'" + hocvien.TenHV + "'," + phienhieudonvi);
                        break;
                    case 2:
                        CanBo canbo = db.CanBoes.Where(c => c.MaTK == taikhoan.MaTK).FirstOrDefault();
                        phienhieudonvi = canbo.PhienHieuDonVi;
                        label_Title.Text = "Đại Đội " + canbo.PhienHieuDonVi.ToString().Substring(1);
                        CboDonvi.Visible = false;
                        loadDTGV("exec phancongCV_hv  " + "''," + phienhieudonvi);

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
        private void loadDTGV(string query)
        {
            try
            {
                using (HTTT httt = new HTTT())
                {
                    var listPC = httt.Database.SqlQuery<viewPhanCong>(query).ToList();
                    dtgDSUser.DataSource = listPC;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnNhatKyCV_Click(object sender, EventArgs e)
        {
            Form f = new PhanCongCvHVien();
            f.ShowDialog();
        }

        private void CboDonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            phienhieudonvi = CboDonvi.SelectedItem.ToString();
            loadDTGV("exec phancongCV_hv  " + "''," + phienhieudonvi);
        }

        private void dtgDSUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDSUser.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString() == "Chưa hoàn thành" && taikhoan.role == 3)
            {
                using (HTTT db = new HTTT())
                {
                    string makh = dtgDSUser.Rows[e.RowIndex].Cells["maKH"].Value.ToString();
                    string ndcv = dtgDSUser.Rows[e.RowIndex].Cells["noidungcv"].Value.ToString();
                    Console.WriteLine(makh);
                    PhanCong khct = db.PhanCongs.Where(p => p.MaKH.ToString() == makh && p.NoiDungCV==ndcv).FirstOrDefault();
                    khct.HoanThanh=1;
                    db.SaveChanges();
                    loadDTGV("exec phancongCV_hv  " + "''," + phienhieudonvi);

                }
            }
        }
    }
    }
