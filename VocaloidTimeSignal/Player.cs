using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VocaloidTimeSignal
{
    static class Player
    {
        //private static string voiceDir = @"D:\Media\Music\wav";
        private static string voiceDir = ApplicationTools.startupPath +  @"\wav";
        private static NameManager nm_jp = new NameManager(language.Miku_jp, voiceDir);

        public static bool Play()
        { return Play(DateTime.Now); }

        public static bool Play(DateTime time)
        {
            var files = nm_jp.GetHourMin(time);

            foreach(string file in files)
            {
                //MessageBox.Show(file);
                PlaySingleSound(file);
            }

            return true;
        }

        private static bool PlaySingleSound(string path)
        {
            try
            {
                var ply = new System.Media.SoundPlayer(path);
                ply.PlaySync();
            }
            catch(Exception e)
            {　MessageBox.Show(e.Message,"音の再生に失敗しました");　return false; }
            return true;
        }

    }
}
