namespace KauppakantaTunnilla;

using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;

public class KauppaDB
{
    private string _connectionString = "Data Source = kauppa.db";

    public KauppaDB()
    {
        // Luodaan yhteys tietokantaan
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        // Luodaan taulut, jos niitä ei vielä ole
        // Yksinkertainen tietokanta, jossa on yksi taulu
        // Taulu Tuotteet, sarakkeet id, nimi, hinta
        var commandForTableCreation = connection.CreateCommand();
        commandForTableCreation.CommandText =
            "CREATE TABLE IF NOT EXISTS Tuotteet (id INTEGER PRIMARY KEY, nimi TEXT, hinta REAL)";
        commandForTableCreation.ExecuteNonQuery();
        connection.Close();
    }

    public void LisaaTuote(string nimi, double hinta)
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        // Lisätään tuote tietokantaan
        var commandForInsert = connection.CreateCommand();
        commandForInsert.CommandText =
            "INSERT INTO Tuotteet (nimi, hinta) VALUES (@Nimi, @Hinta)";
        commandForInsert.Parameters.AddWithValue(@"Nimi", nimi);
        commandForInsert.Parameters.AddWithValue(@"Hinta", hinta);
        commandForInsert.ExecuteNonQuery();
        connection.Close();
    }
    public string HaeTuotteet(string haettuNimi)
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var commandForSelect = connection.CreateCommand();
        commandForSelect.CommandText =
            "SELECT * FROM Tuotteet WHERE nimi LIKE @Nimi";
        commandForSelect.Parameters.AddWithValue(@"Nimi", haettuNimi);
        var reader = commandForSelect.ExecuteReader();
        string tuotteet = "";
        while (reader.Read())
        {
            tuotteet += $"Id: {reader.GetInt32(0)}, Nimi: {reader.GetString(1)}, Hinta: {reader.GetDouble(2)}";
        }
        reader.Close();
        connection.Close();
        if (tuotteet == "")
        {
            return "Hakemaasi tuotetta ei löytynyt.";
        }
        else
        {
            return tuotteet;
        }
    }
}