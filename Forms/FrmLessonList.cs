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
    public partial class FrmLessonList : Form
    {
        public FrmLessonList()
        {
            InitializeComponent();
        }
        StudentExamGradingSystemEntities systemEntities = new StudentExamGradingSystemEntities();
        private void FrmLessonList_Load(object sender, EventArgs e)
        {
            var values = from x in systemEntities.TblLesson
                         select new
                         {
                             Ders_Sıralaması = x.Id,
                             Dersler = x.LessonName
                         };
            dataGridView1.DataSource = values.ToList();
        }
    }
}
