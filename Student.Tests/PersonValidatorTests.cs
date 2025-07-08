using Studenci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studenci.Validators;

namespace Student.Tests
{
    public class PersonValidatorTests
    {
        [Category("IsValidName")]
        [Theory]
        [InlineData("Amelia")]
        [InlineData("Szymon")]
        [InlineData("Leon")]
        public void IsValidName_ShouldReturnTrueWhenRightData(string name)
        {
            //Act
            bool result = PersonValidator.IsValidName(name);

            //Assert
            Assert.True(result);
        }

        [Category("IsValidName")]
        [Theory]
        [InlineData("")]
        [InlineData("Sz1on")]
        [InlineData("23.;")]
        public void IsValidName_ShouldReturnFalseWhenWrongData(string name)
        { 
            //Act
            bool result = PersonValidator.IsValidName(name);

            //Assert
            Assert.False(result);
        }
    }
}
