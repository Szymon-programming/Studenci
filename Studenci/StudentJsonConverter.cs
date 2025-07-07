using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Studenci
{
    public class StudentJsonConverter : JsonConverter<Student>
    {
        public override Student Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            var jsonObject = document.RootElement;

            if (!jsonObject.TryGetProperty("GetStudentType", out var typeProp))
                throw new JsonException("Brakuje typu studenta");

            string? type = typeProp.GetString();

            // Odczytujemy wspólne dane
            string name = jsonObject.GetProperty("Name").GetString();
            string surname = jsonObject.GetProperty("Surname").GetString();
            int age = jsonObject.GetProperty("Age").GetInt32();
            string fieldOfStudy = jsonObject.GetProperty("FieldOfStudy").GetString();
            string studentIndex = jsonObject.GetProperty("StudentIndex").GetString();

            // Tworzymy odpowiedni typ na podstawie tego co przeczytaliśmy:
            switch (type)
            {
                case "Dzienny":
                    int stypendium = jsonObject.GetProperty("Stypendium").GetInt32();
                    return new StudentDzienny(name, surname, age, fieldOfStudy, studentIndex, stypendium);
                case "Zaoczny":
                    int czesne = jsonObject.GetProperty("Czesne").GetInt32();
                    return new StudentZaoczny(name, surname, age, fieldOfStudy, studentIndex, czesne);
                default:
                    throw new JsonException($"Nieznany typ studenta: {type}");
            }
        }

        public override void Write(Utf8JsonWriter writer, Student value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("Name", value.Name);
            writer.WriteString("Surname", value.Surname);
            writer.WriteNumber("Age", value.Age);
            writer.WriteString("FieldOfStudy", value.FieldOfStudy);
            writer.WriteString("StudentIndex", value.Index);
            writer.WriteString("GetStudentType", value.GetStudentType());

            if (value is StudentDzienny dzienny)
            {
                writer.WriteNumber("Stypendium", dzienny.Stypendium);
            }
            else if (value is StudentZaoczny zaoczny)
            {
                writer.WriteNumber("Czesne", zaoczny.Czesne);
            }

            writer.WriteEndObject();
        }
    }
}
