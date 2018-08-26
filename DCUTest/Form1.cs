using DCUTest.MK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCUTest
{
    public partial class Form1 : Form
    {
        //private DO_K do_k;
        public Form1()
        {
            InitializeComponent();
            //do_k = this.紧急解锁;
         //   紧急解锁.putname(紧急解锁.Name);
        }


        // 初始化门按钮
        private void inintDoorBut() {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
             
        }

        private void led1_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
           bool a =  GlobalVar.getInstance().Connect("192.168.0.7","26");
            if (a)
                button14.BackColor = Color.Green;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  定时刷新界面获取网络dido的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GlobalVar.getInstance().lj) {
                GlobalVar.getInstance().InQuire();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pictureBox1.Left += 10;//向右移动10个像素

            ///  在哈哈哈啊啊哈啊啊啊哈哈啊哈啊
        }

        private void mianBan1_Load(object sender, EventArgs e)
        {

        }

        private void 紧急解锁_Load(object sender, EventArgs e)
        {
            Console.WriteLine("SS"+this.Name);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
