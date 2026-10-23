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
    public static class Program_10_5
    {
        public static async Task ExecutarAsync()
        {
            var connectionString = MongoConfiguration.ConnectionString;            
            var contexto = new MongoContext(connectionString, MongoConfiguration.DatabaseName);
            var NoticiaService = new NoticiaService(contexto);
            
            Console.WriteLine("--- Executando a busca por notícias mais lidas da tag 'brasil' ---");

            // Chamada do novo método
            var noticiasMaisLidas = await NoticiaService.ListarNoticiasMaisLidasPorTagAsync("brasil");

            // Impressão dos resultados usando a função auxiliar
            ImprimirResultados("Notícias mais lidas da tag 'brasil'", noticiasMaisLidas, "Visualizacoes");
            Console.WriteLine("-----------------------------------------");
        }

        private static void ImprimirResultados(string titulo, List<BsonDocument> documentos, string campoOrdenado)
        {
            Console.WriteLine($"$--- {titulo} ---");
            if (documentos == null || documentos.Count == 0)
            {
                Console.WriteLine("Nenhum documento encontrado.");
                Console.WriteLine("\n-----------------------------------------");
                return;
            }

            foreach (var doc in documentos)
            {
                var valorOrdenado = "N/A";
                try
                {
                    if (doc.Contains(campoOrdenado) && !doc[campoOrdenado].IsBsonNull)
                    {
                        valorOrdenado = doc[campoOrdenado].ToString();
                    }
                }
                catch { /* Ignora erros se o campo não existir no documento específico */ }
                Console.WriteLine($" - Título: {doc["Titulo"]}, {campoOrdenado}: {valorOrdenado}");
            }
            Console.WriteLine($"Total de resultados: {documentos.Count}");
            Console.WriteLine("\n-----------------------------------------");
        }
    }
}
