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
    public partial class djelatnici : Form
    {
        string godina = "0";
        int godinaInt = 0;
        public djelatnici()
        {
            InitializeComponent();
            popuniGradCombo();
            popunilistu();
        }
        void popunilistu()
        {
            listView1.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.djelatnici;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;

            listView1.View = View.Details;

            listView1.Columns.Add("Redni br.");
            listView1.Columns.Add("Ime i Prezime");
            listView1.Columns.Add("Mjesto");
            listView1.Columns.Add("Adresa");
            listView1.Columns.Add("Broj telefona 1");
            listView1.Columns.Add("Broj telefona 2");
            listView1.Columns.Add("Stručna sprema");
            listView1.Columns.Add("OIB");
            listView1.Columns.Add("Tekuči račun");
            listView1.Columns.Add("Koef. por. olakšice");
            int zadnjiID;
            bazaspoj.Open();
            citaj = bazazapovjed.ExecuteReader();
            while (citaj.Read())
            {
                var item = new ListViewItem();
                item.Text = citaj["idDjelatnika"].ToString();
                item.SubItems.Add(citaj["ime_prezime"].ToString());        // 1st column text
                item.SubItems.Add(citaj["mjesto"].ToString());
                item.SubItems.Add(citaj["ulica_broj"].ToString());
                item.SubItems.Add(citaj["telefon"].ToString());           // 4th column text
                item.SubItems.Add(citaj["telefon2"].ToString());
                item.SubItems.Add(citaj["strucna_s"].ToString());
                item.SubItems.Add(citaj["OIB"].ToString());
                item.SubItems.Add(citaj["tekuci_r"].ToString());
                item.SubItems.Add(citaj["olaksica"].ToString());
                listView1.Items.Add(item);
                zadnjiID = citaj.GetInt32("idDjelatnika");
                txtID.Text = (zadnjiID + 1).ToString();
            }
            if (txtID.Text == "")
            {
                txtID.Text = "1";
            }
            bazaspoj.Close();
        }
        void popuniGradCombo()
        {
            comboBoxGrad.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.gradovi;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziIme = citaj.GetString("grad");
                    comboBoxGrad.Items.Add(traziIme);
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            if (txtIme.Text != "" && txtMjesto.Text != "" && txtOIB.Text != "" && txtOlaksica.Text != "" &&
                txtPrirezDjel.Text != "" && txtStrucna.Text != "" && txtTekuci.Text != "" && txtTelefon.Text != ""
                && txtUlica.Text != "")
            {
                if (comboBoxGrad.Text != "")
                {
                    var today = DateTime.Today;
                    godina = today.ToString("yyyy");
                    if (txtOIB.Text.Length == 11)
                    {
                        double olaksica = Convert.ToDouble(txtOlaksica.Text);
                        olaksica = Math.Round(olaksica, 2);
                        NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                        nfi.NumberGroupSeparator = "";
                        nfi.NumberDecimalSeparator = ".";
                        txtOlaksica.Text = olaksica.ToString("N", nfi);
                        string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                        string upit = "insert into database.djelatnici (idDjelatnika, ime_prezime, mjesto, ulica_broj, telefon, telefon2, strucna_s, OIB, tekuci_r, olaksica, prirez) " +
                                       "values ('" + Convert.ToInt32(txtID.Text) + "','" + txtIme.Text + "','" + txtMjesto.Text + "','" + txtUlica.Text + "','" + txtTelefon.Text + "','" +
                                       txtTelefon2.Text + "','" + txtStrucna.Text + "','" + txtOIB.Text + "','" + txtTekuci.Text + "','" +
                                       txtOlaksica.Text + "','" + txtPrirezDjel.Text + "') ;";
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
                        popunilistu();
                    }
                    else
                    {
                        MessageBox.Show("OIB polje mora sadržavati 11 znakova.");
                    }
                }
                else
                {
                    MessageBox.Show("Molim odaberite grad sa popisa.");
                }
            }
            else
            {
                MessageBox.Show("Provjerite dali ste popunili sve podatke.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.gradovi where grad='" + comboBoxGrad.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziGrad = citaj.GetString("grad");
                    string traziPrirez = citaj.GetString("prirez");
                    txtMjesto.Text = traziGrad;
                    txtPrirezDjel.Text = traziPrirez;
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter Sorter = new ListViewSorter();
            listView1.ListViewItemSorter = Sorter;
            if (!(listView1.ListViewItemSorter is ListViewSorter))
                return;
            Sorter = (ListViewSorter)listView1.ListViewItemSorter;

            if (Sorter.LastSort == e.Column)
            {
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                listView1.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = e.Column;

            listView1.Sort();
        }
        public class ListViewSorter : System.Collections.IComparer
        {
            public int Compare(object o1, object o2)
            {
                if (!(o1 is ListViewItem))
                    return (0);
                if (!(o2 is ListViewItem))
                    return (0);

                ListViewItem lvi1 = (ListViewItem)o2;
                string str1 = lvi1.SubItems[ByColumn].Text;
                ListViewItem lvi2 = (ListViewItem)o1;
                string str2 = lvi2.SubItems[ByColumn].Text;

                int result;
                if (lvi1.ListView.Sorting == SortOrder.Ascending)
                    result = String.Compare(str1, str2);
                else
                    result = String.Compare(str2, str1);

                LastSort = ByColumn;

                return (result);
            }


            public int ByColumn
            {
                get { return Column; }
                set { Column = value; }
            }
            int Column = 0;

            public int LastSort
            {
                get { return LastColumn; }
                set { LastColumn = value; }
            }
            int LastColumn = 0;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtID.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtIme.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txtMjesto.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtUlica.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txtTelefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txtTelefon2.Text = listView1.SelectedItems[0].SubItems[5].Text;
                txtStrucna.Text = listView1.SelectedItems[0].SubItems[6].Text;
                txtOIB.Text = listView1.SelectedItems[0].SubItems[7].Text;
                txtTekuci.Text = listView1.SelectedItems[0].SubItems[8].Text;
                txtOlaksica.Text = listView1.SelectedItems[0].SubItems[9].Text;


            }
            catch
            {
                MessageBox.Show("Učitajte popis");
            }
        }

        private void btnBrisanje_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "delete from database.djelatnici where idDjelatnika='" + txtID.Text + "';" +
                          "delete from database.placa where idDjelatnika='" + txtID.Text + "';"+
                          "delete from database.joppd where idZaposlenika='" + txtID.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                MessageBox.Show("Zapis je izbrisan.");
                while (citaj.Read())
                {

                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            popunilistu();
        }

        private void btnIzmjena_Click(object sender, EventArgs e)
        {
            int redBrojZaposlenika = Convert.ToInt16(txtID.Text);
            double olaksica = Convert.ToDouble(txtOlaksica.Text);
            olaksica = Math.Round(olaksica, 2);
            NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";
            txtOlaksica.Text = olaksica.ToString("N", nfi);
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "update database.djelatnici set idDjelatnika='" + txtID.Text + "', ime_prezime='" + txtIme.Text + "',mjesto='" + txtMjesto.Text +
                            "',ulica_broj='" + txtUlica.Text + "',telefon='" + txtTelefon.Text + "',telefon2='" + txtTelefon2.Text +
                            "',strucna_s='" + txtStrucna.Text + "',OIB='" + txtOIB.Text + "',tekuci_r='" + txtTekuci.Text + "',olaksica='" +
                            txtOlaksica.Text + "',prirez='0' where idDjelatnika='" + txtID.Text + "';" +
                            "update database.gradovi join database.djelatnici on gradovi.grad=djelatnici.mjesto set djelatnici.prirez=gradovi.prirez;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                MessageBox.Show("Postoječi zapis promjenjen.");
                while (citaj.Read())
                {

                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            listView1.Items.Clear();
            popunilistu();
            txtID.Text = (redBrojZaposlenika).ToString();
        }

        private void btnPripArh_Click(object sender, EventArgs e)
        {
            if (txtIme.Text != "")
            {
                var today = DateTime.Today;
                godinaInt = Convert.ToInt32(today.Year);
                godina = today.ToString("yyyy");
                string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                string upit = "select distinct ime_prezime from database.placa_arhiva where ime_prezime='" + txtIme.Text + "' and godina='" + godina + "' and mjesec<12 ;";
                MySqlConnection bazaspoj = new MySqlConnection(constring);
                MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
                MySqlDataReader citaj;
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                string ime = "";
                while (citaj.Read())
                {
                    ime = citaj["ime_prezime"].ToString();
                }
                bazaspoj.Close();
                bool provjera = true;
                if (ime.Contains(txtIme.Text.ToString()))
                {
                    provjera = false;
                }
                if (provjera == true)
                {
                    try
                    {
                        int i = 1;
                        while (i < 13)
                        {
                            if (i < 9)
                            {
                                string mjesec = Convert.ToString(i);
                                upit = "insert into database.placa_arhiva (idDjelatnika, ime_prezime, mjesec, godina, danisplate) "+
                                "values ('" + Convert.ToInt32(txtID.Text) + "','" + txtIme.Text + "','" + "0" + i + "','" + godina + 
                                "', '01.0" + (i + 1) + "." + godina + "');";
                                bazaspoj = new MySqlConnection(constring);
                                bazazapovjed = new MySqlCommand(upit, bazaspoj);
                                i = i + 1;
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
                            else if ( i == 9)
                            {
                                string mjesec = Convert.ToString(i);
                                upit = "insert into database.placa_arhiva (idDjelatnika, ime_prezime, mjesec, godina, danisplate) " +
                                "values ('" + Convert.ToInt32(txtID.Text) + "','" + txtIme.Text + "','" + "0" + i + "','" + godina +
                                "', '01." + (i + 1) + "." + godina + "');";
                                bazaspoj = new MySqlConnection(constring);
                                bazazapovjed = new MySqlCommand(upit, bazaspoj);
                                i = i + 1;
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
                            else if ( i < 12)
                            {
                                string mjesec = Convert.ToString(i);
                                upit = "insert into database.placa_arhiva (idDjelatnika, ime_prezime, mjesec, godina, danisplate) values ('" + Convert.ToInt32(txtID.Text) + "','" + txtIme.Text + "','" + i + "','" + godina + "', '01." + (i + 1) + "." + godina + "');";
                                bazaspoj = new MySqlConnection(constring);
                                bazazapovjed = new MySqlCommand(upit, bazaspoj);
                                i = i + 1;
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
                                godinaInt = Convert.ToInt16(godina) + 1;
                                string mjesec = Convert.ToString(i);
                                upit = "insert into database.placa_arhiva (idDjelatnika, ime_prezime, mjesec, godina, danisplate) values ('" + Convert.ToInt32(txtID.Text) + "','" + txtIme.Text + "','" + mjesec + "','" + godina + "', '01.0" + (i - 11) + "." + godinaInt +"');";
                                bazaspoj = new MySqlConnection(constring);
                                bazazapovjed = new MySqlCommand(upit, bazaspoj);
                                i = i + 1;
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
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Arhiva spremna.");
                    }
                    MessageBox.Show("Dodano u arhivu.");
                }
                else
                {
                    MessageBox.Show("Ime več postoji u arhivi, kontaktirajte programera");
                }
            }
            else
            {
                MessageBox.Show("Niste odabrali zaposlenika");
            }
            
        }

    }

}
