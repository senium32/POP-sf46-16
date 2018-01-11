using POP_sf46_16_GUI.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_sf46_16_GUI.Databases
{
    class KorisnikDatabase
    {
        public static void popunjavanjeKorisnika()
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {

                connection.Open();
                DataSet dataset = new DataSet();


                SqlCommand komanda = connection.CreateCommand();
                komanda.CommandText = @"SELECT * FROM Korisnik";


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(dataset, "Korisnik");

                foreach (DataRow red in dataset.Tables["Korisnik"].Rows)
                {
                    Korisnik k = new Korisnik();
                    k.Ime = (string)red["Ime"];
                    k.Prezime = (string)red["Prezime"];
                    k.Username = (string)red["Username"];
                    k.Password = (string)red["Password"];
                    k.Obrisan = (bool)red["Obrisan"];
                    k.Tip_Korisnika = (string)red["TipKorisnika"];

                    RadSaPodacima.Instance.Korisnici.Add(k);
                }
            }
        }
        public static void KorisnikDodaj(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Korisnik (Ime, Prezime, Username, Password, Obrisan, TipKorisnika) 
                                        VALUES (@Ime, @Prezime, @Username, @Password, @Obrisan, @TipKorisnika)";
                command.Parameters.Add(new SqlParameter("@Ime", k.Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", k.Prezime));
                command.Parameters.Add(new SqlParameter("@Username", k.Username));
                command.Parameters.Add(new SqlParameter("@Password", k.Password));
                command.Parameters.Add(new SqlParameter("@Obrisan", k.Obrisan));
                command.Parameters.Add(new SqlParameter("@TipKorisnika", k.Tip_Korisnika));

                command.ExecuteNonQuery();
            }
        }

        public static void KorisnikIzmeni(Korisnik k)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE Korisnik 
                                        SET Ime=@Ime, Prezime=@Prezime, Username=@Username, Password=@Password, 
                                            Obrisan=@Obrisan, TipKorisnika=@TipKorisnika WHERE Username=@Username";
                command.Parameters.Add(new SqlParameter("@Ime", k.Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", k.Prezime));
                command.Parameters.Add(new SqlParameter("@Username", k.Username));
                command.Parameters.Add(new SqlParameter("@Password", k.Password));
                command.Parameters.Add(new SqlParameter("@Obrisan", k.Obrisan));
                command.Parameters.Add(new SqlParameter("@TipKorisnika", k.Tip_Korisnika));

                command.ExecuteNonQuery();
            }
        }

        public static void KorisnikIzbrisi(Korisnik k)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE Korisnik SET Obrisan=@Obrisan WHERE Username=@Username";

                command.Parameters.Add(new SqlParameter("@Username", k.Username));
                command.Parameters.Add(new SqlParameter("@Obrisan", 1));

                command.ExecuteNonQuery();
            }
        }

        public static void ClearTable()
        {
            using (SqlConnection conn = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"DELETE FROM Korisnik";

                command.ExecuteNonQuery();
            }
        }
    }
}
