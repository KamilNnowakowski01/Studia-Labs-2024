using NUnit.Framework.Legacy;

namespace Labs2024_UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Addition_TwoPlusTwo_ReturnsFour()
        {
            // Arrange
            int number1 = 2;
            int number2 = 2;

            // Act
            int result = number1 + number2;
            // Assert
            ClassicAssert.AreEqual(4, result);
        }
    }
}