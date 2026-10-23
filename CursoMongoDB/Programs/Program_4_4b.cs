using System;
using System.Collections.Generic;
using CursoMongoDB.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CursoMongoDB.Programs
{
    public static class Program_4_4b
    {
        public static async Task ExecutarAsync()
        {
            Console.WriteLine("Processo iniciado (ASSÍNCRONO), esperando 10 segundos...");
            await Task.Delay(10000);
            Console.WriteLine("Processo assíncrono finalizado.");
        }
    }
}