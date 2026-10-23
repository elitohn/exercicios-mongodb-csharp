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
    public static class Program_10_1
    {
        public static async Task ExecutarAsync()
        {
            var connectionString = MongoConfiguration.ConnectionString;            
            var contexto = new MongoContext(connectionString, MongoConfiguration.DatabaseName);
            var NoticiaService = new NoticiaService(contexto);
            
            try
            {
                await NoticiaService.CriarIndiceDataPublicacaoAsync();
                Console.WriteLine("--- Operação de criação de índice finalizada ---");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao criao o indice: {ex.Message}");
            }
        }
    }
}