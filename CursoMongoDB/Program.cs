using CursoMongoDB.Contexts;
using CursoMongoDB.Programs;
using CursoMongoDB.Services;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Curso MongoDB em C#");
            Console.WriteLine("Informe o exercício, por exemplo: dotnet run -- 10_5");
            Console.WriteLine("Use --setup apenas para configurar explicitamente o schema e o índice.");
            return;
        }

        if (args[0] == "--setup")
        {
            var contexto = new MongoContext(MongoConfiguration.ConnectionString, MongoConfiguration.DatabaseName);
            var servico = new NoticiaService(contexto);
            servico.PrepararColecaoParaExerciciosComSchema();
            Console.WriteLine("Coleção configurada. Confirme no Atlas antes de executar os exercícios.");
            return;
        }

        switch (args[0].Replace('.', '_'))
        {
            case "10_1":
                await Program_10_1.ExecutarAsync();
                break;
            case "10_3":
                await Program_10_3.ExecutarAsync();
                break;
            case "10_5":
                await Program_10_5.ExecutarAsync();
                break;
            case "2_4":
                Program_2_4.Executar();
                break;
            case "2_5":
                Program_2_5.Executar();
                break;
            case "3_1a":
                Program_3_1a.Executar();
                break;
            case "3_1b":
                Program_3_1b.Executar();
                break;
            case "3_2":
                Program_3_2.Executar();
                break;
            case "3_3":
                Program_3_3.Executar();
                break;
            case "3_5":
                Program_3_5.Executar();
                break;
            case "4_1":
                Program_4_1.Executar();
                break;
            case "4_2":
                Program_4_2.Executar();
                break;
            case "4_3":
                Program_4_3.Executar();
                break;
            case "4_4a":
                Program_4_4a.Executar();
                break;
            case "4_4b":
                await Program_4_4b.ExecutarAsync();
                break;
            case "4_5a":
                await Program_4_5a.ExecutarAsync();
                break;
            case "4_5b":
                await Program_4_5b.ExecutarAsync();
                break;
            case "5_2a":
                await Program_5_2a.ExecutarAsync();
                break;
            case "5_2b":
                await Program_5_2b.ExecutarAsync();
                break;
            case "5_3a":
                await Program_5_3a.ExecutarAsync();
                break;
            case "5_3b":
                await Program_5_3b.ExecutarAsync();
                break;
            case "6_2a":
                await Program_6_2a.ExecutarAsync();
                break;
            case "6_2b":
                await Program_6_2b.ExecutarAsync();
                break;
            case "6_3":
                await Program_6_3.ExecutarAsync();
                break;
            case "6_5":
                await Program_6_5.ExecutarAsync();
                break;
            case "6_6":
                await Program_6_6.ExecutarAsync();
                break;
            case "7_1":
                await Program_7_1.ExecutarAsync();
                break;
            case "7_2":
                await Program_7_2.ExecutarAsync();
                break;
            case "7_3":
                await Program_7_3.ExecutarAsync();
                break;
            case "7_4":
                await Program_7_4.ExecutarAsync();
                break;
            case "8_1":
                await Program_8_1.ExecutarAsync();
                break;
            case "8_2":
                await Program_8_2.ExecutarAsync();
                break;
            case "8_3":
                await Program_8_3.ExecutarAsync();
                break;
            case "8_4":
                await Program_8_4.ExecutarAsync();
                break;
            case "8_5":
                await Program_8_5.ExecutarAsync();
                break;
            case "9_1":
                await Program_9_1.ExecutarAsync();
                break;
            case "9_2":
                await Program_9_2.ExecutarAsync();
                break;
            case "9_3":
                await Program_9_3.ExecutarAsync();
                break;
            case "9_4":
                await Program_9_4.ExecutarAsync();
                break;
            default:
                Console.WriteLine($"Exercício desconhecido: {args[0]}");
                Console.WriteLine("Consulte a seção de exercícios no README.md.");
                Environment.ExitCode = 1;
                break;
        }
    }
}
