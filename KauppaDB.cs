namespace KauppakantaTunnilla;

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
}