using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stuSys
{
    public partial class NewCourse : Form
    {
        private string connStr = @"server=.;database=StuMagSys;Integrated Security=True";
        private SqlConnection con;
        private SqlCommand cmd;
        private string sqlStr;
        public NewCourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlStr="insert into course(Course_name,Credit) values('"+textBox1.Text.Trim()+"','"+textBox2.Text.Trim()+"')";
            con = new SqlConnection(connStr);
            con.Open();
            cmd = new SqlCommand(sqlStr, con);
            int Succum = cmd.ExecuteNonQuery();
            if (Succum > 0)
                MessageBox.Show("录入成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
