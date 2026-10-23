using System;
using System.Collections.Generic;
using CursoMongoDB.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CursoMongoDB.Programs
{
    public static class Program_4_4a
    {
        public static void Executar()
        {
            Console.WriteLine("Processo iniciado (SÍNCRONO), esperando 10 segundos...");
            System.Threading.Thread.Sleep(10000);
            Console.WriteLine("Processo síncrono finalizado.");
        }
    }
}