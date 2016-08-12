using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace stuSys
{
    class MyTool
    {
        //定义数据库连接字符串
        public static string connStr = @"server=.;database=StuMagSys;Integrated Security=True;";
        public static DataGridView myDataGridView;     //用来在窗体间传递数据，做中间人
        public static string currentUserName;           //当前登陆用户
        public static string student_id;
        public static string student_name;
        public static string class_id;
        public static string class_name;
        /// <summary>
        /// 通过学生名字获取学生ID
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public static string getStudentIdByStudentName(string studentName)
        {
            string sqlStr = "select Student_id from Student where Student_name='" + studentName + "'";
            SqlConnection sqlconncetion1 = new SqlConnection(MyTool.connStr);
            sqlconncetion1.Open();
            SqlCommand sqlcommand1 = new SqlCommand(sqlStr, sqlconncetion1);
            string studentId = sqlcommand1.ExecuteScalar().ToString();
            sqlconncetion1.Close();
           
            return studentId;
        }

        /// <summary>
        /// 通过课程名字获取课程ID
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public static string getCourseIdByCourseName(string courseName)
        {
            string sqlStr = "select Course_id from Course where Course_name='" + courseName + "'";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand com = new SqlCommand(sqlStr, conn);
            string courseId = com.ExecuteScalar().ToString();
          
            return courseId;
        }

        /// <summary>
        /// 通过班级名字获取班级ID
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public static string getClassIdByCourseName(string className)
        {
            string sqlStr = "select Class_id from Class where Class_name='" + className + "'";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            string classId = cmd.ExecuteScalar().ToString();
           
            return classId;
        }

        /// <summary>
        /// 通过班级ID，查询该班的所有学生姓名，并放入到指定下拉框中
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="combobox"></param>
        public static void getStuListByClassId(string classId, ComboBox comboBox)
        {
            string sqlStr = "select Student_name from Student where Class_id='" + classId + "'";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");             //查询结果放到数据集里
            comboBox.Items.Clear();            //清空下拉框数据，防止重复
            comboBox.Text = "";
            //通过FOR循环给下拉框填充数据
            for (int i = 0; i < ds.Tables["student"].Rows.Count; i++)
            {
                comboBox.Items.Add(ds.Tables["student"].Rows[i]["Student_name"]);

            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            
        }

        /// <summary>
        /// 查询到指定的字段的数据，并填充到指定的下拉框中
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="columnName"></param>
        /// <param name="comboBox1"></param>
        public static void queryDataToComno(string sqlStr, string columnName, ComboBox comboBox1)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            comboBox1.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][columnName]);
            }
            comboBox1.SelectedIndex = 0;
            
        }

        /// <summary>
        /// 查询到指定的数据记录，并填充到数据控件GridView中
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="dataGridView1"></param>
        public static void queryDataToGrid(string sqlStr, DataGridView  gridView1)
        {
            SqlConnection con = new SqlConnection(connStr);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridView1.DataSource=ds.Tables[0];
            //gridView1.Columns.Add(ds.Tables[0].ToString());

        }
        public static int executeCommand(string sqlstr)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int Succnum = cmd.ExecuteNonQuery();
            
            return Succnum;
        }
    }
}
