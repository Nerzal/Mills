﻿using System.Collections.Generic;

namespace Mills.ConsoleClient {
  public class RuleSet : IRuleSet {
    public IEnumerable<ValidationRule<Move>> MoveValidationRules { get; }
    public IEnumerable<ValidationRule<IBoard>> GameOverRules { get; }

    public RuleSet(IEnumerable<ValidationRule<Move>> moveValidationRules, IEnumerable<ValidationRule<IBoard>> gameOverRules) {
      this.MoveValidationRules = moveValidationRules;
      this.GameOverRules = gameOverRules;
    }
  }
}