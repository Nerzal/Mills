using Mills.ConsoleClient.Ai;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.GameController;

namespace Mills.Ai.Simple {
  public class SimpleAi : AiPlayer {
    public SimpleAi(IGameController controller, IBoardAnalyzer analyzer) : base(controller, analyzer) {

    }

    protected override Move AnalyseInternal() {
      throw new System.NotImplementedException();
    }
  }
}
