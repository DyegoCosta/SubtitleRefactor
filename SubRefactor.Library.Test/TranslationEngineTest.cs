using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubRefactor.Library;

namespace SyncSub.Library.Test
{
    [TestClass]
    public class TranslationEngineTest
    {
        [TestMethod]
        public void TranslateGoogleTest()
        {
            //Arrange
            var target = new TranslationEngine();

            //Act
            var actual = target.Translate(Translators.Google, "Hello", "en", "pt");
            var expected = "Olá";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TranslateBingTest()
        {
            //Arrange
            var target = new TranslationEngine();

            //Act
            var actual = target.Translate(Translators.Bing, "Hello", "en", "pt");
            var expected = "Olá";

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
