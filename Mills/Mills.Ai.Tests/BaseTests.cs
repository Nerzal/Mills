using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.Board.Logic;
using Mills.Board.Logic.Contract;
using Mills.Game.Contract;
using Mills.Game.Data.Contract;
using Mills.Game.GameController;
using Mills.Game.Player;
using Mills.Rules.Contract;
using Mills.Rules.GameOver;
using Mills.Rules.Movement;
using Mills.Rules.Rules;

namespace Mills.Ai.Tests {
  [TestClass]
  public abstract class BaseTests {
    protected IBoard Board;
    protected IBoardAnalyzer Analyzer;
    protected IBoardController Controller;
    protected IPlayer Player;
    protected IPlayer Player2;
    protected IGameController GameController;
    protected IMillRuleEvaluator MillRuleEvaluator;
    protected IPatternRecognizer Recognizer;
    protected IRowController RowController;

    [TestInitialize]
    public void InitializeTests() {
      this.Board = new Game.Data.Contract.Board();
      this.RowController = new RowController();
      this.Recognizer = new PatternRecognizer(this.Board, this.RowController);
      this.Analyzer = new BoardAnalyzer(this.Board);
      this.Controller = new BoardController(this.Board, this.Analyzer, this.Recognizer);
      this.Controller.Initialize();
      this.Player = new Player("Nerzal") { Color = Colors.White };
      this.Player2 = new Player("Wr4thon") { Color = Colors.Black };

      IMovementRules movementRules = new MovementRules(this.Analyzer, this.Board);
      IGameOverRules gameOverRules = new GameOverRules(this.Analyzer);
      IRuleSet ruleSet = new RuleSet(movementRules, gameOverRules);
      IHistory history = new History();
      this.MillRuleEvaluator = new Evaluator(ruleSet, this.Analyzer);
      IRowController rowController = new RowController();
      IPatternRecognizer patternRecognizer = new PatternRecognizer(this.Board, rowController);

      this.GameController = new GameController(this.MillRuleEvaluator, this.Board, history, this.Controller, patternRecognizer, rowController);
    }
  }
}