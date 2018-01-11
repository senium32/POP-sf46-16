using POP_sf46_16.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// by master player Senium
/// </summary>
namespace POP_sf46_16
{
    class Program
    {

        //public static List<TipNamestaja> tip_namestaja = new List<TipNamestaja>();
        //public static List<Namestaj> namestaj = new List<Namestaj>();
        public static List<Korisnik> korisnici = new List<Korisnik>();
        //public static List<Akcija> akcije = new List<Akcija>();
        static void Main(string[] args)
        {
            //var tn1 = new TipNamestaja
            //{
            //    Id = 1,
            //    Naziv = "krevet",
            //    Obrisan = false
            //};
            //var k1 = new Korisnik
            //{
            //    Ime = "Ben",
            //    Prezime = "Dover",
            //    Username = "Gachimuchi",
            //    Password = "billybogotac",
            //    Tip_Korisnika = "Lud"


            //};
            //var k2 = new Korisnik
            //{
            //    Ime = "Orange",
            //    Prezime = "Black",
            //    Username = "T H I C C",
            //    Password = "extra thicc",
            //    Tip_Korisnika = "Niza klasa"


            //};
            var s1 = new Salon
            {
                Id = 1,
                Naziv = "ayy lmao",
                Adresa = "Lenke Dundjerski 32a",
                BrojZiroRacuna = "30213941",
                Email = "ritopls@nesto.com",
                PIB = 3,
                MaticniBroj = 2013124,
                Telefon = "021/461-018",
                Websajt = "nema"

            };
            //var tn2 = new TipNamestaja
            //{
            //    Id = 2,
            //    Naziv = "plakar",
            //    Obrisan = false
            //};
            //var tn3 = new TipNamestaja
            //{
            //    Id = 3,
            //    Naziv = "fotelja",
            //    Obrisan = false
            //};
            //var n1 = new Namestaj
            //{
            //    Id = 1,
            //    Cena = 99.99,
            //    Naziv = "DM krevet",
            //    Kolicina = 12,
            //    Tip_Namestaja = 1
            //};
            //var n2 = new Namestaj
            //{
            //    Id = 2,
            //    Cena = 69.99,
            //    Naziv = "Plakar od iverice",
            //    Kolicina = 4,
            //    Tip_Namestaja = 2
            //};
            //var n3 = new Namestaj
            //{
            //    Id = 3,
            //    Cena = 420.00,
            //    Naziv = "Narkotelja",
            //    Kolicina = 15,
            //    Tip_Namestaja = 3
            //};

            //tip_namestaja.Add(tn1);
            //tip_namestaja.Add(tn2);
            //tip_namestaja.Add(tn3);

            //namestaj.Add(n1);
            //namestaj.Add(n2);
            //namestaj.Add(n3);

            //korisnici.Add(k1);
            //korisnici.Add(k2);
            //var ak1 = new Akcija {
            //    Datum_Pocetka = new DateTime(2017, 10, 9),
            //    Datum_Zavrsetka = new DateTime(2017, 10, 16),
            //    Id = 1,
            //    Popust = 10.99m
            //};
            //akcije.Add(ak1);
            //RadSaPodacima.Instance.akcije = akcije;

            //RadSaPodacima.Instance.tipovi_Namestaja = tip_namestaja;
            //RadSaPodacima.Instance.korisnici = korisnici;
            //RadSaPodacima.Instance.namestaji = namestaj;
            Console.WriteLine("  .::Dobrodosli u  " + s1.Naziv + "::.");
            LogIn();

        }

