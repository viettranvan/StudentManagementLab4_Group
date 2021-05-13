
namespace StudentManager
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_QLSinhVien = new System.Windows.Forms.Button();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.btn_QLLopHoc = new System.Windows.Forms.Button();
            this.btn_NhapDiem = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_QLSinhVien
            // 
            this.btn_QLSinhVien.Location = new System.Drawing.Point(57, 12);
            this.btn_QLSinhVien.Name = "btn_QLSinhVien";
            this.btn_QLSinhVien.Size = new System.Drawing.Size(112, 42);
            this.btn_QLSinhVien.TabIndex = 0;
            this.btn_QLSinhVien.Text = "QL Lớp  Học";
            this.btn_QLSinhVien.UseVisualStyleBackColor = true;
            this.btn_QLSinhVien.Click += new System.EventHandler(this.ql_Class_Click);
            this.btn_QLSinhVien.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ql_Class_MouseClick);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.Location = new System.Drawing.Point(121, 78);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(109, 42);
            this.btn_DangNhap.TabIndex = 1;
            this.btn_DangNhap.Text = "Đăng Nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = true;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_QLLopHoc
            // 
            this.btn_QLLopHoc.Location = new System.Drawing.Point(207, 12);
            this.btn_QLLopHoc.Name = "btn_QLLopHoc";
            this.btn_QLLopHoc.Size = new System.Drawing.Size(110, 42);
            this.btn_QLLopHoc.TabIndex = 2;
            this.btn_QLLopHoc.Text = "QL Sinh Viên";
            this.btn_QLLopHoc.UseVisualStyleBackColor = true;
            this.btn_QLLopHoc.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_NhapDiem
            // 
            this.btn_NhapDiem.Location = new System.Drawing.Point(347, 12);
            this.btn_NhapDiem.Name = "btn_NhapDiem";
            this.btn_NhapDiem.Size = new System.Drawing.Size(119, 42);
            this.btn_NhapDiem.TabIndex = 3;
            this.btn_NhapDiem.Text = "Nhập Điểm";
            this.btn_NhapDiem.UseVisualStyleBackColor = true;
            this.btn_NhapDiem.Click += new System.EventHandler(this.btn_NhapDiem_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(281, 78);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(113, 42);
            this.btn_Thoat.TabIndex = 4;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 151);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_NhapDiem);
            this.Controls.Add(this.btn_QLLopHoc);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.btn_QLSinhVien);
            this.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu chức năng";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_QLSinhVien;
        private System.Windows.Forms.Button btn_QLLopHoc;
        private System.Windows.Forms.Button btn_NhapDiem;
        private System.Windows.Forms.Button btn_Thoat;
        public System.Windows.Forms.Button btn_DangNhap;
    }
}

