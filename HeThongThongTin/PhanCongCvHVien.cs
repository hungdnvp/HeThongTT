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
    public partial class PhanCongCvHVien : Form
    {
        public PhanCongCvHVien()
        {
            InitializeComponent();
        }

        private void PhanCongCvHVien_Load(object sender, EventArgs e)
        {
            string value = txbname.Text;
            loadDTGV("exec phancongCV_hv "+ " N'" + value + "'");
            AddButton();
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
        private void AddButton()
        {
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
            btnDetail.HeaderText = "";
            btnDetail.Text = "Chi tiết";
            btnDetail.Name = "btnDetail";
            btnDetail.UseColumnTextForButtonValue = true;
            btnDetail.FillWeight = 100;
            dtgDSUser.Columns.Add(btnDetail);
        }
    }
}
