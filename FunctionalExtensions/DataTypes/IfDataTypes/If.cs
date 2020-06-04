using System;
using FunctionalExtensions.DataTypes.OptionDataTypes;

namespace FunctionalExtensions.DataTypes.IfDataTypes
{
    public static class If
    {
        public static If<T> Eval<T>(Func<bool> predicate, Func<T> resultFunction) =>
            predicate()
                ? new If<T>(Option.Some(resultFunction))
                : new If<T>(Option.None<Func<T>>());
    }

    public class If<T>
    {
        private readonly Option<Func<T>> _maybeResultFunction;

        internal If(Option<Func<T>> maybeResultFunction)
        {
            _maybeResultFunction = maybeResultFunction;
        }

        public If<T> ElseIf(Func<bool> predicate, Func<T> resultFunction) =>
            _maybeResultFunction switch
            {
                Some<T> _ => this,
                _ => predicate()
                    ? new If<T>(Option.Some(resultFunction))
                    : this
            };

        public T Else(Func<T> resultFunction) =>
            _maybeResultFunction.GetOrElse(resultFunction)();

        public Option<T> ToOption() =>
            _maybeResultFunction.Map(resultFunction => resultFunction());
    }
}
