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

namespace StudentExamGradingSystem.Forms
{
    public partial class FrmStudentPanel : Form
    {
        public FrmStudentPanel()
        {
            InitializeComponent();
        }
        StudentExamGradingSystemEntities systemEntities = new StudentExamGradingSystemEntities();
        public string number;

        void GetList()
        {
            txtNumber.Text = number;
            txtId.Text = systemEntities.TblStudent.Where(x => x.StdNumber == number).Select(y => y.Id).FirstOrDefault().ToString();
            txtName.Text = systemEntities.TblStudent.Where(x => x.StdNumber == number).Select(y => y.StdName).FirstOrDefault();
            txtSurname.Text = systemEntities.TblStudent.Where(x => x.StdNumber == number).Select(y => y.StdSurname).FirstOrDefault();
            txtMail.Text = systemEntities.TblStudent.Where(x => x.StdNumber == number).Select(y => y.StdMail).FirstOrDefault();
            txtPassword.Text = systemEntities.TblStudent.Where(x => x.StdNumber == number).Select(y => y.StdPassword).FirstOrDefault();
            txtPicture.Text = systemEntities.TblStudent.Where(x => x.StdNumber == number).Select(y => y.StdPicture).FirstOrDefault();
            txtDepartment.Text = systemEntities.TblStudent.Where(x => x.StdNumber == number).Select(y => y.StdDepartment).FirstOrDefault().ToString();

            int id = systemEntities.TblStudent.Where(x => x.StdNumber == number).Select(y => y.Id).FirstOrDefault();
            var student = (from x in systemEntities.TblGrade
                           select new
                           {
                               Ders = x.TblLesson.LessonName,
                               x.Exam1,
                               x.Exam2,
                               x.Exam3,
                               x.Quiz1,
                               x.Quiz2,
                               Proje = x.ProjectGrade,
                               x.Average,
                               x.Student
                           }).Where(x => x.Student == id).ToList();
            dataGridView1.DataSource = student.ToList();
            dataGridView1.Columns["Student"].Visible = false;
        }
        void Update()
        {
            int id = int.Parse(txtId.Text);
            var value = systemEntities.TblStudent.Find(id);
            value.StdNumber = txtNumber.Text;
            value.StdMail = txtMail.Text;
            value.StdPassword = txtPassword.Text;
            systemEntities.SaveChanges();
        }
        private void FrmStudentPanel_Load(object sender, EventArgs e)
        {
            GetList();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text == "" && txtMail.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Numara,Mail ve Şifre Alanları Boş Geçilemez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Update();
                MessageBox.Show("Öğrenci Bilgileri Başarıyla Güncellendi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetList();
            }
        }

        
    }
}
