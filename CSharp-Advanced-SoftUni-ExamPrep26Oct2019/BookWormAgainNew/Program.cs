using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWormAgainNew
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] word = Console.ReadLine()
                .ToCharArray();

            Stack<char> initialWord = new Stack<char>(word);

            int n = int.Parse(Console.ReadLine());
             
            char[][] matrix = new char[n][];

            int playerRow = -1;
            int playerCol = -1;
            bool isFound = false;
            InitializeMatrix(n, matrix, ref playerRow, ref playerCol, ref isFound);

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up")
                {
                    playerRow = MoveUp(initialWord, matrix, playerRow, playerCol);
                }
                else if (command == "down")
                {
                    playerRow = MoveDown(initialWord, n, matrix, playerRow, playerCol);
                }
                else if (command == "left")
                {
                    playerCol = MoveLeft(initialWord, matrix, playerRow, playerCol);
                }
                else if (command == "right")
                {
                    playerCol = MoveRight(initialWord, n, matrix, playerRow, playerCol);
                }
            }

            Console.WriteLine(string.Join("", initialWord.Reverse()));
            PrintMatrix(matrix);
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

        private static int MoveRight(Stack<char> initialWord, int n, char[][] matrix, int playerRow, int playerCol)
        {
            if (playerCol + 1 < n)
            {
                playerCol++;
                char symbol = matrix[playerRow][playerCol];
                if (Char.IsLetter(symbol))
                {
                    initialWord.Push(symbol);
                }
                matrix[playerRow][playerCol] = 'P';
                matrix[playerRow][playerCol - 1] = '-';
            }
            else
            {
                Punish(initialWord);
            }

            return playerCol;
        }

        private static int MoveLeft(Stack<char> initialWord, char[][] matrix, int playerRow, int playerCol)
        {
            if (playerCol - 1 >= 0)
            {
                playerCol--;
                char symbol = matrix[playerRow][playerCol];
                if (Char.IsLetter(symbol))
                {
                    initialWord.Push(symbol);
                }
                matrix[playerRow][playerCol] = 'P';
                matrix[playerRow][playerCol + 1] = '-';
            }
            else
            {
                Punish(initialWord);
            }

            return playerCol;
        }

        private static int MoveDown(Stack<char> initialWord, int n, char[][] matrix, int playerRow, int playerCol)
        {
            if (playerRow + 1 < n)
            {
                playerRow++;
                char symbol = matrix[playerRow][playerCol];
                if (Char.IsLetter(symbol))
                {
                    initialWord.Push(symbol);
                }
                matrix[playerRow][playerCol] = 'P';
                matrix[playerRow - 1][playerCol] = '-';
            }
            else
            {
                Punish(initialWord);
            }

            return playerRow;
        }

        private static int MoveUp(Stack<char> initialWord, char[][] matrix, int playerRow, int playerCol)
        {
            if (playerRow - 1 >= 0)
            {
                playerRow--;
                char symbol = matrix[playerRow][playerCol];

                if (Char.IsLetter(symbol))
                {
                    initialWord.Push(symbol);
                }
                matrix[playerRow][playerCol] = 'P';
                matrix[playerRow + 1][playerCol] = '-';
            }
            else
            {
                Punish(initialWord);
            }

            return playerRow;
        }

        private static void Punish(Stack<char> initialWord)
        {   
            if (initialWord.Count > 0)
            {
                initialWord.Pop();
            }
        }

        private static void InitializeMatrix(int n, char[][] matrix, ref int playerRow, ref int playerCol, ref bool isFound)
        {
            for (int row = 0; row < n; row++)
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
    }
}
