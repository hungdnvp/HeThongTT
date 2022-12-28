using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace HeThongThongTin
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void loadDTGV(string query)
        {
            using (HTTT httt = new HTTT())
            {
                var listtc = httt.Database.SqlQuery<KeHoachCongTac>(query).ToList();
                dtgDSUser.DataSource = listtc;
            }
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            using (HTTT httt = new HTTT())
            {
                var list = httt.KeHoachCongTacs.ToList();
                dtgDSUser.DataSource = list;

            }    
            
        }

       
    }
}
