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
                    Console.WriteLine("Podano nieprawidłową wartość");
                    return;
            }
        }

        public void SortChoice()
        {
            bool doYouWantToContinue = true;
            while (doYouWantToContinue == true)
            {
                Console.WriteLine("1. Posortuj po imieniu");
                Console.WriteLine("2. Posortuj po nazwisku");
                Console.WriteLine("3. Posortuj po wieku");
                Console.WriteLine("4. Posortuj po kierunku");
                Console.WriteLine("5. Posortuj po typie studiów");
                Console.Write("Wybór: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        service.SortByName();
                        break;
                    case "2":
                        Console.Clear();
                        service.SortBySurname();
                        break;
                    case "3":
                        Console.Clear();
                        service.SortByAge();
                        break;
                    case "4":
                        Console.Clear();
                        service.SortByField();
                        break;
                    case "5":
                        Console.Clear();
                        service.SortByType();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Podano złą wartość!");
                        return;
                }
                Console.WriteLine("Czy chcesz sortować dalej?");
                Console.Write("tak/nie: ");
                string yesNo = Console.ReadLine().ToLower();
                if (yesNo == "tak")
                {
                    doYouWantToContinue = true;
                }
                else if (yesNo == "nie")
                {
                    doYouWantToContinue = false;
                }
                else
                {
                    Console.WriteLine("Podano złą wartość!");
                }
            }
        }

        public void StatChoice()
        {
            bool doYouWantToContinue = true;
            while (doYouWantToContinue == true)
            {
                Console.WriteLine("1. Średnia wieku");
                Console.WriteLine("2. Najstarszy najmłodszy student");
                Console.WriteLine("3. ile osób na kierunku");
                Console.WriteLine("4. ilu sudentów dziennych, ilu zaocznych");
                Console.Write("Wybór: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        double avarageAge = service.MiddleStudentsAge();
                        Console.WriteLine($"Średni wiek studentów wynosi: {avarageAge}");
                        break;
                    case "2":
                        Console.Clear();
                        service.TheOldestAndYongestStudent();
                        break;
                    case "3":
                        Console.Clear();
                        service.HowMuchStudentsOnDirectField();
                        break;
                    case "4":
                        Console.Clear();
                        service.CountStudentsByType();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Podano złą wartość!");
                        return;
                }
                Console.WriteLine("Czy chcesz dalej przeglądać statystyki?");
                Console.Write("tak/nie: ");
                string yesNo = Console.ReadLine().ToLower();
                if(yesNo == "tak")
                {
                    doYouWantToContinue = true;
                }
                else if(yesNo == "nie")
                {
                    doYouWantToContinue = false;
                }
                else
                {
                    Console.WriteLine("Podano złą wartość!");
                }
            }
        }

        public void FindStudentChoice()
        {
            Console.WriteLine("1. Wyszukaj studenta po imieniu lub nazwisku");
            Console.WriteLine("2. Wyszukaj studenta po indeksie");
            Console.Write("Wybór: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("1. Wyszukaj po imieniu");
                    Console.WriteLine("2. Wyszukaj po nazwisku");
                    Console.Write("Wybór: ");
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
                    return;
            }
        }
    }
}
