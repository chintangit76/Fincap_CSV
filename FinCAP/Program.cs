using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinCAP_CSV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form2());
            //Application.Run(new FrmFileRead());
            Application.Run(new MDIParent1());
            //Application.Run(new FrmGetGrp_Name());
            //Application.Run(new FrmRead_Save_CSV());

        }
    }
}
