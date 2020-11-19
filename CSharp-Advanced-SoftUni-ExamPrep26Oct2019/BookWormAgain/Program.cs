using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWormAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] initials = Console.ReadLine()
                .ToArray();

            Stack<char> word = new Stack<char>(initials);

            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            int playersRow = -1;
            int playersCol = -1;
            bool playersPositionFoud = false;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                if (!playersPositionFoud)
                {
                    for (int col = 0; col < input.Length; col++)
                    {
                        if (input[col] == 'P')
                        {
                            playersRow = row;
                            playersCol = col;
                            playersPositionFoud = true;
                            break;
                        }
                    }
                }
                matrix[row] = input;
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up")
                {
                    playersRow = MoveUp(word, n, matrix, playersRow, playersCol);
                }
                else if (command == "down")
                {
                    playersRow = MoveDown(word, n, matrix, playersRow, playersCol);
                }
                else if (command == "left")
                {
                    playersCol = MoveLeft(word, matrix, playersRow, playersCol);
                }
                else if (command == "right")
                {
                    playersCol = MoveRight(word, n, matrix, playersRow, playersCol);
                }
            }

            Console.WriteLine(string.Join("",word.Reverse()));
            foreach (var input in matrix)
            {
                Console.WriteLine(string.Join("",input));
            }
        }

        private static int MoveRight(Stack<char> word, int n, char[][] matrix, int playersRow, int playersCol)
        {
            if (playersCol + 1 < n)
            {
                playersCol++;
                char symbol = matrix[playersRow][playersCol];
                if (char.IsLetter(symbol))
                {
                    word.Push(symbol);
                }
                matrix[playersRow][playersCol] = 'P';
                matrix[playersRow][playersCol - 1] = '-';
            }
            else
            {
                PunishThePlayer(word);
            }

            return playersCol;
        }

        private static int MoveLeft(Stack<char> word, char[][] matrix, int playersRow, int playersCol)
        {
            if (playersCol - 1 >= 0)
            {
                playersCol--;
                char symbol = matrix[playersRow][playersCol];
                if (char.IsLetter(symbol))
                {
                    word.Push(symbol);
                }
                matrix[playersRow][playersCol] = 'P';
                matrix[playersRow][playersCol + 1] = '-';
            }
            else
            {
                PunishThePlayer(word);
            }

            return playersCol;
        }

        private static int MoveDown(Stack<char> word, int n, char[][] matrix, int playersRow, int playersCol)
        {
            if (playersRow + 1 < n)
            {
                playersRow++;
                char symbol = matrix[playersRow][playersCol];
                if (char.IsLetter(symbol))
                {
                    word.Push(symbol);
                }
                matrix[playersRow][playersCol] = 'P';
                matrix[playersRow - 1][playersCol] = '-';
            }
            else
            {
                PunishThePlayer(word);
            }

            return playersRow;
        }

        private static int MoveUp(Stack<char> word, int n, char[][] matrix, int playersRow, int playersCol)
        {
            if (playersRow - 1 >= 0)
            {
                playersRow--;
                char symbol = matrix[playersRow][playersCol];
                if (char.IsLetter(symbol))
                {
                    word.Push(symbol);
                }
                matrix[playersRow][playersCol] = 'P';
                matrix[playersRow + 1][playersCol] = '-';
            }
            else
            {
                PunishThePlayer(word);
            }

            return playersRow;
        }

        private static void PunishThePlayer(Stack<char> word)
        {
            if (word.Count > 0)
            {
                word.Pop();
            }
        }
    }
}
