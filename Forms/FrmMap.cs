using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentExamGradingSystem.Forms
{
    public partial class FrmMap : Form
    {
        public FrmMap()
        {
            InitializeComponent();
        }
        public string User;
        private void FrmMap_Load(object sender, EventArgs e)
        {
            lblUser.Text = User;
        }
        private void pnlDepartmentList_Click(object sender, EventArgs e)
        {
            FrmDepartmentList frmDepartmentList = new FrmDepartmentList();
            frmDepartmentList.Show();
        }

        private void pnlNewDepartment_Click(object sender, EventArgs e)
        {
            FrmDepartment frmDepartment = new FrmDepartment();
            frmDepartment.Show();
        }

        private void pnlGradeForm_Click(object sender, EventArgs e)
        {
            FrmGrade frmGrade = new FrmGrade();
            frmGrade.Show();
        }

        private void pnlStudentForm_Click(object sender, EventArgs e)
        {
            FrmStudent frmStudent = new FrmStudent();
            frmStudent.Show();
        }

        private void pnlStudentRegister_Click(object sender, EventArgs e)
        {
            FrmStudentRegister frmStudentRegister = new FrmStudentRegister();
            frmStudentRegister.Show();
        }

        private void pnlLessonList_Click(object sender, EventArgs e)
        {
            FrmLessonList frmLessonList = new FrmLessonList();
            frmLessonList.Show();
        }

        private void pnlNewLesson_Click(object sender, EventArgs e)
        {
            FrmNewLesson frmNewLesson = new FrmNewLesson();
            frmNewLesson.Show();
        }

        private void pnlExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlStudentPanel_Click(object sender, EventArgs e)
        {
            FrmStudentPanel frmStudentPanel = new FrmStudentPanel();
            frmStudentPanel.number = lblUser.Text;
            frmStudentPanel.Show();
        }
        
    }
}
