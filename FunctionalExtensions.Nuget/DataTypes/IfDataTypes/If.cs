using System;
using FunctionalExtensions.Nuget.DataTypes.OptionDataTypes;

namespace FunctionalExtensions.Nuget.DataTypes.IfDataTypes
{
    public static class If
    {
        public static If<T> Eval<T>(Func<bool> predicate, Func<T> resultFunction) =>
            new If<T>(predicate()
                ? Option.Some(resultFunction)
                : Option.None<Func<T>>());
    }

    public class If<T>
    {
        private readonly Option<Func<T>> _maybeResultFunction;

        internal If(Option<Func<T>> maybeResultFunction)
        {
            _maybeResultFunction = maybeResultFunction;
        }

        public If<T> ElseIf(Func<bool> predicate, Func<T> resultFunction) =>
            new If<T>(_maybeResultFunction.OrElse(() => predicate()
                ? Option.Some(resultFunction)
                : Option.None<Func<T>>()));

        public T Else(Func<T> resultFunction) =>
            _maybeResultFunction.GetOrElse(resultFunction)();

        public Option<T> ToOption() =>
            _maybeResultFunction.Map(resultFunction => resultFunction());
    }
}
