using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubRefactor.Library.Languages;

namespace SubRefactor.Library.Test.Languages
{
    [TestClass]
    public class ServicesLanguagesTest
    {
        [TestMethod]
        public void GetBingLanguagesTest()
        {
            //Arrange
            var target = new ServicesLanguages();

            //Act
            var languages = target.GetBingLanguages();
            var expected = 34;

            //Assert
            Assert.AreEqual(expected, languages.Count);
        }

        [TestMethod]
        public void GetGoogleLanguagesTest()
        {
            //Arrange
            var target = new ServicesLanguages();

            //Act
            var languages = target.GetGoogleLanguages();
            var expected = 52;

            //Assert
            Assert.AreEqual(expected, languages.Count);
        }
    }
}
