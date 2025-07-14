using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Studenci.Models
{
    public abstract class Student
    {
        private string name;
        private string surname;
        private int age;
        private string fieldOfStudy;
        private string index;

        [JsonPropertyName("Imie")]
        public string Name { get => name; set => name = value; }
        [JsonPropertyName("Nazwisko")]
        public string Surname { get => surname; set => surname = value; }
        [JsonPropertyName("Wiek")]
        public int Age { get => age; set => age = value; }
        [JsonPropertyName("Kierunek")]
        public string FieldOfStudy { get => fieldOfStudy; set => fieldOfStudy = value; }

        public string Index { get => index; set => index = value; }

        public Student() { }

        protected Student(string name, string surname, int age, string fieldOfStudy, string index)
        {
            Name = name;
            Surname = surname;
            Age = age;
            FieldOfStudy = fieldOfStudy;
            Index = index;
        }
        public abstract string Type { get; }
        public override string ToString()
        {
            return $"[{Index}] {Name} {Surname}, {Age} lat, {FieldOfStudy} ({Type})";
        }
    }
}
