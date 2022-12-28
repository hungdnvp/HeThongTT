using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HeThongThongTin
{
    public partial class TaoKeHoach : Form
    {
        string phienhieudonvi;
        TaiKhoan taikhoan = new TaiKhoan();
        public TaoKeHoach(TaiKhoan tk, string donvi)
        {
            this.phienhieudonvi= donvi;
            this.taikhoan = tk;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void refesh()
        {
            txbDiaDiem.Text = "";
            txbMaKh.Text = "";
            txbMaTB.Text = "";
            txbNoiDung.Text = "";
            txbTPThucHien.Text = "";
            cboChiHuy.Text = "";
        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            try
            {
                using (HTTT httt = new HTTT())
                {
                    KeHoachCongTac khct = new KeHoachCongTac();
                        khct.NoiDungKH= txbNoiDung.Text;
                        khct.TPThucHien = txbTPThucHien.Text;
                        khct.PhienHieuDonVi= phienhieudonvi;
                        khct.DiaDiem = txbDiaDiem.Text;
                        khct.MaTrucBan = 1;
                    //khct.CanBo = cboChiHuy.Text;
                        httt.KeHoachCongTacs.Add(khct);
                        httt.SaveChanges();
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        refesh();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
