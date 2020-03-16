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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        myDatabase db = new myDatabase();
        string Maxb = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            refrehDatagridview();
        }
        public void refrehDatagridview()
        {
            dgvXuatban.DataSource = db.getData("Select * From Nhaxb");
        }

        private void dgvXuatban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Maxb = dgvXuatban.Rows[e.RowIndex].Cells["Maxb"].Value.ToString();
            txtTenxb.Text = dgvXuatban.Rows[e.RowIndex].Cells["Tenxb"].Value.ToString();
            txtDiachi.Text = dgvXuatban.Rows[e.RowIndex].Cells["Diachi"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                txtTenxb.Text = "";
                txtDiachi.Text = "";
                txtTenxb.Focus();
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnThem.Text = "Thêm";
                txtTenxb.Clear();
                txtDiachi.Clear();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Hủy";
                txtTenxb.Enabled = true;
                txtDiachi.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Text = "Sửa";
                txtTenxb.Clear();
                txtDiachi.Clear();
                btnThem.Enabled = true;
                btnXoa.Enabled = true;

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == true)
            {
                string sql = string.Format("Insert into Nhaxb(Tenxb,Diachi) values(N'{0}',N'{1}')", txtTenxb.Text, txtDiachi.Text);
                db.runQuery(sql);
                refrehDatagridview();
            }else if (btnSua.Enabled == true)
            {
                string sql = string.Format("Update Nhaxb Set Tenxb=N'{0}', Diachi=N'{1}' Where Maxb={2}", txtTenxb.Text, txtDiachi.Text, Maxb);
                db.runQuery(sql);
                refrehDatagridview();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = string.Format("Delete Nhaxb Where Maxb={0}", Maxb);
            db.runQuery(sql);
            refrehDatagridview();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn đóng chương trình", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
                e.Cancel = true;
        }
    }
}
