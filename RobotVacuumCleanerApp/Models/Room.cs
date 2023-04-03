using System;
using System.Linq;

namespace RobotVacuumCleanerApp.Models
{
	public static class Room
	{

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static int robot_1_loc_x { get; set; }
        public static int robot_1_loc_y { get; set; }

        public static int robot_2_loc_x { get; set; }
        public static int robot_2_loc_y { get; set; }

        // Control for performed to prevent the robots from colliding.
        public static bool CheckLocation(int x, int y, int robot)
        {
            if (robot==1)
            {
                if (robot_2_loc_x==x && robot_2_loc_x==y)
                {
                    return false;
                }
                else
                {
                    robot_1_loc_x = x;
                    robot_1_loc_y = y;
                    return true;
                }
            }
            else if (robot == 2)
            {
                if (robot_1_loc_x == x && robot_1_loc_x == y)
                {
                    return false;
                }
                else
                {
                    robot_2_loc_x = x;
                    robot_2_loc_y = y;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        // Set the initial position of the robots
        public static void SetFirstLocation(int x, int y, int robot)
        {
            if (robot == 1)
            {
                robot_1_loc_x = x;
                robot_1_loc_y = y;
            }
            else if (robot ==2)
            {
                robot_2_loc_x = x;
                robot_2_loc_y = y;
            }
        }

        // Control for preventing the robots from being placed on top of each other when the program runs for the first time.
        public static bool ValidateFirstPosition(int robot1X, int robot1Y, int robot2X, int robot2Y)
        {
            return (robot1X == robot2X) && (robot1Y == robot2Y);
        }

        // Width and height should be greater than zero
        public static bool ValidateRoomSize(int width, int height)
        {
            return width > 0 && height > 0;
        }

        // Robot position should be inside the room
        public static bool ValidateRobotPosition(int x, int y, string orientation, int roomWidth, int roomHeight)
        {
            return x >= 0 && x < roomWidth && y >= 0 && y < roomHeight && (orientation == "N" || orientation == "E" || orientation == "S" || orientation == "W");
        }

        // Instructions should consist only of "L", "R", and "M" characters
        public static bool ValidateRobotInstructions(string instructions)
        {
            return !string.IsNullOrEmpty(instructions) && instructions.All(c => c == 'L' || c == 'R' || c == 'M');
        }
    }
}
