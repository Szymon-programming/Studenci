using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Studenci.Services;


namespace Studenci.UI
{
    public class UserInterface
    {

        private readonly StudentService service = new();
        private ChoiceService chooser = new();
        private void ShowMenu()
        {
            Console.WriteLine("==== MENU ADMINISTRATORA ====");
            Console.WriteLine("1. Dodaj studenta");
            Console.WriteLine("2. Usuń studenta");
            Console.WriteLine("3. Posortuj Studentów");
            Console.WriteLine("4. Podaj statystyki studentów");
            Console.WriteLine("5. Wyszukaj studenta");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybierz opcję: ");
        }

        public void Run()
        {

            service.LoadFromJson("Student.json");

            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        service.AddStudent();
                        break;
                    case "2":
                        chooser.RemoveChoice();
                        break;
                }
            }
        }
    }
}
