using Studenci;
using System.ComponentModel;
using Xunit;

namespace Student.Tests
{
    public class StudentServiceTests
    {
        [Category("AddStudent")]
        [Fact]
        public void AddStudent_ShouldAddStudent_WhenValid()
        {
            // Arrange
            var service = new StudentService();
            var student = new Studenci.Student("Jan", "Kowalski", 20, "Informatyka", "S123");

            // Act
            service.AddStudent(student);

            // Assert
            Assert.Equal(1, service.HowMuchStudentsWeHave());
        }

        [Category("AddStudent")]
        [Fact]
        public void AddStudent_ShouldNotAddDuplicateIndex()
        {
            // Arrange
            var service = new StudentService();
            var s1 = new Studenci.Student("Anna", "Nowak", 22, "Matematyka", "S001");
            var s2 = new Studenci.Student("Ewa", "Kowal", 21, "Fizyka", "S001"); // ten sam indeks!

            // Act
            service.AddStudent(s1);
            service.AddStudent(s2); // powinien zostaæ zignorowany

            // Assert
            Assert.Equal(1, service.HowMuchStudentsWeHave());
        }
    }
}