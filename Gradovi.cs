using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Placa
{
    public partial class Gradovi : Form
    {
        public Gradovi()
        {
            InitializeComponent();
            popunilistu();
        }
        void popunilistu()
        {
            listView1.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.gradovi;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;

            listView1.View = View.Details;

            listView1.Columns.Add("Grad");
            listView1.Columns.Add("Šifra PU");
            listView1.Columns.Add("Šifra REGOS");
            listView1.Columns.Add("Šifra JOPPD");
            listView1.Columns.Add("Stopa prireza");
            bazaspoj.Open();
            citaj = bazazapovjed.ExecuteReader();
            while (citaj.Read())
            {
                var item = new ListViewItem();
                item.Text = citaj["grad"].ToString();        // 1st column text
                item.SubItems.Add(citaj["sifra_pu"].ToString());
                item.SubItems.Add(citaj["sifra_regos"].ToString());
                item.SubItems.Add(citaj["sifra_joppd"].ToString());           // 4th column text
                item.SubItems.Add(citaj["prirez"].ToString());
                listView1.Items.Add(item);
            }
            bazaspoj.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSifraPU.MaxLength = 4;
            txtSifraREGOS.MaxLength = 5;
            txtSifraJOPPD.MaxLength = 6;
            if (txtSifraPU.Text.Length < txtSifraPU.MaxLength && txtSifraREGOS.Text.Length < txtSifraREGOS.MaxLength
                && txtSifraJOPPD.Text.Length < txtSifraJOPPD.MaxLength)
            {
                listView1.Items.Clear();
                double prirez = Convert.ToDouble(txtPrirez.Text);
                prirez = Math.Round(prirez, 2);
                NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                nfi.NumberGroupSeparator = "";
                nfi.NumberDecimalSeparator = ".";
                txtPrirez.Text = prirez.ToString("N", nfi);
                string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                string upit = "insert into database.gradovi (grad, sifra_pu, sifra_regos, sifra_joppd, prirez) " +
                               "values ('" + txtGrad.Text + "','" + txtSifraPU.Text + "','" + txtSifraREGOS.Text + "','" +
                               txtSifraJOPPD.Text + "','" + txtPrirez.Text + "');";
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
                MessageBox.Show("Provjerite točnost unešenih podataka za šifre grada.");
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtGrad.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtSifraPU.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txtSifraREGOS.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtSifraJOPPD.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txtPrirez.Text = listView1.SelectedItems[0].SubItems[4].Text;
                

            }
            catch
            {
                MessageBox.Show("Učitajte popis");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSifraPU.MaxLength = 4;
            txtSifraREGOS.MaxLength = 5;
            txtSifraJOPPD.MaxLength = 6;
            if (txtSifraPU.Text.Length < txtSifraPU.MaxLength && txtSifraREGOS.Text.Length < txtSifraREGOS.MaxLength
                && txtSifraJOPPD.Text.Length < txtSifraJOPPD.MaxLength)
            {
                listView1.Items.Clear();
                double prirez = Convert.ToDouble(txtPrirez.Text);
                prirez = Math.Round(prirez, 2);
                NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                nfi.NumberGroupSeparator = "";
                nfi.NumberDecimalSeparator = ".";
                txtPrirez.Text = prirez.ToString("N", nfi);
                string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                string upit = "update database.gradovi set sifra_pu='" + txtSifraPU.Text +
                              "',sifra_regos='" + txtSifraREGOS.Text + "',sifra_joppd='" + txtSifraJOPPD.Text +
                              "',prirez='" + txtPrirez.Text + "' where grad='" + txtGrad.Text + "';" + 
                              "update database.gradovi join database.djelatnici on gradovi.grad=djelatnici.mjesto set djelatnici.prirez=gradovi.prirez;";
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
                MessageBox.Show("Provjerite točnost unešenih podataka za šifre gradova.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "delete from database.gradovi where grad='" + txtGrad.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                MessageBox.Show("Postoječi zapis je izbrisan.");
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
                
    }
}
