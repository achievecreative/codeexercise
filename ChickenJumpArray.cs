using System;

namespace Algorithms
{
    public class ChickenJumpArray
    {
        int[] platformers = null;
        int currentPosition = 0;
        public ChickenJumpArray(int numberOfTiles, int position)
        {
            platformers = new int[numberOfTiles];
            currentPosition = position;
        }

        public void JumpLeft()
        {
            if (currentPosition == 0)
            {
                return;
            }


            var moveStep = 0;
            var offset = 1;

            do
            {
                var nextIndex = currentPosition - offset;
                if (nextIndex < 0)
                {
                    return;
                }

                if (platformers[nextIndex] == 0)
                {
                    moveStep++;
                }

                if (moveStep == 2)
                {
                    platformers[currentPosition] = 1;
                    currentPosition = nextIndex;
                    return;
                }

                offset++;

            } while (true);

        }

        public void JumpRight()
        {
            if (currentPosition == (platformers.Length - 1))
            {
                return;
            }

            var moveStep = 0;
            var offset = 1;

            do
            {
                var nextIndex = currentPosition + offset;
                if (nextIndex >= platformers.Length)
                {
                    return;
                }

                if (platformers[nextIndex] == 0)
                {
                    moveStep++;
                }

                if (moveStep == 2)
                {
                    platformers[currentPosition] = 1;
                    currentPosition = nextIndex;
                    break;
                }

                offset++;

            } while (true);
        }

        public int Position()
        {
            return currentPosition;
        }

        public static void Main(string[] args)
        {
            var platformer = new ChickenJumpArray(1000000, 5000);
            Console.WriteLine(platformer.Position()); // should print 3

            platformer.JumpLeft();
            Console.WriteLine(platformer.Position()); // should print 1

            platformer.JumpRight();
            Console.WriteLine(platformer.Position()); // should print 4

            platformer.JumpRight();

            Console.WriteLine(platformer.Position()); // should print 4
            platformer.JumpRight();

            Console.WriteLine(platformer.Position()); // should print 4
            platformer.JumpRight();

            Console.WriteLine(platformer.Position()); // should print 4
            platformer.JumpRight();

            Console.WriteLine(platformer.Position()); // should print 4 
            platformer.JumpRight();

            Console.WriteLine(platformer.Position()); // should print 4 

            platformer.JumpLeft();
            Console.WriteLine(platformer.Position()); // should print 4

            for (int i = 0; i < 1000000; i++)
            {
                if (i % 2 == 0)
                {
                    platformer.JumpLeft();

                }
                else
                {
                    platformer.JumpRight();
                }
            }

            Console.WriteLine(platformer.Position());
        }
    }
}