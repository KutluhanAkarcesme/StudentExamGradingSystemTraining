using StudentExamGradingSystem.Entity;
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

namespace StudentExamGradingSystem.Forms
{
    public partial class FrmDepartment : Form
    {
        public FrmDepartment()
        {
            InitializeComponent();
        }

        StudentExamGradingSystemEntities systemEntities = new StudentExamGradingSystemEntities();

        void Add()
        {
            TblDepartment tblDepartment = new TblDepartment();
            tblDepartment.DepartmentName = txtDepartmentName.Text;
            systemEntities.TblDepartment.Add(tblDepartment);
            systemEntities.SaveChanges();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text == "" && txtDepartmentName.Text.Length < 3)
            {
                errorProvider1.SetError(txtDepartmentName, "Bölüm Adı Boş Geçilemez");
            }
            else
            {
                Add();
                MessageBox.Show("Bölüm Başarıyla Kaydedildi","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
