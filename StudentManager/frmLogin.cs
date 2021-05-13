using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data;

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

            #region Login LabNhom
            try
            {
                con.Open();
                string Sha1Hash = Encryptor.SHA1Hash(password);
                byte[] theBytesNV = Encoding.UTF8.GetBytes(Sha1Hash);
                string queryNV = "SELECT * FROM NHANVIEN WHERE MANV='" + username + "'AND MATKHAU= @matkhauNV";
                SqlCommand cmdNV = new SqlCommand(queryNV, con);
                cmdNV.Parameters.Add("@matkhauNV", SqlDbType.VarBinary).Value = theBytesNV;

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
