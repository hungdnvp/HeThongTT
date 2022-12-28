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
    public partial class KHCongtacTieuDoan : Form
    {
        public KHCongtacTieuDoan()
        {
            InitializeComponent();

            using (HTTT httt = new HTTT())
            {
                var DV = httt.DonVis.Where(p => p.MaCap == 2).ToList();
                foreach (var tendv in DV)
                {
                    CboDonvi.Items.Add(tendv.TenDonVi);
                }
            }
        }

        

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dtgDSUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
