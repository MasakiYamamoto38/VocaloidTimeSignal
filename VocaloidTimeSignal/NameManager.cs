using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocaloidTimeSignal
{
    enum language
    {
        /// <summary>
        /// 心華（台湾中国語）
        /// </summary>
        XinHua_tw,
        /// <summary>
        /// 初音ミク（日本語）
        /// </summary>
        Miku_jp
    }

    class NameManager
    {
        private language lng;
        private string voiceDir;
        private string lngDir;

        public NameManager(language lng,string voiceDir)
        {
            this.lng = lng;
            this.voiceDir = voiceDir;

            switch(lng)
            {
                case language.XinHua_tw: lngDir = voiceDir + "\\XinHua"; break;
                case language.Miku_jp: lngDir = voiceDir + "\\Miku"; break;
            }
        }


        public string[] GetHourMin(DateTime dt)
        {
            return GetHourMin(dt.Hour, dt.Minute);
        }

        public string[] GetHourMin(int h,int m)
        {
            var dirs = new string[1];

            if(m == 0)
            {
                dirs[0] = lngDir + "\\hn" + h + ".wav";
                return dirs;
            }
            else if (m % 10 == 0)
            {
                dirs = new string[2];
                dirs[0] = lngDir + "\\hc" + h + ".wav";
                dirs[1] = lngDir + "\\mt" + (m / 10) + ".wav";
                return dirs;
            }
            else if (m < 10)
            {
                dirs = new string[2];
                dirs[0] = lngDir + "\\hc" + h + ".wav";
                dirs[1] = lngDir + "\\mn" + m + ".wav";
                return dirs;
            }

            dirs = new string[3];
            dirs[0] = lngDir + "\\hc" + h + ".wav";
            dirs[1] = lngDir + "\\mc" + (m / 10) + ".wav";
            dirs[2] = lngDir + "\\mn" + m + ".wav";
            return dirs;
        }

        public string[] GetAlarm()
        {
            var files = new string[1];
            files[0] = lngDir + "\\alarm.wav";
            return files;
        }

    }
}
