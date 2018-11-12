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

namespace Projekt_Placa
{
    public partial class A_strana : Form
    {
        public A_strana()
        {
            InitializeComponent();
        }

        private void A_strana_Load(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.joppda;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    txtDatum.Text = citaj.GetString("datumizvj");
                    txtOznaka.Text = citaj.GetString("danugodini");
                    txtVrsta.Text = citaj.GetString("ii");
                    txtNaziv.Text = citaj.GetString("iii_1");
                    txtAdresa.Text = citaj.GetString("iii_2");
                    txtEmail.Text = citaj.GetString("iii_3");
                    txtOib.Text = citaj.GetString("iii_4");
                    txtOznPodnositelja.Text = citaj.GetString("iii_5");
                    txtBrojOsoba.Text = citaj.GetString("iv_1");
                    txtBrojRedaka.Text = citaj.GetString("iv_2");
                    v_1TextBox.Text = citaj.GetString("v_1");
                    v_1_1TextBox.Text = citaj.GetString("v_1_1");
                    v_1_2TextBox.Text = citaj.GetString("v_1_2");
                    v_2TextBox.Text = citaj.GetString("v_2");
                    v_3TextBox.Text = citaj.GetString("v_3");
                    v_4TextBox.Text = citaj.GetString("v_4");
                    v_5TextBox.Text = citaj.GetString("v_5");
                    v_6TextBox.Text = citaj.GetString("v_6");
                    vi_1TextBox.Text = citaj.GetString("vi_1");
                    vi_2TextBox.Text = citaj.GetString("vi_2");
                    vi_3TextBox.Text = citaj.GetString("vi_3");
                    vi_4TextBox.Text = citaj.GetString("vi_4");
                    vi_5TextBox.Text = citaj.GetString("vi_5");
                    vi_6TextBox.Text = citaj.GetString("vi_6");
                    vi_7TextBox.Text = citaj.GetString("vi_7");
                    vi2_1TextBox.Text = citaj.GetString("vi2_1");
                    vi2_2TextBox.Text = citaj.GetString("vi2_2");
                    vi2_3TextBox.Text = citaj.GetString("vi2_3");
                    vi2_4TextBox.Text = citaj.GetString("vi2_4");
                    vi2_5TextBox.Text = citaj.GetString("vi2_5");
                    vi2_6TextBox.Text = citaj.GetString("vi2_6");
                    vi3_1TextBox.Text = citaj.GetString("vi3_1");
                    vi3_2TextBox.Text = citaj.GetString("vi3_2");
                    vi3_3TextBox.Text = citaj.GetString("vi3_3");
                    vi3_4TextBox.Text = citaj.GetString("vi3_4");
                    vi3_5TextBox.Text = citaj.GetString("vi3_5");
                    vi3_6TextBox.Text = citaj.GetString("vi3_6");
                    vi3_7TextBox.Text = citaj.GetString("vi3_7");
                    vi3_8TextBox.Text = citaj.GetString("vi3_8");
                    vi3_9TextBox.Text = citaj.GetString("vi3_9");
                    vi3_10TextBox.Text = citaj.GetString("vi3_10");
                    vi3_11TextBox.Text = citaj.GetString("vi3_11");
                    vi3_12TextBox.Text = citaj.GetString("vi3_12");
                    vi4_1TextBox.Text = citaj.GetString("vi4_1");
                    vi4_2TextBox.Text = citaj.GetString("vi4_2");
                    vi4_3TextBox.Text = citaj.GetString("vi4_3");
                    viiTextBox.Text = citaj.GetString("vii");
                    viiiTextBox.Text = citaj.GetString("viii");
                    sastavioimeTextBox.Text = citaj.GetString("sastavioime");
                    sastavioprezimeTextBox.Text = citaj.GetString("sastavioprezime");

                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnIzmjeni_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "update database.joppda join database.firma on joppda.id=firma.idFirme set datumizvj='" + txtDatum.Text + "',danugodini='" + txtOznaka.Text + 
                "',ii='" + txtVrsta.Text + "',iii_1='" + txtNaziv.Text + "',iii_2='" + txtAdresa.Text + "',iii_3='" + txtEmail.Text + 
                "',iii_4='" + txtOib.Text + "',iii_5='" + txtOznPodnositelja.Text + "',iv_1='" + txtBrojOsoba.Text + "',iv_2='" + txtBrojRedaka.Text +
                "',v_1='" + v_1TextBox.Text + "',v_1_1='" + v_1_1TextBox.Text + "',v_1_2='" + v_1_2TextBox.Text +
                "',v_2='" + v_2TextBox.Text + "',v_3='" + v_3TextBox.Text + "',v_4='" + v_4TextBox.Text + "',v_5='" + v_5TextBox.Text + "',v_6='" + v_6TextBox.Text +
                "',vi_1='" + vi_1TextBox.Text + "',vi_2='" + vi_2TextBox.Text + "',vi_3='" + vi_3TextBox.Text + "',vi_4='" + vi_4TextBox.Text +
                "',vi_5='" + vi_5TextBox.Text + "',vi_6='" + vi_6TextBox.Text + "',vi_7='" + vi_7TextBox.Text + "',vi2_1='" + vi2_1TextBox.Text + "',vi2_2='" + vi2_2TextBox.Text +
                "',vi2_3='" + vi2_3TextBox.Text + "',vi2_4='" + vi2_4TextBox.Text + "',vi2_5='" + vi2_5TextBox.Text + "',vi2_6='" + vi2_6TextBox.Text +
                "',vi3_1='" + vi3_1TextBox.Text + "',vi3_2='" + vi3_2TextBox.Text + "',vi3_3='" + vi3_3TextBox.Text + 
                "',vi3_4='" + vi3_4TextBox.Text + "',vi3_5='" + vi3_5TextBox.Text + "',vi3_6='" + vi3_6TextBox.Text + 
                "',vi3_7='" + vi3_7TextBox.Text + "',vi3_8='" + vi3_8TextBox.Text + "',vi3_9='" + vi3_9TextBox.Text +
                "',vi3_10='" + vi3_10TextBox.Text + "',vi3_11='" + vi3_11TextBox.Text + "',vi3_12='" + vi3_12TextBox.Text + "',vi4_1='" + vi4_1TextBox.Text + "',vi4_2='" + vi4_2TextBox.Text + 
                "',vi4_3='" + vi4_3TextBox.Text + "',vii='" + viiTextBox.Text + "',viii='" + viiiTextBox.Text + 
                "',sastavioime='" + sastavioimeTextBox.Text + "',sastavioprezime='" + sastavioprezimeTextBox.Text + "' where joppda.id=firma.idFirme ;";

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
        }
    }
}
