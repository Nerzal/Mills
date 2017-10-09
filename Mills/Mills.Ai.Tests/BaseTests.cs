using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mills.ConsoleClient;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.Board.Controller;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;
using Mills.ConsoleClient.Rules;
using Mills.ConsoleClient.Rules.GameOver;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.Ai.Tests {
  [TestClass]
  public abstract class BaseTests {
    protected IBoard Board;
    protected IBoardAnalyzer Analyzer;
    protected IBoardController Controller;
    protected Player Player;
    protected Player Player2;
    protected IGameController GameController;

    [TestInitialize]
    public void InitializeTests() {
      this.Board = new Board();
      this.Analyzer = new BoardAnalyzer(this.Board);
      this.Controller = new BoardController(this.Board, this.Analyzer);
      this.Controller.Initialize();
      this.Player = new Player("Nerzal") { Color = Colors.White };
      this.Player2 = new Player("Wr4thon") { Color = Colors.Black };

      IMovementRules movementRules = new MovementRules(this.Analyzer, this.Board);
      IGameOverRules gameOverRules = new GameOverRules(this.Analyzer);
      IRuleSet ruleSet = new RuleSet(movementRules, gameOverRules);
      IHistory history = new History();
      IMillRuleEvaluator millRuleEvaluator = new Evaluator(ruleSet, this.Analyzer);
      this.GameController = new GameController(millRuleEvaluator, this.Board, history, this.Controller);
    }

  }
}