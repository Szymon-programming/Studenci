using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenci
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            var s1 = new Student("Anna", "Kowalska", 21, "Informatyka", "S001");
            var s2 = new Student("Michał", "Nowak", 22, "Matematyka", "S002");
            var s3 = new Student("Katarzyna", "Wiśniewska", 20, "Informatyka", "S003");
            var s4 = new Student("Tomasz", "Zieliński", 23, "Fizyka", "S004");
            var s5 = new Student("Paulina", "Wójcik", 24, "Informatyka", "S005");
            var s6 = new Student("Jakub", "Kamiński", 21, "Matematyka", "S006");
            var s7 = new Student("Magdalena", "Dąbrowska", 22, "Biotechnologia", "S007");
            var s8 = new Student("Adam", "Lewandowski", 25, "Informatyka", "S008");

            studentService.AddStudent(s1);
            studentService.AddStudent(s2);
            studentService.AddStudent(s3);
            studentService.AddStudent(s4);
            studentService.AddStudent(s5);
            studentService.AddStudent(s6);
            studentService.AddStudent(s7);
            studentService.AddStudent(s8);

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


            /* SYSTEM OBSŁUGI STUDENTÓW WERSJA NA 03.07.2025 4 DZIEŃ NAUKI(LINQ, LIST<T>) */

            Console.WriteLine("Wybierz jedną z opcji, co chcesz zrobić: ");
            Console.WriteLine("1: Wyświetl listę studentów.");
            Console.WriteLine("2: Dodaj Studenta.");
            Console.WriteLine("3: Usuń Studenta.");
            Console.WriteLine("4: Posortuj Studentów po kierunku.");
            Console.WriteLine("5: Wyjdź.");

            string wybor = Console.ReadLine();
            switch(wybor)
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
                    return;
                default: Console.WriteLine("nieprawidłowy wybór!!!");
                    break;
            }
        }
    }
}
