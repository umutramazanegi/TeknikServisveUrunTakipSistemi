using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// Muhtemelen TeknikServis.Formlar gibi başka using ifadeleri de olabilir

namespace TeknikServis 
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Formlar.FrmLogin()); // Namespace'in doğru olduğundan emin olun
        }
    }
}