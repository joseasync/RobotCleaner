using System;
using System.Collections.Generic;

namespace RobotCleaner.Test
{
    internal class RobotIA : IRobotIA
    {
        private int v1;
        private int v2;
        private int v3;
        private List<Tuple<string, int>> movements;

        public RobotIA(int v1, int v2, int v3, List<Tuple<string, int>> movements)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.movements = movements;
        }

        public string GetOrientation()
        {
            throw new NotImplementedException();
        }

        public int GetPositionX()
        {
            throw new NotImplementedException();
        }

        public int GetPositionY()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}