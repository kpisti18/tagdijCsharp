using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Kovacs_Istvan_01_console
{
    internal class Database
    {
        MySqlConnection con = null;
        MySqlCommand sqlCmd = null;

        public Database()
        {
            try
            {
                MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
                sb.Clear();
                sb.Server = "localhost";
                sb.UserID = "root";
                sb.Password = "";
                sb.Database = "tagdij";

                con = new MySqlConnection(sb.ConnectionString);
                con.Open();
                sqlCmd = con.CreateCommand();
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Az alábbi hiba lépett fel: {ex.Message}");
            }
        }
        public List<Befizetes> getBefizetes()
        {
            List<Befizetes> befizetesek = new List<Befizetes>();
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                    sqlCmd.CommandText = "SELECT * FROM befiz";
                    using (MySqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Befizetes ujBefizetes = new Befizetes(dr.GetInt32("azon"), dr.GetDateTime("datum"), dr.GetInt32("osszeg"));

                            befizetesek.Add(ujBefizetes);
                        }
                    }
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Az alábbi hiba lépett fel: {ex.Message}");
                }
            }
            return befizetesek;
        }

        public List<Ugyfel> getUgyfel()
        {
            List<Ugyfel> ugyfelek = new List<Ugyfel>();
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                    sqlCmd.CommandText = "SELECT * FROM ugyfel";
                    using (MySqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Ugyfel ujUgyfel = new Ugyfel(dr.GetInt32("azon"), dr.GetString("nev"), dr.GetInt32("szulev"), dr.GetString("irszam"), dr.GetString("orsz"));

                            ugyfelek.Add(ujUgyfel);
                        }
                    }
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Az alábbi hiba lépett fel: {ex.Message}");
                }
            }
            return ugyfelek;
        }

        public void insertBefizetes(int befizAzon, int osszeg)
        {
            sqlCmd.CommandText = $"INSERT INTO befiz(azon, datum, osszeg) VALUES ('{befizAzon.ToString()}', '{DateTime.Now.ToString("yyyy.MM.dd")}', '{osszeg.ToString()}')";

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    int affectedRows = sqlCmd.ExecuteNonQuery();
                    if (affectedRows == 1)
                    {
                        MessageBox.Show("Sikeres felvétel!");
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen felvétel!");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Az alábbi hiba lépett fel: {ex.Message}");
            }
        }
    }
}
