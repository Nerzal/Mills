using System.Collections.Generic;

namespace Mills.Ai.Simple.CoordinateEvaluators {
  internal abstract class CoordinateEvaluator {
    public abstract void Evaluate(ref IList<ValuedCoordinate> coordinates);
  }
}
