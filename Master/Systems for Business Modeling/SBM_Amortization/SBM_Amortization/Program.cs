namespace SBM_Amortization
{
    using System;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// Author: Beytula Hamdi Redzheb
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
