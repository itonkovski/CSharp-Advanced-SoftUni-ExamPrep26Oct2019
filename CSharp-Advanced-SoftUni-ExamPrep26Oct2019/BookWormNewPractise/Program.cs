using System;
using System.Linq;
using System.Collections.Generic;

namespace BookWormNewPractise
{
    class Program
    {
        static char[][] matrix;
        static Stack<char> initialWord;

        static int playerRow;
        static int playerCol;
        static bool isFound = false;

        static void Main(string[] args)
        {
            char[] word = Console.ReadLine()
                .ToCharArray();
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            Stack<char> initialWord = new Stack<char>(word);

            Initialize(rows, matrix);

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;
                        char symbol = matrix[playerRow][playerCol];
                        if (char.IsLetter(symbol))
                        {
                            initialWord.Push(symbol);
                        }
                        matrix[playerRow][playerCol] = 'P';
                        matrix[playerRow + 1][playerCol] = '-';
                    }
                    else
                    {
                        if (initialWord.Count > 0)
                        {
                            initialWord.Pop();
                        }
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 < rows)
                    {
                        playerRow++;
                        char symbol = matrix[playerRow][playerCol];
                        if (char.IsLetter(symbol))
                        {
                            initialWord.Push(symbol);
                        }
                        matrix[playerRow][playerCol] = 'P';
                        matrix[playerRow - 1][playerCol] = '-';
                    }
                    else
                    {
                        if (initialWord.Count > 0)
                        {
                            initialWord.Pop();
                        }
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                        char symbol = matrix[playerRow][playerCol];
                        if (char.IsLetter(symbol))
                        {
                            initialWord.Push(symbol);
                        }
                        matrix[playerRow][playerCol] = 'P';
                        matrix[playerRow][playerCol + 1] = '-';
                    }
                    else
                    {
                        if (initialWord.Count > 0)
                        {
                            initialWord.Pop();
                        }
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 < rows)
                    {
                        playerCol++;
                        char symbol = matrix[playerRow][playerCol];
                        if (char.IsLetter(symbol))
                        {
                            initialWord.Push(symbol);
                        }
                        matrix[playerRow][playerCol] = 'P';
                        matrix[playerRow][playerCol - 1] = '-';
                    }
                    else
                    {
                        if (initialWord.Count > 0)
                        {
                            initialWord.Pop();
                        }
                    }
                }
            }
            Console.WriteLine(string.Join("", initialWord.Reverse()));
            PrintMatrix(matrix);

        }

        private static void Initialize(int rows,char[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                if (!isFound)
                {
                    for (int col = 0; col < input.Length; col++)
                    {
                        if (input[col] == 'P')
                        {
                            playerRow = row;
                            playerCol = col;
                            isFound = true;
                            break;
                        }
                    }
                }
                matrix[row] = input;
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
