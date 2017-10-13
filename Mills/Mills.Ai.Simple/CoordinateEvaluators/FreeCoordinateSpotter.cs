using System.Collections.Generic;
using Mills.Board.Logic.Contract;

namespace Mills.Ai.Simple.CoordinateEvaluators {
  internal sealed class FreeCoordinateSpotter : CoordinateEvaluator {
    private readonly IBoardAnalyzer _boardAnalyzer;

    public FreeCoordinateSpotter(IBoardAnalyzer boardAnalyzer) {
      this._boardAnalyzer = boardAnalyzer;
    }

    public override void Evaluate(ref IList<ValuedCoordinate> coordinates) {
      IList<ValuedCoordinate> freeCoordinates = new List<ValuedCoordinate>();
      foreach (ValuedCoordinate coordinate in coordinates) {
        if (!this._boardAnalyzer.IsFreeSpot(coordinate.Coordinate)) {
          continue;
        }
        freeCoordinates.Add(coordinate);
      }

      coordinates = freeCoordinates;
    }
  }
}
