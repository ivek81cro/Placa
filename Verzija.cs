using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace Projekt_Placa
{
    class Verzija
    {
        public string verzija;
        public string trenutnaVerzija;
        public string Readtextfile()
        {

            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString("http://www.elabdesign.net/Program/verzija.txt");
            verzija = webData;
            return verzija;
        }

        public string TrenutnaVerzija()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            trenutnaVerzija = version;
            return trenutnaVerzija;
        }
    }
}
