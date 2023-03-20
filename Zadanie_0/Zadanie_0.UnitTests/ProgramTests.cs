using NUnit.Framework;
using Zadanie_0;

namespace Zadanie_0.UnitTests
{
    public class ProgramTests
    {
        [Test]
        public void Main_PrintsHelloWorld()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer); // wczytuje output konsoli do zmiennej writer

            // Act
            Program.Main(new string[0]);
            var output = writer.ToString().Trim();

            // Assert
            Assert.AreEqual("Hello world", output);
        }
    }
}