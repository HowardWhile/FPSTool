using System;

namespace AIM.Modules
{
    class FPSTool
    {
        #region fixed time frame number method
        int fps_count = 0;
        int fps_temp = 0;
        DateTime last_fps_update_time = DateTime.Now;
        public double FPS()
        {
            this.fps_count++;

            var nowtime = DateTime.Now;
            var sp = nowtime - this.last_fps_update_time;
            if (sp.TotalSeconds >= 1.0)
            {
                this.fps_temp = this.fps_count;

                this.last_fps_update_time = nowtime;
                this.fps_count = 0;
            }

            return this.fps_temp;
        }
        #endregion

        #region the average sampling time method
        double avg_duration = 0.0;
        DateTime last_fps_check_time = DateTime.Now;
        public double FPS(int avg_num)
        {
            TimeSpan sp = DateTime.Now - this.last_fps_check_time;
            this.last_fps_check_time = DateTime.Now;
            this.avg_duration -= this.avg_duration / avg_num;
            this.avg_duration += sp.TotalSeconds / avg_num;
            return 1.0 / this.avg_duration;
        }
        #endregion

    }
}