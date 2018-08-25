using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DCUTest
{
    public partial class mianBan : UserControl
    {
        public mianBan()
        {
            InitializeComponent();
        }

        private void mianBan_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
               button2.BackgroundImage = global::DCUTest.Properties.Resources.openBtnB; // 全亮
               button2.Refresh();
               Thread.Sleep(800);
               button1.BackgroundImage = global::DCUTest.Properties.Resources.closseBtnC ; // 关闭全亮
               button1.Refresh();
               button2.BackgroundImage = global::DCUTest.Properties.Resources.openBtnA;  // 灭
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackgroundImage = global::DCUTest.Properties.Resources.closseBtnB;
            button1.Refresh();
            Thread.Sleep(800);
            button2.BackgroundImage = global::DCUTest.Properties.Resources.openBtnC; // 打开全亮
            button2.Refresh();

            button1.BackgroundImage = global::DCUTest.Properties.Resources.closseBtnA;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackgroundImage = global::DCUTest.Properties.Resources.doorBS;
            button3.Refresh();
            Thread.Sleep(800);
            button3.BackgroundImage = null;
            button3.Refresh();
        }
    }
}
