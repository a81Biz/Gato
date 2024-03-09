using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gato.Interface;

namespace Gato.Clases
{
    // Clase que representa un jugador de la computadora (IA simple)
    public class ComputerPlayer : IPlayer
    {
        public char Symbol { get; }
        public string Name { get; }
        public int Turn { get; set; }

        public ComputerPlayer(char symbol)
        {
            Symbol = symbol;
            Name = "IA";
            Turn = 0;
        }

        public int MakeMove(Board board)
        {
            // Primero buscamos una oportunidad para ganar
            for (int i = 0; i < 9; i++)
            {
                if (board.IsValidMove(i + 1))
                {
                    board.MakeMove(i + 1, Symbol);
                    if (board.IsWinner(Symbol))
                    {
                        board.MakeMove(i + 1, ' '); // Deshacemos el movimiento para mantener el tablero original
                        return i + 1;
                    }
                    board.MakeMove(i + 1, ' '); // Deshacemos el movimiento para analizar otras casillas
                }
            }

            // Si no hay oportunidad para ganar, se puede elegir un movimiento aleatorio (por ahora)
            Random random = new Random();
            int move;
            do
            {
                move = random.Next(1, 10);
            } while (!board.IsValidMove(move));

            return move;
        }
    }

}
