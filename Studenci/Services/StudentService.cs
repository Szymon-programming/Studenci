using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Studenci.Models;
using Studenci.Validators;
using Studenci.Utils;


namespace Studenci.Services
{

    public interface IServicable
    {
        public void SortByName();
        public void SortBySurname();
        public void SortByAge();

        public void SortByField();

        public void SortByType();
    }
    public class StudentService : IServicable
    {
        private List<Student> students = new();
        public IndexValidator validator = new();
        private int howMuchDziennych;
        private int howMuchZaocznych;

        public void RemoveStudentByNameAndSurname()
        {
            Console.Write("Podaj imię studenta: ");
            string name = Console.ReadLine();
            var names = students.Where(a => a.Name == name);
            int howMuch = names.Count();
            if(howMuch == 0)
            {
                Console.WriteLine("Nie znaleziono studenta o podanym imieniu.");
            }
            else if(howMuch == 1)
            {
                Console.Write($"Czy chcesz usunąć studenta: ");
                foreach (var student in names) Console.WriteLine(student);
                string yesOrNo;
                Console.Write(@"tak\nie: ");
                yesOrNo = Console.ReadLine().ToLower();
                switch (yesOrNo)
                {
                    case "tak":
                        Console.Write($"Usunięto studenta: ");
                        foreach (var student in names) Console.WriteLine(student);
                        var toRemove = names.ToList();
                        foreach (var item in toRemove)
                        {
                            students.Remove(item);
                            validator.RemoveIndexWithStudent(item.Index);
                        }
                        break;
                    case "no":
                        break;
                    default:
                        Console.WriteLine("podano nie prawidłową wartość.");
                        break;
                }
            }
            else if(howMuch > 1)
            {
                Console.WriteLine("Musisz podać nazwisko studenta, ponieważ jest\n więcej niż jeden student o podanym imieniu");
                Console.Write("Podaj nazwisko studenta: ");
                string surname = Console.ReadLine();
                var surnames = names.Where(a => a.Surname == surname);
                int howMuchsurnames = surnames.Count();
                if(howMuchsurnames == 0)
                {
                    Console.WriteLine("Nie znaleziono studenta o podanym nazwisku.");
                }
                else if(howMuchsurnames == 1)
                {
                    Console.Write($"Czy chcesz usunąć studenta: ");
                    foreach (var student in surnames) Console.WriteLine(student);
                    string yesOrNo;
                    Console.Write(@"tak\nie: ");
                    yesOrNo = Console.ReadLine().ToLower();
                    switch (yesOrNo)
                    {
                        case "tak":
                            Console.Write($"Usunięto studenta: ");
                            foreach (var student in surnames) Console.WriteLine(student);
                            var toRemove = surnames.ToList();
                            foreach (var item in toRemove)
                            {
                                students.Remove(item);
                                validator.RemoveIndexWithStudent(item.Index);
                            }
                            break;
                        case "no":
                            break;
                        default:
                            Console.WriteLine("podano nie prawidłową wartość.");
                            break;
                    }
                }
                else if(howMuchsurnames > 1)
                {
                    Console.WriteLine("wiecej niż jeden student o podanym imieniu i nazwisku, musisz podać index.");
                    string index = Console.ReadLine();
                    RemoveStudentByIndex(index);
                }
            }
        }
        public void AddStudent()
        {
            Student student;
            while (true)
            {
                Console.WriteLine("Typ studenta (dzienny/zaoczny): ");
                string type = Console.ReadLine().ToLower();
                if (type == "zaoczny")
                {
                    student = new StudentZaoczny();
                    break;
                }
                else if (type == "dzienny")
                {
                    student = new StudentDzienny();
                    break;
                }
                else
                {
                    Console.WriteLine("Podano zły typ");
                }
            }
            string name;
            while (true)
            {
                Console.Write("Podaj imie: ");
                name = Console.ReadLine();
                if (PersonValidator.IsValidName(name) == true)
                {
                    student.Name = name;
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawne imie, spóbuj ponownie.");
                }
            }
            string surname;
            while (true)
            {
                Console.Write("Podaj Nazwisko: ");
                surname = Console.ReadLine();
                if (PersonValidator.IsValidName(surname) == true)
                {
                    student.Surname = surname;
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawne nazwisko, spóbuj ponownie.");
                }
            }
            int age;
            Console.Write("Podaj wiek: ");
            age = int.Parse(Console.ReadLine());
            while (true)
            {
                if (age < 10 || age > 125)
                {
                    Console.WriteLine("Podano zły wiek spróbuj ponownie. ");
                }
                else
                {
                    student.Age = age;
                    break;
                }
            }
            string direction;
            bool rightDirection = false;
            do
            {
                Console.Write("Podaj kierunek: ");
                direction = Console.ReadLine();
                string directionWszystkieMale = direction.ToLower();
                switch (directionWszystkieMale)
                {
                    case "informatyka":
                        student.FieldOfStudy = "Informatyka";
                        rightDirection = true;
                        break;
                    case "matematyka":
                        student.FieldOfStudy = "Matematyka";
                        rightDirection = true;
                        break;
                    case "biotechnologia":
                        student.FieldOfStudy = "Biotechnologia";
                        rightDirection = true;
                        break;
                    case "fizyka":
                        student.FieldOfStudy = "Fizyka";
                        rightDirection = true;
                        break;
                    default:
                        Console.WriteLine("Podano zły kierunek, spróbuj ponownie.");
                        break;
                }
            }
            while (!rightDirection);
            string index;
            while (true)
            {
                Console.Write("Podaj indeks: ");
                index = Console.ReadLine();
                if (validator.TryAddIndex(index) == true)
                {
                    student.Index = index;
                    validator.TryAddIndex(index);
                    break;
                }
                else
                {
                    Console.WriteLine("Podano zły indeks spróbuj ponownie.");
                }
            }

            students.Add(student);
            //AutoSave();
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
                //AutoSave();
                break;
            }
            if (howmuch == 0)
            {
                Console.WriteLine($"Student o numerze indeksu: {index} nie został odnaleziony!");
            }
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
            if (HowMuch == 0)
            {
                Console.WriteLine("Nie znaleziono żadnego studenta o podanym imieniu.");
            }
        }

