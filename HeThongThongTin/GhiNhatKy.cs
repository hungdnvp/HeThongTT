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
    public partial class GhiNhatKy : Form
    {
        int mank;
        public GhiNhatKy(int MaNK)
        {
            mank = MaNK;
            InitializeComponent();
        }

        private void GhiNhatKy_Load(object sender, EventArgs e)
        {
            comboBox.Items.Add("Hoàn Thành");
            comboBox.Items.Add("Không Hoàn Thành");
            comboBox.Text = comboBox.Items[0].ToString();
        }

        private void btnGhiNhatKy_Click(object sender, EventArgs e)
        {
            int kq = (comboBox.Text == "Hoàn Thành") ? 1 : 0;
            using (HTTT db = new HTTT())
            {
                NhatKyCongViec nk = new NhatKyCongViec();
                try
                {
                    nk.MaNK = mank;
                    nk.HoanThanh = kq;
                    nk.TrangThai = richTextBox1.Text;
                    db.NhatKyCongViecs.Add(nk);
                    db.SaveChanges();
                    MessageBox.Show("Hoàn Thành Ghi Nhật Ký ", "Thông Báo");
                    this.Close();
                }
                catch { MessageBox.Show("Lỗi ", "Hệ Thống"); }
            }
        }
    }
}
