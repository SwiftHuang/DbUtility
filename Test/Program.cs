using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //UI
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new Performance());
            //Application.Run(new DemoFrm.XMLFrm());
            //Application.Run(new DemoFrm.ControlsFrm());
            //Application.Run(new DemoFrm.DragFrm());
            //Application.Run(new dgFrm());
            //Application.Run(new Suggest());
            //Application.Run(new ImgTestFrm());
            //Application.Run(new FrmAsync());
            Application.Run(new TestDBUtility());
            //Application.Run(new HttpFrm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
