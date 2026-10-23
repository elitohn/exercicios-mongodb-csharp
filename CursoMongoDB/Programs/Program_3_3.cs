using CursoMongoDB.Contexts;
using System;
using System.Collections.Generic;
using CursoMongoDB.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CursoMongoDB.Programs
{
    public static class Program_3_3
    {
        public static void Executar()
        {

            var connectionString = MongoConfiguration.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(MongoConfiguration.DatabaseName);
            var collection = database.GetCollection<BsonDocument>("noticias");

            var Noticia = new NoticiaClass
            {
                Titulo = "Brasil bate Equador",
                Texto = "No Maracanã, Brasil vence o Equador por 2x0 ...",
                DataPublicacao = DateTime.Parse("2023-08-10T15:32:00Z"),
                Tags = new List<string> {"esporte", "Brasil"},
                Jornalistas = new List<JornalistaClass> 
                {
                    new JornalistaClass { Nome = "Maria"}
                },
                Comentarios = new List<ComentarioClass> 
                {
                    new ComentarioClass
                    {
                        ComentarioTexto = "Grande Jogo!",
                        Curtidas = 0,
                        Usuario = "Carlos",
                        Data = DateTime.Parse("2023-08-10T18:42:00Z")
                    }
                },
                Anexos = new List<AnexoClass> 
                {
                    new AnexoClass 
                    {
                        NomeArquivo = "foto-jogo.jpg",
                        Url = "https://meusite.com.br/fotos/foto-jogo.jpg",
                        Tamanho = 204800,
                        Tipo = "imagem/jpg",
                        Cliques = 0
                    }
                },
                Visualizacoes = 0,
                TotalComentarios = 1,
                Gostei = 0,
                NaoGostei = 0,
                TempoMedioLeitura = 0.0
            };
            
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

        }
    }
}