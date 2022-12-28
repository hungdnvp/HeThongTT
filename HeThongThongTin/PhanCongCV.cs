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
        public PhanCongCV()
        {
            InitializeComponent();
            btnPhanCongCV.FillColor = Color.Purple;


            using (HTTT httt = new HTTT())
            {
                var DV = httt.DonVis.Where(p =>p.MaCap == 2).ToList();
                foreach(var tendv in DV)
                {
                    CboDonvi.Items.Add(tendv.TenDonVi);
                }    
            }    
        }

        private void PhanCongCV_Load(object sender, EventArgs e)
        {
            loadDTGV("exec phancongCV");
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnNhatKyCV_Click(object sender, EventArgs e)
        {
            Form f = new PhanCongCvHVien();
            f.ShowDialog();
        }
    }
}
