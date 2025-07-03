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

            studentService.WriteDwonAllStudents();
            Console.WriteLine();

            //studentService.RemoveStudentByIndex("S009");

            //studentService.WriteDwonAllStudents();
            //Console.WriteLine();

            //studentService.RemoveStudentFromDirectField("Informatyka");
            //studentService.WriteDwonAllStudents();
            //Console.WriteLine();

            //Console.WriteLine(studentService.HowMuchStudentsWeHave());
            //Console.WriteLine(studentService.MiddleStudentsAge());
            //studentService.TheOldestAndYongestStudent();

        }
    }
}
