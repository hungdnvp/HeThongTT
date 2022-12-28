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
    public partial class ThemNX : Form
    {
        string MaNK;
        int MaTK;
        CanBo cb;
        public ThemNX(string MaNK,int MaTK)
        {
            this.MaNK = MaNK;
            this.MaTK = MaTK;
            InitializeComponent();
        }

        private void ThemNX_Load(object sender, EventArgs e)
        {
            using (HTTT db = new HTTT())
            {
                cb = db.CanBoes.Where(c => c.MaTK == MaTK).FirstOrDefault();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (HTTT db = new HTTT())
            {
                NhanXetNhatKy nx = new NhanXetNhatKy();
                try
                {
                    nx.NhanXet = rtb_Nhanxet.Text;
                    nx.MaCB = cb.MaCB;
                    nx.MaNK = int.Parse(MaNK);
                    db.NhanXetNhatKies.Add(nx);
                    db.SaveChanges();
                    MessageBox.Show("Đã Thêm Nhận Xét", "Thông Báo",MessageBoxButtons.OK);
                    this.Close();
            }
                catch { MessageBox.Show("Lỗi Hệ Thống", "Hệ Thống"); }
                
            }

        }
    }
}
