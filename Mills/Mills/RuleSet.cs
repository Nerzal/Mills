using System;
using System.Collections.Generic;

namespace Mills {
  public class RuleSet : IRuleSet {
    public IEnumerable<ValidationRule<Move>> MoveValidationRules { get; }
  }
}