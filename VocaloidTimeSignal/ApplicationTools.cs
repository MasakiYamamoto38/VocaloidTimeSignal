using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace VocaloidTimeSignal
{
    static class ApplicationTools
    {
        private static string stPath;
        /// <summary>
        /// exeファイルのあるディレクトリを取得します
        /// </summary>
        public static string startupPath
        {
            get
            { return stPath; }
        }

        static ApplicationTools()
        {
            var exePath = Environment.GetCommandLineArgs()[0];
            var exeFullPath = System.IO.Path.GetFullPath(exePath);
            stPath = System.IO.Path.GetDirectoryName(exeFullPath);
        }

        /// <summary>
        /// 強制再描画します
        /// </summary>
        public static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            var callback = new DispatcherOperationCallback(obj =>
            {
                ((DispatcherFrame)obj).Continue = false;
                return null;
            });
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, callback, frame);
            Dispatcher.PushFrame(frame);
        }
    }
}
