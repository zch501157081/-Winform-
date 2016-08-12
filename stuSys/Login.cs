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

namespace stuSys
{
    public partial class Login : Form
    {
        private SqlConnection sqlConnection1;
        private SqlCommand sqlCommand1;
        private SqlDataAdapter sqlDataAdapter1;
        DataSet dataset;
        private string connStr = @"server=.;database=StuMagSys;Integrated Security=True;";
        private string sqlstr;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //根据用户输入的用户名和密码初始化查询
            sqlstr = "select * from syuser where Use_name='"+this.textBox1.Text.Trim()+"'and password='"+this.textBox2.Text.Trim()+"'";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "syuser");
            DataTable mytable = ds.Tables[0];
            if (mytable.Rows.Count > 0)
            {
                this.Hide();       //隐藏当前窗体
                MyTool.currentUserName = textBox1.Text;
                MainFrm mainFrm = new MainFrm();
                mainFrm.Show();
                


            }
            else
            {
                MessageBox.Show("用户名/密码错误！请重试！", "确认", MessageBoxButtons.OK);
            }
            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
