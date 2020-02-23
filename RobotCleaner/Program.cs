using System;
using System.Collections.Generic;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            IRobotIA _Robot;
            List<Tuple<string, int>> movements = new List<Tuple<string, int>>();

            Console.WriteLine("Hello, Welcome to Robot Cleaner!\n");
            Console.WriteLine("Please, Type the number of commands!");
            int numberofCommands = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please, Type the starting coordinates(x,y)");
            string startCoordinates = Console.ReadLine();

            int[] coordinates = Array.ConvertAll(startCoordinates.Split(" "), int.Parse);

            for (int i = 0; i < numberofCommands; i++)
            {
                Console.WriteLine("Please, Type the direction and the numbers of steps");
                string movement = Console.ReadLine();
                string[] movementSplited = movement.Split(" ");
                movements.Add(Tuple.Create(movementSplited[0], Convert.ToInt32(movementSplited[1])));
            }

            _Robot = new RobotIA(numberofCommands, coordinates[0], coordinates[1], movements);
            _Robot.Start();
            Console.WriteLine(_Robot.ToString());

        }
    }
}
