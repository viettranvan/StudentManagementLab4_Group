using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class frmPointInput : Form
    {
        public frmPointInput()
        {
            InitializeComponent();
        }

        string chuoiketnoi = ConfigurationManager.ConnectionStrings["QlySV"].ConnectionString.ToString();
        string pubkey = "";

        private void frmPointInput_Load(object sender, System.EventArgs e)
        {
            dgv_DiemThi.DataSource = GetAllDiemThi(chuoiketnoi).Tables[0];
            btn_Save.Enabled = false;
            btn_Remove.Enabled = false;
            cbo_HocPhan.Enabled = false;
            cbo_SinhVien.Enabled = false;
            txt_DiemThi.Enabled = false;

            // đổ dữ liêu vào cbo_HocPhan
            cbo_HocPhan.Items.Clear();
            string query = "SELECT TENHP FROM HOCPHAN ";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbo_HocPhan.Items.Add(reader.GetString(0));// add dữ liệu vào cbo
                }
                // giải phóng
                cmd.Dispose();
                reader.Close();

                string queryPubKey = "SELECT PUBKEY FROM NHANVIEN WHERE MANV = '" + frmLogin.manvLogin + "'";
                SqlCommand cmdPubkey = new SqlCommand(queryPubKey, con);
                SqlDataReader readerPubkey = cmdPubkey.ExecuteReader();
                while (readerPubkey.Read())
                {
                    pubkey = readerPubkey.GetString(0); // add dữ liệu vào cbo
                }
                cmdPubkey.Dispose();
                readerPubkey.Close();

                con.Close();
            }

        }

        DataSet GetAllDiemThi(string chuoiketnoi)
        {
            DataSet data = new DataSet();
            string query = "SELECT HOTEN,MAHP,CONVERT(VARCHAR(MAX)," +
                "DECRYPTBYASYMKEY(ASYMKEY_ID('"+ pubkey  +"'),DIEMTHI,N'" + frmLogin.passLogin +"')) " +
                "AS DIEMTHI FROM BANGDIEM,SINHVIEN WHERE SINHVIEN.MASV = BANGDIEM.MASV";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(data);

                con.Close();
            }

            return data;
        }

        private void btn_Add_Click(object sender, System.EventArgs e)
        {
            cbo_HocPhan.Enabled = true;
            btn_Save.Enabled = true;
            btn_Remove.Enabled = true;
            btn_Add.Enabled = false;
            btn_Refresh.Enabled = false;
        }

        private void cbo_HocPhan_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            cbo_SinhVien.Enabled = true;
            cbo_SinhVien.Items.Clear();
            string query = "SELECT MAHP FROM HOCPHAN WHERE TENHP=N'" + cbo_HocPhan.Text + "'";
            string mahp = "";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mahp = reader.GetString(0)  ; // add dữ liệu vào cbo
                }
                // giải phóng
                cmd.Dispose();
                reader.Close();

                string querySV = "SELECT HOTEN FROM SINHVIEN";
                SqlCommand cmdSV = new SqlCommand(querySV, con);
                SqlDataReader readerSV = cmdSV.ExecuteReader();
                while (readerSV.Read())
                {
                    cbo_SinhVien.Items.Add(readerSV.GetString(0)); ;// add dữ liệu vào cbo
                }
                cmdSV.Dispose();
                readerSV.Close();

                con.Close();
            }
        }

        private void cbo_SinhVien_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txt_DiemThi.Enabled = true;

        }

        private void btn_Remove_Click(object sender, System.EventArgs e)
        {
            
            setState2();
        }

        private void setState2()
        {
            btn_Save.Enabled = false;
            btn_Remove.Enabled = false;
            cbo_HocPhan.Enabled = false;
            cbo_SinhVien.Enabled = false;
            txt_DiemThi.Enabled = false;
            btn_Add.Enabled = true;
            btn_Refresh.Enabled = true;

            cbo_HocPhan.Text = "";
            cbo_SinhVien.Text = "";
            txt_DiemThi.Text = "";
        }

        private void btn_Refresh_Click(object sender, System.EventArgs e)
        {
            dgv_DiemThi.DataSource = GetAllDiemThi(chuoiketnoi).Tables[0];
        }

        private void btn_Save_Click(object sender, System.EventArgs e)
        {
            string masv = "";
            string mahp = "";
            string diemthi = "";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                string querySV = "SELECT MASV FROM SINHVIEN WHERE HOTEN=N'" + cbo_SinhVien.Text + "'";
                SqlCommand cmdSV = new SqlCommand(querySV, con);
                SqlDataReader readerSV = cmdSV.ExecuteReader();
                while (readerSV.Read())
                {
                    masv = readerSV.GetString(0); // add dữ liệu vào cbo
                }
                // giải phóng
                cmdSV.Dispose();
                readerSV.Close();

                string queryHP = "SELECT MAHP FROM HOCPHAN WHERE TENHP=N'" + cbo_HocPhan.Text + "'";
                SqlCommand cmdHP = new SqlCommand(queryHP, con);
                SqlDataReader readerHP = cmdHP.ExecuteReader();
                while (readerHP.Read())
                {
                    mahp = readerHP.GetString(0); // add dữ liệu vào cbo
                }
                // giải phóng
                cmdSV.Dispose();
                readerSV.Close();

                diemthi = txt_DiemThi.Text;

                string queryIns = "INSERT INTO BANGDIEM VALUES ('" +masv +"','"+ mahp +
                    "',ENCRYPTBYASYMKEY(ASYMKEY_ID('"+pubkey+"'),'" + diemthi +"'))";
                SqlCommand cmdIns = new SqlCommand(queryIns, con);
                cmdIns.ExecuteNonQuery();

                MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_DiemThi.DataSource = GetAllDiemThi(chuoiketnoi).Tables[0];
                cmdIns.Dispose();
                setState2();
                con.Close();
            }
        }
    }
}
