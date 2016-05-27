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
    public partial class frmExp : Form
    {
        public Form MyParent = null;
        public frmExp()
        {
            InitializeComponent();
        }

        private void frmExp_FormClosed(object sender, FormClosedEventArgs e)
        {
           if (MyParent!=null)
            {MyParent.Show(); }
                
            
        }

        private void frmExp_Load(object sender, EventArgs e)
        {
            TreeNode root = new TreeNode("我的电脑");
            this.treeView1.Nodes.Add(root);

            var drives = System.IO.DriveInfo.GetDrives();

            foreach (var d in drives)
            {
                TreeNode child = new TreeNode(d.Name);
                root.Nodes.Add(child); //Remove
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
