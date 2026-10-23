using System;
using System.Collections.Generic;
using CursoMongoDB.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using CursoMongoDB.Contexts;
using CursoMongoDB.Services;

namespace CursoMongoDB.Programs
{
    public static class Program_5_3b
    {
        public static async Task ExecutarAsync()
        {

            var connectionString = MongoConfiguration.ConnectionString;
            // var client = new MongoClient(connectionString);
            // var database = client.GetDatabase(MongoConfiguration.DatabaseName);
            // var collection = database.GetCollection<BsonDocument>("noticias");

            var contexto = new MongoContext(connectionString, MongoConfiguration.DatabaseName);
            var NoticiaService = new NoticiaService(contexto);

            string caminhoArquivo = Path.Combine(AppContext.BaseDirectory, "data", "noticias.example.json");
            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine("Arquivo noticias.json não encontrado!");
                return;
            }

            string conteudoJson = File.ReadAllText(caminhoArquivo);
            var listaNoticias = JsonConvert.DeserializeObject<List<NoticiaClass>>(conteudoJson) ?? new List<NoticiaClass>();
            
            // var listaBson = new List<BsonDocument>();
            // foreach(var Noticia in listaNoticias)
            // {
            //     listaBson.Add(Noticia.ToBson());
            // }
            // try
            // {
            //     await collection.InsertManyAsync(listaBson);
            //     Console.WriteLine("Notícia incluídas com sucesso!");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine("Ocorreu um erro ao tentar inserir a lista de noticias:");
            //     Console.WriteLine(ex.Message);
            // }

            try
            {
                await NoticiaService.InserirNoticiasAsync(listaNoticias);
                Console.WriteLine("Notícias incluida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar inserir a lista de notícias:");
                Console.WriteLine(ex.Message);
            }

        }
    }
}