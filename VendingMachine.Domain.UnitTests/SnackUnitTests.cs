using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachine.Domain.UnitTests
{
    [TestClass]
    public class SnackUnitTests
    {
        [TestMethod]
        public void ChangeName_WithNameTigreton_ShouldUpdateTheSnackName()
        {
            // Arrange
            const string expectedName = "Tigreton";
            var snack = new Snack("KitKat", 10);

            // Act
            snack.ChangeName(expectedName);

            // Assert
            snack.Name.Should().Be(expectedName);
        }

        [TestMethod]
        public void ChangeName_GivenEmptyString_ShouldThrowArgumentNullException()
        {
            // Arrange
            var snack = new Snack("KitKat", 10);

            // Act
            Action changeNameAction = () =>  snack.ChangeName(string.Empty);

            // Assert
            changeNameAction.Should().Throw<ArgumentException>();
        }
    }
}
