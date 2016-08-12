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
    public partial class NewChooseCourse : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        DataSet ds;
        private string sqlStr;
        public NewChooseCourse()
        {
            InitializeComponent();
 //           this.Load+=NewChooseCourse_Load;
  //          this.Load += StudentList_SelectedIndexChanged;
        }

        private void NewChooseCourse_Load(object sender, EventArgs e)
        {
          //  sqlStr = "select Class_name from Class";
          //  MyTool.queryDataToComno(sqlStr,"Class_name",ClassList);
            sqlStr = "select Course_name from Course";
            MyTool.queryDataToComno(sqlStr, "Course_name", CourseList);

          ////  string studentId = MyTool.getStudentIdByStudentName(StudentList.Text);
          //   sqlStr = "select Student_id from Student where Student_name='" + StudentList.Text + "'";
          //  SqlConnection sqlconncetion1 = new SqlConnection(MyTool.connStr);
          //  sqlconncetion1.Open();
          //  SqlCommand sqlcommand1 = new SqlCommand(sqlStr, sqlconncetion1);
          //  string studentId = sqlcommand1.ExecuteScalar().ToString();
          //  sqlconncetion1.Close();
          //   sqlStr = "select Student_course.ID as 记录ID,Student_name as 学生姓名,Class_name as 班级" +
          //      " ,Course_name as 课程,Course.Credit as 学分 from Student,Course,Student_course,Class" +
          //      " where Student.Student_id=Student_course.Student_id and Course.Course_id=Student_course.Course_id" +
          //      " and Class.Class_id =Student.Class_id and Student.Student_id ='" + studentId + "'";
          //  //填充数据表
          //  MyTool.queryDataToGrid(sqlStr, dataGridView1);
          //  //填充学生下拉框
          //  sqlStr = "select Student_name from Student";
          //  MyTool.queryDataToComno(sqlStr, "Student_name", StudentList);
            MyTool.queryDataToComno("select Class_name from Class", "Class_name", ClassList);
        }

        private void ClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string classId = MyTool.getClassIdByCourseName(ClassList.Text);
            StudentList.Items.Clear();
            MyTool.getStuListByClassId(classId, StudentList);
        }

        private void StudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string studentId = MyTool.getStudentIdByStudentName(StudentList.Text);
            //string sqlStr = "select Student_course.ID as 记录ID,Student_name as 学生姓名,Class_name as 班级" +
            //    " ,Course_name as 课程,Course.Credit as 学分 from Student,Course,Student_course,Class" +
            //    " where Student.Student_id=Student_course.Student_id and Course.Course_id=Student_course.Course_id" +
            //    " and Class.Class_id =Student.Class_id and Student.Student_id ='" + studentId + "'";
            ////填充数据表
            //MyTool.queryDataToGrid(sqlStr, dataGridView1);
            ////填充学生下拉框
            //sqlStr = "select Student_name from Student";
            //MyTool.queryDataToComno(sqlStr, "Student_name", StudentList);
            //sqlStr = "select Student_id from Student where Student_name='" + StudentList.Text + "'";
            //SqlConnection sqlconncetion1 = new SqlConnection(MyTool.connStr);
            //sqlconncetion1.Open();
            //SqlCommand sqlcommand1 = new SqlCommand(sqlStr, sqlconncetion1);
            //string studentId = sqlcommand1.ExecuteScalar().ToString();
            //sqlconncetion1.Close();
            //sqlStr = "select Student_course.ID as 记录ID,Student_name as 学生姓名,Class_name as 班级" +
            //   " ,Course_name as 课程,Course.Credit as 学分 from Student,Course,Student_course,Class" +
            //   " where Student.Student_id=Student_course.Student_id and Course.Course_id=Student_course.Course_id" +
            //   " and Class.Class_id =Student.Class_id and Student.Student_id ='" + studentId + "'";
            ////填充数据表
            //MyTool.queryDataToGrid(sqlStr, dataGridView1);
            ////填充学生下拉框
            //sqlStr = "select Student_name from Student";
            //MyTool.queryDataToComno(sqlStr, "Student_name", StudentList);
            string studentId = MyTool.getStudentIdByStudentName(StudentList.Text);
            string sqlStr = "select Student_course.ID as 记录ID,Student_name as 学生姓名,Class_name as 班级" +
               " ,Course_name as 课程, Student_course.Score as 成绩 from Student,Course,Student_course,Class" +
               " where Student.Student_id=Student_course.Student_id and Course.Course_id=Student_course.Course_id" +
               " and Class.Class_id =Student.Class_id and Student.Student_id ='" + studentId + "'";
            //填充数据表
            MyTool.queryDataToGrid(sqlStr, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentId = MyTool.getStudentIdByStudentName(StudentList.Text);
            string courseId = MyTool.getCourseIdByCourseName(CourseList.Text);
            string sqlStr = "insert into Student_course(Student_id,Course_id) values ('" + studentId + "','" + courseId + "')";
            int Succnum = MyTool.executeCommand(sqlStr);
            if (Succnum > 0)
                MessageBox.Show("录入成功");
            StudentList_SelectedIndexChanged(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确认要删除该记录吗？", "确认", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                string id = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string sqlStr = "delete from Student_course where id =" + id + "";
                int Succnum = MyTool.executeCommand(sqlStr);
                if (Succnum > 0)
                    MessageBox.Show("删除成功");
                StudentList_SelectedIndexChanged(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
