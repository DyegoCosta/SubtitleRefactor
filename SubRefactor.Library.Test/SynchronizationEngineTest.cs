using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SubRefactor.Library.Test
{
    [TestClass]
    public class SynchronizationEngineTest
    {
        [TestMethod]
        public void SynchronizationEngineConstructorTest()
        {
            //Arrange
            SynchronizationEngine target = new SynchronizationEngine();

            //Assert
            Assert.IsNotNull(target);
        }
    }
}
