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
    class DodatnaUslugaDatabase
    {
        public static void popunjavanjeDodatneUsluge()
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {

                connection.Open();
                DataSet dataset = new DataSet();


                SqlCommand komanda = connection.CreateCommand();
                komanda.CommandText = @"SELECT * FROM DodatnaUsluga";


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(dataset, "DodatnaUsluga");

                foreach (DataRow red in dataset.Tables["DodatnaUsluga"].Rows)
                {
                    DodatnaUsluga k = new DodatnaUsluga();
                    k.Id = (int)red["Id"];
                    k.Naziv = (string)red["Naziv"];
                    k.Cena = (int)red["Cena"];
                    k.Obrisan = (bool)red["Obrisan"];

                    RadSaPodacima.Instance.DodatnaUsluga.Add(k);
                }
            }
        }
        public static void DodatnaUslugaDodaj(DodatnaUsluga k)
        {
            using (SqlConnection conn = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO DodatnaUsluga (Id, Naziv, Cena, Obrisan) 
                                        VALUES (@Id, @Naziv, @Cena, @Obrisan)";
                command.Parameters.Add(new SqlParameter("@Id", k.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", k.Naziv));
                command.Parameters.Add(new SqlParameter("@Cena", k.Cena));
                command.Parameters.Add(new SqlParameter("@Obrisan", k.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void DodatnaUslugaIzmeni(DodatnaUsluga k)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE DodatnaUsluga 
                                        SET Id=@Id, Naziv=@Naziv, Cena=@Cena, Obrisan=@Obrisan WHERE Id=@Id";
                command.Parameters.Add(new SqlParameter("@Id", k.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", k.Naziv));
                command.Parameters.Add(new SqlParameter("@Cena", k.Cena));
                command.Parameters.Add(new SqlParameter("@Obrisan", k.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void DodatnaUslugaIzbrisi(DodatnaUsluga k)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE DodatnaUsluga SET Obrisan=@Obrisan WHERE Id=@Id";

                command.Parameters.Add(new SqlParameter("@Id", k.Id));
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
                command.CommandText = @"DELETE FROM DodatnaUsluga";

                command.ExecuteNonQuery();
            }
        }
    }
}
