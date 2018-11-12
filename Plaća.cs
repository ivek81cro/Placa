using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Projekt_Placa
{
    public partial class Plaća : Form
    {
        public Plaća()
        {
            InitializeComponent();
            popuniImeCombo();
            popunilistuPlaca();
            
        }
        /*string daliPodPlaca;*/
        string checkMioStup;
        void popuniImeCombo()
        {
            cboxZaposlenici.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.djelatnici;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziIme = citaj.GetString("ime_prezime");
                    cboxZaposlenici.Items.Add(traziIme);
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popunilistuPlaca()
        {
            listViewPlaca.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.placa;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;

            listViewPlaca.View = View.Details;

            listViewPlaca.Columns.Add("Redni br.");
            listViewPlaca.Columns.Add("Ime i Prezime");
            listViewPlaca.Columns.Add("Bruto");
            listViewPlaca.Columns.Add("MIO 1");
            listViewPlaca.Columns.Add("MIO 2");
            listViewPlaca.Columns.Add("Odbitak");
            listViewPlaca.Columns.Add("Porez 24%");
            listViewPlaca.Columns.Add("Porez 25%");
            listViewPlaca.Columns.Add("Porez 40%");
            listViewPlaca.Columns.Add("Prirez");
            listViewPlaca.Columns.Add("Neto");
            listViewPlaca.Columns.Add("Prijevoz");
            listViewPlaca.Columns.Add("Za isplatu");
            listViewPlaca.Columns.Add("Dop. za zdravsveno");
            listViewPlaca.Columns.Add("Dop. za zašt. na radu");
            listViewPlaca.Columns.Add("Dop. za zapošljavanje");
            listViewPlaca.Columns.Add("Uk. trošak za poslodavca");

            bazaspoj.Open();
            citaj = bazazapovjed.ExecuteReader();
            while (citaj.Read())
            {
                NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                nfi.NumberGroupSeparator = "";
                nfi.NumberDecimalSeparator = ".";
                var item = new ListViewItem();
                item.Text = citaj["idDjelatnika"].ToString();
                item.SubItems.Add(citaj["ime_prezime"].ToString());        // 1st column text
                item.SubItems.Add(citaj["bruto"].ToString());
                item.SubItems.Add(citaj["mio1"].ToString());
                item.SubItems.Add(citaj["mio2"].ToString());           // 4th column text
                item.SubItems.Add(citaj["odbitak"].ToString());
                item.SubItems.Add(citaj["porez12"].ToString());
                item.SubItems.Add(citaj["porez25"].ToString());
                item.SubItems.Add(citaj["porez40"].ToString());
                item.SubItems.Add(citaj["prirez"].ToString());
                item.SubItems.Add(citaj["neto"].ToString());
                item.SubItems.Add(citaj["prijevoz"].ToString());
                item.SubItems.Add(citaj["zaisplatu"].ToString());
                item.SubItems.Add(citaj["dopzdravstveno"].ToString());
                item.SubItems.Add(citaj["dopzastita"].ToString());
                item.SubItems.Add(citaj["dopzaposljavanje"].ToString());
                item.SubItems.Add(citaj["trosakposlodavac"].ToString());
                listViewPlaca.Items.Add(item);
            }
            bazaspoj.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if ( txtPrijevoz.Text != "" && txtBruto.Text != "" && cboxZaposlenici.Text != "")
            {
                double mio1;
                double mio2;
                double bruto = Double.Parse(txtBruto.Text, CultureInfo.CurrentCulture);
                if (checkMioStup == "1")
                {
                    if (bruto > 47658)
                    {
                        mio1 = 47658 * 0.20;
                        mio2 = 47658 * 0.00;
                    }
                    else
                    {
                        mio1 = bruto * 0.20;
                        mio2 = bruto * 0.00;
                    }
                }
                else
                {
                    if (bruto > 47658)
                    {
                        mio1 = 47658 * 0.15;
                        mio2 = 47658 * 0.05;
                    }
                    else
                    {
                        mio1 = bruto * 0.15;
                        mio2 = bruto * 0.05;
                    }
                }
                double koefOdbitka = Convert.ToDouble(txtKoefOdbitak.Text);
                double odbitak = (2500 * (koefOdbitka-1)+3800);
                double oporezivo = (bruto - (mio1 + mio2)) - odbitak;
                double porez24;
                double porez36;
                if (oporezivo <= 17500)
                {
                    if (oporezivo <= 0)
                    {
                        txtPorez24.Text = "0";
                        oporezivo = 0.00;
                    }
                
                    porez24 = oporezivo * 0.24;
                    txtPorez24.Text = porez24.ToString();
                    oporezivo = oporezivo - 17500;
                }
                else
                {
                    porez24 = 17500 * 0.24;
                    txtPorez24.Text = porez24.ToString();
                    oporezivo = oporezivo - 17500;
                }
                if (oporezivo > 0)
                {
                    porez36 = oporezivo * 0.36;
                    txtPorez36.Text = porez36.ToString();
                }
                else
                {
                    txtPorez36.Text = "0";
                } 
                double mioUkupno = mio1 + mio2;
                double dohodak = bruto - mioUkupno;
                if(dohodak < odbitak)
                {
                    odbitak = dohodak;
                }
                double porOsnovica = dohodak - odbitak;
                if (porOsnovica <=0)
                {
                    porOsnovica = 0.00;
                }

                porez24 = Convert.ToDouble(txtPorez24.Text);
                //porez25 = Convert.ToDouble(txtPorez25.Text);
                porez36 = Convert.ToDouble(txtPorez36.Text);
                double ukupnoPorez = porez24 + porez36;
                double stopaPrireza = Convert.ToDouble(txtPrirezPlaca.Text);
                double prirez = (porez24 + porez36) * (stopaPrireza / 100);
                double ukupnoPorezi = porez24 + porez36 + prirez;
                double prijevoz = Double.Parse(txtPrijevoz.Text, CultureInfo.CurrentCulture);
                double ukupno = bruto - mio1 - mio2 - ukupnoPorezi + prijevoz;
                double neto = bruto - mio1 - mio2 - ukupnoPorezi;
                double dopZdravstv = bruto * 0.15;
                double dopZast = bruto * 0.005;
                double dopZaposlj = bruto * 0.017;
                double ukupniTrosak = bruto + dopZast + dopZaposlj + dopZdravstv;
                double ukupnoNaPlacu = dopZaposlj + dopZast + dopZdravstv;
                bruto = Math.Round(bruto, 2);
                prijevoz = Math.Round(prijevoz, 2);
                NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                nfi.NumberGroupSeparator = "";
                nfi.NumberDecimalSeparator = ".";
                txtBruto.Text = bruto.ToString("N", nfi);
                txtMio1.Text = mio1.ToString("N", nfi);
                txtMio2.Text = mio2.ToString("N", nfi);
                txtOdbitak.Text = odbitak.ToString("N", nfi);
                txtPorez24.Text = porez24.ToString("N", nfi);
                txtPorez36.Text = porez36.ToString("N", nfi);
                txtPrirez.Text = prirez.ToString("N", nfi);
                txtNeto.Text = neto.ToString("N", nfi);
                txtUkupno.Text = ukupno.ToString("N", nfi);
                txtDopZdr.Text = dopZdravstv.ToString("N", nfi);
                txtDopZast.Text = dopZast.ToString("N", nfi);
                txtDopZapos.Text = dopZaposlj.ToString("N", nfi);
                txtUkupniTrosak.Text = ukupniTrosak.ToString("N", nfi);
                txtPrijevoz.Text = prijevoz.ToString("N", nfi);
                txtMioUkupno.Text = mioUkupno.ToString("N", nfi);
                txtDohodak.Text = dohodak.ToString("N", nfi);
                txtPorOsn.Text = porOsnovica.ToString("N", nfi);
                txtUkupnoPorez.Text = ukupnoPorez.ToString("N", nfi);
                txtUkNaPlacu.Text = ukupnoNaPlacu.ToString("N", nfi);
            }
            else
            {
                MessageBox.Show("Provjerite da li ste popunili sva polja.");
            }
            popunilistuPlaca();
        }
        
        private void cboxZaposlenici_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.djelatnici where ime_prezime='" + cboxZaposlenici.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziPrirez = citaj.GetString("prirez");
                    string traziOlaksicu = citaj.GetString("olaksica");
                    string traziID = citaj.GetString("idDjelatnika");
                    txtPrirezPlaca.Text = traziPrirez;
                    txtKoefOdbitak.Text = traziOlaksicu;
                    txtRedniBr.Text = traziID;


                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkMioStup = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkMioStup = "2";
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPrijevoz.Text != "" && txtBruto.Text != "" && cboxZaposlenici.SelectedItem.ToString() != "")
            {
                string odabranoIme = this.cboxZaposlenici.GetItemText(this.cboxZaposlenici.SelectedItem);
                string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                string upit = "update database.placa set bruto='" + txtBruto.Text + "',mio1='" + txtMio1.Text + "',mio2='" + txtMio2.Text +
                              "',odbitak='" + txtOdbitak.Text + "',porez12='" + txtPorez24.Text + "',porez25='0',porez40='" + txtPorez36.Text +
                              "',prirez='" + txtPrirez.Text + "',neto='" + txtNeto.Text + "',prijevoz='" + txtPrijevoz.Text +
                              "',zaisplatu='" + txtUkupno.Text + "',dopzdravstveno='" + txtDopZdr.Text + "',dopzastita='" + txtDopZast.Text +
                              "',dopzaposljavanje='" + txtDopZapos.Text + "',trosakposlodavac='" + txtUkupniTrosak.Text +
                              "',mioukupno='" + txtMioUkupno.Text + "',dohodak='" + txtDohodak.Text + "',porosn='" + txtPorOsn.Text +
                              "',porezukupno='" + txtUkupnoPorez.Text + "',ukupnonaplacu='" + txtUkNaPlacu.Text +
                              "'  where ime_prezime='" + odabranoIme + "';";

                MySqlConnection bazaspoj = new MySqlConnection(constring);
                MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
                MySqlDataReader citaj;
                try
                {
                    bazaspoj.Open();
                    citaj = bazazapovjed.ExecuteReader();
                    MessageBox.Show("Zapis je promjenjen.");
                    while (citaj.Read())
                    {

                    }
                    bazaspoj.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (checkBox1.Checked)
                {
                    upit = "update database.placa set podplaca='da' where ime_prezime ='" + odabranoIme + "';";
                    bazaspoj = new MySqlConnection(constring);
                    bazazapovjed = new MySqlCommand(upit, bazaspoj);
                    try
                    {
                        bazaspoj.Open();
                        citaj = bazazapovjed.ExecuteReader();
                        while (citaj.Read())
                        {

                        }
                        bazaspoj.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    upit = "update database.placa set podplaca='ne' where ime_prezime ='" + odabranoIme + "';";
                    bazaspoj = new MySqlConnection(constring);
                    bazazapovjed = new MySqlCommand(upit, bazaspoj);
                    try
                    {
                        bazaspoj.Open();
                        citaj = bazazapovjed.ExecuteReader();
                        while (citaj.Read())
                        {

                        }
                        bazaspoj.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                popunilistuPlaca();
            }
            else
            {
                MessageBox.Show("Odaberite zaposlenika i porvjerite dali su popunjena sva polja.");
            }
        }

         private void Plaća_Load(object sender, EventArgs e)
        {
            
        }

         private void btnSpremi_Click(object sender, EventArgs e)
         {
             if (txtPrijevoz.Text != "" && txtBruto.Text != "" && cboxZaposlenici.SelectedItem.ToString() != "")
             {
                 string odabranoIme = this.cboxZaposlenici.GetItemText(this.cboxZaposlenici.SelectedItem);
                 string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                 string upit = "insert into database.placa ( ime_prezime, bruto, mio1, mio2, odbitak, porez12, porez25, porez40, prirez, neto," +
                               "prijevoz, zaisplatu, dopzdravstveno, dopzastita, dopzaposljavanje, trosakposlodavac, mioukupno," +
                               "dohodak, porosn, porezukupno, ukupnonaplacu) values ('" + odabranoIme + "','" + txtBruto.Text + "','" + txtMio1.Text + "','" +
                               txtMio2.Text + "','" + txtOdbitak.Text + "','" + txtPorez24.Text + "','0','" + txtPorez36.Text + "','" +
                               txtPrirez.Text + "','" + txtNeto.Text + "','" + txtPrijevoz.Text + "','" + txtUkupno.Text + "','" +
                               txtDopZdr.Text + "','" + txtDopZast.Text + "','" + txtDopZapos.Text + "','" + txtUkupniTrosak.Text + "','" +
                               txtMioUkupno.Text + "','" + txtDohodak.Text + "','" + txtPorOsn.Text + "','" + txtUkupnoPorez.Text + "','" +
                               txtUkNaPlacu.Text + "');" +
                               "update database.djelatnici join database.placa on djelatnici.ime_prezime=placa.ime_prezime set " +
                               "placa.idDjelatnika=djelatnici.idDjelatnika;";

                 MySqlConnection bazaspoj = new MySqlConnection(constring);
                 MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
                 MySqlDataReader citaj;
                 try
                 {
                     bazaspoj.Open();
                     citaj = bazazapovjed.ExecuteReader();
                     MessageBox.Show("Novi zapis spremljen.");
                     while (citaj.Read())
                     {

                     }
                     bazaspoj.Close();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
                 if (checkBox1.Checked)
                 {
                     upit = "update database.placa set podplaca='da' where ime_prezime ='" + odabranoIme + "';";
                     bazaspoj = new MySqlConnection(constring);
                     bazazapovjed = new MySqlCommand(upit, bazaspoj);
                     try
                     {
                         bazaspoj.Open();
                         citaj = bazazapovjed.ExecuteReader();
                         MessageBox.Show("Novi zapis spremljen.");
                         while (citaj.Read())
                         {

                         }
                         bazaspoj.Close();
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.Message);
                     }
                 }
                 else
                 {
                     upit = "update database.placa set podplaca='ne' where ime_prezime ='" + odabranoIme + "';";
                     bazaspoj = new MySqlConnection(constring);
                     bazazapovjed = new MySqlCommand(upit, bazaspoj);
                     try
                     {
                         bazaspoj.Open();
                         citaj = bazazapovjed.ExecuteReader();
                         MessageBox.Show("Novi zapis spremljen.");
                         while (citaj.Read())
                         {

                         }
                         bazaspoj.Close();
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.Message);
                     }
                 }
                 popunilistuPlaca();
             }
             else
             {
                 MessageBox.Show("Odaberite zaposlenika i provjerite dali su sva polja popunjena.");
             }
         }

         private void listViewPlaca_MouseClick(object sender, MouseEventArgs e)
         {
             try
             {
                 txtRedniBr.Text = listViewPlaca.SelectedItems[0].SubItems[0].Text;
                 cboxZaposlenici.Text = listViewPlaca.SelectedItems[0].SubItems[1].Text;
                 txtBruto.Text = listViewPlaca.SelectedItems[0].SubItems[2].Text;
                 txtMio1.Text = listViewPlaca.SelectedItems[0].SubItems[3].Text;
                 txtMio2.Text = listViewPlaca.SelectedItems[0].SubItems[4].Text;
                 txtOdbitak.Text = listViewPlaca.SelectedItems[0].SubItems[5].Text;
                 txtPorez24.Text = listViewPlaca.SelectedItems[0].SubItems[6].Text;
                 //txtPorez25.Text = listViewPlaca.SelectedItems[0].SubItems[7].Text;
                 txtPorez36.Text = listViewPlaca.SelectedItems[0].SubItems[8].Text;
                 txtPrirez.Text = listViewPlaca.SelectedItems[0].SubItems[9].Text;
                 txtNeto.Text = listViewPlaca.SelectedItems[0].SubItems[10].Text;
                 txtPrijevoz.Text = listViewPlaca.SelectedItems[0].SubItems[11].Text;
                 txtUkupno.Text = listViewPlaca.SelectedItems[0].SubItems[12].Text;
                 txtDopZdr.Text = listViewPlaca.SelectedItems[0].SubItems[13].Text;
                 txtDopZast.Text = listViewPlaca.SelectedItems[0].SubItems[14].Text;
                 txtDopZapos.Text = listViewPlaca.SelectedItems[0].SubItems[15].Text;
                 txtUkupniTrosak.Text = listViewPlaca.SelectedItems[0].SubItems[16].Text;


             }
             catch
             {
                 MessageBox.Show("Učitajte popis");
             }
         }

         private void btnJOPPD_Click(object sender, EventArgs e)
         {
             string odabranoIme = this.cboxZaposlenici.GetItemText(this.cboxZaposlenici.SelectedItem);
             string constring = "datasource=localhost;port=3306;username=root;password=pass123";
             string upit = "insert into database.joppd (idZaposlenika, ime) values ('" + txtRedniBr.Text + "','" + cboxZaposlenici.Text + "');" +
                           "update database.gradovi join database.djelatnici on gradovi.grad=djelatnici.mjesto set djelatnici.mjesto_sifrajoppd=gradovi.sifra_joppd;"+
                           "update database.placa join database.joppd on placa.ime_prezime=joppd.ime set joppd.poslodavac=placa.podplaca;";
                 MySqlConnection bazaspoj = new MySqlConnection(constring);
                 MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
                 MySqlDataReader citaj;
                 try
                 {
                     bazaspoj.Open();
                     citaj = bazazapovjed.ExecuteReader();
                     MessageBox.Show("Novi zapis spremljen.");
                     while (citaj.Read())
                     {

                     }
                     bazaspoj.Close();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
         }
    }
}
