using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlysach
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            Sach sach = new Sach();
            sach.Show();
        }

        private void btnNhaxb_Click(object sender, EventArgs e)
        {
            Form1 nxb = new Form1();
            nxb.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn đóng chương trình", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
                e.Cancel = true;
        }
    }
}
