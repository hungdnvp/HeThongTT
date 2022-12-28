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
    public partial class ViewNhanXetNhatKy : Form
    {
        string MaNK;
        public ViewNhanXetNhatKy(string para)
        {
            this.MaNK = para;
            InitializeComponent();
        }

        private void ViewNhanXetNhatKy_Load(object sender, EventArgs e)
        {
            using(HTTT db = new HTTT())
            {
                List<ViewNhanXet> view = db.Database.SqlQuery<ViewNhanXet>("ViewNhanXet " + MaNK).ToList();
                dtGV.DataSource = view;

            }
        }
    }
}
