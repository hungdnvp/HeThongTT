﻿using HeThongThongTin.Model;
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
            //using (HTTT httt = new HTTT())
            //{
            //    var DV = httt.DonVis.Where(p => p.MaCap == 2).ToList();
            //    foreach (var tendv in DV)
            //    {
            //        CboDonvi.Items.Add(tendv.PhienHieuDonVi);
            //    }
            //}
        }

        private void loaddtgv(string query)
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
            loaddtgv("exec hienthikehoach " + phienhieudonvi);
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            Form F = new TaoKeHoach(taikhoan, phienhieudonvi);
            F.ShowDialog();
            loaddtgv("exec hienthikehoach " + phienhieudonvi);
        }
       
        private void dtgDSUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView)sender;
            //Console.WriteLine(e.RowIndex);
            Console.WriteLine(e.ColumnIndex);
            if (dtgDSUser.Rows[e.RowIndex].Cells["pheduyet"].Value.ToString() == "Chưa phê duyệt" && e.ColumnIndex == 8 && taikhoan.role == 1)
            {
                using (HTTT db = new HTTT())
                {
                    string makh = dtgDSUser.Rows[e.RowIndex].Cells["maKeHoach"].Value.ToString();
                    Console.WriteLine(makh);
                    KeHoachCongTac khct = db.KeHoachCongTacs.Where(p => p.MaKH.ToString() == makh).FirstOrDefault();
                    khct.PheDuyet = 1;
                    khct.TrangThai = "2";
                    db.SaveChanges();
                    loaddtgv("exec hienthikehoach " + phienhieudonvi);

                }
            }

            else if (dtgDSUser.Rows[e.RowIndex].Cells["trangthai"].Value.ToString() == "chưa hoàn thành" && e.ColumnIndex == 2 && taikhoan.role == 2)
            {
                using (HTTT db = new HTTT())
                {
                    string makh = dtgDSUser.Rows[e.RowIndex].Cells["maKeHoach"].Value.ToString();
                    Console.WriteLine(makh);
                    KeHoachCongTac khct = db.KeHoachCongTacs.Where(p => p.MaKH.ToString() == makh).FirstOrDefault();
                    khct.TrangThai = "4";
                    db.SaveChanges();
                    loaddtgv("exec hienthikehoach " + phienhieudonvi);

                }
            }
            else if (dtgDSUser.Rows[e.RowIndex].Cells["trangthai"].Value.ToString() == "chờ phân công" && e.ColumnIndex == 2 && taikhoan.role == 2)
            {
                using (HTTT db = new HTTT())
                {
                    string makh = dtgDSUser.Rows[e.RowIndex].Cells["maKeHoach"].Value.ToString();
                    Console.WriteLine(makh);
                    KeHoachCongTac khct = db.KeHoachCongTacs.Where(p => p.MaKH.ToString() == makh).FirstOrDefault();
                    PhanCongDetail pcdt = new PhanCongDetail(taikhoan, makh);
                    pcdt.Show();
                   
                    db.SaveChanges();
                    loaddtgv("exec hienthikehoach " + phienhieudonvi);

                }
            }

            //        if (senderGrid.Columns[e.ColumnIndex].Name == "trangthai" && e.RowIndex >= 0 && taikhoan.role == 2)
            //{
            //    string makh = dtgDSUser.Rows[e.RowIndex].Cells["maKeHoach"].Value.ToString();
            //    string trangthai = dtgDSUser.Rows[e.RowIndex].Cells["trangthai"].Value.ToString();
            //    if (trangthai == "chưa hoàn thành")
            //    {
            //        PhanCongDetail pcdt = new PhanCongDetail(taikhoan, makh);
            //        pcdt.Show();
            //    }

            //}

        }
     }
    
}
