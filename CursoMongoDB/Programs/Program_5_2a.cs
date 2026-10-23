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
    public static class Program_5_2a
    {
        public static async Task ExecutarAsync()
        {

            var connectionString = MongoConfiguration.ConnectionString;
            // var client = new MongoClient(connectionString);
            // var database = client.GetDatabase(MongoConfiguration.DatabaseName);
            // var collection = database.GetCollection<BsonDocument>("noticias");
            
            var contexto = new MongoContext(connectionString, MongoConfiguration.DatabaseName);
            var NoticiaService = new NoticiaService(contexto);

            string jsonRecebido = @"{
                ""Titulo"": ""Brasil bate Equador"",
                ""Texto"": ""No Maracanã, Brasil vence por 2 a 0..."",
                ""DataPublicacao"": ""2023-08-10T15:32:00Z"",
                ""Tags"": [ ""esporte"", ""brasil""],
                ""Jornalistas"": [{ ""Nome"": ""Maria"" }],
                ""Comentarios"": [{
                    ""ComentarioTexto"": ""Grande jogo!"",
                    ""Curtidas"": 0,
                    ""Usuario"": ""Carlos"",
                    ""Data"": ""2023-08-10T18:45:00Z""
                }],
                ""Anexos"": [{
                    ""NomeArquivo"": ""foto-jogo.jpg"",
                    ""Url"": ""https://meusite.com/fotos/foto-jogo.jpg"",
                    ""Tamanho"": 204800,
                    ""Tipo"": ""imagem/jpeg"",
                    ""Cliques"": 157
                }],
                ""Visualizacoes"": 0,
                ""TotalComentarios"": 1,
                ""Gostei"": 0,
                ""NaoGostei"": 0,
                ""TempoMedioLeitura"": 0.0
            }";

            var Noticia = JsonConvert.DeserializeObject<NoticiaClass>(jsonRecebido);            
            
            // var noticiaBson = Noticia.ToBson();
            // try
            // {
            //     await collection.InsertOneAsync(noticiaBson);
            //     Console.WriteLine("Notícia incluída com sucesso!");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine("Ocorreu um erro ao tentar inserir o JSON como string:");
            //     Console.WriteLine(ex.Message);
            // }

            try
            {
                await NoticiaService.InserirNoticiaAsync(Noticia);
                Console.WriteLine("Notícia incluida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar inserir o JSON como string:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}