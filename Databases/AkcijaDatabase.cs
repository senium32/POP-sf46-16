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
    class AkcijaDatabase
    {
        public static void popunjavanjeAkcija()
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {

                connection.Open();
                DataSet dataset = new DataSet();


                SqlCommand komanda = connection.CreateCommand();
                komanda.CommandText = @"SELECT * FROM Akcija";


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(dataset, "Akcija");

                foreach (DataRow red in dataset.Tables["Akcija"].Rows)
                {
                    Akcija k = new Akcija();
                    k.Id = (int)red["Id"];
                    k.Naziv = (string)red["Naziv"];
                    k.Datum_Pocetka = (DateTime)red["DatumPocetka"];
                    k.Datum_Zavrsetka = (DateTime)red["DatumZavrsetka"];
                    k.Popust = (int)red["Popust"];
                    k.Obrisan = (bool)red["Obrisan"];

                    RadSaPodacima.Instance.Akcije.Add(k);
                }
            }
        }
        public static void AkcijaDodaj(Akcija k)
        {
            using (SqlConnection conn = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Akcija (Id, Naziv, DatumPocetka, DatumZavrsetka,Popust, Obrisan) 
                                        VALUES (@Id, @Naziv, @DatumPocetka, @DatumZavrsetka, @Popust, @Obrisan)";
                command.Parameters.Add(new SqlParameter("@Id", k.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", k.Naziv));
                command.Parameters.Add(new SqlParameter("@DatumPocetka", k.Datum_Pocetka));
                command.Parameters.Add(new SqlParameter("@DatumZavrsetka", k.Datum_Zavrsetka));
                command.Parameters.Add(new SqlParameter("@Popust", k.Popust));
                command.Parameters.Add(new SqlParameter("@Obrisan", k.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void AkcijaIzmeni(Akcija k)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE Akcija 
                                        SET Id=@Id, Naziv=@Naziv, DatumPocetka=@DatumPocetka, DatumZavrsetka=@DatumZavrsetka, Popust=@Popust, Obrisan=@Obrisan WHERE Id=@Id";
                command.Parameters.Add(new SqlParameter("@Id", k.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", k.Naziv));
                command.Parameters.Add(new SqlParameter("@DatumPocetka", k.Datum_Pocetka));
                command.Parameters.Add(new SqlParameter("@DatumZavrsetka", k.Datum_Zavrsetka));
                command.Parameters.Add(new SqlParameter("@Popust", k.Popust));
                command.Parameters.Add(new SqlParameter("@Obrisan", k.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void AkcijaIzbrisi(Akcija k)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE Akcija SET Obrisan=@Obrisan WHERE Id=@Id";

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
                command.CommandText = @"DELETE FROM Akcija";

                command.ExecuteNonQuery();
            }
        }
    }
}
