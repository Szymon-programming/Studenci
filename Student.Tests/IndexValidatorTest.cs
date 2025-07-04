using Studenci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Tests
{
    public class IndexValidatorTest
    {
        [Category("GetAllIndexes")]
        [Fact]
        public void GetAllIndexes_ShouldCorrectlyReturnIndexes()
        {
            //Arrange
            var validator = new IndexValidator();
            var ExpectedIndexes = new List<string> { "S001", "S002", "S003" };

            foreach (var index in ExpectedIndexes)
            {
                validator.TryAddIndex(index);
            }

            //Act
            var result = validator.GetAllIndexes().ToList();

            //Assert
            Assert.Equal(ExpectedIndexes.Count, result.Count);
            foreach (var index in ExpectedIndexes)
            {
                Assert.Contains(index, result);
            }
        }

        [Category("GetAllIndexes")]
        [Fact]
        public void GetAllIndexes_ShouldReturnEmpty_WhenNoIndexesAdded()
        {
            // Arrange
            var validator = new IndexValidator();

            // Act
            var result = validator.GetAllIndexes();

            // Assert
            Assert.Empty(result);
        }

        [Category("Exists")]
        [Fact]
        public void Exists_ShouldReturnTrueWhenIndexExists()
        {
            var validator = new IndexValidator();
            string index = "S001";
            validator.TryAddIndex(index);

            //Act
            var result = validator.Exists(index);

            Assert.True(result);
        }

        [Category("Exists")]
        [Fact]
        public void Exists_ShouldReturnFalseWhenIndexDoesntExists()
        {
            var validator = new IndexValidator();
            string index = "S001";

            //Act
            var result = validator.Exists(index);

            Assert.False(result);
        }

        [Category("TryAddIndex")]
        [Fact]
        public void TryAddIndex_ShouldReturnTrue_WhenIndexIsValidAndNotUsed()
        {
            // Arrange
            var validator = new IndexValidator();
            string newIndex = "S001";

            // Act
            bool result = validator.TryAddIndex(newIndex);

            // Assert
            Assert.True(result);
        }

        [Category("TryAddIndex")]
        [Fact]
        public void TryAddIndex_ShouldReturnFalse_WhenIndexAlreadyExists()
        {
            // Arrange
            var validator = new IndexValidator();
            string index = "S002";

            // Act
            validator.TryAddIndex(index); // pierwszy raz
            bool result = validator.TryAddIndex(index); // drugi raz

            // Assert
            Assert.False(result);
        }

        [Category("TryAddIndex")]
        [Theory]
        [InlineData("123")]     // Brak litery S
        [InlineData("s001")]    // Małe "s"
        [InlineData("S12")]     // Za krótki
        [InlineData("S0011")]   // Za długi
        [InlineData("SABC")]    // Litery po S
        public void TryAddIndex_ShouldReturnFalse_WhenIndexIsInvalidFormat(string invalidIndex)
        {
            // Arrange
            var validator = new IndexValidator();

            // Act
            bool result = validator.TryAddIndex(invalidIndex);

            // Assert
            Assert.False(result);
        }
    }
}
