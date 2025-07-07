using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studenci.Validators;

namespace Studenci.Services
{
    public class ChoiceService
    {
        private readonly StudentService service = new();
        private readonly IndexValidator validator = new();
        public void RemoveChoice()
        {
            Console.WriteLine("1. Usuń studenta po imieniu i nazwisku");
            Console.WriteLine("2. Usuń studenta po indeksie");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();
            
            switch(choice)
            {
                case "1":

                    break;
                case "2":
                    Console.Write("Podaj indeks: ");
                    string index = Console.ReadLine();
                    bool valid = validator.TryAddIndex(index);
                    if (valid == true)
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
            }

        }
    }
}
