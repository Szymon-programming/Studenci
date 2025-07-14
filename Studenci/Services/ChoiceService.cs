using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Studenci.Validators;

namespace Studenci.Services
{
    public class ChoiceService
    {
        private StudentService service;
        private IndexValidator validator;

        public ChoiceService(StudentService service, IndexValidator validator)
        {
            this.service = service;
            this.validator = validator;
        }
        public void RemoveChoice()
        {
            Console.WriteLine("1. Usuń studenta po imieniu i nazwisku");
            Console.WriteLine("2. Usuń studenta po indeksie");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();
            
            switch(choice)
            {
                case "1":
                    service.RemoveStudentByNameAndSurname();
                    break;
                case "2":
                    Console.Write("Podaj indeks: ");
                    string index = Console.ReadLine();
                    bool valid = validator.TryAddIndex(index);
                    if(valid == false)
                    {
                        service.RemoveStudentByIndex(index);
                        validator.RemoveIndexWithStudent(index);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono podanego indeksu");
                        break;
                    }
                default:
                    Console.WriteLine("Podano zła wartość");
                    break;
            }
        }

        public void SortChoice()
        {
            Console.WriteLine("1. Posortuj po imieniu");
            Console.WriteLine("2. Posortuj po nazwisku");
            Console.WriteLine("3. Posortuj po wieku");
            Console.WriteLine("4. Posortuj po kierunku");
            Console.WriteLine("5. Posortuj po typie studiów");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    service.SortByName();
                    break;
                case "2":
                    service.SortBySurname();
                    break;
                case "3":
                    service.SortByAge();
                    break;
                case "4":
                    service.SortByField();
                    break;
                case "5":
                    service.SortByType();
                    break;
                default:
                    Console.WriteLine("Podano złą wartość!");
                    break;
            }
        }

        public void StatChoice()
        {
            Console.WriteLine("1. Średnia wieku");
            Console.WriteLine("2. Najstarszy najmłodszy student");
            Console.WriteLine("3. ile osób na kierunku");
            Console.WriteLine("4. ilu sudentów dziennych, ilu zaocznych");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    double averageAge = service.MiddleStudentsAge();
                    Console.WriteLine($"Sredni wiek studentów wynosi: {averageAge}");
                    break;
                case "2":
                    service.TheOldestAndYongestStudent();
                    break;
                case "3":
                    service.HowMuchStudentsOnDirectField();
                    break;
                case "4":
                    service.CountStudentsByType();
                    break;
                default:
                    Console.WriteLine("Podano złą wartość!");
                    break;
            }
        }

        public void FindStudentChoice()
        {
            Console.WriteLine("1. Wyszukaj studenta po imieniu lub nazwisku");
            Console.WriteLine("2. Wyszukaj studenta po indeksie");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("1. Wyszukaj po imieniu");
                    Console.WriteLine("2. Wyszukaj po nazwisku");
                    string nameOrSurname = Console.ReadLine();
                    switch (nameOrSurname)
                    {
                        case "1":
                            Console.Write("Podaj imie studenta: ");
                            string name = Console.ReadLine();
                            service.FindStudentByName(name);
                            break;
                        case "2":
                            Console.WriteLine("Podaj nazwisko studenta: ");
                            string surname = Console.ReadLine();
                            service.FindStudentBySurname(surname);
                            break;
                        default:
                            Console.WriteLine("podano złą wartość!");
                            break;
                    }
                    break;
                case "2":
                    Console.Write("Podaj indeks: ");
                    string index = Console.ReadLine();
                    service.FindStudentByIndex(index);
                    break;
                default:
                    Console.WriteLine("Podano złą warość!");
                    break;
            }
        }
    }
}
