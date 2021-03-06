using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mills.Rules.Contract;

namespace Mills.Rules.Rules {
  /// <summary>
  /// BaseClass for rules
  /// </summary>
  /// <typeparam name="TEvaluationObject"></typeparam>
  public abstract class BaseRules<TEvaluationObject> : IBaseRules<TEvaluationObject> {
    protected readonly ICollection<ValidationRule<TEvaluationObject>> Rules;

    /// <summary>
    /// ctor
    /// </summary>
    protected BaseRules() {
      this.Rules = new List<ValidationRule<TEvaluationObject>>();
    }

    /// <inheritdoc />
    public abstract void Initialize();

    /// <inheritdoc />
    public IEnumerator<ValidationRule<TEvaluationObject>> GetEnumerator() {
      return this.Rules.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }

    /// <inheritdoc cref="IBaseRules{TEvaluationObject}"/>
    public bool Evaluate(TEvaluationObject evaluatable) {
      return this.Rules.All(movementRules => movementRules.Evaluate(evaluatable));
    }
  }
}