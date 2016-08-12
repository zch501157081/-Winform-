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
    public partial class QueryCourse : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        DataSet ds;
        private string sqlStr;       
        public QueryCourse()
        {
            InitializeComponent();
        }

        private void QueryCourse_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox2.Visible = false;
            sqlStr = "select Course_id as 课程编号,Course_name as 课程名称,Credit as 学分 from course";
            con = new SqlConnection(MyTool.connStr);
            da = new SqlDataAdapter(sqlStr, con);
            ds = new DataSet();
            da.Fill(ds, "course");
            dataGridView1.DataSource=ds.Tables["course"];         //绑定数据
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlStr = "select Course_id as 课程编号,Course_name as 课程名称,Credit as 学分 from course";
            sqlStr = sqlStr + @" where Course_name like '%"+textBox1.Text+@"%'";
            con = new SqlConnection(MyTool.connStr);
            da = new SqlDataAdapter(sqlStr, con);
            ds = new DataSet();
            da.Fill(ds, "course");
            dataGridView1.DataSource = ds.Tables["course"];         //绑定数据

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text=="编辑")
            {
                button2.Text = "保存修改";
                label2.Visible = true;
                textBox2.Visible = true;
                   
            }
            else if (button2.Text == "保存修改")
            {
                if (dataGridView1.SelectedRows.Count < 0)
                {
                    MessageBox.Show("请选中要修改的数据行");
                    return;
                }
                sqlStr="update course set Course_name ='"+textBox1.Text.Trim()+"',Credit='"+
                    textBox2.Text.Trim()+"'where Course_id='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'";
                con = new SqlConnection(MyTool.connStr);
                cmd = new SqlCommand(sqlStr, con);
                con.Open();
                int Succnum = cmd.ExecuteNonQuery();
                con.Close();
                if (Succnum > 0)
                    MessageBox.Show("修改成功");
                button2.Text = "编辑";
                label2.Visible = false;
                textBox2.Visible = false;
                //调用查询按钮的代码，刷新窗体上的DataGridView里的数据
                this.button1_Click(sender, e);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确认要删除该记录吗？", "确认", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                string course_id = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sqlStr = "delete from Course where Course_id ='" + course_id + "'";
                con = new SqlConnection(MyTool.connStr);
                cmd = new SqlCommand(sqlStr, con);
                con.Open();
                int Succnum = cmd.ExecuteNonQuery();
                con.Close();;
                //调用查询按钮的代码，刷新窗体上的DataGridView里的数据
                this.button1_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

    }
}
