using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Projekt_Placa
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
            Verzija provjeraVerzije;
            provjeraVerzije = new Verzija();
            string trenutna = provjeraVerzije.TrenutnaVerzija();
            string nova = provjeraVerzije.Readtextfile();
            label2.Text = "Trenutna verzija: " + trenutna;
            label3.Text = "Nova verzija " + nova;
            if (trenutna != nova)
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path;
            string pathopen;
            Verzija provjeraVerzije;
            provjeraVerzije = new Verzija();
            label3.Text = "Nova verzija " + provjeraVerzije.Readtextfile();
            string trenutna = provjeraVerzije.TrenutnaVerzija();
            if (trenutna != provjeraVerzije.Readtextfile())
            {
                MessageBox.Show("Skini novu verziju programa");
                //System.Diagnostics.Process.Start("ftp://elabdesign.net/Program/Instalacija_Tim.msi");
                SaveFileDialog savFile = new SaveFileDialog();
                savFile.Title = "Odaberi lokaciju za spremanje";
                savFile.Filter = "msi|*.msi";
                savFile.FileName = "Instalacija_Tim.msi";
                if (savFile.ShowDialog() == DialogResult.OK)
                {
                    path = savFile.FileName;
                    string savePath = path.ToString();
                    DownloadFtpFile("ftp://elabdesign.net/Program/Instalacija_Tim.msi", savePath);
                }
                OpenFileDialog open = new OpenFileDialog();
                open.FileName = "Instalacija_servis.msi";
                open.Title = "Odaberi instalaciju";
                open.Filter = "msi|*.msi";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pathopen = open.FileName;
                    System.Diagnostics.Process.Start(pathopen);
                }
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Imate posljednju verziju.");
            }

            
        }
        public void DownloadFtpFile(string url, string savePath)
        {

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("admin.elabdesign", "ProjektPlaca.Joppd!81");
            request.UseBinary = true;
            SetMethodRequiresCWD();
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (Stream rs = response.GetResponseStream())
                {
                    using (FileStream ws = new FileStream(savePath, FileMode.Create))
                    {
                        //long total = rs.Length;
                        byte[] buffer = new byte[2048];
                        int bytesRead = rs.Read(buffer, 0, buffer.Length);
                        double totalReadBytesCount = 0;
                        int readBytesCount;

                        while ((readBytesCount = bytesRead) > 0)
                        {
                            ws.Write(buffer, 0, bytesRead);
                            bytesRead = rs.Read(buffer, 0, buffer.Length);
                            totalReadBytesCount += readBytesCount;
                            label1.Text = (totalReadBytesCount / 1048576).ToString("#.##") + " MB";
                            label1.Refresh();

                        }
                    }
                }
            }
        }

        private static void SetMethodRequiresCWD()
        {
            Type requestType = typeof(FtpWebRequest);
            FieldInfo methodInfoField = requestType.GetField("m_MethodInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            Type methodInfoType = methodInfoField.FieldType;


            FieldInfo knownMethodsField = methodInfoType.GetField("KnownMethodInfo", BindingFlags.Static | BindingFlags.NonPublic);
            Array knownMethodsArray = (Array)knownMethodsField.GetValue(null);

            FieldInfo flagsField = methodInfoType.GetField("Flags", BindingFlags.NonPublic | BindingFlags.Instance);

            int MustChangeWorkingDirectoryToPath = 0x100;
            foreach (object knownMethod in knownMethodsArray)
            {
                int flags = (int)flagsField.GetValue(knownMethod);
                flags |= MustChangeWorkingDirectoryToPath;
                flagsField.SetValue(knownMethod, flags);
            }
        }
    }
}
