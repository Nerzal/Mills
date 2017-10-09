using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mills.Ai.Simple;
using Mills.ConsoleClient.Ai;
using Mills.ConsoleClient.GameController;

namespace Mills.Ai.Tests {
  [TestClass]
  public class UnitTest1 : BaseTests {
    [TestMethod]
    public void TestMethod1() {
      IAiPlayer simpleAi = new SimpleAi(this.GameController, this.Analyzer);
      Move move = simpleAi.Analyse();
      simpleAi.Act(move);
    }
  }
}
