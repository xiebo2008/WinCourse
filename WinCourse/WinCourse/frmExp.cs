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

            //获取驱动器
            var drives = System.IO.DriveInfo.GetDrives();

            foreach (var d in drives)
            {
                TreeNode child = new TreeNode(d.Name);
                root.Nodes.Add(child); //Remove
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //循环当前展开节点的子节点集合
           foreach(TreeNode node in e.Node.Nodes)
            {
                //异常处理
                try
                {
                   
                    LoadDir(node);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                };
                

            }
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {

        }

        /// <summary>
        /// 在指定节点上加载子文件夹
        /// </summary>
        /// <param name="node"></param>
        void LoadDir(TreeNode node)
        {
            //加载之前，清除子节点
             node.Nodes.Clear();
            //c:\\  目录的path  
           
           string[] dirs = System.IO.Directory.GetDirectories(node.Text);

            foreach (var dir in dirs)
            {
                TreeNode child = new TreeNode(dir);
                node.Nodes.Add(child);
            }

        }
    }
}
