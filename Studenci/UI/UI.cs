using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Studenci.Services;
using Studenci.Validators;


namespace Studenci.UI
{
    public class UserInterface
    {

        private readonly StudentService service = new();
        private readonly IndexValidator validator;
        private readonly ChoiceService chooser;

        public UserInterface()
        {
            validator = service.validator;
            chooser = new ChoiceService(service, validator);
        }
        private void ShowMenu()
        {
            Console.WriteLine("==== MENU ADMINISTRATORA ====");
            Console.WriteLine("1. Wyświetl listę studentów");
            Console.WriteLine("2. Dodaj studenta");
            Console.WriteLine("3. Usuń studenta");
            Console.WriteLine("4. Posortuj Studentów");
            Console.WriteLine("5. Podaj statystyki studentów");
            Console.WriteLine("6. Wyszukaj studenta");
            Console.WriteLine("7. Wyjście");
            Console.Write("Wybierz opcję: ");
        }

        public void Run()
        {

            service.LoadFromJson();
            bool theEnd = false;
            while (theEnd == false)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        service.WriteDwonAllStudents();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.Clear();
                        service.AddStudent();
                        service.SaveToJson();
                        break;
                    case "3":
                        Console.Clear();
                        chooser.RemoveChoice();
                        service.SaveToJson();
                        break;
                    case "4":
                        Console.Clear();
                        chooser.SortChoice();
                        break;
                    case "5":
                        Console.Clear();
                        chooser.StatChoice();
                        break;
                    case "6":
                        Console.Clear();
                        chooser.FindStudentChoice();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Zamykanie programu");
                        theEnd = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Podano złą wartość.");
                        break;
                }
            }
        }
    }
}
