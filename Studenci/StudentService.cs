using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Studenci
{
    public class StudentService
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            if(!students.Contains(student))
            {
                students.Add(student);
            }
            else
            {
                Console.WriteLine($"Student o numerze indeksu: {student.StudentIndex} jest już na liście!");
            }
        }

        public void RemoveStudentByIndex(string index)
        {
            int howmuch = 0;
            var ThisOne = students.Where(a => a.StudentIndex == index);

            foreach (var item in ThisOne)
            {
                students.Remove(item);
                Console.WriteLine($"Usunięto studenta o nmumerze indeksu {index}");
                howmuch++;
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
                if(student.StudentIndex == index)
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

        public void ChangeStudentData()
        {

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
            foreach(Student student in students)
            {
                Console.WriteLine(student);
            }
        }

    }
}
