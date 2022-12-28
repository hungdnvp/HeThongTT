using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongThongTin
{
    public partial class TaoKeHoach : Form
    {
        public TaoKeHoach()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void refesh()
        {
            txbDiaDiem.Text = "";
            txbMaKh.Text = "";
            txbMaTB.Text = "";
            txbNoiDung.Text = "";
            txbTPThucHien.Text = "";
            cboChiHuy.Text = "";
        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (HTTT httt = new HTTT())
            //    {
            //        Room R = new Room();
            //        R.id = txbRoomId.Text;
            //        R.description = txbDes.Text;
            //        R.status = false;
            //        R.image = pathImage;
            //        var R_C = ht.Room_Class.Where(p => p.name == cbR_C.Text).FirstOrDefault();
            //        if (R_C != null)
            //        {
            //            R.room_class_id = R_C.id;
            //        }
            //        if (R.id == "" || R.description == "" || R_C == null)
            //        {
            //            MessageBox.Show("Thêm thất bại", "Thông báo");
            //        }
            //        else
            //        {
            //            ht.Rooms.Add(R);
            //            ht.SaveChanges();
            //            MessageBox.Show("Thêm thành công", "Thông báo");
            //            refesh();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Thêm thất bại", "Thông báo");
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
