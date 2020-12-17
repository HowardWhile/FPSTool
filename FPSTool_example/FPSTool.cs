using System;

namespace AIM.Modules
{
    class FPSTool
    {
        int fps1_count = 0;
        int fps1 = 0;
        DateTime last_fps_time1 = DateTime.Now;
        public double FPS()
        {
            this.fps1_count++;

            var nowtime = DateTime.Now;
            var sp = nowtime - this.last_fps_time1;
            if (sp.TotalSeconds >= 1.0)
            {
                this.fps1 = this.fps1_count;

                this.last_fps_time1 = nowtime;
                this.fps1_count = 0;
            }

            return this.fps1;
        }

        double avg_duration = 0.0;
        DateTime last_fps2_time = DateTime.Now;
        public double FPS(int avg_num)
        {
            TimeSpan sp = DateTime.Now - this.last_fps2_time;
            this.last_fps2_time = DateTime.Now;
            this.avg_duration -= this.avg_duration / avg_num;
            this.avg_duration += sp.TotalSeconds / avg_num;
            return 1.0 / this.avg_duration;
        }
    }
}