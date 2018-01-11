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
    class ProdajaNamestajaDatabase
    {
        public static void popunjavanjeProdaja()
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {

                connection.Open();
                DataSet dataset = new DataSet();


                SqlCommand komanda = connection.CreateCommand();
                komanda.CommandText = @"SELECT * FROM ProdajaNamestaja";


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(dataset, "ProdajaNamestaja");

                foreach (DataRow red in dataset.Tables["ProdajaNamestaja"].Rows)
                {
                    ProdajaNamestaja k = new ProdajaNamestaja();
                    k.Broj_Racuna = (int)red["Broj_Racuna"];
                    k.Broj_Komada_Namestaja = (int)red["Broj_Komada_Namestaja"];
                    k.Kupac = (string)red["Kupac"];
                    k.Datum_Prodaje = (DateTime)red["Datum_Prodaje"];
                    k.NamestajId = (int)red["NamestajId"];
                    k.Obrisan = (bool)red["Obrisan"];

                    RadSaPodacima.Instance.ProdajaNamestaja.Add(k);
                }
            }
        }
        public static void ProdajaDodaj(ProdajaNamestaja k)
        {
            using (SqlConnection conn = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO ProdajaNamestaja (Broj_Racuna, Broj_Komada_Namestaja, Kupac, Datum_Prodaje, NamestajId, Obrisan) 
                                        VALUES (@Broj_Racuna, @Broj_Komada_Namestaja, @Kupac, @Datum_Prodaje, @NamestajId, @Obrisan)";
                command.Parameters.Add(new SqlParameter("@Broj_Racuna", k.Broj_Racuna));
                command.Parameters.Add(new SqlParameter("@Broj_Komada_Namestaja", k.Broj_Komada_Namestaja));
                command.Parameters.Add(new SqlParameter("@Kupac", k.Kupac));
                command.Parameters.Add(new SqlParameter("@Datum_Prodaje", k.Datum_Prodaje));
                command.Parameters.Add(new SqlParameter("@NamestajId", k.NamestajId));
                command.Parameters.Add(new SqlParameter("@Obrisan", k.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        
        public static void ProdajaIzbrisi(ProdajaNamestaja k)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE ProdajaNamestaja SET Obrisan=@Obrisan WHERE Broj_Racuna=@Broj_Racuna";

                command.Parameters.Add(new SqlParameter("@Broj_Racuna", k.Broj_Racuna));
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
                command.CommandText = @"DELETE FROM ProdajaNamestaja";

                command.ExecuteNonQuery();
            }
        }
    }
}
