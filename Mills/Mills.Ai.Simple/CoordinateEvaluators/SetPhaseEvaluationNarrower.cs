using System.Collections.Generic;
using System.Linq;

namespace Mills.Ai.Simple.CoordinateEvaluators {
  internal sealed class SetPhaseEvaluationNarrower : CoordinateEvaluator {
    public override void Evaluate(ref IList<ValuedCoordinate> coordinates) {
      IList<ValuedCoordinate> narrowed = new List<ValuedCoordinate>();

      IOrderedEnumerable<decimal> foo = coordinates.Select(i => i.Score).Distinct().OrderByDescending(i => i);

      decimal largest = foo.FirstOrDefault();
      decimal second = foo.Skip(1).FirstOrDefault();

      foreach (ValuedCoordinate coordinate in coordinates) {
        if (coordinate.Score == largest) {
          narrowed.Add(coordinate);
          narrowed.Add(coordinate);
        } else if (coordinate.Score == second) {
          narrowed.Add(coordinate);
        }
      }
      coordinates = narrowed;
    }
  }
}
