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
using StudentExamGradingSystem;
using StudentExamGradingSystem.Entity;

namespace StudentExamGradingSystem.Forms
{
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
        }

        StudentExamGradingSystemEntities systemEntities = new StudentExamGradingSystemEntities();

        void GetStudentList()
        {
            var values = from x in systemEntities.TblStudent
                         select new
                         {
                             x.Id,
                             Adı = x.StdName,
                             Soyadı = x.StdSurname,
                             Numara = x.StdNumber,
                             E_mail = x.StdMail,
                             x.StdPassword,
                             Fotograf = x.StdPicture,
                             x.StdDepartment,
                             Bölüm = x.TblDepartment.DepartmentName,
                             x.IsActive
                         };
            dataGridView1.DataSource = values.Where(x => x.IsActive == true).ToList();
            
        }
        void Delete()
        {
            int id = int.Parse(txtId.Text);
            var x = systemEntities.TblStudent.Find(id);
            x.IsActive = false;
            systemEntities.SaveChanges();
            
        }
        void Update()
        {
            int id = int.Parse(txtId.Text);
            var x = systemEntities.TblStudent.Find(id);
            x.StdName= txtName.Text;
            x.StdSurname = txtSurname.Text;
            x.StdNumber = txtNumber.Text;
            x.StdPassword = txtPassword.Text;
            x.StdMail = txtMail.Text;
            x.StdPicture = txtPicture.Text;
            x.StdDepartment = int.Parse(comboBox1.SelectedValue.ToString());
            systemEntities.SaveChanges();
            
        }
        private void FrmStudent_Load(object sender, EventArgs e)
        {
            GetStudentList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["StdDepartment"].Visible = false;
            dataGridView1.Columns["IsActive"].Visible = false;
            dataGridView1.Columns["StdPassword"].Visible = false;

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "DepartmentName";
            comboBox1.DataSource = systemEntities.TblDepartment.ToList();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            GetStudentList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["StdDepartment"].Visible = false;
            dataGridView1.Columns["IsActive"].Visible = false;
            dataGridView1.Columns["StdPassword"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPicture.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            MessageBox.Show("Öğrenci Başarıyla Silindi.Silinen Öğrencinin Bilgilerine Pasif Öğrenciler Listesinden Erişebilirsiniz.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetStudentList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["StdDepartment"].Visible = false;
            dataGridView1.Columns["IsActive"].Visible = false;
            dataGridView1.Columns["StdPassword"].Visible = false;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Update();
            MessageBox.Show("Öğrenci bilgileri Başarıyla Güncellendi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetStudentList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["StdDepartment"].Visible = false;
            dataGridView1.Columns["IsActive"].Visible = false;
            dataGridView1.Columns["StdPassword"].Visible = false;
        }

        private void btnPicturePath_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtPicture.Text = openFileDialog1.FileName; //path + file name
        }
    }
}