        private static void Meni()
        {
            Console.WriteLine("  ");
            Console.WriteLine("  Izaberite jednu od sledecih opcija:");
            Console.WriteLine("  1 - Rad sa namestajem");
            Console.WriteLine("  2 - Rad sa korisnicima");

            int izbor = 0;
            try
            {
                do
                {
                    string str_izbor = Console.ReadLine();
                    izbor = int.Parse(str_izbor);

                }
                while (izbor < 1 || izbor > 2);
                switch (izbor) {

                    case 1:
                        Console.WriteLine("  Izabrali ste rad sa namestajem");
                        GlavniMeni();
                        break;
                    case 2:
                        Console.WriteLine("  Izabrali ste rad sa korisnicima");
                        GlavniMeni2();
                        break;

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("  Samo broj ffs");
                Meni();
            }
        }

        private static void GlavniMeni()
        {
            ///            funkcija za ispis menija i pozivanje odgovarajuce funkcije
            Console.WriteLine("  ");
            Console.WriteLine("  Izaberite jednu od sledecih opcija:");
            Console.WriteLine("  1 - Prikaz namestaja na stanju");
            Console.WriteLine("  2 - Dodavanje novog namsetaja");
            Console.WriteLine("  3 - Izmena postojeceg namestaja");
            Console.WriteLine("  4 - brisanje namestaja");
            Console.WriteLine("  5 - povratak na izbor menija");
            Console.WriteLine("  6 - izlaz iz aplikacije");
            Provera_Unosa();


        }

        private static void GlavniMeni2()
        {
            ///            funkcija za ispis menija i pozivanje odgovarajuce funkcije
            Console.WriteLine("  ");
            Console.WriteLine("  Izaberite jednu od sledecih opcija:");
            Console.WriteLine("  1 - Prikaz svih korisnika");
            Console.WriteLine("  2 - Dodavanje novog korisnika");
            Console.WriteLine("  3 - Izmena postojeceg korisnika");
            Console.WriteLine("  4 - brisanje korisnika");
            Console.WriteLine("  5 - povratak na izbor menija");
            Console.WriteLine("  6 - izlaz iz aplikacije");
            Provera_Unosa2();


        }



        private static void Provera_Unosa()
        {
            int izbor = 0;
            try
            {
                do
                {
                    string st_izbor = Console.ReadLine();
                    izbor = int.Parse(st_izbor);
                }
                while (izbor < 1 || izbor > 6);
                switch (izbor)
                {
                    case 1:
                        Prikaz_Namestaja();
                        break;
                    case 2:
                        Console.WriteLine("  Izabrali ste dodavanje namestaja: ");
                        Novi_izmena(2);
                        break;
                    case 3:
                        Console.WriteLine("  Izabrali ste izmenu namestaja: ");
                        Novi_izmena(3);
                        break;
                    case 4:
                        Brisanje_namestaja();
                        break;
                    case 5:
                        Meni();
                        break;
                    case 6:
                        izlaz();
                        break;


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("morate uneti ceo broj!");
                Provera_Unosa();

            }

           
        }
        private static void Provera_Unosa2()
        {
            int izbor = 0;
            try
            {
                while (izbor < 1 || izbor > 6)
                {
                    string st_izbor = Console.ReadLine();
                    izbor = int.Parse(st_izbor);
                }
                if (izbor == 1)
                {
                    Prikaz_Korisnika();
                }
                else if (izbor == 2)
                {
                    Console.WriteLine("  Izabrali ste unos novog korisnika: ");
                    Dodaj_izmeni_korisnika(2);
                }
                else if (izbor == 3)
                {
                    Console.WriteLine("  Izabrali ste izmenu korisnika: ");
                    Dodaj_izmeni_korisnika(3);
                }
                else if (izbor == 4)
                {
                    Brisanje_korisnika();
                }
                else if (izbor == 5)
                {
                    Meni();
                }
                else if (izbor == 6)
                {
                    izlaz();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("morate uneti ceo broj!");
                Provera_Unosa();

            }
        }

        private static void Brisanje_korisnika()
        {
            ///funkcija koja trazi username korisnika, i brise ga iz liste
            Console.WriteLine("Unesite Username korisnika kojeg zelite da obrisete: ");
            foreach (Korisnik n in korisnici)
            {
                Console.WriteLine("|Ime: " + n.Ime + "|" + "Username: " + n.Username + " | ");
                Console.WriteLine("");
            };
            try
            {
                string izbor = Console.ReadLine();

                foreach (Korisnik n in korisnici)
                {
                    if (izbor.Equals(n.Username))
                    {
                        Console.WriteLine("Uspesno ste obrisali " + n.Ime + " " + n.Prezime);
                        korisnici.Remove(n);
                        RadSaPodacima.Instance.korisnici = korisnici;
                        GlavniMeni2();
                    }
                }
                Brisanje_korisnika();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ako se ova poruka prikazuje, onda stvarno svaka cast!");
                Brisanje_korisnika();
            }
        }

        private static void Prikaz_Korisnika()
        {
            ///            Funkcija koja prolazi kroz listu sa objektima i prikazuje njihove atribute


            Console.WriteLine("  Izabrali ste prikaz namestaja: ");
            var korisnici = RadSaPodacima.Instance.korisnici;
            foreach (Korisnik n in korisnici)
            {
                Console.WriteLine("|Ine: " + n.Ime + "|" + "Prezime: " + n.Prezime + " | " + "Username: "
                    + n.Username + "|" + "Password: " + n.Password + "|" + "Tip korisnika: " + n.Tip_Korisnika + "|");
                Console.WriteLine("");
            };
            GlavniMeni2();
        }

        private static void Brisanje_namestaja()
        {
            var namestaj = RadSaPodacima.Instance.namestaji;
            Console.WriteLine("Unesite Id namestaja koji zelite da obrisete: ");
            foreach (Namestaj n in namestaj)
            {
                Console.WriteLine("|Id: " + n.Id + "|" + "Naziv: " + n.Naziv + " | ");
                Console.WriteLine("");
            };
            try
            {
                string str_izbor = Console.ReadLine();
                int izbor = int.Parse(str_izbor);
                foreach (Namestaj n in namestaj)
                {
                    if (izbor == n.Id)
                    {
                        Console.WriteLine("Uspesno ste obrisali " + n.Naziv);
                        namestaj.Remove(n);
                        RadSaPodacima.Instance.namestaji = namestaj;
                        GlavniMeni();
                    }
                }
                Brisanje_namestaja();
            }
            catch (Exception ex)
            {
                Console.WriteLine("morate uneti ceo broj!");
                Brisanje_namestaja();
            }


        }

        private static void izlaz()
        {
            ///            funkcija koja izlazi iz aplikacije
            Console.WriteLine("izlazim iz aplikacije!");
            Environment.Exit(0);
        }

        private static void Novi_izmena(int br)
        {
            ///            funkcija koja prima izbor iz menija, i prosledjuje ga metodi koja
            ///            u zavisnosti od izbora ili daje izmenu namestaja ili dodavanje novog.
            int izbor = br;
            var namestaj = RadSaPodacima.Instance.namestaji;
            if (izbor == 2)
            {
                Console.WriteLine("   ");
                Console.WriteLine("  Unesite Id novog namestaja: ");

                int id = 0;

                try
                {
                    string str_id = Console.ReadLine();
                    id = int.Parse(str_id);
                    
                    foreach (Namestaj n in namestaj)
                    {
                        if (id == n.Id)
                        {
                            Console.WriteLine("Vec postoji namestaj sa tom sifrom!!");
                            Novi_izmena(2);
                        }

                    }
                    Unos_vrednosti_namestaja(id, 2);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("morate uneti ceo broj!");
                    Novi_izmena(2);
                }
            }
            else if (izbor == 3)
            {
                Console.WriteLine("   ");
                Console.WriteLine("  Unesite Id namestaja koji zelite da izmenite: ");
                int id = 0;

                try
                {
                    string str_id = Console.ReadLine();
                    id = int.Parse(str_id);
                    foreach (Namestaj n in namestaj)
                    {
                        if (id == n.Id)
                        {
                            Console.WriteLine("namestaj je: ");
                            Console.WriteLine("|Id: " + n.Id + "|" + "Naziv: " + n.Naziv + " | " + "Kolicina: "
                                + n.Kolicina + "|" + "Cena: " + n.Cena + "|" + "Tip namestaja: " + n.Tip_Namestaja + "|");
                            Unos_vrednosti_namestaja(id, 3);
                        }

                    }
                    Console.WriteLine("Ne postoji namestaj sa tom sifrom!!");
                    Novi_izmena(3);

                }

                catch (Exception ex)
                {
                    Console.WriteLine("morate uneti ceo broj!");
                    Novi_izmena(3);
                }
            }
        }
        private static void Unos_vrednosti_namestaja(int kd, int izbor)
        {
            ///            funkcija koja prima id i izbor i na osnovu toga
            ///            menja ili dodaje novi namestaj.

            int id = kd;
            int izborr = izbor;
            var tip_namestaja = RadSaPodacima.Instance.tipovi_Namestaja;
            var namestaj = RadSaPodacima.Instance.namestaji;
            try
            {

                Console.WriteLine("Unesite zeljeni naziv namestaja: ");
                string naziv = Console.ReadLine();
                Console.WriteLine("Unesite kolicinu namestaja koji unosite: ");

                int kolicina = 0;

                string str_kolicina = Console.ReadLine();
                kolicina = int.Parse(str_kolicina);


                Console.WriteLine("Unesite cenu namestaja koji unosite: ");
                double cena = 0;
                string str_cena = Console.ReadLine();
                cena = double.Parse(str_cena);



                Console.WriteLine("Unesite jedan od sledecih tipova namestaja: ");
                Console.WriteLine("|" + "Tip namestaja: " + "|");
                foreach (TipNamestaja n in tip_namestaja)
                {
                    Console.WriteLine("|" + n.Naziv + "|");
                    Console.WriteLine("");
                };
                if (izborr == 2)
                {
                    try
                    {

                        string str_tip = Console.ReadLine();
                        foreach (TipNamestaja n in tip_namestaja)
                        {
                            if (n.Naziv.Equals(str_tip))
                            {
                                var nam = new Namestaj
                                {
                                    Id = id,
                                    Naziv = naziv,
                                    Kolicina = kolicina,
                                    Cena = cena,
                                    Tip_Namestaja = n.Id

                                };
                                namestaj.Add(nam);
                                RadSaPodacima.Instance.namestaji = namestaj;
                                Console.WriteLine("Uspesno ste dodali namestaj!");
                                GlavniMeni();
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("ne postoji taj tip namestaja!");
                        Unos_vrednosti_namestaja(id, izborr);
                    }
                }
                else if (izborr == 3)
                {
                    try
                    {

                        string str_tip = Console.ReadLine();
                        foreach (TipNamestaja n in tip_namestaja)
                        {
                            if (n.Naziv.Equals(str_tip))
                            {
                                foreach (Namestaj gn in namestaj)
                                {
                                    if (gn.Id == id)
                                    {
                                        gn.Cena = cena;
                                        gn.Kolicina = kolicina;
                                        gn.Naziv = naziv;
                                        gn.Tip_Namestaja = n.Id;

                                    }
                                }

                                RadSaPodacima.Instance.namestaji = namestaj;
                                Console.WriteLine("Uspesno ste izmenili namestaj!");
                                GlavniMeni();
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("ne postoji taj tip namestaja!");
                        Unos_vrednosti_namestaja(id, izborr);
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("niste dobro uneli podatke!");
                GlavniMeni();

            }
        }

        private static void Prikaz_Namestaja()
        {
            ///            Funkcija koja prolazi kroz listu sa objektima i prikazuje njihove atribute

            Console.WriteLine("  Izabrali ste prikaz namestaja: ");
            var namestaj = RadSaPodacima.Instance.namestaji;
            foreach (Namestaj n in namestaj)
            {
                Console.WriteLine("|Id: " + n.Id + "|" + "Naziv: " + n.Naziv + " | " + "Kolicina: " + n.Kolicina + "|" + "Cena: " + n.Cena + "|" + "Tip namestaja: " + n.Tip_Namestaja + "|");
                Console.WriteLine("");
            };
            GlavniMeni();
        }
        private static void Dodaj_izmeni_korisnika(int br)
        {
            ///            funkcija koja prima izbor iz menija, i prosledjuje ga metodi koja
            ///            u zavisnosti od izbora ili daje izmenu korisnika ili dodavanje novog.
            int izbor = br;
            if (izbor == 2)
            {
                Console.WriteLine("   ");
                Console.WriteLine("  Unesite Username novog korisnika: ");
                var korisnici = RadSaPodacima.Instance.korisnici;

                string username = "";

                try
                {
                    username = Console.ReadLine();

                    foreach (Korisnik n in korisnici)
                    {
                        if (username.Equals(n.Username))
                        {
                            Console.WriteLine("  Vec postoji korisnik sa tim username-om!!");
                            Dodaj_izmeni_korisnika(2);
                        }

                    }
                    Unos_vrednosti_korisnika(username, 2);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("svaka cast!");
                    Dodaj_izmeni_korisnika(2);
                }
            }
            else if (izbor == 3)
            {
                Console.WriteLine("   ");
                Console.WriteLine("  Unesite username korisnika kojeg zelite da izmenite: ");


                try
                {
                    string username = Console.ReadLine();
                    foreach (Korisnik n in korisnici)
                    {
                        if (username.Equals(n.Username))
                        {
                            Console.WriteLine("korisnik je: ");
                            Console.WriteLine("|Ime: " + n.Ime + "|" + "Prezime: " + n.Prezime + " | " + "Username: "
                                + n.Username + "|");
                            Unos_vrednosti_korisnika(username, 3);
                        }

                    }
                    Console.WriteLine("Ne postoji korisnik sa tim username-om!!");
                    Dodaj_izmeni_korisnika(3);

                }

                catch (Exception ex)
                {
                    Console.WriteLine("greska!");
                    Dodaj_izmeni_korisnika(3);
                }
            }
        }

        private static void Unos_vrednosti_korisnika(string user, int v)
        {
            string username = user;
            int izbor = v;
            var korisnici = RadSaPodacima.Instance.korisnici;

            try
            {

                Console.WriteLine("Unesite ime korisnika: ");
                string ime = Console.ReadLine();
                Console.WriteLine("Unesite prezime korisnika: ");
                string prezime = Console.ReadLine();

                Console.WriteLine("Unesite password korisnika: ");
                string password = Console.ReadLine();

                Console.WriteLine("Unesite tip korisnika od ponudjenih korisnika: ");
                Console.WriteLine("Lud");
                Console.WriteLine("Niza klasa");
                if (izbor == 2)
                {
                    try
                    {

                        string tip = Console.ReadLine();
                        if (tip.Equals("Lud") || tip.Equals("Niza klasa"))
                        {
                            var k = new Korisnik
                            {
                                Ime = ime,
                                Prezime = prezime,
                                Username = username,
                                Password = password,
                                Tip_Korisnika = tip


                            };
                            korisnici.Add(k);
                            RadSaPodacima.Instance.korisnici = korisnici;
                            Console.WriteLine("uspesno ste dodali korisnika");
                            GlavniMeni2();
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("ne postoji taj tip korisnika!");
                        Unos_vrednosti_korisnika(username, izbor);
                    }
                }
                else if (izbor == 3)
                {
                    try
                    {

                        string tip = Console.ReadLine();
                        if (tip.Equals("Lud") || tip.Equals("Niza klasa"))
                        {
                            foreach (Korisnik n in korisnici)
                            {
                                if (n.Username.Equals(username))
                                {
                                    n.Ime = ime;
                                    n.Prezime = prezime;
                                    n.Password = password;
                                    n.Tip_Korisnika = tip;
                                }
                            }
                            RadSaPodacima.Instance.korisnici = korisnici;
                            Console.WriteLine("Uspesno ste izmenili korisnika");
                            GlavniMeni2();

                        }

                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("ne postoji taj tip korisnika!");
                        Unos_vrednosti_korisnika(username, izbor);
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("niste dobro uneli podatke!");
                GlavniMeni2();

            }
        }

        private static void LogIn()
        {
            int br = 0;
            string ime = "";
            string prezime = "";
            do {
                Console.WriteLine("Molim unesite vase korisnicko ime: ");
                string unos1 = Console.ReadLine();
                Console.WriteLine("Molim unesite vasu lozinku");
                string unos2 = Console.ReadLine();
                var korisnici = RadSaPodacima.Instance.korisnici;

                foreach (Korisnik n in korisnici)
                {
                    if (unos1.Equals(n.Username) && unos2.Equals(n.Password)){
                        br += 1;
                        ime = n.Ime;
                        prezime = n.Prezime;
                    }

                }

            }
            while (br != 1);

            Console.WriteLine("BRAVO! ulogovani ste kao: " + ime + " " + prezime);
            Meni();
        }
    }

}