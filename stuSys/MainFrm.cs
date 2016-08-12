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
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 读取工具类MyTool的currentUserName,显示当前登陆的用户名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "当前登陆用户：" + MyTool.currentUserName;
        }

        private void 课程信息录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCourse nc = new NewCourse();
            nc.Show();
        }

        private void 课程信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryCourse qc = new QueryCourse();
            qc.Show();
        }

        private void 学生信息录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewStu ns=new NewStu();
            ns.Show();
        }

        private void 学生信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryStu qs = new QueryStu();
            qs.Show();
        }

        private void 选课信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewChooseCourse ncc = new NewChooseCourse();
            ncc.Show();
        }

        private void 学生信息管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewStuScore nss = new NewStuScore();
            nss.Show();
        }

        private void 学生信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
