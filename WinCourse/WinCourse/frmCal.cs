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
    public partial class frmCal : Form
    {
        public frmCal()
        {
            InitializeComponent();
        }

        private void frmCal_Load(object sender, EventArgs e)
        {
            this.btn0.Click += Btn_Click;
            this.btn2.Click += Btn_Click;
            this.btn3.Click += Btn_Click;
            this.btn4.Click += Btn_Click;
            this.btn5.Click += Btn_Click;
            this.btn6.Click += Btn_Click;
            this.btn7.Click += Btn_Click;
            this.btn8.Click += Btn_Click;
            this.btn9.Click += Btn_Click;
            this.btn1.Click += Btn_Click;

            this.btnPlus.Click += PlusInput;
          
             

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.txtShow.Text += button.Text;
        }

      
        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void frmCal_Click(object sender, EventArgs e)
        {

        }

        private void frmCal_MouseMove(object sender, MouseEventArgs e)
        {
            string txt = "X:" + e.X.ToString() + "_________Y:" + e.Y.ToString();
            this.slDisplay.Text = txt;
        }
        public void Add()
        {
            string txt = this.txtShow.Text;
            if (!string.IsNullOrEmpty(txt))
            {
                string[] arr =  txt.Split('+');
               int last = int.Parse(arr[arr.Length - 2]);

                int result = int.Parse(this.txtResult.Text) + last;
                this.txtResult.Text = result.ToString();
            }
            
        }

        

        public void PlusInput(object sender, EventArgs e)
        {
            string txt = this.txtShow.Text;
            if ( !string.IsNullOrEmpty(txt))
            {
                string last = txt.Remove(0, txt.Length - 1);
                if (last != "+")
                {
                    //合法的放入加号
                    this.txtShow.Text += "+";
                    Add();
                }
            }
            
            
        }
      
    }
}
