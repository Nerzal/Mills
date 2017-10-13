using System.Collections.Generic;
using System.IO;
using Mills.Ai.Simple.CoordinateEvaluators;
using Mills.ConsoleClient.Ai;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.GameController;

using Newtonsoft.Json;

namespace Mills.Ai.Simple {
  public class SimpleAi : AiPlayer {
    private readonly ProtoBoard _protoBoard;
    private readonly MoveEvaluator _moveEvaluator;
    private readonly IRandomProvider _random;

    public SimpleAi(IGameController controller, IBoardAnalyzer analyzer, IRandomProvider random) : base(controller, analyzer) {
      using (Stream resourceStream = GetType().Assembly.GetManifestResourceStream(GetType().Namespace + ".Board.json")) {
        using (StreamReader sr = new StreamReader(resourceStream)) {
          string content = sr.ReadToEnd();
          this._protoBoard = JsonConvert.DeserializeObject<ProtoBoard>(content);
        }
      }

      this._random = random;
      this._moveEvaluator = new MoveEvaluator(this.BoardAnalyzer, this._protoBoard);
      this._moveEvaluator.Initialize();
    }

    protected override Move AnalyseInternal() {
      IList<ValuedCoordinate> evaluatedCoordinates = this._moveEvaluator.EvaluateBoard();
      int coordinatesCount = evaluatedCoordinates.Count;
      int coordinateIndex = this._random.Next(0, coordinatesCount);
      ValuedCoordinate selectedCoordinate = evaluatedCoordinates[coordinateIndex];
      return new Move(Coordinate.Empty, selectedCoordinate.Coordinate, this);
    }
  }
}
