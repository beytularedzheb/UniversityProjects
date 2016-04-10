namespace P2_Histogram
{
	using System;
	using System.Windows.Forms;

    static class Starter
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
