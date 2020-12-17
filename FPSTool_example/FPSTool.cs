using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIM.Modules
{
    class FPSTool
    {
        int fps_count = 0;
        int fps = 0;
        DateTime last_fps_time1 = DateTime.Now;       
        public double FPS()
        {
            this.fps_count++;

            var nowtime = DateTime.Now;
            var sp = nowtime - this.last_fps_time1;
            if (sp.TotalSeconds >= 1.0) 
            {
                this.fps = this.fps_count;

                this.last_fps_time1 = nowtime;
                this.fps_count = 0;
            }

            return this.fps;
        }

        double fps_avg = 0.0;
        DateTime last_fps_time2 = DateTime.Now;
        public double FPS(int N)
        {
            TimeSpan sp = DateTime.Now - this.last_fps_time2;
            double fps = 1.0 / sp.TotalSeconds;

            // https://stackoverflow.com/questions/10990618/calculate-rolling-moving-average-in-c
            this.fps_avg -= this.fps_avg / N;
            this.fps_avg += fps / N;

            this.last_fps_time1 = DateTime.Now;
            return this.fps_avg;
        }
    }
