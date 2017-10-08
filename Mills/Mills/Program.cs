using System;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;
using Mills.ConsoleClient.Rules;
using Mills.ConsoleClient.Rules.GameOver;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.ConsoleClient {
    class Program {
        static void Main(string[] args) {
            IPlayer player1 = new Player.Player("Olaf");
            IPlayer player2 = new Player.Player("Karl");
            
            IBoard board = new Board.Board();
            IBoardController boardController = new BoardController(board);
            boardController.Initialize();

            IGameOverRules gameOverRules = new GameOverRules(boardController);
            IMovementRules moveValidationRules = new MovementRules(boardController, board);
            IRuleSet ruleSet = new RuleSet(moveValidationRules, gameOverRules);
            IMillRuleEvaluator ruleEvaluator = new Evaluator(ruleSet);

           
            History history = new History();
            IGameController controller = new GameController.GameController(ruleEvaluator, board, history, boardController);
            controller.PlayerWon += OnPlayerWon;
            controller.NewGame(player1, player2);

            while (true) {
                Draw(board, controller.ActivePlayer);
                ConsoleKeyInfo key = Console.ReadKey();
                int.TryParse(key.KeyChar.ToString(), out int level);
                key = Console.ReadKey();
                int.TryParse(key.KeyChar.ToString(), out int x);
                key = Console.ReadKey();
                int.TryParse(key.KeyChar.ToString(), out int y);
                Console.WriteLine();
                Coordinate coordinate = new Coordinate(level, x, y, controller.ActivePlayer);
                bool validTurn = controller.DoTurn(new Move(null, coordinate, controller.ActivePlayer));
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

            Console.Write(controllerActivePlayer.Name + " Chose Level, X and Y: ");
        }
    }
}