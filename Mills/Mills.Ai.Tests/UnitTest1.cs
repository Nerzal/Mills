using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mills.ConsoleClient.Player;
using NSubstitute;
using NSubstitute.Extensions;
namespace Mills.Ai.Tests {
  [TestClass]
  public class UnitTest1 : BaseTests {
    [TestMethod]
    public void TestMethod1() {
      IRandomProvider randomProvider = NSubstitute.Substitute.For<IRandomProvider>();
      randomProvider.Next(0, 0).ReturnsForAnyArgs(5);

      SimpleAi simpleAi = new SimpleAi(this.GameController, this.Analyzer, randomProvider);
      Move move = simpleAi.Analyse();
      simpleAi.Act(move);
    }
  }
}
