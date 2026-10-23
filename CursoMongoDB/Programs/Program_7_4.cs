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
    public static class Program_7_4
    {
        public static async Task ExecutarAsync()
        {

            var connectionString = MongoConfiguration.ConnectionString;            
            var contexto = new MongoContext(connectionString, MongoConfiguration.DatabaseName);
            var NoticiaService = new NoticiaService(contexto);

            var Url = "feira_de_ciencia_apresenta_invencoes_de_estudantes";
            var sinalGostou = 1;
            var tempoVisualizacao = 2.5;

            try
            {
                await NoticiaService.AtualizarEstatisticasVisualizacaoAsync(Url, sinalGostou, tempoVisualizacao);
                Console.WriteLine("Estatísticas atualizadas com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao atualizar as estatísticas:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}