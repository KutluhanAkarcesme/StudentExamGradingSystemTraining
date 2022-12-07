using StudentExamGradingSystem.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentExamGradingSystem.Forms
{
    public partial class FrmGrade : Form
    {
        public FrmGrade()
        {
            InitializeComponent();
        }
        StudentExamGradingSystemEntities systemEntities = new StudentExamGradingSystemEntities();
        void GetList()
        {
            //dataGridView1.DataSource = systemEntities.View_1.ToList();

            var values = from x in systemEntities.TblGrade
                         select new
                         {
                             x.Id,
                             Ders = x.TblLesson.LessonName,
                             Öğrenci = x.TblStudent.StdName + " " + x.TblStudent.StdSurname,
                             x.Exam1,
                             x.Exam2,
                             x.Exam3,
                             x.Quiz1,
                             x.Quiz2,
                             Proje = x.ProjectGrade,
                             x.Average,
                             x.TblStudent.StdPicture
                         };
            dataGridView1.DataSource = values.ToList();
            dataGridView1.Columns["StdPicture"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
        }
        void Add()
        {
            TblGrade tblGrade = new TblGrade();
            tblGrade.Exam1 = int.Parse(txtExam1.Text);
            tblGrade.Exam2 = int.Parse(txtExam2.Text);
            tblGrade.Exam3 = int.Parse(txtExam3.Text);
            tblGrade.Quiz1 = int.Parse(txtQuiz1.Text);
            tblGrade.Quiz2 = int.Parse(txtQuiz2.Text);
            tblGrade.ProjectGrade = int.Parse(txtProject.Text);
            tblGrade.Average = int.Parse(txtAverage.Text);
            tblGrade.Lesson = int.Parse(comboBox1.SelectedValue.ToString());
            tblGrade.Student = int.Parse(txtStudent.Text);
            systemEntities.TblGrade.Add(tblGrade);
            systemEntities.SaveChanges();
            
        }

        void Calculate()
        {
            int s1, s2, s3, q1, q2, project;
            double average;
            s1 = int.Parse(txtExam1.Text);
            s2 = int.Parse(txtExam2.Text);
            s3 = int.Parse(txtExam3.Text);
            q1 = int.Parse(txtQuiz1.Text);
            q2 = int.Parse(txtQuiz2.Text);
            project = int.Parse(txtProject.Text);
            average = (s1 + s2 + s3 + q1 + q2 + project) / 6;
            txtAverage.Text = average.ToString();
        }

        void Update()
        {
            int id = Convert.ToInt32(txtId.Text);
            var x = systemEntities.TblGrade.Find(id);
            x.Exam1 = int.Parse(txtExam1.Text);
            x.Exam2 = int.Parse(txtExam2.Text);
            x.Exam3 = int.Parse(txtExam3.Text);
            x.Quiz1 = int.Parse(txtQuiz1.Text);
            x.Quiz2 = int.Parse(txtQuiz2.Text);
            x.ProjectGrade = int.Parse(txtProject.Text);
            x.Average = decimal.Parse(txtAverage.Text);
            systemEntities.SaveChanges();
            
        }

        private void FrmGrade_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "LessonName";
            comboBox1.DataSource = systemEntities.TblLesson.ToList();

            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "LessonName";
            comboBox2.DataSource = systemEntities.TblLesson.ToList();
            GetList();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void btnAdded_Click(object sender, EventArgs e)
        {
            Add();
            MessageBox.Show("Öğrenci Not Bilgisi Sisteme Kaydedildi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetList();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var values = from x in systemEntities.TblGrade
                         select new
                         {
                             x.Id,
                             Ders = x.TblLesson.LessonName,
                             Öğrenci = x.TblStudent.StdName + " " + x.TblStudent.StdSurname,
                             x.Exam1,
                             x.Exam2,
                             x.Exam3,
                             x.Quiz1,
                             x.Quiz2,
                             Proje = x.ProjectGrade,
                             x.Average,
                             x.TblStudent.StdPicture,
                             x.Lesson
                         };
            int temp = int.Parse(comboBox2.SelectedValue.ToString());
            dataGridView1.DataSource = values.Where(y => y.Lesson == temp).ToList();
            dataGridView1.Columns["Lesson"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = from x in systemEntities.TblGrade
                         select new
                         {
                             x.Id,
                             Öğrenci = x.TblStudent.StdName + " " + x.TblStudent.StdSurname,
                             x.Exam1,
                             x.Exam2,
                             x.Exam3,
                             x.Quiz1,
                             x.Quiz2,
                             x.ProjectGrade,
                             x.TblStudent.StdNumber,
                             x.TblLesson.LessonName,
                             x.Average
                         };
            string temp = maskedTextBox1.Text;
            dataGridView1.DataSource = values.Where(y => y.StdNumber == temp).ToList();
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtExam1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtExam2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtExam3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtQuiz1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtQuiz2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtProject.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtStudent.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAverage.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            //comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
            MessageBox.Show("Öğrenci Bilgileri Başarıyla Güncellendi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetList();
        }
    }
}
