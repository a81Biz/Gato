using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gato.Enums
{
    public static class GameMessages
    {
        public static string Welcome => "¡Bienvenido al juego de Gato (Tres en Raya)!";
        public static string SelectOpponent => "¿Desea jugar contra la IA (1) o contra otro jugador (2)?";
        public static string NotValidOption => "Opción no válida. Saliendo del juego.";
        public static string SetFirstPlayerName => "Ingrese el nombre del primer jugador:";
        public static string SetSecondPlayerName => "Ingrese el nombre del segundo jugador:";
        public static string AvailableBoxes => "Casillas Disponibles:";
        public static string PlaysMade => "Jugadas Hechas:";
        public static string GameWon(string playerName) => $"¡El Jugador {playerName} ha ganado!";
        public static string TiedGame => "¡Empate! El juego ha terminado sin ganador.";
        public static string CloseWindow => "Cerrar ventana? Oprima S";
        public static string RepeatGame => "Repetir partida? Oprima R";
        public static string ThanksForPlaying => "Gracias por jugar. ¡Hasta la próxima!";
        public static string PlayerStarting(string playerName) => $"{playerName} comienza el juego.";
        public static string PressAnyKey => "Oprima cualquier tecla para continuar";
        public static string EnterYourMove(string playerName) => $"Jugador {playerName}, ingrese su movimiento (1-9): ";
        public static string InvalidMove => "Movimiento no válido. Inténtelo de nuevo.";


    }
}
