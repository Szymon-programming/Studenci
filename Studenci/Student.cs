using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Studenci
{
    public class Student
    {
        private string name;
        private string surname;
        private int age;
        private string fieldOfStudy;
        private string studentIndex;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public string FieldOfStudy { get => fieldOfStudy; set => fieldOfStudy = value; }

        public string StudentIndex { get => studentIndex; set => studentIndex = value; }

        public Student(string name, string surname, int age, string fieldOfStudy, string studentIndex)
        {
            Name = name;
            Surname = surname;
            Age = age;
            FieldOfStudy = fieldOfStudy;
            StudentIndex = studentIndex;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Age} {FieldOfStudy} {StudentIndex}";
        }
    }
}
