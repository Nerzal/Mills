using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Rules;
using Mills.ConsoleClient.Rules.GameOver;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.Tests {
  [TestClass]
  public class EvaluatorTests : BaseTests {
    private Evaluator _evaluator;

    [TestInitialize]
    public void Initialize() {
      MovementRules moveValidationRules = new MovementRules(this.Analyzer, this.Board);
      GameOverRules gameOverRules = new GameOverRules(this.Analyzer);
      RuleSet ruleSet = new RuleSet(moveValidationRules, gameOverRules);
      this._evaluator = new Evaluator(ruleSet, this.Analyzer);
    }

    [TestMethod]
    public void EvaluatePhase_Phase1_2OffBoardStonesWhite() {
      // Arrange
      // Most of Arrangement is done via TestInitialize of the BaseClass
      // The Second part is done via the Initialize Method of this class

      //Act
      this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
      this.Controller.Set(new Coordinate(0, 0, 1), this.Player);
      this.Controller.Set(new Coordinate(0, 0, 2), this.Player);
      this.Controller.Set(new Coordinate(0, 1, 0), this.Player);
      this.Controller.Set(new Coordinate(0, 2, 0), this.Player);
      this.Controller.Set(new Coordinate(1, 0, 0), this.Player);
      GamePhases phase = this._evaluator.EvaluatePhase(this.Player);
      //Assert
      Assert.AreEqual(GamePhases.Set, phase);
    }

    [TestMethod]
    public void EvaluatePhase_Phase2_4StonesWhite() {
      // Arrange
      // Most of Arrangement is done via TestInitialize of the BaseClass
      // The Second part is done via the Initialize Method of this class
      this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
      this.Controller.Set(new Coordinate(0, 0, 1), this.Player);
      this.Controller.Set(new Coordinate(0, 0, 2), this.Player);
      this.Controller.Set(new Coordinate(0, 1, 0), this.Player);
      this.Controller.Set(new Coordinate(0, 2, 0), this.Player);
      this.Controller.Set(new Coordinate(1, 1, 0), this.Player);
      this.Controller.Set(new Coordinate(1, 2, 0), this.Player);
      this.Controller.Set(new Coordinate(1, 0, 1), this.Player);
      this.Controller.Unset(new Coordinate(0, 2, 0), this.Player);
      this.Controller.Unset(new Coordinate(1, 1, 0), this.Player);
      this.Controller.Unset(new Coordinate(1, 2, 0), this.Player);
      this.Controller.Unset(new Coordinate(1, 0, 1), this.Player);

      //Act
      GamePhases phase = this._evaluator.EvaluatePhase(this.Player);

      //Assert
      Assert.AreEqual(GamePhases.Draw, phase);
    }

    [TestMethod]
    public void EvaluatePhase_Phase3_2StonesWhite() {
      // Arrange
      // Most of Arrangement is done via TestInitialize of the BaseClass
      // The Second part is done via the Initialize Method of this class
      this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
      this.Controller.Set(new Coordinate(0, 0, 1), this.Player);
      this.Controller.Set(new Coordinate(0, 0, 2), this.Player);
      this.Controller.Set(new Coordinate(0, 1, 0), this.Player);
      this.Controller.Set(new Coordinate(0, 2, 0), this.Player);
      this.Controller.Set(new Coordinate(1, 1, 0), this.Player);
      this.Controller.Set(new Coordinate(1, 2, 0), this.Player);
      this.Controller.Set(new Coordinate(1, 0, 1), this.Player);
      this.Controller.Unset(new Coordinate(0, 0, 0), this.Player2);
      this.Controller.Unset(new Coordinate(0, 0, 1), this.Player2);
      this.Controller.Unset(new Coordinate(0, 0, 2), this.Player2);
      this.Controller.Unset(new Coordinate(1, 1, 0), this.Player2);
      this.Controller.Unset(new Coordinate(1, 2, 0), this.Player2);

      //Act
      GamePhases phase = this._evaluator.EvaluatePhase(this.Player);

      //Assert
      Assert.AreEqual(GamePhases.Jump, phase);
    }
  }
}