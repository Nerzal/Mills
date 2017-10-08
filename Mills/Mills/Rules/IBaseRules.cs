using System.Collections.Generic;

namespace Mills.ConsoleClient.Rules {
    public interface IBaseRules<TObject> : IEnumerable<ValidationRule<TObject>> {
        /// <summary>
        /// Initializes this ruleset
        /// </summary>
        void Initialize();
    }
}