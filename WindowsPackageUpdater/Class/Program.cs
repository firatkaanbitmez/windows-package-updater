using System;
using System.Windows.Forms;
using WindowsPackageUpdater.Forms;
using Microsoft.VisualBasic.ApplicationServices;


namespace WindowsPackageUpdater
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SingleInstanceApplicationWrapper wrapper = new SingleInstanceApplicationWrapper();
            wrapper.Run(Environment.GetCommandLineArgs());
        }

        private class SingleInstanceApplicationWrapper : WindowsFormsApplicationBase
        {
            public SingleInstanceApplicationWrapper()
            {
                IsSingleInstance = true;
            }

            protected override void OnCreateMainForm()
            {
                MainForm = new frmMain();
            }

            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
            {
                base.OnStartupNextInstance(eventArgs);

                frmMain mainForm = MainForm as frmMain;
                if (mainForm != null)
                {
                    mainForm.Invoke(new Action(mainForm.BringToForeground));
                }
                else
                {
                    // İlk örneğin ana formu oluşturulmadıysa yeni bir ana form oluşturun
                    MainForm = new frmMain();
                    MainForm.Invoke(new Action(mainForm.BringToForeground));
                }
            }


        }
    }
}
