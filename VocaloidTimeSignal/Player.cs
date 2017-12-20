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

        public static bool Play()
        { return Play(DateTime.Now); }

        public static bool Play(DateTime time)
        {
            //数字（時）

            //時


            //数字(分)

            //分


            return false;
        }

        private static bool PlaySingleSound()
        {
            try
            {
                var ply = new System.Media.SoundPlayer("hogehoge.wav");
                ply.PlaySync();
            }
            catch(Exception e)
            {　MessageBox.Show(e.Message,"音の再生に失敗しました");　return false; }
            return true;
        }

    }
}
