using System;
using RobotVacuumCleanerApp.Models;

namespace RobotVacuumCleanerApp.Models
{
    public enum Orientation
    {
        N, // North
        E, // East
        S, // South
        W  // West
    }

    public class Robot
	{
        private int x;
        private int y;
        private Orientation orientation;
        private int width;
        private int height;
        private int number;

        public string[] movement;


        public Robot(int x, int y, Orientation orientation, int width, int height, int number)
        {
            this.x = x;
            this.y = y;
            this.orientation = orientation;
            this.width = width;
            this.height = height;
            this.number = number;
        }


        public void Move(string instructions)
        {
            foreach (char instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        MoveForward();
                        break;
                    default:
                        //throw new ArgumentException($"Invalid instruction: {"Invalid move"}");
                        throw new ArgumentException("Invalid move");
                }
            }
        }

        public override string ToString()
        {
            return $"{x} {y} {orientation}";
        }

        private void TurnLeft()
        {
            switch (orientation)
            {
                case Orientation.N:
                    orientation = Orientation.W;
                    break;
                case Orientation.E:
                    orientation = Orientation.N;
                    break;
                case Orientation.S:
                    orientation = Orientation.E;
                    break;
                case Orientation.W:
                    orientation = Orientation.S;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (orientation)
            {
                case Orientation.N:
                    orientation = Orientation.E;
                    break;
                case Orientation.E:
                    orientation = Orientation.S;
                    break;
                case Orientation.S:
                    orientation = Orientation.W;
                    break;
                case Orientation.W:
                    orientation = Orientation.N;
                    break;
            }
        }

        private void MoveForward()
        {
            if(Control(this.x, this.y, orientation,this.width,this.height))
            {
                switch (orientation)
                {
                    case Orientation.N:
                        if (Room.CheckLocation(x, y+1, number))
                            y++;
                        break;
                    case Orientation.E:
                        if (Room.CheckLocation(x+1, y, number))
                            x++;
                        break;
                    case Orientation.S:
                        if (Room.CheckLocation(x, y-1, number))
                            y--;
                        break;
                    case Orientation.W:
                        if (Room.CheckLocation(x-1, y, number))
                            x--;
                        break;
                }
            }
        }

        public bool Control(int locationX, int locationY, Orientation orientation,int width, int height)
        {

            if ((orientation == Orientation.W && locationX - 1>=0) || (orientation == Orientation.S && locationY - 1 >= 0)
                ||
                (orientation == Orientation.N && locationY+1<=height) || (orientation == Orientation.E && locationX+1 <=width))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

