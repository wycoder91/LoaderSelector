using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoaderCodeSelector
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
            Application.Run(new FrmMain());           
        }
        public static List<string> strUIIn = new List<string>();
        public static List<string> strUIOptionIn = new List<string>();
        public static byte optionModelFlag = 0;
    }
}
