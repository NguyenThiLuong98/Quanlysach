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
    public partial class Sach : Form
    {
        public Sach()
        {
            InitializeComponent();
        }
        myDatabase db = new myDatabase();
        string Masach = null;
        private void Sach_Load(object sender, EventArgs e)
        {
            refreshDatagridview();
            grbSach.Enabled=false;
            cbMaloai.DataSource = db.getData("Select * From Loaisach");
            cbMaloai.DisplayMember = "Tenloai";
            cbMaloai.ValueMember = "Maloai";

            cbMaxb.DataSource = db.getData("Select * From Nhaxb");
            cbMaxb.DisplayMember = "Tenxb";
            cbMaxb.ValueMember = "Maxb";
        }
        public void refreshDatagridview()
        {
            dgvSach.DataSource = db.getData("Select * from Sach");
        }
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Masach = dgvSach.Rows[e.RowIndex].Cells["Masach"].Value.ToString();
            cbMaloai.SelectedValue = dgvSach.Rows[e.RowIndex].Cells["Maloai"].Value.ToString();
            txtTensach.Text = dgvSach.Rows[e.RowIndex].Cells["Tensach"].Value.ToString();
            txtTacgia.Text = dgvSach.Rows[e.RowIndex].Cells["Tacgia"].Value.ToString();
            cbMaxb.SelectedValue = dgvSach.Rows[e.RowIndex].Cells["Maxb"].Value.ToString();
            txtSotrang.Text = dgvSach.Rows[e.RowIndex].Cells["Sotrang"].Value.ToString();
            txtGhichu.Text = dgvSach.Rows[e.RowIndex].Cells["Ghichu"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                grbSach.Enabled = true;
                btnThem.Text = "Hủy";
                txtTensach.Text = "";
                txtTacgia.Text = "";
                txtSotrang.Text = "";
                txtGhichu.Text = "";
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnThem.Text = "Thêm";
                txtTensach.Clear();
                txtTacgia.Clear();
                txtSotrang.Clear();
                txtGhichu.Clear();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                grbSach.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                grbSach.Enabled = true;
                btnSua.Text = "Hủy";
                txtTensach.Enabled = true;
                txtTacgia.Enabled = true;
                txtSotrang.Enabled = true;
                txtGhichu.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                grbSach.Enabled = false;
                btnSua.Text = "Sửa";
                txtTensach.Clear();
                txtTacgia.Clear();
                txtSotrang.Clear();
                txtGhichu.Clear();
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == true)
            {
                string sql = string.Format("Insert into Sach(Maloai, Tensach, Tacgia,Maxb,Sotrang,Ghichu) values({0},N'{1}',N'{2}',{3},{4},N'{5}')", cbMaloai.SelectedValue, txtTensach.Text, txtTacgia.Text, cbMaxb.SelectedValue, txtSotrang.Text, txtGhichu.Text);
                db.runQuery(sql);
                refreshDatagridview();
            }
            else if (btnSua.Enabled == true)
            {
                string sql = string.Format("Update Sach Set Maloai={0}, Tensach=N'{1}',Tacgia=N'{2}',Maxb={3},Sotrang={4},Ghichu=N'{5}' Where Masach= {6}", cbMaloai.SelectedValue, txtTensach.Text, txtTacgia.Text, cbMaxb.SelectedValue, txtSotrang.Text, txtGhichu.Text, Masach);
                db.runQuery(sql);
                refreshDatagridview();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = string.Format("Delete Sach where Masach={0}", Masach);
            db.runQuery(sql);
            refreshDatagridview();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn đóng chương trình", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
                e.Cancel = true;
        }
    }
}
