using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gato.Clases;

namespace Gato.Interface
{
    // Interfaz para definir el comportamiento de un jugador
    public interface IPlayer
    {
        char Symbol { get; }
        string Name { get; }
        int Turn { get; set; }
        int MakeMove(Board board);
    }

}
