using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stuSys
{
    public partial class NewStuScore : Form
    {
        public NewStuScore()
        {
            InitializeComponent();
        }

        private void NewStuScore_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            MyTool.queryDataToComno("select Class_name from Class", "Class_name", ClassList);
        }

        private void StudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox1.Text = "";
            string studentId = MyTool.getStudentIdByStudentName(StudentList.Text);
            string sqlStr = "select Student_course.ID as 记录ID,Student_name as 学生姓名,Class_name as 班级" +
               " ,Course_name as 课程, Student_course.Score as 成绩 from Student,Course,Student_course,Class" +
               " where Student.Student_id=Student_course.Student_id and Course.Course_id=Student_course.Course_id" +
               " and Class.Class_id =Student.Class_id and Student.Student_id ='" + studentId + "'";
            //填充数据表
            MyTool.queryDataToGrid(sqlStr, dataGridView1);
        }

        private void ClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string classId = MyTool.getClassIdByCourseName(ClassList.Text);
            StudentList.Items.Clear();
            MyTool.getStuListByClassId(classId, StudentList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlStr="update Student_course set Score = "+textBox2.Text+" where id='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'";
            int Succnum=MyTool.executeCommand(sqlStr);
            if(Succnum>0)
            {
                MessageBox.Show("录入成功");
            }
            StudentList_SelectedIndexChanged(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("您确认要删除该记录吗？","确认",MessageBoxButtons.YesNoCancel)==DialogResult.Yes )
            {
                string sqlStr = "update Student_course set Score=null where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                int Succnum=MyTool.executeCommand(sqlStr);
                if (Succnum > 0)
                {
                    MessageBox.Show("删除成功");
                }
                StudentList_SelectedIndexChanged(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
