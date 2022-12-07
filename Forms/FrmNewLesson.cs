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
    public partial class FrmNewLesson : Form
    {
        public FrmNewLesson()
        {
            InitializeComponent();
        }
        StudentExamGradingSystemEntities systemEntities = new StudentExamGradingSystemEntities();

        void Add()
        {
            TblLesson tblLesson = new TblLesson();
            tblLesson.LessonName = txtLessonName.Text;
            systemEntities.TblLesson.Add(tblLesson);
            systemEntities.SaveChanges();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLessonName.Text == "")
            {
                MessageBox.Show("Ders Adı Boş Geçilemez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Add();
                MessageBox.Show("Ders Başarıyla Kaydedildi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }
    }
}
