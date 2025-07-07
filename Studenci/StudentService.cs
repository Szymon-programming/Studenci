using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Studenci
{
    public class StudentService
    {
        private List<Student> students = new List<Student>();
        public IndexValidator validator = new IndexValidator();

        public void AddStudent()
        {
            string imie;
            while(true)
            {
                Console.Write("Podaj imie: ");
                imie = Console.ReadLine();
                if (PersonValidator.IsValidName(imie) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawne imie, spóbuj ponownie.");
                }
            }
            string nazwisko;
            while (true)
            {
                Console.Write("Podaj Nazwisko: ");
                nazwisko = Console.ReadLine();
                if (PersonValidator.IsValidName(nazwisko) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawne nazwisko, spóbuj ponownie.");
                }
            }
            int wiek;
            Console.Write("Podaj wiek: ");
            wiek = int.Parse(Console.ReadLine());
            while (true)
            {
                if (wiek < 10 || wiek > 125)
                {
                    Console.WriteLine("Podano zły wiek spróbuj ponownie. ");
                }
                else
                {
                    break;
                }
            }
            string kierunek;
            bool poprawny_kierunek = false;
            do
            {
                Console.Write("Podaj kierunek: ");
                kierunek = Console.ReadLine();
                string kierunekWszystkieMale = kierunek.ToLower();
                switch (kierunekWszystkieMale)
                {
                    case "informatyka":
                        kierunek = "Informatyka";
                        poprawny_kierunek = true;
                        break;
                    case "matematyka":
                        kierunek = "Matematyka";
                        poprawny_kierunek = true;
                        break;
                    case "biotechnologia":
                        kierunek = "Biotechnologia";
                        poprawny_kierunek = true;
                        break;
                    case "fizyka":
                        kierunek = "Fizyka";
                        poprawny_kierunek = true;
                        break;
                    default:
                        Console.WriteLine("Podano zły kierunek, spróbuj ponownie.");
                        break;
                }
            }
            while (!poprawny_kierunek);
            string indeks;
            while (true)
            {
                Console.Write("Podaj indeks: ");
                indeks = Console.ReadLine();
                if (validator.TryAddIndex(indeks) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Podano zły indeks spróbuj ponownie.");
                }
            }

            Student student = new Student(imie, nazwisko, wiek, kierunek, indeks);

            students.Add(student);
            AutoSave();
        }
        public void AddStudent(Student student)
        {
            if(!students.Contains(student) && validator.TryAddIndex(student.Index) == true)
            {
                validator.TryAddIndex(student.Index);
                students.Add(student);
                AutoSave();
            }
            else
            {
                Console.WriteLine($"Student o numerze indeksu: {student.Index} jest już na liście!");
            }
        }

        public void RemoveStudentByIndex(string index)
        {
            int howmuch = 0;
            var ThisOne = students.Where(a => a.Index == index);

            foreach (var item in ThisOne)
            {
                students.Remove(item);
                Console.WriteLine($"Usunięto studenta o nmumerze indeksu {index}");
                howmuch++;
                AutoSave();
                break;
            }
            if(howmuch == 0)
            {
                Console.WriteLine($"Student o numerze indeksu: {index} nie został odnaleziony!");
            }
        }

        public void RemoveStudentFromDirectField(string Field)
        {
            students.RemoveAll(s => s.FieldOfStudy == Field);
            Console.WriteLine($"Usunięto studentów z kierunku: {Field}");
            AutoSave();
        }

        public void FindStudentByName(string name)
        {
            int HowMuch = 0;
            foreach (Student student in students)
            {
                if (student.Name == name)
                {
                    Console.WriteLine(student);
                    HowMuch++;
                }
            }
            if(HowMuch == 0)
            {
                Console.WriteLine("Nie znaleziono żadnego studenta o podanym imieniu.");
            }
        }

        public void FindStudentByIndex(string index)
        {
            int HowMuch = 0;
            foreach (Student student in students)
            {
                if(student.Index == index)
                {
                    Console.WriteLine(student);
                    HowMuch++;
                }
            }
            if(HowMuch == 0)
            {
                Console.WriteLine("Nie znaleziono studenta o podanym indeksie.");
            }
        }

        public void FindEveryOneOlderThan(int age)
        {
            var olderThan = students.Where(a => a.Age > age);

            int howMuch = olderThan.Count();
            if (howMuch > 0)
            {
                foreach (Student student in olderThan)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine($"Nie znaleziono studentów starszych niż {age} lat");
            }
        }

        public int HowMuchStudentsWeHave()
        {
            var HowMuch = students.Count();
            return HowMuch;
        }

        public double MiddleStudentsAge()
        {
            var StudentsMiddleAge = students.Average(a => a.Age);
            return StudentsMiddleAge;
        }

        public void TheOldestAndYongestStudent()
        {
            var TheOldest = students.OrderByDescending(a => a.Age).FirstOrDefault();
            var TheYongest = students.OrderBy(a => a.Age).FirstOrDefault();

            Console.WriteLine(TheOldest);
            Console.WriteLine(TheYongest);
        }

        public void WriteDwonAllStudents()
        {
            LoadFromJson("students.json", true);
        }

        public void SotrByField()
        {
            var sorted = students.OrderBy(a => a.FieldOfStudy).ToList();

            foreach (Student student in sorted)
            {
                Console.WriteLine(student);
            }
        }

        public void SaveToJson(string path)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new StudentJsonConverter() }
            };
            string json = JsonSerializer.Serialize(students, options);
            File.WriteAllText(path, json);
        }

        public void LoadFromJson(string path, bool doyouWantToWriteDown)
        {
            if(File.Exists(path))
            {
                var options = new JsonSerializerOptions
                {
                    Converters = { new StudentJsonConverter() }
                };
                string json = File.ReadAllText(path);
                var loaded = JsonSerializer.Deserialize<List<Student>>(json, options);
                if (loaded != null)
                {
                    students = loaded;
                    validator.LoadUsedIndexes(students);
                }
            }

            if(doyouWantToWriteDown == true)
            {
                foreach (var item in students)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void AutoSave()
        {
            SaveToJson("students.json");
        }
    }
}
