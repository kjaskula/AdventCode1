using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode1
{
    class Program
    {
        static void Main(string[] args)
        {
            string road = "L3, R1, L4, L1, L2, R4, L3, L3, R2, R3, L5, R1, R3, L4, L1, L2, R2, R1, L4, L4, R2, L5, R3, R2, R1, L1, L2, R2, R2, L1, L1, R2, R1, L3, L5, R4, L3, R3, R3, L5, L190, L4, R4, R51, L4, R5, R5, R2, L1, L3, R1, R4, L3, R1, R3, L5, L4, R2, R5, R2, L1, L5, L1, L1, R78, L3, R2, L3, R5, L2, R2, R4, L1, L4, R1, R185, R3, L4, L1, L1, L3, R4, L4, L1, R5, L5, L1, R5, L1, R2, L5, L2, R4, R3, L2, R3, R1, L3, L5, L4, R3, L2, L4, L5, L4, R1, L1, R5, L2, R4, R2, R3, L1, L1, L4, L3, R4, L3, L5, R2, L5, L1, L1, R2, R3, L5, L3, L2, L1, L4, R4, R4, L2, R3, R1, L2, R1, L2, L2, R3, R3, L1, R4, L5, L3, R4, R4, R1, L2, L5, L3, R1, R4, L2, R5, R4, R2, L5, L3, R4, R1, L1, R5, L3, R1, R5, L2, R1, L5, L2, R2, L2, L3, R3, R3, R1";
            //string road = "R4, L3";
            Point start = new Point(0, 0);

            Walk walk = new Walk(road, start);

            Point end = walk.GetRoadEnd();

            Console.WriteLine(end.X + end.Y);
            Console.ReadKey();
        }
    }

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public void SetCoords(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Walk
    {
        public string Road { get; private set; }

        public Point Start { get; private set; }

        public Walk(string road, Point start)
        {
            Road = road;
            Start = start;
        }

        public Point GetRoadEnd()
        {
            string[] roadParts = Road.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            Point end = new Point(0, 0);

            Point direction = new Point(0, 1);

            foreach (string part in roadParts)
            {
                Console.WriteLine("coords before: [" + end.X + "," + end.Y + "]");

                if (part.StartsWith("R"))
                    direction = TurnRight(direction);
                if (part.StartsWith("L"))
                    direction = TurnLeft(direction);

                string x = part.Substring(1, part.Length - 1);
                int distance = int.Parse(part.Substring(1, part.Length - 1).Trim());

                if (direction.X != 0)
                    end.SetCoords(end.X + direction.X * distance, end.Y);
                else
                    end.SetCoords(end.X, end.Y + direction.Y * distance);

                Console.WriteLine("coords after: [" + end.X + "," + end.Y + "]");
            }

            return end;
        }

        public Point TurnLeft(Point direction)
        {
            if (direction.X == 0 && direction.Y == 1)
                return new Point(-1, 0);
            if (direction.X == -1 && direction.Y == 0)
                return new Point(0, -1);
            if (direction.X == 0 && direction.Y == -1)
                return new Point(1, 0);
            if (direction.X == 1 && direction.Y == 0)
                return new Point(0, 1);

            throw new Exception("oops");
        }

        public Point TurnRight(Point direction)
        {
            if (direction.X == 0 && direction.Y == 1)
                return new Point(1, 0);
            if (direction.X == 1 && direction.Y == 0)
                return new Point(0, -1);
            if (direction.X == 0 && direction.Y == -1)
                return new Point(-1, 0);
            if (direction.X == -1 && direction.Y == 0)
                return new Point(0, 1);

            throw new Exception("oops");
        }
    }
}
