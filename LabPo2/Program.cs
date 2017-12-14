using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPo2
{
    public class Osoba
    {
        private string imie;
        private string nazwisko;
        private string dataUrodzenia;

        public Osoba(string imie_, string nazwisko_, string dataUrodzenia_)
        {
            Imie = imie_;
            Nazwisko = nazwisko_;
            DataUrodzenia = dataUrodzenia_;
        }

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }
        public string DataUrodzenia
        {
            get { return dataUrodzenia; }
            set { dataUrodzenia = value; }
        }

        public virtual void WypiszInfo()
        {
            Console.WriteLine("______________________________________");
            Console.WriteLine("Imie: " + Imie);
            Console.WriteLine("Nazwisko: " + Nazwisko);
            Console.WriteLine("Data urodzenia: " + DataUrodzenia);
        }
    }  //..........................................................................................................

    public class Pilkarz : Osoba
    {
        private string pozycja;
        private string klub;
        private int liczbaGoli = 0;
        public Pilkarz(string imie_, string nazwisko_, string dataUrodzenia_, string pozycja_, string klub_) : base(imie_, nazwisko_, dataUrodzenia_)
        {
            Pozycja = pozycja_;
            Klub = klub_;
        }

        public string Pozycja
        {
            get { return pozycja; }
            set { pozycja = value; }
        }
        public string Klub
        {
            get { return klub; }
            set { klub = value; }
        }

        public override void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine("Pozycja: " + Pozycja);
            Console.WriteLine("Klub: " + Klub);
            Console.WriteLine("Liczba goli: " + liczbaGoli);
        }

        public virtual void StrzelGola()
        {
            liczbaGoli++;
        }
    }  //..........................................................................................................

    public class Student : Osoba
    {
        private int rok;
        private int grupa;
        private int nrIndexu;
        private List<Ocena> oceny = new List<Ocena>();

        public Student(
            string imie_,
            string nazwisko_,
            string dataUrodzenia_,
            int rok_,
            int grupa_,
            int nrIndexu_
            ) : base(imie_, nazwisko_, dataUrodzenia_)
        {
            Rok = rok_;
            Grupa = grupa_;
            NrIndexu = nrIndexu_;
        }

        public int Rok
        {
            get { return rok; }
            set { rok = value; }
        }
        public int Grupa
        {
            get { return grupa; }
            set { grupa = value; }
        }
        public int NrIndexu
        {
            get { return nrIndexu; }
            set { nrIndexu = value; }
        }

        public override void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine("Rok: " + Rok);
            Console.WriteLine("Grupa: " + Grupa);
            Console.WriteLine("Numer indexu: " + NrIndexu);
            Console.WriteLine(" ");
            WypiszOceny();
        }

        public void DodajOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            oceny.Add(new Ocena(nazwaPrzedmiotu, data, wartosc));
        }

        public void WypiszOceny()
        {
            for (int i = 0; i < oceny.Count; i++)
            {
                oceny[i].WypiszInfo();
            }
        }

        public void WypiszOceny(string nazwaPrzedmiotu)
        {
            for (int i = 0; i < oceny.Count; i++)
            {
                if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu)
                {
                    oceny[i].WypiszInfo();
                }
            }
        }
        public void UsunOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            for (int i = 0; i < oceny.Count; i++)
            {
                if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu && oceny[i].Data == data && oceny[i].Wartosc == wartosc)
                {
                    oceny.Remove(oceny[i]);
                    break;
                }
            }
        }

        public void UsunOceny()
        {
            oceny.Clear();
        }

        public void UsunOceny(string nazwaPrzedmiotu)
        {
            for (int i = 0; i < oceny.Count; i++)
            {
                if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu)
                {
                    oceny.Remove(oceny[i]);
                    i--;
                }
            }
        }
    }  //..........................................................................................................

    public class Ocena
    {
        private string nazwaPrzedmiotu;
        private string data;
        private double wartosc;

        public Ocena(string nazwaPrzedmiotu_, string data_, double wartosc_)
        {
            NazwaPrzedmiotu = nazwaPrzedmiotu_;
            Data = data_;
            Wartosc = wartosc_;
        }

        public string NazwaPrzedmiotu
        {
            get { return nazwaPrzedmiotu; }
            set { nazwaPrzedmiotu = value; }
        }
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        public double Wartosc
        {
            get { return wartosc; }
            set { wartosc = value; }
        }

        public void WypiszInfo()
        {
            Console.WriteLine("   Nazwa przedmiotu: " + NazwaPrzedmiotu);
            Console.WriteLine("   Data: " + Data);
            Console.WriteLine("   Wartość: " + Wartosc);
            Console.WriteLine(" ");
        }
    }  //..........................................................................................................

    class PilkarzNozny : Pilkarz
    {
        public PilkarzNozny(string imie_, string nazwisko_, string dataUrodzenia_, string pozycja_, string klub_) : base(imie_, nazwisko_, dataUrodzenia_, pozycja_, klub_)
        {
        }

        public override void StrzelGola()
        {
            base.StrzelGola();
            Console.WriteLine("Ręczny strzelił");
        }
    } //..........................................................................................................

    class PilkarzReczny : Pilkarz
    {
        public PilkarzReczny(string imie_, string nazwisko_, string dataUrodzenia_, string pozycja_, string klub_) : base(imie_, nazwisko_, dataUrodzenia_, pozycja_, klub_)
        {
        }

        public override void StrzelGola()
        {
            base.StrzelGola();
            Console.WriteLine("Nożny strzelił");
        }
    } //..........................................................................................................

    class Program // >>>> Klasa TESTUJACA <<<< ....................................................................
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadanie 1- Sprawdzenie.............................................................. ");

            Osoba o = new Osoba("Adam", "Miś", "20.03.1980");
            Osoba o2 = new Student("Michał", "Kot", "13.04.1990", 2, 1, 12345);
            Osoba o3 = new Pilkarz("Mateusz", "Żbik", "10.08.1986", "obrońca", "FC Czestochowa");
            o.WypiszInfo();
            o2.WypiszInfo();
            o3.WypiszInfo();

            Student s = new Student("Krzysztof", "Jeż", "22.12.1990", 2, 5, 54321);
            Pilkarz p = new Pilkarz("Piotr", "Kos", "14.09.1984", "napastnik", "FC Politechnika");

            s.WypiszInfo();
            p.WypiszInfo();

            ((Pilkarz)o3).StrzelGola();
            p.StrzelGola();
            p.StrzelGola();

            o3.WypiszInfo();
            p.WypiszInfo();

            Console.WriteLine("Zadanie 1- Koniec Sprawdzenia.............................................................. ");
            Console.ReadKey();

            Console.WriteLine("Zadanie 2- Sprawdzenie..............................................................");

            ((Student)o2).DodajOcene("PO", "20.02.2011", 5.0);
            ((Student)o2).DodajOcene("Bazy danych", "13.02.2011", 4.0);

            o2.WypiszInfo();

            s.DodajOcene("Bazy danych", "01.05.2011", 5.0);
            s.DodajOcene("AWW", "11.05.2011", 5.0);
            s.DodajOcene("AWW", "02.04.2011", 4.5);

            s.WypiszInfo();

            s.UsunOcene("AWW", "02.04.2011", 4.5);

            s.WypiszInfo();

            s.DodajOcene("AWW", "02.04.2011", 4.5);
            s.UsunOceny("AWW");

            s.WypiszInfo();

            s.DodajOcene("AWW", "02.04.2011", 4.5);
            s.UsunOceny();

            s.WypiszInfo();
            Console.WriteLine("Zadanie 2- Koniec Sprawdzenia.............................................................. ");
            Console.ReadKey();


            Console.WriteLine("Zadanie domowe- Sprawdzenie..............................................................");

            PilkarzNozny pilkarzNozny = new PilkarzNozny("Adam", "Nowak", "12.03.1996", "pomocnik", "FC Jakisklub");
            PilkarzReczny pilkarzReczny = new PilkarzReczny("Jan", "Kowalski", "07.12.1993", "bramkarz", "Inny klub");

            pilkarzNozny.StrzelGola();
            pilkarzReczny.StrzelGola();

            pilkarzNozny.WypiszInfo();
            pilkarzReczny.WypiszInfo();

            Console.WriteLine("Zadanie domowe- Koniec Sprawdzenia.............................................................. ");
            Console.ReadKey();
        }
    }
}
