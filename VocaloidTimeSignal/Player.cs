using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Media;

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
            var plys = new SoundPlayer[files.Length];


            try
            {
                //まとめてメモリ確保
                for (var i = 0; i < plys.Length; i++)
                    plys[i] = new SoundPlayer(files[i]);
                foreach (SoundPlayer sp in plys)
                    sp.PlaySync();
                foreach (SoundPlayer sp in plys)
                    sp.Dispose();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message, "音の再生に失敗しました"); return false; }
            
            //foreach (string file in files)
            //{
            //    //MessageBox.Show(file);
            //    PlaySingleSound(file);
            //}

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
