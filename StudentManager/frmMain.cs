using System;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ql_Class_MouseClick(object sender, MouseEventArgs e)
        {

        }
        public static bool isLogin = false;
        public static string LoginName = "";
        //btn_QLSinhVien
        private void ql_Class_Click(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var frm = new frmClassInformtion();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();
            }
        }

        //btn_QLLopHoc
        private void button3_Click(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var frm = new frmStudentManagement();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();
            }
        }

        //btn_NhapDiem
        private void btn_NhapDiem_Click(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var frm = new frmPointInput();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();
            }
        }

        
        //btn_Thoat
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (isLogin)
            {
                var frm = new frmMain();
                this.Hide();
                frmMain.isLogin = false;
                frm.btn_DangNhap.Text = "Đăng nhập";
                frm.Show();
            }
            else
            {
                var frm = new frmLogin();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();

            }
        }
    }
}
