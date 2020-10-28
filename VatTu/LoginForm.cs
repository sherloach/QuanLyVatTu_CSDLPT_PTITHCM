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

namespace VatTu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);
            comboBox_ChiNhanh.SelectedIndex = 1;
            comboBox_ChiNhanh.SelectedIndex = 0;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.serverName = comboBox_ChiNhanh.SelectedValue.ToString();
        }

        private void Login() {
            Program.mlogin = textBox_Username.Text;
            Program.password = textBox_Password.Text;
            if (Program.KetNoi() == 0) return;

            MessageBox.Show("Đăng nhập thành công.", "", MessageBoxButtons.OK);
            Program.tenChiNhanh = comboBox_ChiNhanh.Text; //Lay ten chi nhanh da dang nhap
            Program.mChinhanh = comboBox_ChiNhanh.SelectedIndex;
            Program.bds_dspm = vDSPHANMANHBindingSource;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            Program.serverNameHT = Program.serverName;
            Program.conn = new SqlConnection(Program.connstr);
            Program.conn.Open();

            SqlDataReader myReader;

            String strleng = "EXEC SP_DANGNHAP '" + Program.mloginDN + "'";
            myReader = Program.ExecSqlDataReader(strleng);
            if (myReader == null) return;
            myReader.Read();

            Program.username = myReader.GetString(0);
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login của bạn không có quyền truy cập dữ liệu", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = myReader.GetString(1);
            Program.mGroup = myReader.GetString(2);
            myReader.Close();

            Program.formMain = new FormChinh();
            this.Visible = false;
            Program.formMain.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void TextBox_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
