using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gato.Interface;

namespace Gato.Clases
{
    // Clase que representa un jugador humano
    public class HumanPlayer : IPlayer
    {
        public char Symbol { get; }
        public string Name { get; }
        public int Turn { get; set; }

        public HumanPlayer(char symbol, string name)
        {
            Symbol = symbol;
            Name = name;
            Turn = 0;
        }

        public int MakeMove(Board board)
        {
            Console.Write($"Jugador {Name}, ingrese su movimiento (1-9): ");
            int move;
            while (!int.TryParse(Console.ReadLine(), out move) || !board.IsValidMove(move))
            {
                Console.WriteLine("Movimiento no válido. Inténtelo de nuevo.");
            }
            return move;
        }
    }

}
