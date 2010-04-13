using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hwj.MarkTableObject
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Common.MainPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TableObject";
            Application.Run(new Forms.Main());
        }
    }
}
