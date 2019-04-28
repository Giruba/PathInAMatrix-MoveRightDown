using System;
using System.Collections.Generic;
using System.Text;

namespace RatInAMaze
{
    class SolveMaze
    {
        int dimension;
        int[,] maze;
        int[,] solutionOfMaze;

        public SolveMaze() { }

        public SolveMaze(int dimension) {
            this.dimension = dimension;
            maze = new int[dimension, dimension];
            solutionOfMaze = new int[dimension, dimension];
        }


        public void SetMazeDimension(int dimension) {
            this.dimension = dimension;
        }

        public void SetMazeMatrix(int[,] matrix) {
            this.maze = matrix;
        }

        public int GetMazeDimension() {
            return dimension;
        }

        public int[,] GetMazeMatrix() {
            return maze;
        }

        public void SetMazeSolutionMatrix(int[,] matrix) {
            solutionOfMaze = matrix;
        }

        public int[,] GetMazeSolutionMatrix() {
            return solutionOfMaze;
        }

        public void FindMazeSolution() {
                        
            maze = GetMazeInputMatrix();
            dimension = maze.GetLength(0);
            solutionOfMaze = new int[dimension, dimension];
            if (_FindMazeSolution(0, 0))
            {
                Console.WriteLine("Maze solution exists!");
                PrintSolutionMatrix();
            }
            else {
                Console.WriteLine("Solution does not exist!");
            }
        }


        private bool _FindMazeSolution(int row, int column) {
            if (row == (dimension - 1) && column == (dimension - 1)) {
                solutionOfMaze[dimension - 1, dimension - 1] = 1;
                return true;
            }

            if (CanPassThroughPosition(row, column)) {
                solutionOfMaze[row, column] = 1;

                if (_FindMazeSolution(row + 1, column)) {
                    return true;
                }

                if (_FindMazeSolution(row, column + 1)) {
                    return true;
                }

                //If we cannot reach solution, backtrack and reset the position
                solutionOfMaze[row, column] = 0;
                return false;
            }

            return false;
        }


        public int[,] GetMazeInputMatrix() {
            int[,] matrix = null;

            Console.WriteLine("Enter the dimension of the maze");
            try
            {
                int dimension = int.Parse(Console.ReadLine());
                matrix = new int[dimension, dimension];
                for (int index = 0; index < dimension; index++) {
                    Console.WriteLine("Enter the elements of row "+(index+1)
                        +" separated by space, comma or semi-colon");
                    String[] elements = Console.ReadLine().Trim().Split(' ', ',', ';');
                    for (int secIndex = 0; secIndex < dimension; secIndex++) {
                        matrix[index, secIndex] = int.Parse(elements[secIndex]);
                    }
                }

            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }

            return matrix;
        }

        public void PrintSolutionMatrix() {
            for (int index = 0; index < dimension; index++) {
                for (int colIndex = 0; colIndex < dimension; colIndex++) {
                    Console.Write(solutionOfMaze[index, colIndex]+" ");
                }
                Console.WriteLine();
            }
        }

        public bool CanPassThroughPosition(int row, int column) {
            bool result =  (row >= 0 && row < dimension &&
                column >= 0 && column < dimension &&
                maze[row, column] == 1);
            return result;
        }
    }
}
