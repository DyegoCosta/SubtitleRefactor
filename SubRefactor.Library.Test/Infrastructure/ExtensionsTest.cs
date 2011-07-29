using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubRefactor.Library.Infrastructure;

namespace SubRefactor.Library.Test.Infrastructure
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void IsNegativeTrueTest()
        {
            //Arrange
            var target = -1;

            //Act
            var expected = true;
            var actual = target.IsNegative();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNegativeFalseTest()
        {
            //Arrange
            var target = 1;

            //Act
            var expected = false;
            var actual = target.IsNegative();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
