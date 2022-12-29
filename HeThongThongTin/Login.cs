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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //create a string MD5
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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txbTenDangNhap.Text;
            string password = GetMD5(txbMatKhau.Text);
            using(HTTT Context = new HTTT())
            {
                TaiKhoan tk = Context.TaiKhoans.Where(c => c.TenDangNhap == username && c.MatKhau == password).FirstOrDefault();
                if (tk != null)
                {
                    NhatKyCV nhatKyCV = new NhatKyCV(tk);
                    //PhanCongDetail pcdt = new PhanCongDetail(tk, "3");
                    this.Hide();
                    nhatKyCV.Show();
                    //pcdt.Show();
                }
                else
                {
                    MessageBox.Show("Sai Tên Đăng Nhập hoặc Mật Khẩu", "Lỗi",MessageBoxButtons.OK);
                }
            }
        }
    }
}
