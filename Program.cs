using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace thisIsGoingToFar
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*string[] roles = {
                "Shulk",
                "Melia",
                "Dunban",
                "Reyn",
                "Fiora",
                "Otharon",
                "Vangarre",
                "Tyrea",
                "Mumkar*",
                "Zanza*",
                "Dickson*",
                "Alvis*",};*/

            string[] rawFile = System.IO.File.ReadAllText("TextFile1.txt").Split('\n');

            Dictionary<string, string> descriptions = new Dictionary<string, string>();
            string[] roles = new string[rawFile.Length];
            for (int i = 0; i < rawFile.Length; i++)
            {
                roles[i] = rawFile[i].Split('\t')[0];
                descriptions.Add(roles[i], rawFile[i].Split('\t')[1]);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(roles,descriptions));
        }
    }
}
