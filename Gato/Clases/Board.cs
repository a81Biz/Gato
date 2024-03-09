using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato.Clases
{
    // Clase que representa el tablero del juego
    public class Board
    {
        private char[] cells;

        public Board()
        {
            cells = new char[9];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = ' ';
            }
        }

        public void DisplayBoard(bool showSymbols)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (showSymbols)
                {
                    Console.Write($" {cells[i]} ");
                }
                else if (cells[i] == ' ')
                {
                    Console.Write($" {i + 1} ");
                }
                else
                {
                    Console.Write("   ");
                }

                if (i % 3 == 2)
                {
                    Console.WriteLine();
                    if (i < 8)
                    {
                        Console.WriteLine("-----------");
                    }
                }
                else
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }
        public void DisplayBoardNumbers()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i] == ' ')
                {
                    Console.Write($" {i + 1} ");
                }
                else
                {
                    Console.Write("   ");
                }

                if (i % 3 == 2)
                {
                    Console.WriteLine();
                    if (i < 8)
                    {
                        Console.WriteLine("-----------");
                    }
                }
                else
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }

        public bool IsFull()
        {
            return Array.IndexOf(cells, ' ') == -1;
        }

        public bool IsWinner(char symbol)
        {
            // Verifica todas las posibles combinaciones ganadoras
            return cells[0] == symbol && cells[1] == symbol && cells[2] == symbol ||
                   cells[3] == symbol && cells[4] == symbol && cells[5] == symbol ||
                   cells[6] == symbol && cells[7] == symbol && cells[8] == symbol ||
                   cells[0] == symbol && cells[3] == symbol && cells[6] == symbol ||
                   cells[1] == symbol && cells[4] == symbol && cells[7] == symbol ||
                   cells[2] == symbol && cells[5] == symbol && cells[8] == symbol ||
                   cells[0] == symbol && cells[4] == symbol && cells[8] == symbol ||
                   cells[2] == symbol && cells[4] == symbol && cells[6] == symbol;
        }

        public bool IsValidMove(int move)
        {
            return move >= 1 && move <= 9 && cells[move - 1] == ' ';
        }

        public void MakeMove(int move, char symbol)
        {
            cells[move - 1] = symbol;
        }
    }
}
