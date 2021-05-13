using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace StudentManager
{
    public partial class frmEmployeeManagement : Form
    {
        public frmEmployeeManagement()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["QlySV"].ConnectionString.ToString();
        SqlConnection con;
        

        string Key = "4401104244VIETTV";

        string action = "";

        private void frmEmployeeManagement_Load(object sender, EventArgs e)
        {
            
            dgv_Employee.DataSource = GetAllNhanVien(connectionString).Tables[0];
            initState();
        }

        private void initState()
        {
            btn_Add.Enabled = true;
            btn_Delete.Enabled = true;
            btn_update.Enabled = true;
            btn_exit.Enabled = true;
            btn_Save.Enabled = false;
            btn_cancel.Enabled = false;
        }

        private void AddState()
        {
            btn_Add.Enabled = false;
            btn_Delete.Enabled = false;
            btn_update.Enabled = false;
            btn_exit.Enabled = false;
            btn_Save.Enabled = true;
            btn_cancel.Enabled = true;
        }

        private void UpdateState()
        {
            btn_Add.Enabled = false;
            btn_Delete.Enabled = false;
            btn_update.Enabled = false;
            btn_exit.Enabled = false;
            btn_Save.Enabled = true;
            btn_cancel.Enabled = true;
            txt_username.Enabled = false;
            txt_EmployeeID.Enabled = false;
            txt_password.Enabled = false;
        }

        private void CancelState()
        {
            txt_Email.Clear();
            txt_EmployeeID.Clear();
            txt_fullname.Clear();
            txt_password.Clear();
            txt_salary.Clear();
            txt_username.Clear();
            btn_Add.Enabled = true;
            btn_Delete.Enabled = true;
            btn_update.Enabled = true;
            btn_exit.Enabled = true;
            btn_Save.Enabled = false;
            btn_cancel.Enabled = false;
        }

        DataSet GetAllNhanVien(string connectionString)
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SEL_PUBLIC_ENCRYPT_NHANVIEN", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = frmLogin.manvLogin;
                cmd.Parameters.Add("@matkhau", SqlDbType.VarChar).Value = frmLogin.passLogin;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);
            }

            return data;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddState();
            action = "ADD";
        }

   
        private void btn_Delete_Click_1(object sender, EventArgs e)
        {
            string manv = txt_EmployeeID.Text;
            if (manv.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string delete = "DELETE FROM NHANVIEN WHERE MANV='" + manv + "'";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        SqlCommand cmdDel = new SqlCommand(delete, con);
                        cmdDel.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv_Employee.DataSource = GetAllNhanVien(connectionString).Tables[0];
                        cmdDel.Dispose();
                        con.Close();
                    }
                }
            }

        }

        private void btn_update_Click_1(object sender, EventArgs e)
        {
            UpdateState();
            action = "UPDATE";
        }

        // format Column Luong byte array => to string
        private void dgv_Employee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value != null)
                {
                    
                    byte[] salaryByte = (byte[])e.Value;
                    string salaryString = Encoding.UTF8.GetString(salaryByte);
                    //string salaryDescyptor = Encryptor.DecryptionRSA(salaryString, pubkey);
                    e.Value = salaryString;
                    e.FormattingApplied = true;
                }
                else
                    e.FormattingApplied = false;
            }
        }

        private void dgv_Employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_EmployeeID.Text = dgv_Employee.CurrentRow.Cells[0].Value.ToString();
            txt_fullname.Text = dgv_Employee.CurrentRow.Cells[1].Value.ToString();
            txt_Email.Text = dgv_Employee.CurrentRow.Cells[2].Value.ToString();
            byte[] salaryByte = (byte[])dgv_Employee.CurrentRow.Cells[3].Value;
            string pubkey = "";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string queryPubKey = "SELECT PUBKEY FROM NHANVIEN WHERE MANV = '" + dgv_Employee.CurrentRow.Cells[0].Value.ToString() + "'";
                SqlCommand cmdPubkey = new SqlCommand(queryPubKey, con);
                SqlDataReader readerPubkey = cmdPubkey.ExecuteReader();
                while (readerPubkey.Read())
                {
                    pubkey = readerPubkey.GetString(0);
                }
                cmdPubkey.Dispose();
                readerPubkey.Close();

                con.Close();
            }
            string salaryString = Encoding.UTF8.GetString(salaryByte);
            string salaryDescyptor = Encryptor.DecryptionRSA(salaryString, pubkey);
            txt_salary.Text = salaryDescyptor;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(action == "ADD")
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string publicKeyString = Encryptor.generatePublicKey();
                       
                    string salary = Encryptor.EncryptionRSA(txt_salary.Text, publicKeyString);
                    string password = Encryptor.SHA1Hash(txt_password.Text);
                    using (SqlCommand cmd = new SqlCommand("SP_INS_PUBLIC_ENCRYPT_NHANVIEN", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = txt_EmployeeID.Text;
                        cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = txt_fullname.Text;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = txt_Email.Text;
                        cmd.Parameters.Add("@luongcb", SqlDbType.VarChar).Value = salary;
                        cmd.Parameters.Add("@tendn", SqlDbType.NVarChar).Value = txt_username.Text;
                        cmd.Parameters.Add("@matkhau", SqlDbType.VarChar).Value = password;
                        cmd.Parameters.Add("@pubkey", SqlDbType.VarChar).Value = publicKeyString;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv_Employee.DataSource = GetAllNhanVien(connectionString).Tables[0];
                        CancelState();
                    }
                }
            }else if(action == "UPDATE")
            {
                txt_EmployeeID.Enabled = false;
                txt_username.Enabled = false;
                if(txt_EmployeeID.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn nhân viên muốn chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        string publicKeyString = "";
                        string queryPubKey = "SELECT PUBKEY FROM NHANVIEN WHERE MANV = '" + txt_EmployeeID.Text + "'";
                        SqlCommand cmdPubkey = new SqlCommand(queryPubKey, con);
                        SqlDataReader readerPubkey = cmdPubkey.ExecuteReader();
                        while (readerPubkey.Read())
                        {
                            publicKeyString = readerPubkey.GetString(0);
                        }
                        cmdPubkey.Dispose();
                        readerPubkey.Close();
                        string salary = Encryptor.EncryptionRSA(txt_salary.Text, publicKeyString);
                        string password = Encryptor.SHA1Hash(txt_password.Text);
                        byte[] salaryBin = Encoding.ASCII.GetBytes(salary);
                        byte[] passwordBin = Encoding.ASCII.GetBytes(password);
                        string update = "update NHANVIEN set EMAIL=@email, HOTEN=@hoten, LUONG=@luong where MANV='" + txt_EmployeeID.Text + "'";
                        SqlCommand cmdUdt = new SqlCommand(update, con);
                        cmdUdt.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = txt_fullname.Text;
                        cmdUdt.Parameters.Add("@email", SqlDbType.NVarChar).Value = txt_Email.Text;
                        cmdUdt.Parameters.Add("@luong", SqlDbType.VarBinary).Value = salaryBin;
                        

                        cmdUdt.ExecuteNonQuery();

                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv_Employee.DataSource = GetAllNhanVien(connectionString).Tables[0];
                        CancelState();
                        cmdUdt.Dispose();
                        con.Close();
                    }

                }
            }
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            CancelState();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {

        }
    }
}
