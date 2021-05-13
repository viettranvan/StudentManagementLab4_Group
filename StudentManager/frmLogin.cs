using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace StudentManager
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SqlConnection con;
        public static string manvLogin = "";
        public static string passLogin = "";
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["QlySV"].ConnectionString.ToString();
            con = new SqlConnection(chuoiketnoi);

            string username = txt_Username.Text;
            string password = txt_Password.Text;
            #region Login LabCaNhan
            /*
            try
            {
                con.Open();
                string md5 = "CONVERT(VARCHAR(100), HashBytes('MD5', '" + password + "'), 2)";
                string sha1 = "CONVERT(VARCHAR(100), HashBytes('SHA1', '" + password + "'), 2)";

                string querySV = "select * from SINHVIEN where TENDN='" + username + "'AND MATKHAU= CAST(" + md5 + " as varbinary(max))";
                string queryNV = "select * from NHANVIEN where TENDN='" + username + "'AND MATKHAU= CAST(" + sha1 + " as varbinary(max))";
                
                SqlCommand cmdSV = new SqlCommand(querySV, con);
                SqlDataReader readerSV = cmdSV.ExecuteReader();


                if (readerSV.Read())
                {
                    MessageBox.Show("Đăng nhập hệ thống thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmdSV.Dispose();
                    readerSV.Close();

                    SqlCommand cmdNV = new SqlCommand(queryNV, con);
                    SqlDataReader readerNV = cmdNV.ExecuteReader();

                    if (readerNV.Read())
                    {
                        MessageBox.Show("Đăng nhập hệ thống thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            #endregion

            #region Login LabNhom
            try
            {
                con.Open();
                string sha1 = "CONVERT(VARCHAR(100), HashBytes('SHA1', '" + password + "'), 2)";
                string queryNV = "select * from NHANVIEN where MANV='" + username + "'AND MATKHAU= CAST(" + sha1 + " as varbinary(max))";

                SqlCommand cmdNV = new SqlCommand(queryNV, con);
                SqlDataReader readerNV = cmdNV.ExecuteReader();

                if (readerNV.Read())
                {
                    MessageBox.Show("Đăng nhập hệ thống thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdNV.Dispose();
                    readerNV.Close();
                    frmMain.LoginName = username;
                    frmMain.isLogin = true;
                    this.Hide();
                    var frm = new frmMain();
                    manvLogin = username;
                    passLogin = password;

                    frm.btn_DangNhap.Text= "Đăng Xuất";
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new frmMain();
            frm.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
