namespace KauppakantaTunnilla;

using System.Collections;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main(string[] args)
    {
        KauppaDB kauppa = new KauppaDB();

        while (true)
        {
            Console.WriteLine("Haluatko lisätä tuotteen (L), hakea (H) vai lopettaa (X)?");
            string? vastaus = Console.ReadLine();
            switch (vastaus)
            {
                case "L":
                    Console.WriteLine("Anna tuotteen nimi:");
                    string? nimi = Console.ReadLine();
                    Console.WriteLine("Anna tuotteen hinta:");
                    double hinta = Convert.ToDouble(Console.ReadLine());
                    // Lisätään tuote tietokantaan
                    kauppa.LisaaTuote(nimi, hinta);
                    break;

                case "H":

                case "X":
                    return;
                default:
                    Console.WriteLine($"{vastaus} ei ole hyväksytty valinta, anna L, H tai X");
                    break;

            }
        }
    }
}
