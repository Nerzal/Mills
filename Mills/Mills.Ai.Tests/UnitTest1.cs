using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.Ai.Simple;
using Mills.Game.Data.Contract;
using Mills.Utils;
using NSubstitute;
namespace Mills.Ai.Tests {
  [TestClass]
  public class UnitTest1 : BaseTests {
    [TestMethod]
    public void TestMethod1() {
      IRandomProvider randomProvider = NSubstitute.Substitute.For<IRandomProvider>();
      randomProvider.Next(0, 0).ReturnsForAnyArgs(5);

      SimpleAi simpleAi = new SimpleAi(this.GameController, this.Analyzer, randomProvider, this.MillRuleEvaluator);
      Move move = simpleAi.Analyse();
      simpleAi.Act(move);
    }
  }
}
