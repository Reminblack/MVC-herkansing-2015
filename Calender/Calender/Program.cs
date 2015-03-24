using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Before UI operations
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Create forms
            Form1 calender = new Form1();


            //run forms
            Application.Run(calender);
        }
    }
}
