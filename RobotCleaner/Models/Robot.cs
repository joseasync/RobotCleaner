using System.Collections.Generic;

namespace RobotCleaner
{
    public class Robot
    {
        public string HeadDirection { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public HashSet<string> SpotsCleaned { get; set; }
    }
}