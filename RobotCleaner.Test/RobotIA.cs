using System;
using System.Collections.Generic;

namespace RobotCleaner.Test
{
    internal class RobotIA : IRobotIA
    {
        private Robot _robot;


        private int numberofcommands;
        private int v2;
        private int v3;
        private List<Tuple<string, int>> movements;

        public RobotIA(int numberofcommands, int v2, int v3, List<Tuple<string, int>> movements)
        {
            this.numberofcommands = numberofcommands;
            this.movements = movements;
            _robot = new Robot
            {
                XCoordinate = v2,
                YCoordinate = v3,
                SpotsCleaned = new HashSet<string> { v2 + "_" + v3 }
            };
        }

        public string GetOrientation() => _robot.HeadDirection;

        public int GetPositionX() => _robot.XCoordinate;

        public int GetPositionY() => _robot.YCoordinate;

        public void Start()
        {
            for (int i = 0; i < numberofcommands; i++)
            {
                _robot.HeadDirection = movements[i].Item1;
                int qnt = 0;
                bool canMove = true;
                while (qnt < movements[i].Item2 && canMove)
                {
                    canMove = MoveForward();
                    qnt++;
                }
            }
        }

        private bool MoveForward()
        {
            switch (_robot.HeadDirection)
            {
                case "N":
                    if (_robot.YCoordinate == 100000)
                    {
                        return false;
                    }
                    _robot.YCoordinate +=1;
                    break;
                case "S":
                    if (_robot.YCoordinate == -100000)
                    {
                        return false;
                    }
                    _robot.YCoordinate -=1;
                    break;
                case "W":
                    if (_robot.XCoordinate == -100000)
                    {
                        return false;
                    }
                    _robot.XCoordinate -=1;
                    break;
                case "E":
                    if (_robot.XCoordinate == 100000)
                    {
                        return false;
                    }
                    _robot.XCoordinate +=1;
                    break;
                default:
                    throw new NotSupportedException("Invalid Coordinate");
            }
            return true;
        }


    }
}