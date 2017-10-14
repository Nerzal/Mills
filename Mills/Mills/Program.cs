using System;
using Mills.Board.Logic;
using Mills.Board.Logic.Contract;
using Mills.Game.Contract;
using Mills.Game.Contract.Data;
using Mills.Game.Data.Contract;
using Mills.Game.GameController;
using Mills.Game.Player;
using Mills.Rules.Contract;
using Mills.Rules.GameOver;
using Mills.Rules.Movement;
using Mills.Rules.Rules;


namespace Mills.ConsoleClient {
  class Program {
    private static IGameController _controller;

    static void Main(string[] args) {
      IPlayer player1 = new Player("Olaf");
      IPlayer player2 = new Player("Karl");
      IBoard board = new Game.Data.Contract.Board();
      IBoardAnalyzer analyzer = new BoardAnalyzer(board);
      IGameOverRules gameOverRules = new GameOverRules(analyzer);
      IMovementRules moveValidationRules = new MovementRules(analyzer, board);
      IRuleSet ruleSet = new RuleSet(moveValidationRules, gameOverRules);
      IMillRuleEvaluator ruleEvaluator = new Evaluator(ruleSet, analyzer);
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(board, rowController);
      IBoardController boardController = new BoardController(board, analyzer, recognizer);
      boardController.Initialize();


      History history = new History();
      _controller = new GameController(ruleEvaluator, board, history, boardController, recognizer, rowController);
      _controller.PlayerWon += OnPlayerWon;
      _controller.MillCompleted += OnMillCompleted;
      _controller.NewGame(player1, player2);

      while (true) {
        Draw(board, _controller.ActivePlayer);
        GamePhases activePhase = ruleEvaluator.EvaluatePhase(_controller.ActivePlayer);
        switch (activePhase) {
          case GamePhases.Set:
            Set(_controller);
            break;
          case GamePhases.Draw:
          case GamePhases.Jump:
            DrawJump(_controller);
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }
    }

    private static void OnMillCompleted() {
      Unset(_controller);
    }

    private static void DrawJump(IGameController controller) {
      Console.Write(controller.ActivePlayer.Name + " Chose Start Level, X and Y: ");
      Coordinate source = GetCoordinateFromUser();

      Console.Write(controller.ActivePlayer.Name + " Chose Destination Level, X and Y: ");
      Coordinate destination = GetCoordinateFromUser();
      Move move = new Move(source, destination, controller.ActivePlayer);
      bool validTurn = controller.DoTurn(move);
    }

    private static void Set(IGameController controller) {
      Console.Write(controller.ActivePlayer.Name + " Chose Level, X and Y: ");
      Coordinate coordinate = GetCoordinateFromUser();
      bool validTurn = controller.Set(coordinate, controller.ActivePlayer);
    }

    private static void Unset(IGameController controller) {
      Console.Write(controller.ActivePlayer.Name + " Chose to remove: Level, X and Y: ");
      Coordinate coordinate = GetCoordinateFromUser();
      bool validTurn = controller.Unset(coordinate, controller.ActivePlayer);
    }

    private static Coordinate GetCoordinateFromUser() {
      ConsoleKeyInfo key = Console.ReadKey();
      int.TryParse(key.KeyChar.ToString(), out int level);
      key = Console.ReadKey();
      int.TryParse(key.KeyChar.ToString(), out int x);
      key = Console.ReadKey();
      int.TryParse(key.KeyChar.ToString(), out int y);
      Console.WriteLine();
      Coordinate coordinate = new Coordinate(level, x, y);
      return coordinate;
    }

    private static void OnPlayerWon(IPlayer player) {
      Console.WriteLine(player.Name + " hat krass gewonnen, diggah!");
    }

    /// <summary>
    /// TODO kill me
    /// </summary>
    /// <param name="board"></param>
    /// <param name="controllerActivePlayer"></param>
    private static void Draw(IBoard board, IPlayer controllerActivePlayer) {
      Spot[,] level1 = board.Spots[0];
      Spot[,] level2 = board.Spots[1];
      Spot[,] level3 = board.Spots[2];

      Console.WriteLine($@"{level1[0, 0]}-----{level1[1, 0]}-----{level1[2, 0]}");
      Console.WriteLine($@"| {level2[0, 0]}---{level2[1, 0]}---{level2[2, 0]} |");
      Console.WriteLine($@"| | {level3[0, 0]}-{level3[1, 0]}-{level3[2, 0]} | |");
      Console.WriteLine(
          $@"{level1[0, 1]} {level2[0, 1]} {level3[0, 1]}   {level3[2, 1]} {level2[2, 1]} {level1[2, 1]}");
      Console.WriteLine($@"| | {level3[0, 2]}-{level3[1, 2]}-{level3[2, 2]} | |");
      Console.WriteLine($@"| {level2[0, 2]}---{level2[1, 2]}---{level2[2, 2]} |");
      Console.WriteLine($@"{level1[0, 2]}-----{level1[1, 2]}-----{level1[2, 2]}");
    }
  }
}