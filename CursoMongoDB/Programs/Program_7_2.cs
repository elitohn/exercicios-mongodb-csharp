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
    public static class Program_7_2
    {
        public static async Task ExecutarAsync()
        {

            var connectionString = MongoConfiguration.ConnectionString;            
            var contexto = new MongoContext(connectionString, MongoConfiguration.DatabaseName);
            var NoticiaService = new NoticiaService(contexto);

            var Url = "feira_de_ciencia_apresenta_invencoes_de_estudantes";
            var comentario = new ComentarioClass
            {
                ComentarioTexto = "Incrível ver jovens tão engajados com ciência!",
                Curtidas = 3,
                Usuario = "MariaSilva",
                Data = DateTime.UtcNow
            };

            try
            {
                await NoticiaService.AdicionarComentarioAsync(Url, comentario);
                Console.WriteLine("Comentário adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar adicionar o comentário da Notícia:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}