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
    public partial class QueryStu : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        DataSet ds;
        private SqlDataAdapter da;
        private string sqlStr;
        public QueryStu()
        {
            InitializeComponent();
        }

        private void QueryStu_Load(object sender, EventArgs e)
        {
            sqlStr = "select Class_name from class";
            con = new SqlConnection(MyTool.connStr);
            da = new SqlDataAdapter(sqlStr,con);
            ds = new DataSet();
            da.Fill(ds,"Class");                  //查询结果放在数据集里
            for(int i=0;i<ds.Tables["Class"].Rows.Count;i++)
            {
                ClassList.Items.Add(ds.Tables["Class"].Rows[i]["Class_name"]);
            }
            sqlStr = "select Student_id as 学生ID,Student_name as 姓名,Class_name as 班级,Sex as 性别,Birth " +
                " as 生日,Nation as 民族, Entrance_date as 入学日期,Home as 籍贯,Politic as 政治面貌,ID as " +
                " 身份证号码,Job as 职务,Specialty as 专业,Age as 年龄 from Student,Class where Student.Class_id=Class.Class_id";
            con = new SqlConnection(MyTool.connStr);
            da = new SqlDataAdapter(sqlStr,con);
            ds = new DataSet();
            da.Fill(ds,"Student");
            datagridview1.DataSource=ds.Tables["Student"];    //绑定数据
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlStr = "select Student_id as 学生ID,Student_name as 姓名,Class_name as 班级,Sex as 性别,Birth " +
               " as 生日,Nation as 民族, Entrance_date as 入学日期,Home as 籍贯,Politic as 政治面貌,ID as " +
               " 身份证号码,Job as 职务,Specialty as 专业,Age as 年龄 from Student,Class where Student.Class_id=Class.Class_id";
            sqlStr = sqlStr + " and Student_name like '%"+textBox1.Text.Trim()+"%'";
            if (ClassList.Text != "")
                sqlStr = sqlStr + "and Class.Class_name='"+ ClassList.Text +"'";
            con = new SqlConnection(MyTool.connStr);
            da = new SqlDataAdapter(sqlStr, con);
            ds = new DataSet();
            da.Fill(ds, "Student");
            datagridview1.DataSource = ds.Tables["Student"];    //绑定数据
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("您确认删除该记录吗？","确认",MessageBoxButtons.YesNoCancel)==DialogResult.Yes)
            {
                string stu_id = this.datagridview1.CurrentRow.Cells[0].Value.ToString();
                sqlStr = "delete from Student where Student_id=" + stu_id + "";
                con = new SqlConnection(MyTool .connStr);
                cmd = new SqlCommand(sqlStr, con);
                con.Open();
                int Succnum = cmd.ExecuteNonQuery();
                con.Close();
                if (Succnum > 0)
                    MessageBox.Show("删除成功");
                this.button1_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
