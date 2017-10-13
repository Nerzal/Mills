using System.Collections.Generic;

namespace Mills.Rules.Contract {
  public interface IBaseRules<TObject> : IEnumerable<ValidationRule<TObject>> {
    /// <summary>
    /// Initializes this ruleset
    /// </summary>
    void Initialize();

    /// <summary>
    /// Invokes all previously added rules
    /// </summary>
    /// <param name="evaluatable">object to be evaluated</param>
    /// <returns>success of all rules</returns>
    bool Evaluate(TObject evaluatable);
  }
}