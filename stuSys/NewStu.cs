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
    public partial class NewStu : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        DataSet ds;
        private string sqlStr;

        public NewStu()
        {
            InitializeComponent();
            this.Load+=NewStu_Load;
        }

        private void NewStu_Load(object sender, EventArgs e)
        {
            //sqlStr = "select Class_name from Class";
            //con = new SqlConnection (MyTool.connStr);
            //da = new SqlDataAdapter (sqlStr, con);
            //ds = new DataSet();
            //da.Fill(ds,"Class");
            ////通过For循环给下拉框填充数据
            //for(int i=0;i<ds.Tables["Class"].Rows.Count;i++)
            //{
            //    classList.Items.Add(ds.Tables["Class"].Rows[i]["Class_name"]);
            //}
            sqlStr = "select Class_name from class";
            con = new SqlConnection(MyTool.connStr);
            da = new SqlDataAdapter(sqlStr, con);
            ds = new DataSet();
            da.Fill(ds, "Class");                  //查询结果放在数据集里
            for (int i = 0; i < ds.Tables["Class"].Rows.Count; i++)
            {
                classList.Items.Add(ds.Tables["Class"].Rows[i]["Class_name"]);
            }
            //if(classList.Items.Count>0)
            //{
            //    classList.SelectedIndex = 0;      //让下拉框选中第一项数据
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(classList.SelectedItem.ToString().Trim()=="" || Stu_name.Text=="")
            {
                MessageBox.Show("学生姓名、班级必须填写！","提示");
            }
            else
            {
                sqlStr = "select Class_id from class where Class_name='" + classList.SelectedItem.ToString().Trim() + "'";
                con=new SqlConnection (MyTool.connStr);
                con.Open();
                cmd=new SqlCommand (sqlStr,con);
                string ClassId=cmd.ExecuteScalar().ToString();
                //在学生表中插入新数据
                sqlStr="insert into Student (Student_name,Sex,Entrance_date,Class_id,Birth,Nation"+
                    ",Home,Politic,ID,Job,specialty,Age) values ('"+Stu_name.Text.Trim()+"'"+
                    ",'"+Stu_sex.Text.Trim()+"','"+dateTimePicker1.Value.Date.ToString()+"','"+ClassId+"'"+
                    ",'"+dateTimePicker2.Value.Date.ToString()+"','"+Stu_nation.Text.Trim()+"','"+Stu_home.Text.Trim()+"'"+
                    ",'"+Stu_politic.Text.Trim()+"','"+Stu_idnum.Text.Trim()+"','"+Stu_position.Text.Trim()+"','"+Stu_specialty.Text.Trim()+"','"+Stu_age.Text.Trim()+"')";
                con = new SqlConnection(MyTool.connStr);
                con.Open();
                cmd = new SqlCommand(sqlStr ,con);
                int Succnum = cmd.ExecuteNonQuery();
                if(Succnum>0)
                {
                    MessageBox.Show("录入成功");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stu_name.Text = "";
            Stu_sex.Text = "";
            Stu_age.Text = "";
            Stu_home.Text = "";
            Stu_nation.Text = "";
            Stu_specialty.Text = "";
            Stu_politic.Text = "";
            Stu_position.Text = "";
            Stu_idnum.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void classList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewStu_Load_1(object sender, EventArgs e)
        {

        }
    }
}
