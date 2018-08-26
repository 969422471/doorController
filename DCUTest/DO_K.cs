using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCUTest.MK;
using System.Threading;

namespace DCUTest
{
    public partial class DO_K : UserControl
    {

        public void putname(string namevalue){
                label1.Text= namevalue;
            }
        public DO_K()
        {
            InitializeComponent();
            init();

        }

        public string ButtonName
        {
            get
            {
                //TODO
                return button1.Name;
            }
            set
            {
                //TODO
                button1.Name = value;
            }
        }

        public int ButtonTag
        {
            get
            {
                //TODO
                return Convert.ToInt32(button1.Tag) ;
            }
            set
            {
                //TODO
                button1.Tag = value;
            }
        }


        Thread nonParameterThread;
        private void init()
        {
            this.label1.Text = this.Name;
          
            nonParameterThread = new Thread(new ThreadStart(NonParameterRun2));         
            nonParameterThread.Start();
        }

        private delegate void ledDeleg();//定义一个线程委托
        public void NonParameterRun2()
        {
            // 做一个循环等待连接
            while (true) {
                while (GlobalVar.getInstance().lj)
                {
                     try {

                        Console.WriteLine(button1.Name);
                        if (GlobalVar.doMap[button1.Name].Equals("1"))
                        {
                           ledDeleg white = new ledDeleg(LedON);
                        }
                        else
                        {
                           ledDeleg white = new ledDeleg(LedOFF);
                         }
                        
                        } catch
                        {

                            MessageBox.Show("控件命名错误！");
                        }
                // 控件的刷新频率
                Thread.Sleep(300);
                }
            }
          


           
        }

        private void LedON()
        {
            Console.WriteLine("ON");
            button1.BackgroundImage = global::DCUTest.Properties.Resources.DriverLight_10;

        }

        private void LedOFF()
        {
            Console.WriteLine("OFF");
            button1.BackgroundImage = global::DCUTest.Properties.Resources.DeskLight_10;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 如果连接成功
            if (GlobalVar.getInstance().lj) {

                // button1.Text = Convert.ToInt32(button1.Tag) + "";
                int tag = Convert.ToInt32(((Button)sender).Tag);
                Int16 Address = 0;
                if (tag > 0 && tag < 10)
                {
                    Address = 1;
                }
                else if (tag > 20 && tag < 30)
                {
                    Address = 2;
                    tag = tag - 20;
                }
                else if (tag > 30 && tag < 40)
                {
                    Address = 3;
                    tag = tag - 30;
                }

                if (button1.BackgroundImage == global::DCUTest.Properties.Resources.DeskLight_10)
                {

                    GlobalVar.getInstance().PowerOFF(Address, tag);
                }
                else
                {
                    GlobalVar.getInstance().PowerON(Address, tag);
                }
            }
          
         }
   }
}
