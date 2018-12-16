using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqPrzyklady
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    select pracownik
                ).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Dodawanie obiektow:
            //1. Najpierw tworzymy pusty obiekt
            Pracownicy pracownik = new Pracownicy();
            //2. Wypelniamy pracownika danymi
            pracownik.Imie = "Damian";
            pracownik.Nazwisko = "Nowak";
            pracownik.Stanowisko = "Operator";
            pracownik.PlacaNetto = 2000;
            //3. Dodajemy utworzonego pracownika do lokalnej kolekcji
            db.Pracownicies.Add(pracownik);
            //4. Zapisujemy zmiany w bazie danych
            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Modyfikowanie obiektow:
            //1. Najpierw odnajdujemy rekord ktory chcemy modyfikowac
            Pracownicy pracownik = db.Pracownicies.Find(1);
            //2. Modyfikujemy jego dane
            pracownik.Imie = "Marcin";
            pracownik.Stanowisko = "Dyrektor";
            //3. Zapisujemy zmiany w bazie danych
            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Modyfikowanie obiektow:
            //1. Najpierw odnajdujemy rekord ktory chcemy usunac
            Pracownicy pracownik = db.Pracownicies.Find(1);
            //2. Usuwamy rekord
            db.Pracownicies.Remove(pracownik);
            //3. Zapisujemy zmiany w bazie danych
            db.SaveChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            dataGridView1.DataSource = db.Pracownicies.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.Stanowisko
                    }
                ).ToList();
        }
 
        private void button12_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Wyswietlimy tych pracownikow ktorzy zarabiaja wiecej niz 1000
            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    where pracownik.PlacaNetto < 1000
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.Stanowisko
                    }
                ).ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Odczytanie zarobkow z interfejsu
            decimal min = decimal.Parse(textBox1.Text);
            decimal max = Convert.ToDecimal(textBox2.Text);

            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    where pracownik.PlacaNetto >= min && pracownik.PlacaNetto <= max
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.Stanowisko
                    }
                ).ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Odczytanie zarobkow z interfejsu
            decimal a = decimal.Parse(textBox1.Text);
            decimal b = Convert.ToDecimal(textBox2.Text);

            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    where pracownik.PlacaNetto <= a || pracownik.PlacaNetto >= b
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.Stanowisko
                    }
                ).ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Klauzura where dla kolekcji
            dataGridView1.DataSource = db.Pracownicies.Where(p => p.PlacaNetto > 1000).ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Pracownicy posortowani po nazwisku
            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    where pracownik.PlacaNetto >= 1000
                    orderby pracownik.Nazwisko
                    select pracownik
                ).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Pracownicy posortowani po stanowisku, a w obrebie stanowiska po nazwisku
            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    where pracownik.PlacaNetto >= 1000
                    orderby pracownik.Stanowisko, pracownik.Nazwisko
                    select pracownik
                ).ToList();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    orderby pracownik.PlacaNetto descending
                    select pracownik
                ).ToList();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Wyswietlamy grupy stanowisk, czyli kazede stanowisko tylko raz
            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    group pracownik by pracownik.Stanowisko
                ).ToList();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Analogicznie jak wyzej kazde stanowisko tylko raz, tylko przy pomocy klauzury distinct
            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    select new
                    {
                        pracownik.Stanowisko
                    }
                ).Distinct().ToList();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //W linq mozemy tworzyc obliczalne kolumny
            dataGridView1.DataSource =
                (
                    from pracownik in db.Pracownicies
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.PlacaNetto,
                        Podatek = pracownik.PlacaNetto * 20 / 100
                    }
                ).Distinct().ToList();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //obliczamy sume wszystkich wyplat pracownikow
            label1.Text =
                (
                    from pracownik in db.Pracownicies
                    select new
                    {
                        pracownik.PlacaNetto
                    }
                ).Sum(p => p.PlacaNetto).ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //obliczamy sume wszystkich wyplat pracownikow
            label1.Text =
                (
                    from pracownik in db.Pracownicies
                    select pracownik.PlacaNetto
                ).Sum().ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //minimalna placa w firmie
            label1.Text =
                (
                    from pracownik in db.Pracownicies
                    select pracownik.PlacaNetto
                ).Min().ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //srednia placa w firmie
            label1.Text =
                (
                    from pracownik in db.Pracownicies
                    select pracownik.PlacaNetto
                ).Average().ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //czy krotykolwiek z pracownikow zarabia mniej niz 5000
            label1.Text =
                (
                    from pracownik in db.Pracownicies
                    select new
                    {
                        pracownik.PlacaNetto
                    }
                ).Any(p => p.PlacaNetto <= 5000).ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //czy wszyscy z pracownikow zarabia mniej niz 5000
            label1.Text =
                (
                    from pracownik in db.Pracownicies
                    select new
                    {
                        pracownik.PlacaNetto
                    }
                ).All(p => p.PlacaNetto <= 5000).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Wyswietlamy dane pierwszego pracownika ktory zarabia wiecej niz 5000
            var wybrany =
                (
                    from pracownik in db.Pracownicies
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.Stanowisko,
                        pracownik.PlacaNetto
                    }
                ).First(z => z.PlacaNetto > 5000);

            //teraz wyswietlamy pracownika w labelu
            label1.Text = wybrany.Imie + " " + wybrany.Nazwisko;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Wyswietlamy dane pierwszego pracownika ktory zarabia wiecej niz 5000
            var wybrany =
                (
                    from pracownik in db.Pracownicies
                    orderby pracownik.PlacaNetto descending
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.Stanowisko,
                        pracownik.PlacaNetto
                    }
                ).First(z => z.PlacaNetto > 5000);

            //teraz wyswietlamy pracownika w labelu
            label1.Text = wybrany.Imie + " " + wybrany.Nazwisko;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();
            //Wyswietlamy dane pierwszego pracownika ktory zarabia wiecej niz 5000
            var wybrany =
                (
                    from pracownik in db.Pracownicies
                    orderby pracownik.PlacaNetto descending
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.Stanowisko,
                        pracownik.PlacaNetto
                    }
                ).FirstOrDefault(z => z.PlacaNetto > 500000);

            //teraz wyswietlamy pracownika w labelu
            if (wybrany != null)
            {
                label1.Text = wybrany.Imie + " " + wybrany.Nazwisko;
            }
            else
            {
                label1.Text = "Takiego nie ma";
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();

            var zapytanie1 =
                (
                    from pracownik in db.Pracownicies
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.PlacaNetto
                    }
                );

            var zapytanie2 =
                (
                    from pracownik in zapytanie1 //zagniezdzenie zapytan
                    where pracownik.PlacaNetto > 2000
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.PlacaNetto
                    }
                );

            var zapytanie3 =
               (
                    from pracownik in zapytanie2
                    orderby pracownik.PlacaNetto
                    select new
                    {
                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.PlacaNetto
                    }
                );

            dataGridView1.DataSource = zapytanie3.ToList();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            LinqEntities db = new LinqEntities();

            var wyplata = db.Wyplaties.Find(1);

            label1.Text = wyplata.Pracownicy.Imie + " " + wyplata.Pracownicy.Nazwisko + " Wyplata1: " + wyplata.Kwota; 
        }
    }
}
