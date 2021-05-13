using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class frmStudentManagement : Form
    {
        public frmStudentManagement()
        {
            InitializeComponent();
        }

        string chuoiketnoi = ConfigurationManager.ConnectionStrings["QlySV"].ConnectionString.ToString();
        private void frmStudentManagement_Load(object sender, System.EventArgs e)
        {
            // get all SINHVIEN
            dgv_SinhVien.DataSource = GetAllSinhVien(chuoiketnoi).Tables[0];
            txt_SoSV.Text = (dgv_SinhVien.Rows.Count - 1).ToString();
            initState();
            txt_SoSV.Enabled = false;
            cbo_NhanVien.Enabled = false;

            // đổ dữ liệu vào cbo_LopHoc
            cbo_LopHoc.Items.Clear();
            string query = "SELECT TENLOP FROM LOP";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbo_LopHoc.Items.Add(reader.GetString(0));// add dữ liệu vào cbo
                }
                // giải phóng
                cmd.Dispose();
                reader.Close();
                con.Close();
            }

        }

        private void initState()
        {
            txt_MSSV.Enabled = false;
            txt_Username.Enabled = false;
            txt_Password.Enabled = false;
            txt_Adress.Enabled = false;
            txt_Name.Enabled = false;
            dtp_NgaySinh.Enabled = false;
            btn_Save.Enabled = false;
            btn_Remove.Enabled = false;
            btn_Refresh.Enabled = true;
            btn_Edit.Enabled = true;
        }

        DataSet GetAllSinhVien(string chuoiketnoi)
        {
            DataSet data = new DataSet();
            string query = "SELECT MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, CAST(MATKHAU AS VARCHAR(MAX)) AS MATKHAU FROM SINHVIEN";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(data);

                con.Close();
            }

            return data;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (cbo_LopHoc.Text.Length == 0)
            {
                MessageBox.Show("Vui Lòng chọn lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                txt_MSSV.Enabled = false;
                txt_Username.Enabled = false;
                txt_Password.Enabled = true;
                txt_Adress.Enabled = true;
                txt_Name.Enabled = true;
                dtp_NgaySinh.Enabled = true;
                btn_Save.Enabled = true;
                btn_Remove.Enabled = true;
                btn_Edit.Enabled = false;
                btn_Refresh.Enabled = false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string matkhau = txt_Password.Text;
            string hoten = txt_Name.Text;
            string ngaysinh = dtp_NgaySinh.Text;
            string diachi = txt_Adress.Text;
            string queryUDT = "UPDATE SINHVIEN SET MATKHAU=CAST('" + matkhau + "' AS VARBINARY(MAX)), HOTEN=N'" + hoten + "',NGAYSINH='" + ngaysinh + "',DIACHI=N'" + diachi + "' WHERE MASV='" + txt_MSSV.Text + "'";

            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();

                SqlCommand cmdUdt = new SqlCommand(queryUDT, con);
                cmdUdt.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_SinhVien.DataSource = GetAllSinhVien(chuoiketnoi).Tables[0];
                txt_SoSV.Text = (dgv_SinhVien.Rows.Count - 1).ToString();
                initState();
                cmdUdt.Dispose();
                con.Close();
            }

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            dgv_SinhVien.DataSource = GetAllSinhVien(chuoiketnoi).Tables[0];
            txt_SoSV.Text = (dgv_SinhVien.Rows.Count - 1).ToString();
            initState();
            btn_Edit.Enabled = true;
            btn_Refresh.Enabled = true;
            txt_MSSV.Clear();
            txt_Username.Clear();
            txt_Password.Clear();
            txt_Name.Clear();
            txt_Adress.Clear();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            dgv_SinhVien.DataSource = GetAllSinhVien(chuoiketnoi).Tables[0];
            txt_SoSV.Text = (dgv_SinhVien.Rows.Count - 1).ToString();
            initState();
        }

        private void dgv_SinhVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txt_MSSV.Text = dgv_SinhVien.CurrentRow.Cells[0].Value.ToString();
            txt_Name.Text = dgv_SinhVien.CurrentRow.Cells[1].Value.ToString();
            dtp_NgaySinh.Text = dgv_SinhVien.CurrentRow.Cells[2].Value.ToString();
            txt_Adress.Text = dgv_SinhVien.CurrentRow.Cells[3].Value.ToString();
            txt_Username.Text = dgv_SinhVien.CurrentRow.Cells[5].Value.ToString();
            txt_Password.Text = dgv_SinhVien.CurrentRow.Cells[6].Value.ToString();
        }

        private void cbo_LopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string manv = "", tennv = "", malop = "";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                string query = "SELECT MANV,MALOP FROM LOP WHERE TENLOP=N'" + cbo_LopHoc.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    manv = reader.GetString(0);
                    malop = reader.GetString(1);
                }
                // giải phóng
                cmd.Dispose();
                reader.Close();
                string queryNV = "SELECT HOTEN FROM NHANVIEN WHERE MANV='" + manv + "'";
                SqlCommand cmdNV = new SqlCommand(queryNV, con);
                SqlDataReader readerNV = cmdNV.ExecuteReader();
                while (readerNV.Read())
                {
                    tennv = readerNV.GetString(0);// add dữ liệu vào cbo
                }
                cbo_NhanVien.Text = tennv;
                // giải phóng
                cmd.Dispose();
                reader.Close();

                DataSet data = new DataSet();
                string queryFilter = "SELECT MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, CAST(MATKHAU AS VARCHAR(MAX)) AS MATKHAU FROM SINHVIEN WHERE MALOP='" + malop + "'";
                SqlDataAdapter adapter2 = new SqlDataAdapter(queryFilter, con);

                adapter2.Fill(data);
                dgv_SinhVien.DataSource = data.Tables[0];
                txt_SoSV.Text = (dgv_SinhVien.Rows.Count - 1).ToString();
                con.Close();
            }

        }
    }
}
