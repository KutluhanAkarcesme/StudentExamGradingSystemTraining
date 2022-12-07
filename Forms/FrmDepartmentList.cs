using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentExamGradingSystem.Entity;
using StudentExamGradingSystem.Forms;

namespace StudentExamGradingSystem.Forms
{
    public partial class FrmDepartmentList : Form
    {
        public FrmDepartmentList()
        {
            InitializeComponent();
        }
        StudentExamGradingSystemEntities entities = new StudentExamGradingSystemEntities();
        private void FrmDepartmentList_Load(object sender, EventArgs e)
        {
            var values = from x in entities.TblDepartment
                         select new
                         {
                             Bölüm_Sıralaması = x.Id,
                             Bölümler = x.DepartmentName
                         };
            dataGridView1.DataSource = values.ToList();
        }
    }
}
