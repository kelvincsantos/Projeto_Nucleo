using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nucleo.Forms
{
    public static class Program
    {

        public static Operacoes.Central Central;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool createdNew = true;

            using (Mutex mutex = new Mutex(true, "Nucleo", out createdNew))
            {
                if (createdNew)
                {
                    Central = new Operacoes.Central();

                    //Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                    if(Central.Iniciar(Central))
                    {
                        Reload:
                        Telas.Login login = new Telas.Login();
                        Comum.Leiaute.Tela.ExibirPequeno(login);

                        if (!Central.Login(login.controller.usuario))
                        {
                            Application.Exit();
                        }
                            

                        Central.Versao(Application.ProductVersion.ToString());

                        Comum.Leiaute.Tela.ExibirMedioMaximizado(new Telas.MenuPrincipal());

                        if (login.controller.usuario != null)
                            goto Reload;
                    }
                }
                else
                {
                    //State.Exit();
                }
            }
        }


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
