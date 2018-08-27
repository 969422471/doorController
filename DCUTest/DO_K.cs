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

        public string ButtonText
        {
            get
            {
                //TODO
                return label1.Text;
            }
            set
            {
                //TODO
                label1.Text = value;
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
            nonParameterThread.IsBackground = true;//设为 后台线程         
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
                            zt = true; 
                           ledDeleg white = new ledDeleg(LedON);
                            this.Invoke(white);
                        }
                        else
                        {
                            zt = false; // 开关状态
                           ledDeleg off = new ledDeleg(LedOFF);
                            this.Invoke(off);
                        }
                        
                        } catch
                        {
                          // 出现异常后 结束程序避免占用 cpu
                           nonParameterThread.Abort();
                        }
                // 控件的刷新频率
                Thread.Sleep(300);
                }
                // 300ms 判断一次 程序是否建立连接
                Thread.Sleep(300);
            }
          


           
        }

        private void LedON()
        {
            zt = true;
            Console.WriteLine("ON");
            button1.BackgroundImage = global::DCUTest.Properties.Resources.DriverLight_10;

        }

        private void LedOFF()
        {
            zt = false;
            Console.WriteLine("OFF");
            button1.BackgroundImage = global::DCUTest.Properties.Resources.DeskLight_10;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool zt;
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

                if (zt)
                {
                  //  zt = false;
                    GlobalVar.getInstance().PowerOFF(Address, tag);
                }
                else
                {
                 //   zt = true;
                    GlobalVar.getInstance().PowerON(Address, tag);
                }
            }
          
         }
   }
}