        public void FindStudentBySurname(string surname)
        {
            int HowMuch = 0;
            foreach (Student student in students)
            {
                if (student.Surname == surname)
                {
                    Console.WriteLine(student);
                    HowMuch++;
                }
            }
            if (HowMuch == 0)
            {
                Console.WriteLine("Nie znaleziono żadnego studenta o podanym nazwisku.");
            }
        }

        public void FindStudentByIndex(string index)
        {
            int HowMuch = 0;
            foreach (Student student in students)
            {
                if (student.Index == index)
                {
                    Console.WriteLine(student);
                    HowMuch++;
                }
            }
            if (HowMuch == 0)
            {
                Console.WriteLine("Nie znaleziono studenta o podanym indeksie.");
            }
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

        public void HowMuchStudentsOnDirectField()
        {
            var studentsOnIT = students.Where(a => a.FieldOfStudy == "Informatyka");

            Console.WriteLine($"Informatyka: {studentsOnIT.Count()}");

            var studentsOnPhysics = students.Where(a => a.FieldOfStudy == "Fizyka");

            Console.WriteLine($"Fizyka: {studentsOnPhysics.Count()}");

            var studentsOnMathematica = students.Where(a => a.FieldOfStudy == "Matematyka");

            Console.WriteLine($"Matematyka: {studentsOnMathematica.Count()}");

            var studentsOnBiotechnology = students.Where(a => a.FieldOfStudy == "Biotechnologia");

            Console.WriteLine($"Biotechnologia: {studentsOnBiotechnology.Count()}");
        }

            public void WriteDwonAllStudents()
        {
            //LoadFromJson("Student.json");
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
        }

        public void SortByField()
        {
            var sorted = students.OrderBy(a => a.FieldOfStudy).ToList();

            foreach (Student student in sorted)
            {
                Console.WriteLine(student);
            }
        }

        public void SortByName()
        {
            var nameSort = students.OrderBy(a => a.Name);

            foreach (var item in nameSort)
            {
                Console.WriteLine(item);
            }
        }

        public void SortBySurname()
        {
            var surnameSort = students.OrderBy(a => a.Surname);

            foreach (var item in surnameSort)
            {
                Console.WriteLine(item);
            }
        }

        public void CountStudentsByType()
        {
            int dzienni = students.Count(s => s is StudentDzienny);
            int zaoczni = students.Count(s => s is StudentZaoczny);

            Console.WriteLine($"Studenci dzienni: {dzienni}");
            Console.WriteLine($"Studenci zaoczni: {zaoczni}");
        }

        public void SortByAge()
        {
            var ageSort = students.OrderBy(a => a.Age);

            foreach (var item in ageSort)
            {
                Console.WriteLine(item);
            }
        }

        //wrócić i ogarnąć jak to zrobić
        public void SortByType()
        {
            var sortedByType = students.OrderBy(s => s is StudentDzienny ? 0 : 1).ThenBy(s => s.Surname);

            foreach (var item in sortedByType)
            {
                Console.WriteLine(item);
            }
        }

        //public void SaveToJson(string path)
        //{
        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true,
        //        Converters = { new StudentJsonConverter() }
        //    };
        //    var json = JsonSerializer.Serialize(students, options);
        //    File.WriteAllText(path, json);
        //}

        //public void LoadFromJson(string path)
        //{
        //    if (!File.Exists(path)) return;
        //    var options = new JsonSerializerOptions
        //    {
        //        Converters = { new StudentJsonConverter() }
        //    };
        //    var json = File.ReadAllText(path);
        //    students = JsonSerializer.Deserialize<List<Student>>(json, options) ?? new();
        //    foreach (var student in students)
        //        validator.TryAddIndex(student.Index);
        //}

        //private void AutoSave() => SaveToJson("Student.json");
    }
}
