using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenci
{
    public class StudentDzienny: Student
    {
        private double stypendium;

        public double Stypendium { get => stypendium; set => stypendium = value; }

        public StudentDzienny(string name, string surname, int age, string fieldOfStudy, string index, double stypendium) : base(name, surname, age, fieldOfStudy, index)
        {
            Stypendium = stypendium;
        }

        public override string GetStudentType() => "Dzienny";
    }
}
