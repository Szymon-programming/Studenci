using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Studenci
{
    public abstract class Student
    {
        private string name;
        private string surname;
        private int age;
        private string fieldOfStudy;
        private string index;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public string FieldOfStudy { get => fieldOfStudy; set => fieldOfStudy = value; }

        public string Index { get => index; set => index = value; }

        protected Student(string name, string surname, int age, string fieldOfStudy, string Index)
        {
            Name = name;
            Surname = surname;
            Age = age;
            FieldOfStudy = fieldOfStudy;
            Index = Index;
        }

        public abstract string GetStudentType();
        public override string ToString()
        {
            return $"[{Index}] {Name} {Surname}, {Age} lat, {FieldOfStudy} ({GetStudentType()})";
        }
    }
}
