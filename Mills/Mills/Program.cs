using System;
using System.Collections.Generic;

namespace Mills {
  class Program {
    static void Main(string[] args) {
      IPlayer player1 = new Player("Olaf");
      IPlayer player2 = new Player("Karl");
      IRuleSet ruleSet = new RuleSet(new List<ValidationRule<Move>>(), new List<ValidationRule<IBoard>>());
      IBoard board = new Board();
      board.Initialize();
      History history = new History();
      IGameController controller = new GameController(ruleSet, board, history);
      controller.PlayerWon += OnPlayerWon;
      controller.NewGame(player1, player2);

      while (true) {
        Draw(board, controller.ActivePlayer);
        ConsoleKeyInfo key = Console.ReadKey();
        int.TryParse(key.KeyChar.ToString(), out int level);
        int.TryParse(key.KeyChar.ToString(), out int x);
        int.TryParse(key.KeyChar.ToString(), out int y);
        controller.DoTurn(new Move(null, new Spot(level, x, y, controller.ActivePlayer), controller.ActivePlayer));
      }


      Console.ReadLine();
    }

    private static void OnPlayerWon(IPlayer player) {
      Console.WriteLine(player.Name + " hat krass gewonnen, diggah!");
    }

    /// <summary>
    /// TODO kill me
    /// </summary>
    /// <param name="board"></param>
    /// <param name="controllerActivePlayer"></param>
    static void Draw(IBoard board, IPlayer controllerActivePlayer) {
      int x = 0;
      int y = 0;
      Spot[,] level1 = board.Spots[0];
      Spot[,] level2 = board.Spots[1];
      Spot[,] level3 = board.Spots[2];

      Console.WriteLine($@"{level1[0, 0]}-----{level1[1, 0]}-----{level1[2, 0]}");
      Console.WriteLine($@"| {level2[0, 0]}---{level2[1, 0]}---{level2[2, 0]} |");
      Console.WriteLine($@"| | {level3[0, 0]}-{level3[1, 0]}-{level3[2, 0]} | |");
      Console.WriteLine($@"{level1[0, 1]} {level2[0, 1]} {level3[0, 1]}   {level3[2, 1]} {level2[2, 1]} {level1[2, 1]}");
      Console.WriteLine($@"| | {level3[0, 2]}-{level3[1, 2]}-{level3[2, 2]} | |");
      Console.WriteLine($@"| {level2[0, 2]}---{level2[1, 2]}---{level2[2, 2]} |");
      Console.WriteLine($@"{level1[0, 2]}-----{level1[1, 2]}-----{level1[2, 2]}");

      Console.Write(controllerActivePlayer.Name + " Do something!");
    }
  }
}

