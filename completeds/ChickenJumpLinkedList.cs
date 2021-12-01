using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class ChickenJumpLinkedList
    {
        private readonly LinkedList<int> list;

        private LinkedListNode<int> Current;

        public ChickenJumpLinkedList(int numberOfTiles, int position)
        {
            list = new LinkedList<int>();

            for (int i = 1; i <= numberOfTiles; i++)
            {
                var node = new LinkedListNode<int>(i);
                if (position == i)
                {
                    Current = node;
                }

                list.AddLast(node);
            }
        }

        public void JumpLeft()
        {
            var jumpLeft = Current.Previous?.Previous;
            if (jumpLeft == null)
            {
                return;
            }

            list.Remove(Current);
            Current = jumpLeft;
        }

        public void JumpRight()
        {
            var jumpRight = Current.Next?.Next;
            if (jumpRight == null)
            {
                return;
            }

            list.Remove(Current);
            Current = jumpRight;
        }

        public int Position()
        {
            return Current?.Value ?? 0;
        }

        public static void Main(string[] args)
        {
            ChickenJumpLinkedList platformer = new ChickenJumpLinkedList(1000000, 5000);
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