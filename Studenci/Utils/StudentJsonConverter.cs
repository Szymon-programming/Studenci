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
            using var doc = JsonDocument.ParseValue(ref reader);
            var type = doc.RootElement.GetProperty("Type").GetString();
            var json = doc.RootElement.GetRawText();

            return type switch
            {
                "Dzienny" => JsonSerializer.Deserialize<StudentDzienny>(json, options),
                "Zaoczny" => JsonSerializer.Deserialize<StudentZaoczny>(json, options),
                _ => throw new NotSupportedException($"Nieobsługiwany typ studenta: {type}")
            };
        }

        public override void Write(Utf8JsonWriter writer, Student value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}
