using CursoMongoDB.Contexts;
using System;
using System.Collections.Generic;
using CursoMongoDB.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CursoMongoDB.Programs
{
    public static class Program_4_2
    {
        public static void Executar()
        {

            var connectionString = MongoConfiguration.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(MongoConfiguration.DatabaseName);
            var collection = database.GetCollection<BsonDocument>("noticias");

            string caminhoArquivo = Path.Combine(AppContext.BaseDirectory, "data", "noticias.example.json");
            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine("Arquivo noticias.json não encontrado!");
                return;
            }

            string conteudoJson = File.ReadAllText(caminhoArquivo);
            var listaNoticias = JsonConvert.DeserializeObject<List<NoticiaClass>>(conteudoJson) ?? new List<NoticiaClass>();
            int contador = 1;
            foreach(var Noticia in listaNoticias)
            {
                var noticiaBson = Noticia.ToBson();
                try
                {
                    collection.InsertOne(noticiaBson);
                    Console.WriteLine("Notícia incluída com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao tentar inserir o JSON como string:");
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine($"Notícia {contador} inserida no MongoDB: {Noticia.Titulo}");
                contador++;
            }
            
        }
    }
}