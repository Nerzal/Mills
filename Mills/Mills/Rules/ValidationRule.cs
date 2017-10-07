using System;

namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Base class for validation rules which represent a single game rule each
    /// </summary>
    /// <typeparam name="TValidateable"></typeparam>
    public abstract class ValidationRule<TValidateable> {
        /// <summary>
        /// The Function which evaluates this rule
        /// </summary>
        private readonly Func<TValidateable, bool> _evaluator;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="evaluator"></param>
        protected ValidationRule(Func<TValidateable, bool> evaluator) {
            this._evaluator = evaluator;
        }

        /// <summary>
        /// Evaluates this rule
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Evaluate(TValidateable element) {
            return this._evaluator(element);
        }
    }
}