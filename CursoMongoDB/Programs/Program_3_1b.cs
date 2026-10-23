using CursoMongoDB.Contexts;
using System;
using System.Collections.Generic;
using CursoMongoDB.Models;
using MongoDB.Driver;

namespace CursoMongoDB.Programs
{
    public static class Program_3_1b
    {
        public static void Executar()
        {
            var connectionString = MongoConfiguration.ConnectionString;
            Console.WriteLine("Esta operação apaga o banco NoticiasDB inteiro.");
            Console.Write("Digite APAGAR para continuar: ");
            if (!string.Equals(Console.ReadLine(), "APAGAR", StringComparison.Ordinal))
            {
                Console.WriteLine("Operação cancelada.");
                return;
            }

            var client = new MongoClient(connectionString);
            client.DropDatabase(MongoConfiguration.DatabaseName);
            Console.WriteLine("Banco de dados 'NoticiaDB' removido com sucesso!");
        }
    }
}