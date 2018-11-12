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
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace Projekt_Placa
{
    public partial class JOPPD_priprema : Form
    {
        public JOPPD_priprema()
        {
            InitializeComponent();
            popunilistuJoppd();
            popuni61Combo();
            popuni62Combo();
            popuni71Combo();
            popuni72Combo();
            popuni8Combo();
            popuni9Combo();
            popuni151Combo();
            popuni161Combo();
        }
        void popuni61Combo()
        {
            comboBox61.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_stjecatelj;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru61 = citaj.GetString("sifra");
                    string traziOpis61 = citaj.GetString("opis");
                    comboBox61.Items.Add(traziSifru61);
                    comboBox61.Text = "0001";
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuni62Combo()
        {
            comboBox62.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_primitak;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru62 = citaj.GetString("sifra");
                    string traziOpis62 = citaj.GetString("opis");
                    comboBox62.Items.Add(traziSifru62);
                    comboBox62.Text = "0001";
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuni71Combo()
        {
            comboBox71.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_71;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru71 = citaj.GetString("sifra");
                    string traziOpis71 = citaj.GetString("opis");
                    comboBox71.Items.Add(traziSifru71);
                    comboBox71.Text = "0";
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuni72Combo()
        {
            comboBox72.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_72;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru72 = citaj.GetString("sifra");
                    string traziOpis72 = citaj.GetString("opis");
                    comboBox72.Items.Add(traziSifru72);
                    comboBox72.Text = "0";
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuni8Combo()
        {
            comboBox8.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_8;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru8 = citaj.GetString("sifra");
                    string traziOpis8 = citaj.GetString("opis");
                    comboBox8.Items.Add(traziSifru8);
                    comboBox8.Text = "3";
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuni9Combo()
        {
            comboBox9.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_9;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru9 = citaj.GetString("sifra");
                    string traziOpis9 = citaj.GetString("opis");
                    comboBox9.Items.Add(traziSifru9);
                    comboBox9.Text = "1";
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuni151Combo()
        {
            combo151.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_neoporezivo;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru151 = citaj.GetString("sifra");
                    string traziOpis151 = citaj.GetString("opis");
                    combo151.Items.Add(traziSifru151);
                    combo151.Text = "19";
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuni161Combo()
        {
            combo161.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_isplata;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru161 = citaj.GetString("sifra");
                    string traziOpis161 = citaj.GetString("opis");
                    combo161.Items.Add(traziSifru161);
                    combo161.Text = "1";
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popunilistuJoppd()
        {
            listViewJoppd.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.joppd;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;

            listViewJoppd.View = View.Details;

            listViewJoppd.Columns.Add("P1");
            listViewJoppd.Columns.Add("P2");
            listViewJoppd.Columns.Add("P3");
            listViewJoppd.Columns.Add("P4");
            listViewJoppd.Columns.Add("P5");
            listViewJoppd.Columns.Add("P61");
            listViewJoppd.Columns.Add("P62");
            listViewJoppd.Columns.Add("P71");
            listViewJoppd.Columns.Add("P72");
            listViewJoppd.Columns.Add("P8");
            listViewJoppd.Columns.Add("P9");
            listViewJoppd.Columns.Add("P10");
            listViewJoppd.Columns.Add("P100");
            listViewJoppd.Columns.Add("P101");
            listViewJoppd.Columns.Add("P102");
            listViewJoppd.Columns.Add("P11");
            listViewJoppd.Columns.Add("P12");
            listViewJoppd.Columns.Add("P121");
            listViewJoppd.Columns.Add("P122");
            listViewJoppd.Columns.Add("P123");
            listViewJoppd.Columns.Add("P124");
            listViewJoppd.Columns.Add("P125");
            listViewJoppd.Columns.Add("P126");
            listViewJoppd.Columns.Add("P127");
            listViewJoppd.Columns.Add("P128");
            listViewJoppd.Columns.Add("P129");
            listViewJoppd.Columns.Add("P131");
            listViewJoppd.Columns.Add("P132");
            listViewJoppd.Columns.Add("P133");
            listViewJoppd.Columns.Add("P134");
            listViewJoppd.Columns.Add("P135");
            listViewJoppd.Columns.Add("P141");
            listViewJoppd.Columns.Add("P142");
            listViewJoppd.Columns.Add("P151");
            listViewJoppd.Columns.Add("P152");
            listViewJoppd.Columns.Add("P161");
            listViewJoppd.Columns.Add("P162");
            listViewJoppd.Columns.Add("P17");

            bazaspoj.Open();
            citaj = bazazapovjed.ExecuteReader();
            while (citaj.Read())
            {
                NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                nfi.NumberGroupSeparator = "";
                nfi.NumberDecimalSeparator = ".";
                var item = new ListViewItem();
                item.Text = citaj["idZaposlenika"].ToString();
                item.SubItems.Add(citaj["2"].ToString());        // 1st column text
                item.SubItems.Add(citaj["3"].ToString());
                item.SubItems.Add(citaj["4"].ToString());
                item.SubItems.Add(citaj["ime"].ToString());           // 4th column text
                item.SubItems.Add(citaj["6_1"].ToString());
                item.SubItems.Add(citaj["6_2"].ToString());
                item.SubItems.Add(citaj["7_1"].ToString());
                item.SubItems.Add(citaj["7_2"].ToString());
                item.SubItems.Add(citaj["8"].ToString());
                item.SubItems.Add(citaj["9"].ToString());
                item.SubItems.Add(citaj["10"].ToString());
                item.SubItems.Add(citaj["10_0"].ToString());
                item.SubItems.Add(citaj["10_1"].ToString());
                item.SubItems.Add(citaj["10_2"].ToString());
                item.SubItems.Add(citaj["11"].ToString());
                item.SubItems.Add(citaj["12"].ToString());
                item.SubItems.Add(citaj["12_1"].ToString());
                item.SubItems.Add(citaj["12_2"].ToString());
                item.SubItems.Add(citaj["12_3"].ToString());
                item.SubItems.Add(citaj["12_4"].ToString());
                item.SubItems.Add(citaj["12_5"].ToString());
                item.SubItems.Add(citaj["12_6"].ToString());
                item.SubItems.Add(citaj["12_7"].ToString());
                item.SubItems.Add(citaj["12_8"].ToString());
                item.SubItems.Add(citaj["12_9"].ToString());
                item.SubItems.Add(citaj["13_1"].ToString());
                item.SubItems.Add(citaj["13_2"].ToString());
                item.SubItems.Add(citaj["13_3"].ToString());
                item.SubItems.Add(citaj["13_4"].ToString());
                item.SubItems.Add(citaj["13_5"].ToString());
                item.SubItems.Add(citaj["14_1"].ToString());
                item.SubItems.Add(citaj["14_2"].ToString());
                item.SubItems.Add(citaj["15_1"].ToString());
                item.SubItems.Add(citaj["15_2"].ToString());
                item.SubItems.Add(citaj["16_1"].ToString());
                item.SubItems.Add(citaj["16_2"].ToString());
                item.SubItems.Add(citaj["17"].ToString());
                listViewJoppd.Items.Add(item);
            }
            bazaspoj.Close();
        }
        void popuniStranicuA()
        {
            NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";
            string connStr = "datasource=localhost;port=3306;username=root;password=pass123"; //Set your MySQL connection string here.

            //-------------------------------------------ZAPOSLENICI---------------------------------
            string query = "Select * from  database.joppd where poslodavac='ne'"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            double mio1Zap = 0.00;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                mio1Zap += Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
            }
            mio1Zap = mio1Zap / 100;
            txtUkMio1.Text = mio1Zap.ToString("N", nfi);
            double mio2zap = 0.00;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                mio2zap += Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
            }
            mio2zap = mio2zap / 100;
            txtUkMio2.Text = mio2zap.ToString("N", nfi);
            double zdrZapos = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                zdrZapos += Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value);
            }
            zdrZapos = zdrZapos / 100;
            txtZdravRad.Text = zdrZapos.ToString("N", nfi);
            double zastRad = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                zastRad += Convert.ToDouble(dataGridView1.Rows[i].Cells[20].Value);
            }
            zastRad = zastRad / 100;
            txtZastRad.Text = zastRad.ToString("N", nfi);
            double dopZapos = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dopZapos += Convert.ToDouble(dataGridView1.Rows[i].Cells[21].Value);
            }
            dopZapos = dopZapos / 100;
            txtDopZap.Text = dopZapos.ToString("N", nfi);

            //------------------------------------------POSLODAVAC-------------------------------
            query = "Select * from  database.joppd where poslodavac='da'"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            double mio1Posl = 0.00;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                mio1Posl += Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
            }
            mio1Posl = mio1Posl / 100;
            txtMioPod.Text = mio1Posl.ToString("N", nfi);
            double mio2Posl = 0.00;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                mio2Posl += Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
            }
            mio2Posl = mio2Posl / 100;
            txtMio2Pod.Text = mio2Posl.ToString("N", nfi);
            double zdarvPosl = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                zdarvPosl += Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value);
            }
            zdarvPosl = zdarvPosl / 100;
            txtZdravPod.Text = zdarvPosl.ToString("N", nfi);
            double zastpoduz = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                zastpoduz += Convert.ToDouble(dataGridView1.Rows[i].Cells[20].Value);
            }
            zastpoduz = zastpoduz / 100;
            txtZastPod.Text = zastpoduz.ToString("N", nfi);
            double dopZaposPOd = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dopZaposPOd += Convert.ToDouble(dataGridView1.Rows[i].Cells[21].Value);
            }
            dopZaposPOd = dopZaposPOd / 100;
            txtDopZapPod.Text = dopZaposPOd.ToString("N", nfi);

            //---------------------------------------------PRIREZ I POREZ - UKUPNO I NEOPOREZIVO--------------------------
            query = "Select * from  database.joppd"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            double porez = 0.00;
            double prirez = 0.00;
            double poreziUk;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                porez += Convert.ToDouble(dataGridView1.Rows[i].Cells[31].Value);
            }
            porez = porez / 100;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                prirez += Convert.ToDouble(dataGridView1.Rows[i].Cells[32].Value);
            }
            prirez = prirez / 100;
            poreziUk = porez + prirez;
            txtUkPorezPrirez.Text = poreziUk.ToString("N", nfi);
            double neopor = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                neopor += Convert.ToDouble(dataGridView1.Rows[i].Cells[34].Value);
            }
            neopor = neopor / 100;
            txtUkNeop.Text = neopor.ToString("N", nfi);
        }
        private void JOPPD_priprema_Load(object sender, EventArgs e)
        {

        }

        private void comboBox61_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_stjecatelj where sifra='" + comboBox61.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru61 = citaj.GetString("sifra");
                    string traziOpis = citaj.GetString("opis");
                    comboBox61.Text = traziSifru61;
                    lbl61.Text = traziOpis;


                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox62_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_primitak where sifra='" + comboBox62.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru62 = citaj.GetString("sifra");
                    string traziOpis = citaj.GetString("opis");
                    comboBox62.Text = traziSifru62;
                    lbl62.Text = traziOpis;
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox71_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_71 where sifra='" + comboBox71.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru71 = citaj.GetString("sifra");
                    string traziOpis = citaj.GetString("opis");
                    comboBox71.Text = traziSifru71;
                    lbl71.Text = traziOpis;
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox72_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_72 where sifra='" + comboBox72.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru72 = citaj.GetString("sifra");
                    string traziOpis = citaj.GetString("opis");
                    comboBox72.Text = traziSifru72;
                    lbl72.Text = traziOpis;
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_8 where sifra='" + comboBox8.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru8 = citaj.GetString("sifra");
                    string traziOpis = citaj.GetString("opis");
                    comboBox8.Text = traziSifru8;
                    lbl8.Text = traziOpis;
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_9 where sifra='" + comboBox9.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru9 = citaj.GetString("sifra");
                    string traziOpis = citaj.GetString("opis");
                    comboBox9.Text = traziSifru9;
                    lbl9.Text = traziOpis;
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo151_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_neoporezivo where sifra='" + combo151.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru151 = citaj.GetString("sifra");
                    string traziOpis = citaj.GetString("opis");
                    combo151.Text = traziSifru151;
                    lbl151.Text = traziOpis;
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo161_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.sifrarnik_isplata where sifra='" + combo161.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziSifru161 = citaj.GetString("sifra");
                    string traziOpis = citaj.GetString("opis");
                    combo161.Text = traziSifru161;
                    lbl161.Text = traziOpis;
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewJoppd_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtOdabrani.Text = listViewJoppd.SelectedItems[0].SubItems[4].Text;
                comboBox61.Text = listViewJoppd.SelectedItems[0].SubItems[5].Text;
                comboBox62.Text = listViewJoppd.SelectedItems[0].SubItems[6].Text;
                comboBox71.Text = listViewJoppd.SelectedItems[0].SubItems[7].Text;
                comboBox72.Text = listViewJoppd.SelectedItems[0].SubItems[8].Text;
                comboBox8.Text = listViewJoppd.SelectedItems[0].SubItems[9].Text;
                comboBox9.Text = listViewJoppd.SelectedItems[0].SubItems[10].Text;
                txtSatiRada.Text = listViewJoppd.SelectedItems[0].SubItems[11].Text;
                txtSatiNerad.Text = listViewJoppd.SelectedItems[0].SubItems[12].Text;
                maskOd.Text = listViewJoppd.SelectedItems[0].SubItems[13].Text;
                maskDo.Text = listViewJoppd.SelectedItems[0].SubItems[14].Text;
                txt126.Text = listViewJoppd.SelectedItems[0].SubItems[22].Text;
                txt127.Text = listViewJoppd.SelectedItems[0].SubItems[23].Text;
                txt128.Text = listViewJoppd.SelectedItems[0].SubItems[24].Text;
                txt129.Text = listViewJoppd.SelectedItems[0].SubItems[25].Text;
                txt131.Text = listViewJoppd.SelectedItems[0].SubItems[26].Text;
                combo151.Text = listViewJoppd.SelectedItems[0].SubItems[33].Text;
                combo161.Text = listViewJoppd.SelectedItems[0].SubItems[35].Text;


            }
            catch
            {
                MessageBox.Show("Učitajte popis");
            }
        }

        private void btnIzmjeni_Click(object sender, EventArgs e)
        {
            string odabranoIme = txtOdabrani.Text;
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "update database.joppd set 6_1='" + comboBox61.Text + "',6_2='" + comboBox62.Text + "',7_1='" + comboBox71.Text +
                          "',7_2='" + comboBox72.Text + "',joppd.8='" + comboBox8.Text + "',joppd.9='" + comboBox9.Text +
                          "',joppd.10='" + txtSatiRada.Text + "',10_0='" + txtSatiNerad.Text + "',10_1='" + maskOd.Text + "',10_2='" + maskDo.Text +
                          "',12_6='" + txt126.Text + "',12_7='" + txt127.Text + "',12_8='" + txt128.Text +
                          "',12_9='" + txt129.Text + "',13_1='" + txt131.Text + "',15_1='" + combo151.Text + "',16_1='" + combo161.Text +
                          "' where ime='" + odabranoIme + "';";

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
                popunilistuJoppd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtOdabrani.Text == "")
            {
                var today = DateTime.Today;
                var month = new DateTime(today.Year, today.Month, 1);
                var first = month.AddMonths(-1);
                var last = month.AddDays(-1);
                string prvi = first.ToString("yyyy-MM-dd");
                string zadnji = last.ToString("yyyy-MM-dd");

                string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                string upit = "update database.placa join database.joppd on placa.idDjelatnika=joppd.idZaposlenika set " +
                              "joppd.ime=placa.ime_prezime, joppd.11=placa.bruto, joppd.12=placa.bruto, " +
                              "joppd.12_1=placa.mio1, joppd.12_2=placa.mio2, joppd.12_3=placa.dopzdravstveno, joppd.12_4=placa.dopzastita, " +
                              "joppd.12_5=placa.dopzaposljavanje, joppd.13_2=placa.mioukupno, joppd.13_3=placa.dohodak, joppd.13_4=placa.odbitak, " +
                              "joppd.13_5=placa.porosn, joppd.14_1=placa.porezukupno, joppd.14_2=placa.prirez, joppd.15_2=placa.prijevoz, " +
                              "joppd.16_2=placa.zaisplatu, joppd.17=placa.bruto, joppd.poslodavac=placa.podplaca;" +
                              "update database.djelatnici join database.joppd on djelatnici.idDjelatnika=joppd.idZaposlenika set joppd.4=djelatnici.OIB, " +
                              "joppd.2=djelatnici.mjesto_sifrajoppd ;" +
                              "update database.joppd inner join database.firma set joppd.3=firma.sifra_joppd where joppd.idZaposlenika<>'';" +
                              "update database.joppd set 10_1='" + prvi + "',10_2='" + zadnji + "',6_1='0001' ,6_2='0001',7_1='0', 7_2='0', " +
                              "joppd.8='3', joppd.9='1', joppd.10='176', 12_6='0.00', 12_7='0.00', 12_8='0.00', 12_9='0.00', 13_1='0.00', " +
                              "15_1='19', 16_1='1' where joppd.idZaposlenika<>'';";
                MySqlConnection bazaspoj = new MySqlConnection(constring);
                MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
                MySqlDataReader citaj;
                try
                {
                    bazaspoj.Open();
                    citaj = bazazapovjed.ExecuteReader();
                    while (citaj.Read())
                    {

                    }
                    bazaspoj.Close();
                    maskOd.Text = first.ToString("yyyy-MM-dd");
                    maskDo.Text = last.ToString("yyyy-MM-dd");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                listViewJoppd.Clear();
                popunilistuJoppd();
            }

        }
        string path;
        private void button1_Click_1(object sender, EventArgs e)
        {
            popuniStranicuA();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            int brojRedovaInt = dataGridView1.RowCount;
            string brojRedova = (brojRedovaInt - 1).ToString();
            int petnaest = 15000;
            int dayOfYear = DateTime.Now.DayOfYear;
            int danUgod = petnaest + dayOfYear;
            string upit;
            MySqlConnection bazaspoj;
            MySqlCommand bazazapovjed;
            MySqlDataReader citaj;

            upit = "select * from database.firma;";
            bazaspoj = new MySqlConnection(constring);
            bazazapovjed = new MySqlCommand(upit, bazaspoj);
            bazaspoj.Open();
            citaj = bazazapovjed.ExecuteReader();
            citaj.Read();
            string adresa = citaj.GetString("ulica");
            string mjesto = citaj.GetString("mjesto");
            string brojkucni = citaj.GetString("broj");
            bazaspoj.Close();

            string UUID = Guid.NewGuid().ToString();
            DateTime currTime = DateTime.Now;
            string date = currTime.ToString("s");
            string date2 = currTime.ToString("yyyy-MM-dd");
            SaveFileDialog savFile = new SaveFileDialog();
            savFile.Filter = "XML|*.xml";
            if (savFile.ShowDialog() == DialogResult.OK)
            {
                path = savFile.FileName;
                constring = "datasource=localhost;port=3306;username=root;password=pass123";
                upit = "select * from database.joppda;";
                bazaspoj = new MySqlConnection(constring);
                bazazapovjed = new MySqlCommand(upit, bazaspoj);

                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                citaj.Read();
                //-----------------------------------------------STRANICA A-----------------------------------------------------------                
                XNamespace ns = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1";
                XNamespace ns2 = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0";
                XNamespace ns3 = "";

                XDocument xDoc = new XDocument(

                            new XElement(ns + "ObrazacJOPPD",
                                new XAttribute("verzijaSheme", "1.1"),
                                new XElement(ns2 + "Metapodaci",
                                    new XElement(ns2 + "Naslov", "Izvješće o primicima, porezu na dohodak i prirezu te doprinosima za obvezna osiguranja",
                                        new XAttribute("dc", "http://purl.org/dc/elements/1.1/title")),
                                    new XElement(ns2 + "Autor", citaj["sastavioime"].ToString() + " " + citaj["sastavioprezime"].ToString(),
                                        new XAttribute("dc", "http://purl.org/dc/elements/1.1/creator")),
                                    new XElement(ns2 + "Datum", date,
                                        new XAttribute("dc", "http://purl.org/dc/elements/1.1/date")),
                                    new XElement(ns2 + "Format", "text/xml",
                                        new XAttribute("dc", "http://purl.org/dc/elements/1.1/format")),
                                    new XElement(ns2 + "Jezik", "hr-HR",
                                        new XAttribute("dc", "http://purl.org/dc/elements/1.1/language")),
                                    new XElement(ns2 + "Identifikator", UUID,
                                        new XAttribute("dc", "http://purl.org/dc/elements/1.1/identifier")),
                                    new XElement(ns2 + "Uskladjenost", "ObrazacJOPPD-v1-1",
                                        new XAttribute("dc", "http://purl.org/dc/terms/conformsTo")),
                                    new XElement(ns2 + "Tip", "Elektronički obrazac",
                                        new XAttribute("dc", "http://purl.org/dc/elements/1.1/type")),
                                    new XElement(ns2 + "Adresant", "Ministarstvo Financija, Porezna uprava, Zagreb")),
                                new XElement(ns + "StranaA",
                                    new XElement(ns + "DatumIzvjesca", citaj["datumizvj"].ToString()),
                                    new XElement(ns + "OznakaIzvjesca", citaj["danugodini"].ToString()),
                                    new XElement(ns + "VrstaIzvjesca", citaj["ii"].ToString()),
                                    new XElement(ns + "PodnositeljIzvjesca",
                                        new XElement(ns + "Naziv", citaj["iii_1"].ToString()),
                                        new XElement(ns + "Adresa",
                                            new XElement(ns + "Mjesto", mjesto),
                                            new XElement(ns + "Ulica", adresa),
                                            new XElement(ns + "Broj", brojkucni)),
                                        new XElement(ns + "Email", citaj["iii_3"].ToString()),
                                        new XElement(ns + "OIB", citaj["iii_4"].ToString()),
                                        new XElement(ns + "Oznaka", citaj["iii_5"].ToString())),
                                    new XElement(ns + "ObveznikPlacanja",
                                        new XElement(ns + "Naziv", citaj["iii_1"].ToString()),
                                        new XElement(ns + "Adresa",
                                            new XElement(ns + "Mjesto", mjesto),
                                            new XElement(ns + "Ulica", adresa),
                                            new XElement(ns + "Broj", brojkucni)),
                                        new XElement(ns + "Email", citaj["iii_3"].ToString()),
                                        new XElement(ns + "OIB", citaj["iii_4"].ToString())),
                                    new XElement(ns + "BrojOsoba", citaj["iv_1"].ToString()),
                                    new XElement(ns + "BrojRedaka", citaj["iv_2"].ToString()),
                                    new XElement(ns + "PredujamPoreza",
                                        new XElement(ns + "P1", citaj["v_1"].ToString()),
                                        new XElement(ns + "P11", citaj["v_1_1"].ToString()),
                                        new XElement(ns + "P12", citaj["v_1_2"].ToString()),
                                        new XElement(ns + "P2", citaj["v_2"].ToString()),
                                        new XElement(ns + "P3", citaj["v_3"].ToString()),
                                        new XElement(ns + "P4", citaj["v_4"].ToString()),
                                        new XElement(ns + "P5", citaj["v_5"].ToString()),
                                        new XElement(ns + "P6", citaj["v_6"].ToString())),
                                    new XElement(ns + "Doprinosi",
                                        new XElement(ns + "GeneracijskaSolidarnost",
                                            new XElement(ns + "P1", citaj["vi_1"].ToString()),
                                            new XElement(ns + "P2", citaj["vi_2"].ToString()),
                                            new XElement(ns + "P3", citaj["vi_3"].ToString()),
                                            new XElement(ns + "P4", citaj["vi_4"].ToString()),
                                            new XElement(ns + "P5", citaj["vi_5"].ToString()),
                                            new XElement(ns + "P6", citaj["vi_6"].ToString()),
                                            new XElement(ns + "P7", citaj["vi_7"].ToString())),
                                        new XElement(ns + "KapitaliziranaStednja",
                                            new XElement(ns + "P1", citaj["vi2_1"].ToString()),
                                            new XElement(ns + "P2", citaj["vi2_2"].ToString()),
                                            new XElement(ns + "P3", citaj["vi2_3"].ToString()),
                                            new XElement(ns + "P4", citaj["vi2_4"].ToString()),
                                            new XElement(ns + "P5", citaj["vi2_5"].ToString()),
                                            new XElement(ns + "P6", citaj["vi2_6"].ToString())),
                                        new XElement(ns + "ZdravstvenoOsiguranje",
                                            new XElement(ns + "P1", citaj["vi3_1"].ToString()),
                                            new XElement(ns + "P2", citaj["vi3_2"].ToString()),
                                            new XElement(ns + "P3", citaj["vi3_3"].ToString()),
                                            new XElement(ns + "P4", citaj["vi3_4"].ToString()),
                                            new XElement(ns + "P5", citaj["vi3_5"].ToString()),
                                            new XElement(ns + "P6", citaj["vi3_6"].ToString()),
                                            new XElement(ns + "P7", citaj["vi3_7"].ToString()),
                                            new XElement(ns + "P8", citaj["vi3_8"].ToString()),
                                            new XElement(ns + "P9", citaj["vi3_9"].ToString()),
                                            new XElement(ns + "P10", citaj["vi3_10"].ToString()),
                                            new XElement(ns + "P11", citaj["vi3_11"].ToString()),
                                            new XElement(ns + "P12", citaj["vi3_12"].ToString())),
                                        new XElement(ns + "Zaposljavanje",
                                            new XElement(ns + "P1", citaj["vi4_1"].ToString()),
                                            new XElement(ns + "P2", citaj["vi4_2"].ToString()),
                                            new XElement(ns + "P3", citaj["vi4_3"].ToString()))),
                                    new XElement(ns + "IsplaceniNeoporeziviPrimici", citaj["vii"].ToString()),
                                    new XElement(ns + "KamataMO2", citaj["viii"].ToString()),
                                    new XElement(ns + "UkupniNeoporeziviPrimici", citaj["ix"].ToString()),
                                    new XElement(ns + "NaknadaZaposljavanjeInvalida", 
                                        new XElement (ns + "P1", citaj["x_1"].ToString()),
                                        new XElement (ns + "P2", citaj["x_2"].ToString())),
                                    new XElement(ns + "IzvjesceSastavio",
                                        new XElement(ns + "Ime", citaj["sastavioime"].ToString()),
                                        new XElement(ns + "Prezime", citaj["sastavioprezime"].ToString()))),
                                new XElement(ns + "StranaB",
                                    new XElement(ns + "Primatelji", null
                                  ))));

                StringWriter sw = new StringWriter();
                XmlWriter xWrite = XmlWriter.Create(sw);
                //xDoc.Save(xWrite);
                //xWrite.Close();
                bazaspoj.Close();
                // Save to Disk
                xDoc.Save(path);
                //---------------------------------------------------------------STRANICA B--------------------------------------------------------
                constring = "datasource=localhost;port=3306;username=root;password=pass123";
                upit = "select * from database.joppd;";
                bazaspoj = new MySqlConnection(constring);
                bazazapovjed = new MySqlCommand(upit, bazaspoj);
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    XDocument doc = XDocument.Load(path);
                    doc.Element(ns + "ObrazacJOPPD").Element(ns + "StranaB").Element(ns + "Primatelji").Add(new XElement(ns + "P",
                                                        new XElement(ns + "P1", citaj["idZaposlenika"].ToString()),
                                                        new XElement(ns + "P2", citaj["2"].ToString()),
                                                        new XElement(ns + "P3", citaj["3"].ToString()),
                                                        new XElement(ns + "P4", citaj["4"].ToString()),
                                                        new XElement(ns + "P5", citaj["ime"].ToString()),
                                                        new XElement(ns + "P61", citaj["6_1"].ToString()),
                                                        new XElement(ns + "P62", citaj["6_2"].ToString()),
                                                        new XElement(ns + "P71", citaj["7_1"].ToString()),
                                                        new XElement(ns + "P72", citaj["7_2"].ToString()),
                                                        new XElement(ns + "P8", citaj["8"].ToString()),
                                                        new XElement(ns + "P9", citaj["9"].ToString()),
                                                        new XElement(ns + "P10", citaj["10"].ToString()),
                                                        new XElement(ns + "P100", citaj["10_0"].ToString()),
                                                        new XElement(ns + "P101", citaj["10_1"].ToString()),
                                                        new XElement(ns + "P102", citaj["10_2"].ToString()),
                                                        new XElement(ns + "P11", citaj["11"].ToString()),
                                                        new XElement(ns + "P12", citaj["12"].ToString()),
                                                        new XElement(ns + "P121", citaj["12_1"].ToString()),
                                                        new XElement(ns + "P122", citaj["12_2"].ToString()),
                                                        new XElement(ns + "P123", citaj["12_3"].ToString()),
                                                        new XElement(ns + "P124", citaj["12_4"].ToString()),
                                                        new XElement(ns + "P125", citaj["12_5"].ToString()),
                                                        new XElement(ns + "P126", citaj["12_6"].ToString()),
                                                        new XElement(ns + "P127", citaj["12_7"].ToString()),
                                                        new XElement(ns + "P128", citaj["12_8"].ToString()),
                                                        new XElement(ns + "P129", citaj["12_9"].ToString()),
                                                        new XElement(ns + "P131", citaj["13_1"].ToString()),
                                                        new XElement(ns + "P132", citaj["13_2"].ToString()),
                                                        new XElement(ns + "P133", citaj["13_3"].ToString()),
                                                        new XElement(ns + "P134", citaj["13_4"].ToString()),
                                                        new XElement(ns + "P135", citaj["13_5"].ToString()),
                                                        new XElement(ns + "P141", citaj["14_1"].ToString()),
                                                        new XElement(ns + "P142", citaj["14_2"].ToString()),
                                                        new XElement(ns + "P151", citaj["15_1"].ToString()),
                                                        new XElement(ns + "P152", citaj["15_2"].ToString()),
                                                        new XElement(ns + "P161", citaj["16_1"].ToString()),
                                                        new XElement(ns + "P162", citaj["16_2"].ToString()),
                                                        new XElement(ns + "P17", citaj["17"].ToString())));

                    doc.Save(path);

                }
                bazaspoj.Close();
            }
            if (path != null)
            {
                XmlDocument doc1 = new XmlDocument();
                doc1.Load(path);
                var declarations = doc1.ChildNodes.OfType<XmlNode>().Where(x => x.NodeType == XmlNodeType.XmlDeclaration).ToList();
                declarations.ForEach(x => doc1.RemoveChild(x));


                doc1.Save(path);
            }

        }

        private void btnZbroj_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "delete from database.JOPPD where ime='" + txtOdabrani.Text + "';";
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
            popunilistuJoppd();
        }

        private void btnJoppdAprint_Click(object sender, EventArgs e)
        {
            JOPPD_A_REPORT joppda = new JOPPD_A_REPORT();
            joppda.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            JOPPD_B_REPORT joppdb = new JOPPD_B_REPORT();
            joppdb.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            popuniStranicuA();
            DateTime currTime = System.DateTime.Now;
            string date2 = currTime.ToString("yyyy-MM-dd");
            int brojRedovaInt = dataGridView1.RowCount;
            string brojRedova = (brojRedovaInt - 1).ToString();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string godina = date2.Substring(2, 2);
            godina = godina + "000";
            int petnaest = Convert.ToInt32(godina);
            int dayOfYear = DateTime.Now.DayOfYear;
            int danUgod = petnaest + dayOfYear;
            string upit = "update database.joppda join database.firma on joppda.id=firma.idFirme set v_1='" + txtUkPorezPrirez.Text + "',v_1_1='" + txtUkPorezPrirez.Text +
                          "',vi_1='" + txtUkMio1.Text + "' ,vi_2='0.00',vi_3='" + txtMioPod.Text + "' ,vi2_1='" + txtUkMio2.Text +
                          "',vi3_1='" + txtZdravRad.Text + "' ,vi3_2='" + txtZastRad.Text + "' ,vi3_3='" + txtZdravPod.Text +
                          "',vi3_4='" + txtZastPod.Text + "' ,vi4_1='" + txtDopZap.Text + "',vi4_2='0.00' ,vi4_3='" + txtDopZapPod.Text +
                          "',vii='" + txtUkNeop.Text + "' ,danugodini='" + danUgod + "',iv_1='" + brojRedova + "',iv_2='" + brojRedova +
                          "',ii='1',datumizvj='" + date2 + "', x_1='0'  where joppda.id=firma.idFirme;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {

                }
                MessageBox.Show("Stranica A popunjena");
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIzmjeniA_Click(object sender, EventArgs e)
        {
            A_strana astrana = new A_strana();
            astrana.ShowDialog();
        }

    }
}
