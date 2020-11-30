using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatTu.SimpleForm
{
    public partial class FormTaoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public FormTaoTaiKhoan()
        {
            InitializeComponent();
            if (Program.mGroup == "CONGTY")
            {
                //this.label4.Visible = false;
                //this.radioButton_ChiNhanh.Visible = false;
                this.radioButton_User.Visible = false;
                this.radioButton_ChiNhanh.Text = "CÔNG TY";
                this.radioButton_ChiNhanh.Checked = true;
            }
        }

        private void FormTaoTaiKhoan_Load(object sender, EventArgs e)
        {

            this.v_DS_NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS_NHANVIEN.V_DS_NHANVIEN' table. You can move, or remove it, as needed.
            this.v_DS_NHANVIENTableAdapter.Fill(this.dS_NHANVIEN.V_DS_NHANVIEN);
        }

        private void createAccount()
        {
            /*if (comboBox_Role.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (comboBox_NV.SelectedValue.ToString() == "System.Data.DataRowView") return;*/
            if (textBox_LoginName.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                textBox_LoginName.Focus();
                return;
            }
            else if (textBox_Password.Text.Trim() == "")
            {
                MessageBox.Show("Password không được để trống", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                textBox_Password.Focus();
                return;
            }
            String login = textBox_LoginName.Text.Trim();
            String password = textBox_Password.Text.Trim();
            int username = (int)comboBox_NV.SelectedValue;
            String role = "";
            //if (comboBox_Role.SelectedIndex == 0) role = "CONGTY";
            //else if (comboBox_Role.SelectedIndex == 1) role = "CHINHANH";
            //else if (comboBox_Role.SelectedIndex == 2) role = "USER";
            if (Program.mGroup == "CONGTY") role = "CONGTY";
            else
            {
                if (radioButton_ChiNhanh.Checked == true) role = "CHINHANH";
                else if (radioButton_User.Checked == true) role = "USER";
            }
            Console.WriteLine(login + "  " + password + "   " + username + "    " + role);

            Program.conn = new SqlConnection(Program.connstr);
            Program.conn.Open();
            SqlCommand cmd = new SqlCommand("SP_TAOACCOUNT", Program.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@LGNAME", login));
            cmd.Parameters.Add(new SqlParameter("@PASS", password));
            cmd.Parameters.Add(new SqlParameter("@USERNAME", username));
            cmd.Parameters.Add(new SqlParameter("@ROLE", role));
            SqlDataReader myReader = null;
            //String strleng = "EXEC SP_TAOTAIKHOAN '" + login + "','"+password+"','"+username+"','"+role+"'";
            try
            {
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Button_confirm_Click(object sender, EventArgs e)
        {
            createAccount();
            Console.WriteLine(comboBox_NV.SelectedValue);
            Console.WriteLine();
            Console.WriteLine(textBox_LoginName.Text);
            Console.WriteLine(textBox_Password.Text);
            //Console.WriteLine(comboBox_Role.SelectedIndex);
        }

        private void RadioButton_ChiNhanh_CheckedChanged(object sender, EventArgs e)
        {
            if (Program.mGroup == "CONGTY")
            {
                radioButton_ChiNhanh.Checked = true;
            }
            else if (radioButton_User.Checked == true) radioButton_User.Checked = false;
        }

        private void RadioButton_User_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_ChiNhanh.Checked == true) radioButton_ChiNhanh.Checked = false;
        }
    }
}
