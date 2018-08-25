using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

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
                return button1.Text;
            }
            set
            {
                //TODO
                button1.Text = value;
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

        private void init()
        {
            this.label1.Text = this.Name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = Convert.ToInt32(button1.Tag) + "";
        }
    }
}
