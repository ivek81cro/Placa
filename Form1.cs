using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Placa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Verzija provjeraVerzije;
            provjeraVerzije = new Verzija();
            provjeraVerzije.Readtextfile();
            label1.Text = "Trenutna verzija: " + provjeraVerzije.TrenutnaVerzija();
        }
        djelatnici djel;
        Gradovi grad;
        Plaća placa;
        Tvrtka firma;
        JOPPD_priprema priprema;
        Placa_obracun plObracun;
        TablicaZaposlenici tZaposlenici;
        TablicaPlacaArhiva tPlArhiva;
        Update upDate;
      
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void gradoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grad == null)
            {
                grad = new Gradovi();
                grad.MdiParent = this;
                grad.FormClosed += grad_FormClosed;
                grad.Show();
                grad.WindowState = FormWindowState.Maximized;
            }
            else
            {
                grad.Close();
                grad = new Gradovi();
                grad.MdiParent = this;
                grad.FormClosed += grad_FormClosed;
                grad.Show();
                grad.WindowState = FormWindowState.Maximized;
            }
           
        }

        void grad_FormClosed(object sender, FormClosedEventArgs e)
        {
            grad = null;
            //throw new NotImplementedException();
        }

        private void plaćaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (placa == null)
            {
                placa = new Plaća();
                placa.MdiParent = this;
                placa.FormClosed += placa_FormClosed;
                placa.Show();
                placa.WindowState = FormWindowState.Maximized;
            }
            else
            {
                placa.Activate();
            }
           
        }

        void placa_FormClosed(object sender, FormClosedEventArgs e)
        {
            placa = null;
            //throw new NotImplementedException();
        }

        private void zaposleniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (djel == null)
            {
                djel = new djelatnici();
                djel.MdiParent = this;
                djel.FormClosed += djel_FormClosed;
                djel.Show();
                djel.WindowState = FormWindowState.Maximized;
            }
            else
            {
                djel.Activate();
            }
            
        }

        void djel_FormClosed(object sender, FormClosedEventArgs e)
        {
            djel = null;
            //throw new NotImplementedException();
        }

        private void firmapodatciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (firma == null)
            {
                firma = new Tvrtka();
                firma.MdiParent = this;
                firma.FormClosed += firma_FormClosed;
                firma.Show();
                firma.WindowState = FormWindowState.Maximized;
            }
            else
            {
                firma.Activate();
            }
        }

        void firma_FormClosed(object sender, FormClosedEventArgs e)
        {
            firma = null;
            //throw new NotImplementedException();
        }

        private void jOPPDpripremaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (priprema == null)
            {
                priprema = new JOPPD_priprema();
                priprema.MdiParent = this;
                priprema.FormClosed += priprema_FormClosed;
                priprema.Show();
                priprema.WindowState = FormWindowState.Maximized;
            }
            else
            {
                priprema.Activate();
            }
        }

        void priprema_FormClosed(object sender, FormClosedEventArgs e)
        {
            priprema = null;
            //throw new NotImplementedException();
        }

        private void obračunPlaćeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plObracun == null)
            {
                plObracun = new Placa_obracun();
                plObracun.MdiParent = this;
                plObracun.FormClosed += plObracun_FormClosed;
                plObracun.Show();
                plObracun.WindowState = FormWindowState.Maximized;
            }
            else
            {
                plObracun.Activate();
            }

        }
        void plObracun_FormClosed(object sender, FormClosedEventArgs e)
        {
            plObracun = null;
            //throw new NotImplementedException();
        }

        private void iPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPprint ipObrazac = new IPprint();
            ipObrazac.Show();
        }

        private void oPpllistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OP_obrazac opObreazac = new OP_obrazac();
            opObreazac.Show();
        }

        private void tablicaZaposleniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tZaposlenici == null)
            {
                tZaposlenici = new TablicaZaposlenici();
                tZaposlenici.MdiParent = this;
                tZaposlenici.FormClosed += tZaposlenici_FormClosed;
                tZaposlenici.Show();
                tZaposlenici.WindowState = FormWindowState.Maximized;
            }
            else
            {
                plObracun.Activate();
            }
        }
        void tZaposlenici_FormClosed(object sender, FormClosedEventArgs e)
        {
            tZaposlenici = null;
            //throw new NotImplementedException();
        }

        private void tablicaPlacaArhivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tPlArhiva == null)
            {
                tPlArhiva = new TablicaPlacaArhiva();
                tPlArhiva.MdiParent = this;
                tPlArhiva.FormClosed += tPlArhiva_FormClosed;
                tPlArhiva.Show();
                tPlArhiva.WindowState = FormWindowState.Maximized;
            }
            else
            {
                plObracun.Activate();
            }
        }
        void tPlArhiva_FormClosed(object sender, FormClosedEventArgs e)
        {
            tPlArhiva = null;
            //throw new NotImplementedException();
        }

        private void backupBazeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupBaze backupBaze;
            backupBaze = new BackupBaze();
            backupBaze.Backup();
        }

        private void povratKopijeBazeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupBaze backupBaze;
            backupBaze = new BackupBaze();
            backupBaze.Restore();
        }
        private void novaVerzijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (upDate == null)
            {
                upDate = new Update();
                upDate.MdiParent = this;
                upDate.FormClosed += upDate_FormClosed;
                upDate.Show();
            }
            else
            {
                upDate.Activate();
            }
        }

        void upDate_FormClosed(object sender, FormClosedEventArgs e)
        {
            upDate = null;
            //throw new NotImplementedException();
        }
    }
}

