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
    public static class Program_5_3a
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
                ""Titulo"": ""Festival de Música agita a cidade do Rio de Janeiro"",
                ""Texto"": ""O festival reuniu artistas nacionais e internacionais..."",
                ""DataPublicacao"": ""2024-11-22T20:30:00Z"",
                ""Tags"": [""cultura"", ""musica"", ""brasil""],
                ""Jornalistas"": [
                    { ""Nome"": ""João Almeida"" }
                ],
                ""Comentarios"": [
                    {
                        ""ComentarioTexto"": ""Evento sensacional!"",
                        ""Curtidas"": 19,
                        ""Usuario"": ""LarissaSantos"",
                        ""Data"": ""2024-11-22T22:10:00Z""
                    }
                ],
                ""Anexos"": [
                    {
                        ""NomeArquivo"": ""festival-musica.jpg"",
                        ""Url"": ""https://meusite.com/img/festival-musica.jpg"",
                        ""Tamanho"": 98000,
                        ""Tipo"": ""image/jpeg"",
                        ""Cliques"": 31
                    }
                ],
                ""Visualizacoes"": 950,
                ""TotalComentarios"": 1,
                ""Gostei"": 76,
                ""NaoGostei"": 2,
                ""TempoMedioLeitura"": 3.1
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