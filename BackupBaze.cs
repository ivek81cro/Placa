﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Projekt_Placa
{
    class BackupBaze
    {
        string path;
        public void Backup()
        {
            string constring = "server=localhost;user=root;pwd=pass123;database=database;";
            SaveFileDialog spremiBackup = new SaveFileDialog();
            spremiBackup.Filter = "SQL|*.sql";
            spremiBackup.FileName = "Database_tim.sql";
            if (spremiBackup.ShowDialog() == DialogResult.OK)
            {
                path = spremiBackup.FileName;
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(path);
                            conn.Close();
                            MessageBox.Show("Backup izvrsen.");
                        }
                    }
                }
            }           
        }

        public void Restore()
        {
            string constring = "server=localhost;user=root;pwd=pass123;database=database;";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "SQL|*.sql";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                path = openFile.FileName;
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(path);
                            conn.Close();
                            MessageBox.Show("Povrat baze izvršen.");
                        }
                    }
                }
            }            
        }
    }
}
