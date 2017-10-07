using System.Collections.Generic;

namespace Mills.ConsoleClient.Rules.GameOver {
    public interface IBaseRules<TObject> : IEnumerable<ValidationRule<TObject>> {
        /// <summary>
        /// Initializes this ruleset
        /// </summary>
        void Initialize();
    }
}