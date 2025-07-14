using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Studenci.Models;

namespace Studenci.Utils
{
    public class StudentJsonConverter : JsonConverter<Student>
    {
        public override Student Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            JsonElement root = document.RootElement;

            if (!root.TryGetProperty("Type", out JsonElement typeElement))
            {
                throw new JsonException("Brak pola 'Type' przy deserializacji.");
            }

            string type = typeElement.GetString().ToLower();

            return type switch
            {
                "dzienny" => JsonSerializer.Deserialize<StudentDzienny>(root.GetRawText(), options),
                "zaoczny" => JsonSerializer.Deserialize<StudentZaoczny>(root.GetRawText(), options),
                _ => throw new JsonException($"Nieznany typ studenta: {type}")
            };
        }

        public override void Write(Utf8JsonWriter writer, Student value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}
