using System;

namespace RatInAMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rat in a Maze!");
            Console.WriteLine();
                        
            try
            {                
                new SolveMaze().FindMazeSolution();
            }
            catch (Exception exception) {
                Console.WriteLine("Exception thrown is "+exception.Message);
            }

            Console.ReadLine();
        }
    }
}
