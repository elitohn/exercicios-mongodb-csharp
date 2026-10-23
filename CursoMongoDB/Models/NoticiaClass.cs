using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MongoDB.Bson;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CursoMongoDB.Models;

public class NoticiaClass
{
    // public string Titulo { get; set; }
    [BsonId]
    [Newtonsoft.Json.JsonIgnore]
    public ObjectId Id { get; set; }
    private string _titulo = string.Empty;
    public string Titulo
    {
        get => _titulo;
        set
        {
            _titulo = value;
            Url = GerarUrl(value);
        }
    }

    public string Url { get; set; } = string.Empty;
    public string Texto { get; set; } = string.Empty;
    public DateTime DataPublicacao { get; set; }
    public List<string> Tags { get; set; } = new();
    public List<JornalistaClass> Jornalistas { get; set; } = new();
    public List<ComentarioClass> Comentarios { get; set; } = new();
    public List<AnexoClass> Anexos { get; set; } = new();
    public int Visualizacoes { get; set; }
    public int TotalComentarios { get; set; }
    public int Gostei { get; set; }
    public int NaoGostei { get; set; }
    public double TempoMedioLeitura { get; set; }

    private static string GerarUrl(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            return string.Empty;

        // Remove acentos
        string url = titulo.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        foreach (var c in url)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }
        url = sb.ToString().Normalize(NormalizationForm.FormC);

        // Substitui espaços por underline, deixa minúsculo e remove caracteres especiais
        url = url.Replace(' ', '_').ToLowerInvariant();
        url = Regex.Replace(url, @"[^a-z0-9_]", "");

        return url;
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public BsonDocument ToBson()
    {
        return this.ToBsonDocument();
    }
}

public class JornalistaClass
{
    public string Nome { get; set; } = string.Empty;
}

public class ComentarioClass
{
    [JsonProperty("Comentario")]
    [BsonElement("Comentario")]
    public string ComentarioTexto { get; set; } = string.Empty;

    public int Curtidas { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public DateTime Data { get; set; }
}

public class AnexoClass
{
    public string NomeArquivo { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public int Tamanho { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public int Cliques { get; set; }
}