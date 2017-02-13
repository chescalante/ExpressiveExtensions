using NUnit.Framework;
using Shouldly;
using ExpressiveExtensions.Core;

namespace ExpressiveExtensions.UnitTest
{
    [TestFixture]
    public class StringAddTests
    {
        [Test]
        public void AddPrefix_ShouldReturn_A_Complete_Sentence()
        {
            // Arrange
            string s = " World!";
            string prefix = "Hello,";

            // Act
            string results = s.AddPrefix(prefix);

            // Assert
            results.ShouldBe("Hello, World!");
        }
    }
}
