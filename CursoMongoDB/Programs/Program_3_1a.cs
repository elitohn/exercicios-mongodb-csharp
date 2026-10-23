using CursoMongoDB.Contexts;
using System;
using System.Collections.Generic;
using CursoMongoDB.Models;
using MongoDB.Driver;

namespace CursoMongoDB.Programs
{
    public static class Program_3_1a
    {
        public static void Executar()
        {
            var connectionString = MongoConfiguration.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(MongoConfiguration.DatabaseName);
            var colecoes = database.ListCollectionNames().ToList();
            if (!colecoes.Contains("noticias"))
                database.CreateCollection("noticias");
            Console.WriteLine("Banco e coleção verificados/criados com sucesso.");
        }
    }
}