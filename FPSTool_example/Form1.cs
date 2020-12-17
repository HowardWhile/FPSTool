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
            this.trackBar1.Value = 100;
            this.backgroundWorker1.RunWorkerAsync();
        }

         

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Text = $"timer.Interval = {trackBar1.Value} ms, {1000.0/ trackBar1.Value : 0.0} FPS";
           
            this.bg_interval = trackBar1.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = $"fps1 = {this.fps1:0.00}";
            this.label2.Text = $"fps2 = {this.fps2:0.00}";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        double bg_interval = 100.0;
        double fps1 = 0.0;
        double fps2 = 0.0;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.DateTime ckTime = System.DateTime.Now;
            while (true)
            {
                var sp = System.DateTime.Now - ckTime;
                if (sp.TotalMilliseconds >= bg_interval)
                {
                    ckTime = System.DateTime.Now;

                    // fixed time frame number method
                    this.fps1 = fpsTool.FPS();

                    // the average sampling time method
                    this.fps2 = fpsTool.FPS(10);
                }
            }
        }
    }
}
