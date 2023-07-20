using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nucleo.Forms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool createdNew = true;

            using (Mutex mutex = new Mutex(true, "FrenteCaixaBoxPDV", out createdNew))
            {
                if (createdNew)
                {
                    //Environment = new Core.Application.Environment();

                    //Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                    //Environment.Main = new Main();
                    //Environment.Main.Run();
                }
                else
                {
                    //State.Exit();
                }
            }

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MenuPrincipal());
        }

        /*
         [STAThread]
        static void Main()
        {
            
        }

        
         */

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Log the exception, display it, etc

            //Debug.WriteLine("Application_ThreadException");
            //Debug.WriteLine(e.Exception.Message);

            //MessageBox.Show(e.Exception.Message);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log the exception, display it, etc

            //Debug.WriteLine("CurrentDomain_UnhandledException");
            //Debug.WriteLine((e.ExceptionObject as Exception).Message);

            //MessageBox.Show((e.ExceptionObject as Exception).Message);
        }
    }
}
