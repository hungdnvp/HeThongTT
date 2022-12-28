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
        public KeHoachCV(/*TaiKhoan tk*/)
        {
            //this.taikhoan = tk;
            InitializeComponent();

            using (HTTT httt = new HTTT())
            {
                var DV = httt.DonVis.Where(p => p.MaCap == 2).ToList();
                foreach (var tendv in DV)
                {
                    CboDonvi.Items.Add(tendv.PhienHieuDonVi);
                }
            }
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
            loaddtgv("exec hienthikehoach"+ CboDonvi.Text);
        }

        private void CboDonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddtgv("exec hienthikehoach " + CboDonvi.Text);
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            Form F = new TaoKeHoach();
            F.ShowDialog();
            loaddtgv("exec hienthikehoach " + CboDonvi.Text);
        }
    }
}
