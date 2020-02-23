using System;
using System.Collections.Generic;
using Xunit;

namespace RobotCleaner.Test
{
    public class RobotMovementsTest
    {
        private IRobotIA _myRobotCleaner;

        private const int NEGATIVE_LIMIT = -100000;
        private const int POSITIVE_LIMIT = 100000;

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

        [Fact]
        public void ShoulStayStopped()
        {
            var movements = new List<Tuple<string, int>>();
            _myRobotCleaner = new RobotIA(movements.Count, 24, 12, movements);
            _myRobotCleaner.Start();

            Assert.True(_myRobotCleaner.GetPositionX() == 24);
            Assert.True(_myRobotCleaner.GetPositionY() == 12);

        }

        [Fact]
        public void ShouldMoveToSouthLimit()
        {
            var movements = new List<Tuple<string, int>>()
            {
                Tuple.Create("E",2),
                Tuple.Create("S",100050)
            };
            _myRobotCleaner = new RobotIA(movements.Count, 24, 41, movements);
            _myRobotCleaner.Start();

            Assert.True(_myRobotCleaner.GetOrientation() == "S");
            Assert.True(_myRobotCleaner.GetPositionX() == 26);
            Assert.True(_myRobotCleaner.GetPositionY() == NEGATIVE_LIMIT);
        }

        [Fact]
        public void ShouldMoveToNorthLimit()
        {
            var movements = new List<Tuple<string, int>>()
            {
                Tuple.Create("W",2),
                Tuple.Create("N",100050)
            };
            _myRobotCleaner = new RobotIA(movements.Count, 20, 41, movements);
            _myRobotCleaner.Start();

            Assert.True(_myRobotCleaner.GetOrientation() == "N");
            Assert.True(_myRobotCleaner.GetPositionX() == 18);
            Assert.True(_myRobotCleaner.GetPositionY() == POSITIVE_LIMIT);
        }

        [Fact]
        public void ShouldMoveToWestLimit()
        {
            var movements = new List<Tuple<string, int>>()
            {
                Tuple.Create("S",2),
                Tuple.Create("W",100050)
            };
            _myRobotCleaner = new RobotIA(movements.Count, 17, 21, movements);
            _myRobotCleaner.Start();

            Assert.True(_myRobotCleaner.GetOrientation() == "W");
            Assert.True(_myRobotCleaner.GetPositionY() == 19);
            Assert.True(_myRobotCleaner.GetPositionX() == NEGATIVE_LIMIT);
        }

        [Fact]
        public void ShouldMoveToEastLimit()
        {
            var movements = new List<Tuple<string, int>>()
            {
                Tuple.Create("N",2),
                Tuple.Create("E",100050)
            };
            _myRobotCleaner = new RobotIA(movements.Count, 20, 41, movements);
            _myRobotCleaner.Start();

            Assert.True(_myRobotCleaner.GetOrientation() == "E");
            Assert.True(_myRobotCleaner.GetPositionY() == 43);
            Assert.True(_myRobotCleaner.GetPositionX() == POSITIVE_LIMIT);
        }

        [Fact]
        public void ShouldKeepFollowingCommandsAfterReachedOneLimit()
        {
            var movements = new List<Tuple<string, int>>()
            {
                Tuple.Create("N",2),
                Tuple.Create("E",100050),
                Tuple.Create("S",100),
                Tuple.Create("W",50)
            };
            _myRobotCleaner = new RobotIA(movements.Count, 10, 10, movements);
            _myRobotCleaner.Start();

            Assert.True(_myRobotCleaner.GetOrientation() == "W");
            Assert.True(_myRobotCleaner.GetPositionY() == -88);
            Assert.True(_myRobotCleaner.GetPositionX() == 99950);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("B")]
        [InlineData("C")]
        [InlineData("1")]
        [InlineData("d")]
        public void ShouldThrowErrorByInvalidOrientation(string orientation)
        {
            var movements = new List<Tuple<string, int>>()
            {
                Tuple.Create("E",2),
                Tuple.Create(orientation,100010)
            };
            _myRobotCleaner = new RobotIA(movements.Count, 24, 1, movements);

            Assert.Throws<NotSupportedException>(() => _myRobotCleaner.Start());

        }

    }
}
