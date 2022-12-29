using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongThongTin
{
    public partial class DoiMatKhau : Form
    {
        TaiKhoan tk;
        public DoiMatKhau(TaiKhoan para)
        {
            this.tk = para;
            InitializeComponent();
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            if(GetMD5(txtMKhientai.Text) == tk.MatKhau)
            {
                using(HTTT db = new HTTT())
                {
                    db.TaiKhoans.Find(tk.MaTK).MatKhau = GetMD5(txtMKmoi.Text);
                    db.SaveChanges();
                    MessageBox.Show("Đổi Mật Khẩu Thành Công", "Thông Báo", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
