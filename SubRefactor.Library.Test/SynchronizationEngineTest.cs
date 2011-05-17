using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SubRefactor.Domain;

namespace SubRefactor.Library.Test
{
    [TestClass]
    public class SynchronizationEngineTest
    {
        private IList<Quote> quotes = new List<Quote>();

        [TestInitialize]
        public void Start()
        {
            quotes.Add(
                new Quote()
                    {
                        Index = "1",
                        BeginTimeLine = DateTime.Now.TimeOfDay.ToString(),
                        EndTimeLine = DateTime.Now.TimeOfDay.ToString(),
                        QuoteLine = "Hello"
                    }
                );
            quotes.Add(
                new Quote()
                    {
                        Index = "2",
                        BeginTimeLine = DateTime.Now.TimeOfDay.ToString(),
                        EndTimeLine = DateTime.Now.TimeOfDay.ToString(),
                        QuoteLine = "World"
                    }
                );
        }

        [TestMethod]
        public void SynchronizationEngineConstructorTest()
        {
            //Arrange
            SynchronizationEngine target = new SynchronizationEngine();

            //Assert
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void SyncSubtitleIncreaseDelayTest()
        {
            //Arrange
            SynchronizationEngine target = new SynchronizationEngine();
            var beginTimeLine = TimeSpan.Parse(quotes[0].BeginTimeLine);
            var endTimeLine = TimeSpan.Parse(quotes[0].EndTimeLine);

            //Act
            var expected = new string[2]{
                (beginTimeLine.Add(TimeSpan.Parse("00:01:15.100"))).ToString(),
                (endTimeLine.Add(TimeSpan.Parse("00:01:15.100"))).ToString()
            };
            target.SyncSubtitle(quotes, TimeSpan.Parse("00:01:15.100"), false);            

            //Assert
            Assert.AreEqual(quotes[0].BeginTimeLine, expected[0]);
            Assert.AreEqual(quotes[1].BeginTimeLine, expected[1]);
        }

        [TestMethod]
        public void SyncSubtitleDecreaseDelayTest()
        {
            //Arrange
            SynchronizationEngine target = new SynchronizationEngine();
            var beginTimeLine = TimeSpan.Parse(quotes[0].BeginTimeLine);
            var endTimeLine = TimeSpan.Parse(quotes[0].EndTimeLine);

            //Act
            var expected = new string[2]{
                (beginTimeLine.Subtract(TimeSpan.Parse("00:01:15.100"))).ToString(),
                (endTimeLine.Subtract(TimeSpan.Parse("00:01:15.100"))).ToString()
            };
            target.SyncSubtitle(quotes, TimeSpan.Parse("00:01:15.100"), true);

            //Assert
            Assert.AreEqual(quotes[0].BeginTimeLine, expected[0]);
            Assert.AreEqual(quotes[1].BeginTimeLine, expected[1]);
        }
    }
}
