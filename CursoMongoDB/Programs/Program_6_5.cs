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
    public static class Program_6_5
    {
        public static async Task ExecutarAsync()
        {

            var connectionString = MongoConfiguration.ConnectionString;
            var contexto = new MongoContext(connectionString, MongoConfiguration.DatabaseName);
            var NoticiaService = new NoticiaService(contexto);

            try
            {
                await NoticiaService.RemoverNoticiasComUrlDuplicadaAsync();
                Console.WriteLine("Prévia da verificação de URLs duplicadas concluída.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar remover as URLs repetidas:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}