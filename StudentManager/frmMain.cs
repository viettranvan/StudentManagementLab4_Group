using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
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
            //Application.Exit();
            //var publicKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent><P>/aULPE6jd5IkwtWXmReyMUhmI/nfwfkQSyl7tsg2PKdpcxk4mpPZUdEQhHQLvE84w2DhTyYkPHCtq/mMKE3MHw==</P><Q>3WV46X9Arg2l9cxb67KVlNVXyCqc/w+LWt/tbhLJvV2xCF/0rWKPsBJ9MC6cquaqNPxWWEav8RAVbmmGrJt51Q==</Q><DP>8TuZFgBMpBoQcGUoS2goB4st6aVq1FcG0hVgHhUI0GMAfYFNPmbDV3cY2IBt8Oj/uYJYhyhlaj5YTqmGTYbATQ==</DP><DQ>FIoVbZQgrAUYIHWVEYi/187zFd7eMct/Yi7kGBImJStMATrluDAspGkStCWe4zwDDmdam1XzfKnBUzz3AYxrAQ==</DQ><InverseQ>QPU3Tmt8nznSgYZ+5jUo9E0SfjiTu435ihANiHqqjasaUNvOHKumqzuBZ8NRtkUhS6dsOEb8A2ODvy7KswUxyA==</InverseQ><D>cgoRoAUpSVfHMdYXW9nA3dfX75dIamZnwPtFHq80ttagbIe4ToYYCcyUz5NElhiNQSESgS5uCgNWqWXt5PnPu4XmCXx6utco1UVH8HGLahzbAnSy6Cj3iUIQ7Gj+9gQ7PkC434HTtHazmxVgIR5l56ZjoQ8yGNCPZnsdYEmhJWk=</D></RSAKeyValue>";
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512);
            //string publicPrivateKey = RSA.ToXmlString(true);

            string publicPrivateKey = "<RSAKeyValue><Modulus>rguiiVAMOGSQZcyg2RLZV+zBu9mp0GBveAO448vMvORhWA3QKQqsz8HOZpU6riRjIje4ExDbx02Z4srMpzSspQ==</Modulus><Exponent>AQAB</Exponent><P>zyQFSJr+oRw1DoUtdTZ0itmi/ZBh1/+7pOWwfamOdns=</P><Q>1xkw6uW2YPaSKhcTcspSFNkUgzprcP1ro8msRiD4j18=</Q><DP>DR+DFi57o0leMyVM0/g3OfS/1sCm8kBJaxECNXPgirE=</DP><DQ>yJC3uT/quC0SC2cq/k1DDieAZgCyMFBM7xNcrKOPwXc=</DQ><InverseQ>nw+ndBvLH9dH4nH9jLYq2AHjTrPVJD36qSh143hQQ10=</InverseQ><D>XCQ8wIVoctKKv9o9ra6U8j+dsV3i0Ta8zMTrtW3HzpgahnNvtI7l/XaMprlNrArf1MAEhHWB2RPAGYI/ntUwYQ==</D></RSAKeyValue>";
            string text1 = Encryptor.EncryptionRSA("10", publicPrivateKey);
            string text2 = Encryptor.DecryptionRSA(text1, publicPrivateKey);

            MessageBox.Show("text1 :  " + text1 + "\ntext2: " + text2);
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

        private void btn_QlyNhanVien_Click(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var frm = new frmEmployeeManagement();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();
            }
        }
    }
}
