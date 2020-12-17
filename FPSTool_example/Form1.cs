using AIM.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FPSTool_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FPSTool fpsTool = new FPSTool();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.trackBar1.Value = 50;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Text = $"timer.Interval = {trackBar1.Value}";
            this.timer1.Interval = trackBar1.Value;
            this.timer2.Interval = trackBar1.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = $"timer1 fps = {fpsTool.FPS()}";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.label2.Text = $"timer2 fps = {fpsTool.FPS(10)}";
        }


    }
}
