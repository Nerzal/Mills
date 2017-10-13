using System.Collections.Generic;

namespace Mills.Ai.Simple.CoordinateEvaluators {
  internal sealed class BasicScoreApplier : CoordinateEvaluator {
    public override void Evaluate(ref IList<ValuedCoordinate> coordinates) {
      foreach (ValuedCoordinate valuedCoordinate in coordinates) {
        valuedCoordinate.Score = valuedCoordinate.ProtoSpot.BaseScore + valuedCoordinate.ProtoSpot.BaseMovabilityIndex;
      }
    }
  }
}
