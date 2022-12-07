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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        StudentExamGradingSystemEntities systemEntities = new StudentExamGradingSystemEntities();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var number = txtNumber.Text;
            var password = txtPassword.Text;

            var value = from x in systemEntities.TblStudent where x.StdNumber == number && x.StdPassword == password select x;

            if (value.Any())
            {
                FrmMap frmMap = new FrmMap();
                frmMap.User = txtNumber.Text;
                frmMap.Show();
                MessageBox.Show("Giriş Başarılı", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Numara veya Şifre Bilgisi Yanlış", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
