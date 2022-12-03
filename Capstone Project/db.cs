using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;


public class db : MonoBehaviour
{

    private string dbName = "URI=file:Sample.db";
    // Start is called before the first frame update
    void Start()
    {
        CreateDB();
        Add("Sample", 1234);
    }

    public void CreateDB()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS sampleTable(name VARCHAR(25000), idnumber INT);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

    }

    public void Add(string Name, int idnum)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO sampleTable (name, idnumber) VALUES ('" + Name + "','" + idnum + "')";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
