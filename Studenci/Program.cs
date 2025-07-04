using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Studenci
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            studentService.LoadFromJson("students.json", false);

            //studentService.WriteDwonAllStudents();
            //Console.WriteLine();

            //studentService.RemoveStudentByIndex("S009");

            //studentService.WriteDwonAllStudents();
            //Console.WriteLine();

            //studentService.RemoveStudentFromDirectField("Informatyka");
            //studentService.WriteDwonAllStudents();
            //Console.WriteLine();

            //Console.WriteLine(studentService.HowMuchStudentsWeHave());
            //Console.WriteLine(studentService.MiddleStudentsAge());
            //studentService.TheOldestAndYongestStudent();


            /* SYSTEM OBSŁUGI STUDENTÓW WERSJA NA 04.07.2025 5 DZIEŃ NAUKI(Serjalizacja i Deserializacja) */

            bool czykoniec = false;
            while (czykoniec == false)
            {
                Console.WriteLine("Czy chcesz kontynuować, wpisz 1 jeśli chcesz przejść do okna wyboru, wpisz KONIEC, jeśli chcesz zakończyć.");
                Console.Write("Wpisz 1 lub KONIEC, jeśli najpierw chcesz wyczyścić tablicę wpisz tak: ");
                string jedenCzyKoniec = Console.ReadLine();
                switch (jedenCzyKoniec)
                {
                    case "1":
                        Console.WriteLine("1: Wyświetl listę studentów.");
                        Console.WriteLine("2: Dodaj Studenta.");
                        Console.WriteLine("3: Usuń Studenta.");
                        Console.WriteLine("4: Posortuj Studentów po kierunku.");
                        Console.WriteLine("5: Wyjdź.");

                        Console.Write("Wpisz wybraną opcję [1,2,3,4 lub 5]: ");
                        string wybor = Console.ReadLine().ToLower();
                        switch (wybor)
                        {
                            case "1":
                                studentService.WriteDwonAllStudents();
                                break;
                            case "2":
                                studentService.AddStudent();
                                break;
                            case "3":
                                string index;
                                Console.Write("Podaj indeks studenta do usunięcia z listy studentów: ");
                                index = Console.ReadLine();
                                studentService.RemoveStudentByIndex(index);
                                break;
                            case "4":
                                Console.WriteLine("Posortowani studenci: ");
                                studentService.SotrByField();
                                break;
                            case "5":
                                czykoniec = true;
                                Console.WriteLine("Zamykanie menu wyboru");
                                break;
                            default:
                                Console.WriteLine("nieprawidłowy wybór!!!");
                                break;
                        }
                        break;
                    case "koniec":
                        Console.WriteLine("Zamykanie menu wyboru!");
                        czykoniec = true;
                        break;
                    case "tak":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Podano nieprawidłową wartość!");
                        break;
                }
            }
        }
    }
}
