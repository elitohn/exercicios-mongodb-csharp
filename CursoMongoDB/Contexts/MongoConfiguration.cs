namespace CursoMongoDB.Contexts;

public static class MongoConfiguration
{
    public const string DatabaseName = "NoticiasDB";

    public static string ConnectionString =>
        Environment.GetEnvironmentVariable("MONGODB_URI")
        ?? throw new InvalidOperationException(
            "A variável de ambiente MONGODB_URI não foi definida. Consulte o README.");
}
