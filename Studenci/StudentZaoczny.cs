using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenci
{
    public class StudentZaoczny : Student
    {
        private double czesne;

        public double Czesne { get => czesne; set => czesne = value; }

        public StudentZaoczny(string name, string surname, int age, string fieldOfStudy, string index, double czesne) 
            : base(name, surname, age, fieldOfStudy, index)
        {
            Czesne = czesne;
        }

        public override string GetStudentType() => "Zaoczny";
        
    }
}
