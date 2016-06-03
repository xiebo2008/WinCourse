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
                child.Tag = d.Name;
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
                //  var security=  System.IO.Directory.GetAccessControl(node.Text);
          
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
           
           string[] dirs = System.IO.Directory.GetDirectories(node.Tag.ToString());

            foreach (var dir in dirs)
            {
                //获取文件夹的短名称(不含路径)
                //dir ->c:\xunlei\download-----> download    \n \t \r
               string[] f= dir.Split('\\');
                string shortName = f[f.Length - 1];
                TreeNode child = new TreeNode(shortName);
                //存储完整路径
                child.Tag = dir;
                node.Nodes.Add(child);
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag.ToString();
            string[] files= System.IO.Directory.GetFiles(path);
            this.listView1.Items.Clear();
            foreach (string file in files)
            {
                string[] f = file.Split('\\');
                string shortName = f[f.Length - 1];
                ListViewItem item = new ListViewItem(shortName);
                item.Tag = file;

                this.listView1.Items.Add(item);
            }

        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.List;
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.Tile;
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.SmallIcon;
        }
    }
}
