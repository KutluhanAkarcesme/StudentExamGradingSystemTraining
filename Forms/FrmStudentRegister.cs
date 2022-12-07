using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentExamGradingSystem.Entity;
namespace StudentExamGradingSystem.Forms
{
    public partial class FrmStudentRegister : Form
    {
        public FrmStudentRegister()
        {
            InitializeComponent();
        }
        StudentExamGradingSystemEntities systemEntities = new StudentExamGradingSystemEntities();

        void Add()
        {
            TblStudent tblStudent = new TblStudent();
            tblStudent.StdName = txtName.Text;
            tblStudent.StdSurname = txtSurname.Text;
            tblStudent.StdNumber = maskedTextBox1.Text;
            tblStudent.StdMail = txtMail.Text;
            tblStudent.StdPicture = txtPicture.Text;
            tblStudent.StdPassword = txtPassword.Text;
            tblStudent.StdDepartment = int.Parse(comboBox1.SelectedValue.ToString());
            systemEntities.TblStudent.Add(tblStudent);
            systemEntities.SaveChanges();
            
        }

        private void FrmStudentRegister_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "DepartmentName";
            comboBox1.DataSource = systemEntities.TblDepartment.ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtPasswordAgain.Text)
            {
                Add();
                MessageBox.Show("Öğrenci Başarıyla Kaydedildi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Girdiğiniz Şifreler Birbiriyle Uyuşmuyor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPicturePath_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtPicture.Text = openFileDialog1.FileName; //path + file name
        }
    }
}
