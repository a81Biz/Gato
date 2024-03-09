using Gato.Clases;
using Gato.Interface;
using System;
class Program
{
   
    static void Main()
    {
        Game game = new Game();
        game.Start();
        game.Play();
        game.End();
    }
}
