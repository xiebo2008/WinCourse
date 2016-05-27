using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCourse
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;
            //忽略登录代码， 直接进入主窗体
           // this.Hide();
            frmExp exp = new frmExp();
            exp.MyParent = this;
            exp.Show();
          //  exp.ShowDialog(); //模式窗口
        }
    }
}
