using Gato.Clases;
using Gato.Enums;
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
        Console.WriteLine(GameMessages.Welcome);

        Console.WriteLine(GameMessages.SelectOpponent);
        string? input = Console.ReadLine();

        if (input == OpponentType.IA.ToString())
        {
            this._isAgainstAI = true;
        }
        else if (input == OpponentType.Player.ToString())
        {
            _isAgainstAI = false;
        }
        else
        {
            Console.WriteLine(GameMessages.NotValidOption);
            return;
        }

        Console.WriteLine(GameMessages.SetFirstPlayerName);
        _player1Name = Console.ReadLine();

        if (!_isAgainstAI)
        {
            Console.WriteLine(GameMessages.SetSecondPlayerName);
            _player2Name = Console.ReadLine();
        }

        // Desarrollo del juego
        _board = new Board();
        _player1 = new HumanPlayer(Symbol.ex, _player1Name);
        _player2 = !_isAgainstAI ? new HumanPlayer(Symbol.o, _player2Name) : new ComputerPlayer(Symbol.o);
        

    }

    public void Play()
    {
        
        while (true)
        {
            currentPlayer = currentPlayer == null ? this.ChooseStartingPlayer() : currentPlayer;
            // Fase de turno
            Console.Clear();

            Console.WriteLine(GameMessages.AvailableBoxes);
            _board.DisplayBoardNumbers();

            Console.WriteLine(GameMessages.PlaysMade);
            _board.DisplayBoard(true);

            int move = currentPlayer.MakeMove(_board);

            _board.MakeMove(move, currentPlayer.Symbol);

            // Fase de victoria
            if (_board.IsWinner(currentPlayer.Symbol))
            {
                Console.Clear();
                RepeatOrClose();

            }

            // Fase de empate
            if (_board.IsFull())
            {
                Console.Clear();

                RepeatOrClose(ResultGame.tie);
            }


            currentPlayer = currentPlayer != null ? currentPlayer.Turn == _player1.Turn ? _player2 : _player1 : null;
        }
    }

    public void End()
    {
        Console.Clear();

        Console.WriteLine(GameMessages.PlaysMade);
        _board.DisplayBoard(true);

        Console.WriteLine(GameMessages.ThanksForPlaying);
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

        Console.WriteLine(GameMessages.PlayerStarting(currentPlayer.Name));
        while (true)
        {
            Console.WriteLine(GameMessages.PressAnyKey);
            input = Console.ReadKey(true).Key.ToString().ToUpper();
            break;
        }

        return currentPlayer;

    }

    public void RepeatOrClose(char gameResult = '\0')
    {

        string result = gameResult == ResultGame.tie ? GameMessages.TiedGame : GameMessages.GameWon(currentPlayer.Name);


        Console.WriteLine(GameMessages.PlaysMade);
        _board.DisplayBoard(true);

        Console.WriteLine(result);

        Console.WriteLine(GameMessages.CloseWindow);
        Console.WriteLine(GameMessages.RepeatGame);

        // Esperamos a que el usuario presione S o R
        while (true)
        {
            input = Console.ReadKey(true).Key.ToString().ToUpper();
            if (input == Symbol.CloseWindow.ToString())
            {
                Environment.Exit(0);
            }
            else if (input == Symbol.Repeat.ToString())
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
