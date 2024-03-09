using Gato.Clases;
using Gato.Interface;

public class Game
{
    private bool _isAgainstAI;
    private bool _repeatGame;
    private string _player1Name;
    private string _player2Name;
    private Board _board;
    private IPlayer _player1;
    private IPlayer _player2;
    private IPlayer? currentPlayer;
    private bool _isPlayer1Turn;
    private string input;

    public Game()
    {
        _isAgainstAI = false;
        _repeatGame = true;
    }

    public void Start()
    {
        currentPlayer = null;
        // Fase inicial
        Console.WriteLine("¡Bienvenido al juego de Gato (Tres en Raya)!");

        Console.WriteLine("¿Desea jugar contra la IA (1) o contra otro jugador (2)?");
        string input = Console.ReadLine();

        if (input == "1")
        {
            this._isAgainstAI = true;
        }
        else if (input == "2")
        {
            _isAgainstAI = false;
        }
        else
        {
            Console.WriteLine("Opción no válida. Saliendo del juego.");
            return;
        }

        Console.WriteLine("Ingrese el nombre del primer jugador:");
        _player1Name = Console.ReadLine();

        if (!_isAgainstAI)
        {
            Console.WriteLine("Ingrese el nombre del segundo jugador:");
            _player2Name = Console.ReadLine();
        }

        // Desarrollo del juego
        _board = new Board();
        _player1 = new HumanPlayer('X', _player1Name);
        _player2 = !_isAgainstAI ? new HumanPlayer('O', _player2Name) : new ComputerPlayer('O');
        

    }

    public void Play()
    {
        
        while (true)
        {
            currentPlayer = currentPlayer == null ? this.ChooseStartingPlayer() : currentPlayer;
            // Fase de turno
            Console.Clear();

            Console.WriteLine("Casillas Disponibles:");
            _board.DisplayBoardNumbers();

            Console.WriteLine("Jugadas Hechas:");
            _board.DisplayBoard(true);

            int move = currentPlayer.MakeMove(_board);

            _board.MakeMove(move, currentPlayer.Symbol);

            // Fase de victoria
            if (_board.IsWinner(currentPlayer.Symbol))
            {
                Console.Clear();
                RepeatOrClose("W");

            }

            // Fase de empate
            if (_board.IsFull())
            {
                Console.Clear();

                RepeatOrClose("E");
            }


            currentPlayer = currentPlayer != null ? currentPlayer.Turn == _player1.Turn ? _player2 : _player1 : null;
        }
    }

    public void End()
    {
        Console.Clear();

        Console.WriteLine("Jugadas Hechas:");
        _board.DisplayBoard(true);

        Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
    }

    private IPlayer ChooseStartingPlayer()
    {
        _player1.Turn = 0;
        _player2.Turn = 0;

        Random random = new Random();

        _player1.Turn = random.Next(1, 3);

        _player2.Turn = _player1.Turn == 1 ? 2 : 1;

        if (_player1.Turn == 1) 
        { 
            _isPlayer1Turn = true;
            
        }
        else
        {
            _isPlayer1Turn = false;
            
        }

        currentPlayer = _isPlayer1Turn ? _player1 : _player2;

        Console.WriteLine($"{currentPlayer.Name} comienza el juego.");
        while (true)
        {
            Console.WriteLine($"Oprima cualquier tecla para continuar");
            input = Console.ReadKey(true).Key.ToString().ToUpper();
            break;
        }

        return currentPlayer;

    }

    public void RepeatOrClose(string gameResult)
    {

        string result = gameResult == "E" ? "¡Empate! El juego ha terminado sin ganador." : $"¡El Jugador {currentPlayer.Name} ha ganado!";


        Console.WriteLine("Jugadas Hechas:");
        _board.DisplayBoard(true);

        Console.WriteLine(result);

        Console.WriteLine("Cerrar ventana? Oprima S");
        Console.WriteLine("Repetir partida? Oprima R");

        // Esperamos a que el usuario presione S o R
        while (true)
        {
            input = Console.ReadKey(true).Key.ToString().ToUpper();
            if (input == "S")
            {
                Environment.Exit(0);
            }
            else if (input == "R")
            {
                _repeatGame = true;
                break;
            }
        }

        if (_repeatGame)
        {
            Console.Clear();
            currentPlayer = null;
            Start();
        }
    }
}
