
namespace StudentManager
{
    partial class frmPointInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_HocPhan = new System.Windows.Forms.ComboBox();
            this.cbo_SinhVien = new System.Windows.Forms.ComboBox();
            this.txt_DiemThi = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.dgv_DiemThi = new System.Windows.Forms.DataGridView();
            this.MaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DiemThi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Học phần";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sinh Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Điểm thi";
            // 
            // cbo_HocPhan
            // 
            this.cbo_HocPhan.FormattingEnabled = true;
            this.cbo_HocPhan.Location = new System.Drawing.Point(75, 4);
            this.cbo_HocPhan.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_HocPhan.Name = "cbo_HocPhan";
            this.cbo_HocPhan.Size = new System.Drawing.Size(129, 23);
            this.cbo_HocPhan.TabIndex = 3;
            this.cbo_HocPhan.SelectedIndexChanged += new System.EventHandler(this.cbo_HocPhan_SelectedIndexChanged);
            // 
            // cbo_SinhVien
            // 
            this.cbo_SinhVien.FormattingEnabled = true;
            this.cbo_SinhVien.Location = new System.Drawing.Point(75, 39);
            this.cbo_SinhVien.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_SinhVien.Name = "cbo_SinhVien";
            this.cbo_SinhVien.Size = new System.Drawing.Size(129, 23);
            this.cbo_SinhVien.TabIndex = 4;
            this.cbo_SinhVien.SelectedIndexChanged += new System.EventHandler(this.cbo_SinhVien_SelectedIndexChanged);
            // 
            // txt_DiemThi
            // 
            this.txt_DiemThi.Location = new System.Drawing.Point(75, 76);
            this.txt_DiemThi.Margin = new System.Windows.Forms.Padding(2);
            this.txt_DiemThi.Name = "txt_DiemThi";
            this.txt_DiemThi.Size = new System.Drawing.Size(129, 23);
            this.txt_DiemThi.TabIndex = 5;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(305, 7);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(78, 35);
            this.btn_Add.TabIndex = 6;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(387, 7);
            this.btn_Remove.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(78, 35);
            this.btn_Remove.TabIndex = 7;
            this.btn_Remove.Text = "Hủy";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(305, 46);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(78, 35);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(387, 46);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(78, 35);
            this.btn_Refresh.TabIndex = 9;
            this.btn_Refresh.Text = "Tải lại";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // dgv_DiemThi
            // 
            this.dgv_DiemThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DiemThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSV,
            this.MaHP,
            this.DiemThi});
            this.dgv_DiemThi.Location = new System.Drawing.Point(8, 108);
            this.dgv_DiemThi.Name = "dgv_DiemThi";
            this.dgv_DiemThi.RowTemplate.Height = 25;
            this.dgv_DiemThi.Size = new System.Drawing.Size(501, 150);
            this.dgv_DiemThi.TabIndex = 10;
            this.dgv_DiemThi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_DiemThi_CellFormatting);
            // 
            // MaSV
            // 
            this.MaSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaSV.DataPropertyName = "HOTEN";
            this.MaSV.HeaderText = "Mã SV";
            this.MaSV.Name = "MaSV";
            // 
            // MaHP
            // 
            this.MaHP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaHP.DataPropertyName = "MAHP";
            this.MaHP.HeaderText = "Mã HP";
            this.MaHP.Name = "MaHP";
            // 
            // DiemThi
            // 
            this.DiemThi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DiemThi.DataPropertyName = "DIEMTHI";
            this.DiemThi.HeaderText = "Điểm Thi";
            this.DiemThi.Name = "DiemThi";
            // 
            // frmPointInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 270);
            this.Controls.Add(this.dgv_DiemThi);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.txt_DiemThi);
            this.Controls.Add(this.cbo_SinhVien);
            this.Controls.Add(this.cbo_HocPhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPointInput";
            this.Text = "PointInput";
            this.Load += new System.EventHandler(this.frmPointInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DiemThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_HocPhan;
        private System.Windows.Forms.ComboBox cbo_SinhVien;
        private System.Windows.Forms.TextBox txt_DiemThi;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.DataGridView dgv_DiemThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHP;
    }
}