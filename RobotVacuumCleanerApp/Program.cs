using System;
using System.Runtime.CompilerServices;
using RobotVacuumCleanerApp.Models;

[assembly: InternalsVisibleTo("RobotVacuumCleanerApp.UnitTest")]
namespace RobotVacuumCleanerApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Get size of the room
            string[] roomSize = Console.ReadLine().Split(' ');

            int roomWidth = int.Parse(roomSize[0]);
            int roomHeight = int.Parse(roomSize[1]);

            if (Room.ValidateRoomSize(roomWidth, roomHeight) == false)
            {
                Console.WriteLine("Width and height should be greater than zero.");
                Console.ReadKey();
            }

            // Get position and orientation of the first robot
            string[] robot1Position = Console.ReadLine().Split(' ');

            int robot1X = int.Parse(robot1Position[0]);
            int robot1Y = int.Parse(robot1Position[1]);

            string robotOrientation1 = robot1Position[2];


            if (Room.ValidateRobotPosition(robot1X, robot1Y, robotOrientation1, roomWidth, roomHeight)==false)
            {
                Console.WriteLine("First robot position should be inside the room and orientations should be 'N,E,S or W'");
                Console.ReadKey();
            }
            
            Orientation robot1Orientation = (Orientation)Enum.Parse(typeof(Orientation), robot1Position[2]);


            //The last parameter indicates that this is the first robot in the simulation.
            Room.SetFirstLocation(robot1X, robot1Y, 1);

            Robot robot1 = new Robot(robot1X, robot1Y, robot1Orientation, roomWidth, roomHeight, 1);

            // Get the first robot how to navigate the room
            string robot1Instructions = Console.ReadLine();

            if (Room.ValidateRobotInstructions(robot1Instructions)==false)
            {
                Console.WriteLine("Instructions should consist only of 'L', 'R', and 'M' characters");
            }
           
            // Get position and orientation of the second robot
            string[] robot2Position = Console.ReadLine().Split(' ');


            int robot2X = int.Parse(robot2Position[0]);
            int robot2Y = int.Parse(robot2Position[1]);
            string robotOrientation2 = robot1Position[2];

            if (Room.ValidateRobotPosition(robot2X, robot2Y, robotOrientation2, roomWidth, roomHeight) == false)
            {
                Console.WriteLine("Second robot position should be inside the room and orientations should be 'N,E,S or W'");
                Console.ReadKey();
            }

            Orientation robot2Orientation = (Orientation)Enum.Parse(typeof(Orientation), robot2Position[2]);

            //The last parameter indicates that this is the second robot in the simulation.
            Room.SetFirstLocation(robot2X, robot2Y, 2);

            Robot robot2 = new Robot(robot2X, robot2Y, robot2Orientation,roomWidth,roomHeight,2);

            if (Room.ValidateFirstPosition(robot1X, robot1Y, robot2X, robot2Y))
            {
                Console.WriteLine("Robots cannot be placed on top of each other.");
                Console.ReadLine();
            }

            // Get the second robot how to navigate the room
            string robot2Instructions = Console.ReadLine();


            if (Room.ValidateRobotInstructions(robot2Instructions) == false)
            {
                Console.WriteLine("Instructions should consist only of 'L', 'R', and 'M' characters");
            }

            // Move robots
            robot1.Move(robot1Instructions);
            robot2.Move(robot2Instructions);

            // Print output
            Console.WriteLine(robot1);
            Console.WriteLine(robot2);

            Console.ReadLine();
        }
    }
}

