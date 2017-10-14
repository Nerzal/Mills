using System;
using System.Collections.Generic;

using Mills.Board.Logic.Contract;
using Mills.Game.Contract.Data;
using Mills.Game.Data.Contract;
using Mills.Utils;

namespace Mills.Ai.Simple.CoordinateEvaluators {
  internal class MoveEvaluator {
    private readonly List<CoordinateEvaluator> _setEvaluators;
    private readonly IBoardAnalyzer _boardAnalyzer;
    private readonly IRandomProvider _randomProvider;
    private readonly ProtoBoard _protoBoard;

    public MoveEvaluator(IBoardAnalyzer boardAnalyzer, IRandomProvider randomProvider, ProtoBoard protoBoard) {
      this._boardAnalyzer = boardAnalyzer;
      _randomProvider = randomProvider;
      this._protoBoard = protoBoard;
      this._setEvaluators = new List<CoordinateEvaluator>();
    }

    public void Initialize() {
      this._setEvaluators.Add(new FreeCoordinateSpotter(this._boardAnalyzer));
      this._setEvaluators.Add(new BasicScoreApplier());
      this._setEvaluators.Add(new SetPhaseEvaluationNarrower());
    }

    public Move EvaluateBoard(GamePhases currentPhase) {
      Coordinate sourceCoordinate = Coordinate.Empty;
      Coordinate targetCoordinate = Coordinate.Empty;
      IList<ValuedCoordinate> spots = new List<ValuedCoordinate>();

      foreach (Coordinate coordinate in this._protoBoard.GetAllCoordinates()) {
        ProtoSpot protoSpot = this._protoBoard.GetCoordinate(coordinate.Level, coordinate.X, coordinate.Y);
        spots.Add(new ValuedCoordinate(coordinate, protoSpot));
      }

      switch (currentPhase) {
        case GamePhases.Set: {
            spots = RunEvaluatorSet(spots, this._setEvaluators);
            targetCoordinate = PickRandomCoordinate(spots);
          }
          break;
        case GamePhases.Draw:
          break;
        case GamePhases.Jump:
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(currentPhase), currentPhase, null);
      }

      return new Move(sourceCoordinate, targetCoordinate);
    }

    private IList<ValuedCoordinate> RunEvaluatorSet(IList<ValuedCoordinate> spots, IEnumerable<CoordinateEvaluator> coordinateEvaluators) {
      foreach (CoordinateEvaluator spotEvaluator in coordinateEvaluators) {
        spotEvaluator.Evaluate(ref spots);
      }

      return spots;
    }

    private Coordinate PickRandomCoordinate(IList<ValuedCoordinate> spots) {
      int coordinatesCount = spots.Count;
      int coordinateIndex = this._randomProvider.Next(0, coordinatesCount);
      Coordinate targetCoordinate = spots[coordinateIndex].Coordinate;
      return targetCoordinate;
    }
  }
}
