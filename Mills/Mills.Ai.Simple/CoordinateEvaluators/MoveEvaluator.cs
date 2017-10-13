using System.Collections.Generic;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;

namespace Mills.Ai.Simple.CoordinateEvaluators {
  internal class MoveEvaluator {
    private readonly List<CoordinateEvaluator> _evaluators;
    private readonly IBoardAnalyzer _boardAnalyzer;
    private readonly ProtoBoard _protoBoard;

    public MoveEvaluator(IBoardAnalyzer boardAnalyzer, ProtoBoard protoBoard) {
      this._boardAnalyzer = boardAnalyzer;
      this._protoBoard = protoBoard;
      this._evaluators = new List<CoordinateEvaluator>();
    }

    public void Initialize() {
      this._evaluators.Add(new FreeCoordinateSpotter(this._boardAnalyzer));
      this._evaluators.Add(new BasicScoreApplier());
      this._evaluators.Add(new SetPhaseEvaluationNarrower());
    }

    public IList<ValuedCoordinate> EvaluateBoard() {
      IList<ValuedCoordinate> spots = new List<ValuedCoordinate>();
      foreach (Coordinate coordinate in this._protoBoard.GetAllCoordinates()) {
        ProtoSpot protoSpot = this._protoBoard.GetCoordinate(coordinate.Level, coordinate.X, coordinate.Y);
        spots.Add(new ValuedCoordinate(coordinate, protoSpot));
      }

      foreach (CoordinateEvaluator spotEvaluator in this._evaluators) {
        spotEvaluator.Evaluate(ref spots);
      }

      return spots;
    }
  }
}