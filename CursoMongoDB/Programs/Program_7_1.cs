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
    public static class Program_7_1
    {
        public static async Task ExecutarAsync()
        {

            var connectionString = MongoConfiguration.ConnectionString;            
            var contexto = new MongoContext(connectionString, MongoConfiguration.DatabaseName);
            var NoticiaService = new NoticiaService(contexto);

            var Url = "arqueologos_encontram_templo_perdido_de_civilizacao_preinca";
            var NovoTexto = "Pesquisadores comprovam que o templo cerimonial foi criado realmente na época Inca.";  

            try
            {
                await NoticiaService.AtualizarTextoPorUrlAsync(Url, NovoTexto);
                Console.WriteLine("Texto da Notícia alterada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar alterar o texto da Notícia:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}