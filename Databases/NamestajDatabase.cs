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
    class NamestajDatabase
    {
        public static void popunjavanjeNamestaja()
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();
                DataSet dataset = new DataSet();

                SqlCommand namestajCommand = connection.CreateCommand();
                namestajCommand.CommandText = @"SELECT * FROM Namestaj";

                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = namestajCommand;
                sqlda.Fill(dataset, "Namestaj");

                foreach (DataRow row in dataset.Tables["Namestaj"].Rows)
                {
                    Namestaj n = new Namestaj();
                    n.Id = (int)row["Id"];
                    n.Naziv = (string)row["Naziv"];
                    n.Cena = (int)row["Cena"];
                    n.Kolicina = (int)row["Kolicina"];
                    n.NaStanju = (bool)row["NaStanju"];
                    n.AkcijskaCenaId = (int)row["AkcijskaCenaId"];
                    n.Tip_Namestaja = (int)row["TipNamestajaiD"];
                    n.TipNamestaja = TipNamestaja.GetById(n.Tip_Namestaja);

                    try
                    {
                        n.NaPopustu = Akcija.GetById(n.AkcijskaCenaId);
                    }
                    catch (Exception) { }

                    RadSaPodacima.Instance.Namestaj.Add(n);
                }
            }
        }

        public static void NamestajDodaj(Namestaj n)
        {
            using (SqlConnection conn = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Namestaj (Id, Naziv, Cena, Kolicina, TipNamestajaid, AkcijskaCenaId, NaStanju) 
                                        VALUES (@Id, @Naziv, @Cena, @Kolicina, @TipNamestajaid, @AkcijskaCenaId, @NaStanju)";

                command.Parameters.Add(new SqlParameter("@Id", n.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", n.Naziv));
                command.Parameters.Add(new SqlParameter("@Cena", n.Cena));
                command.Parameters.Add(new SqlParameter("@Kolicina", n.Kolicina));
                command.Parameters.Add(new SqlParameter("@TipNamestajaid", n.Tip_Namestaja));
                command.Parameters.Add(new SqlParameter("@AkcijskaCenaId", n.AkcijskaCenaId));
                command.Parameters.Add(new SqlParameter("@NaStanju", n.NaStanju));

                command.ExecuteNonQuery();
            }
        }

        public static void NamestajIzmeni(Namestaj n)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE Namestaj 
                                        SET Naziv=@Naziv, Cena=@Cena, Kolicina=@Kolicina, 
                                        TipNamestajaid=@TipNamestajaid, AkcijskaCenaId=@AkcijskaCenaId, NaStanju=@NaStanju WHERE Id=@Id";

                command.Parameters.Add(new SqlParameter("@Id", n.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", n.Naziv));
                command.Parameters.Add(new SqlParameter("@Cena", n.Cena));
                command.Parameters.Add(new SqlParameter("@Kolicina", n.Kolicina));
                command.Parameters.Add(new SqlParameter("@TipNamestajaid", n.Tip_Namestaja));
                command.Parameters.Add(new SqlParameter("@AkcijskaCenaId", n.AkcijskaCenaId));
                command.Parameters.Add(new SqlParameter("@NaStanju", n.NaStanju));

                command.ExecuteNonQuery();
            }
        }

        public static void NamestajIzbrisi(Namestaj n)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE Namestaj SET NaStanju=@NaStanju WHERE Id=@Id";

                command.Parameters.Add(new SqlParameter("@Id", n.Id));
                command.Parameters.Add(new SqlParameter("@NaStanju", 1));

                command.ExecuteNonQuery();
            }
        }

        public static void NamestajIzbrisiByTip(TipNamestaja tn)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE Namestaj SET NaStanju=@NaStanju WHERE TipNamestajaid=@TipNamestajaid";

                command.Parameters.Add(new SqlParameter("@TipNamestajaid", tn.Id));
                command.Parameters.Add(new SqlParameter("@NaStanju", 1));

                command.ExecuteNonQuery();
            }
        }

        public static void ClearTable()
        {
            using (SqlConnection conn = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"DELETE FROM Namestaj";

                command.ExecuteNonQuery();
            }
        }
    }
}
