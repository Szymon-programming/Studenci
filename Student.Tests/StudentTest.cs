//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Studenci.Models;

//namespace Student.Tests
//{
//    public  class StudentTest
//    {
//        [Category("StudentConstructor")]
//        [Fact]
        
//        public void StudentConstructor_MakeAnInstance_ReturnsGoodStudentData()
//        {
//            string expectedName = "Jan";
//            string expectedSurname = "Kowalski";
//            int expectedAge = 22;
//            string expectedFieldOfStudy = "Informatyka";
//            string expectedIndex = "S001";

//            //Act
//            var student = new Student(expectedName, expectedSurname, expectedAge, expectedFieldOfStudy, expectedIndex);

//            // Assert
//            Assert.Equal(expectedName, student.Name);
//            Assert.Equal(expectedSurname, student.Surname);
//            Assert.Equal(expectedAge, student.Age);
//            Assert.Equal(expectedFieldOfStudy, student.FieldOfStudy);
//            Assert.Equal(expectedIndex, student.Index);
//        }

//        [Category("ToString")]
//        [Fact]
//        public void ToString_ReturnsCorrectValue()
//        {
//            string expectedName = "Jan";
//            string expectedSurname = "Kowalski";
//            int expectedAge = 22;
//            string expectedFieldOfStudy = "Informatyka";
//            string expectedIndex = "S001";

//            //Act
//            var student = new Student(expectedName, expectedSurname, expectedAge, expectedFieldOfStudy, expectedIndex);

//            //Assert
//            Assert.Equal("[S001] Jan Kowalski 22 Informatyka", student.ToString());
//        }
//    }
//}
