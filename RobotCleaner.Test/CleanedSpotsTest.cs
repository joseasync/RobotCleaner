using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RobotCleaner.Test
{
    public class CleanedSpotsTest
    {
        private IRobotIA _myRobotCleaner;


        [Theory]
        [MemberData(nameof(GetArrangeShouldClean), parameters: 5)]
        public void ShouldClean(int numberofcommands, int coordinatex, int coordinatey, List<Tuple<string, int>> movements, int outputexpected)
        {

            _myRobotCleaner = new RobotIA(numberofcommands, coordinatex, coordinatey, movements);
            
            //Act
            _myRobotCleaner.Start();


            //Assert
            Assert.Equal(_myRobotCleaner.GetCleanedSpotsQuantity(), outputexpected);
        }

        //ShouldClean - Arrange
        public static IEnumerable<object[]> GetArrangeShouldClean(int testNumber)
        {
            var movements1 = new List<Tuple<string, int>>()
            {
                Tuple.Create("E",2),
                Tuple.Create("N",1)
            };

            var movements2 = new List<Tuple<string, int>>()
            {
                Tuple.Create("E",2)
            };

            var movements3 = new List<Tuple<string, int>>();

           
            var allTests = new List<object[]>
            {
                new object[] { movements1.Count, 10,22,movements1, 4 },
                new object[] { movements2.Count, 50,31,movements2, 3 },
                new object[] { movements3.Count, 100,654,movements3, 0 }                
            };

            return allTests.Take(testNumber);
        }


    }
}
