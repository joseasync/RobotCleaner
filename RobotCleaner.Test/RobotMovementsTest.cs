using System;
using System.Collections.Generic;
using Xunit;

namespace RobotCleaner.Test
{
    public class RobotMovementsTest
    {
        private IRobotIA _myRobotCleaner;
        public RobotMovementsTest(){}

        [Fact]
        public void ShouldJustMoveForward()
        {
            var movements = new List<Tuple<string, int>>()
            {
                Tuple.Create("E",2)
            };         
            _myRobotCleaner = new RobotIA(1, 24, 12, movements);
            _myRobotCleaner.Start();

            Assert.True(_myRobotCleaner.GetOrientation() == "E");
            Assert.True(_myRobotCleaner.GetPositionX() == 26);
            Assert.True(_myRobotCleaner.GetPositionY() == 12);

        }
    }
}
