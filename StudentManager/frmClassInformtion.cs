using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class frmClassInformtion : Form
    {
        public frmClassInformtion()
        {
            InitializeComponent();
        }
        string chuoiketnoi = ConfigurationManager.ConnectionStrings["QlySV"].ConnectionString.ToString();
        string action = "";
        private void frmClassInformtion_Load(object sender, System.EventArgs e)
        {
            // Get All LOP
            dgvLop.DataSource = GetAllLop(chuoiketnoi).Tables[0];
            txt_MaLop.Enabled = false;
            txt_TenLop.Enabled = false;
            cbo_TenNV.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Huy.Enabled = false;


            // đổ dữ liệu vào cbo_TenNV
            cbo_TenNV.Items.Clear();
            string query = "Select HOTEN from NHANVIEN";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbo_TenNV.Items.Add(reader.GetString(0));// add dữ liệu vào cbo
                }
                // giải phóng
                cmd.Dispose();
                reader.Close();
                con.Close();
            }
        }

        DataSet GetAllLop(string chuoiketnoi) 
        {
            DataSet data = new DataSet();
            string query = "SELECT MALOP,TENLOP,HOTEN FROM LOP,NHANVIEN WHERE NHANVIEN.MANV = LOP.MANV";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query,con);
                adapter.Fill(data);

                con.Close();
            }

                return data;
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            SetState();
            action = "Them";
        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            SetState();
            txt_MaLop.Enabled = false;
            action = "Sua";
        }

        public void SetState()
        {
            txt_MaLop.Enabled = true;
            txt_TenLop.Enabled = true;
            cbo_TenNV.Enabled = true;
            btn_Luu.Enabled = true;
            btn_Huy.Enabled = true;
            btn_Them.Enabled = false;
            btn_Sua.Enabled = false;
            btn_TaiLai.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        public void SetState2()
        {
            txt_MaLop.Enabled = false;
            txt_TenLop.Enabled = false;
            cbo_TenNV.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Huy.Enabled = false;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_TaiLai.Enabled = true;
            btn_Xoa.Enabled = true;

            txt_MaLop.Clear();
            txt_TenLop.Clear();
            cbo_TenNV.Text ="";

        }

        private void btn_TaiLai_Click(object sender, System.EventArgs e)
        {
            dgvLop.DataSource = GetAllLop(chuoiketnoi).Tables[0];
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaLop.Text = dgvLop.CurrentRow.Cells[0].Value.ToString();
            txt_TenLop.Text = dgvLop.CurrentRow.Cells[1].Value.ToString();
            cbo_TenNV.Text = dgvLop.CurrentRow.Cells[2].Value.ToString();
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            SetState2();
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            if (action == "Them")
            {
                ThemLop();
                SetState2();
            }
            if (action == "Sua")
            {
                SuaLop();
                SetState2();
            }
        }

        private void SuaLop()
        {
            string malop = txt_MaLop.Text;
            string TenLop = txt_TenLop.Text;
            string manv = "";
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                string queryK = "SELECT MANV FROM NHANVIEN WHERE HOTEN='" + cbo_TenNV.Text + "'";
                SqlCommand cmdKhoa = new SqlCommand(queryK, con);
                SqlDataReader readerK = cmdKhoa.ExecuteReader();
                while (readerK.Read())
                {
                    manv = readerK.GetString(0); // add vào cboKhoa
                }
                cmdKhoa.Dispose();
                readerK.Close();

                string update = "update LOP set TenLop = N'" + TenLop + "',MANV='" + manv + "' where MALOP='" + malop + "'";
                SqlCommand cmdUdt = new SqlCommand(update, con);
                cmdUdt.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvLop.DataSource = GetAllLop(chuoiketnoi).Tables[0];
                cmdUdt.Dispose();
                con.Close();
            }
        }

        private void ThemLop()
        {
            string malop = txt_MaLop.Text;
            string tenlop = txt_TenLop.Text;
            string manv = "";
            if (malop.Length > 0 && tenlop.Length > 0) 
            {
                using (SqlConnection con = new SqlConnection(chuoiketnoi))
                {
                    con.Open();
                    string queryK = "SELECT MANV FROM NHANVIEN WHERE HOTEN='" + cbo_TenNV.Text + "'";
                    SqlCommand cmdKhoa = new SqlCommand(queryK, con);
                    SqlDataReader readerK = cmdKhoa.ExecuteReader();
                    while (readerK.Read())
                    {
                        manv = readerK.GetString(0); // add vào cboKhoa
                    }
                    cmdKhoa.Dispose();
                    readerK.Close();
                    string insert = "INSERT INTO LOP VALUES('" + malop + "',N'" + tenlop + "','" + manv + "')";
                    SqlCommand cmdIns = new SqlCommand(insert, con);
                    cmdIns.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvLop.DataSource = GetAllLop(chuoiketnoi).Tables[0];
                    cmdIns.Dispose();

                    con.Close();
                }
            }
            
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            string malop = txt_MaLop.Text;
            if (malop.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)) 
                {
                    string delete = "DELETE FROM LOP WHERE MALOP='" + malop + "'";
                    using (SqlConnection con = new SqlConnection(chuoiketnoi))
                    {
                        con.Open();
                        SqlCommand cmdDel = new SqlCommand(delete, con);
                        cmdDel.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        dgvLop.DataSource = GetAllLop(chuoiketnoi).Tables[0];
                        cmdDel.Dispose();
                        con.Close();
                    }
                }
            }
        }
    }
}
