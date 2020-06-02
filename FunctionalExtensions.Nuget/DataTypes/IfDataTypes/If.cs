using System;
using FunctionalExtensions.Nuget.DataTypes.OptionDataTypes;

namespace FunctionalExtensions.Nuget.DataTypes.IfDataTypes
{
    public class If<T>
    {
        private readonly Option<Func<T>> _maybeResultFunction;

        public If(Option<Func<T>> maybeResultFunction)
        {
            _maybeResultFunction = maybeResultFunction;
        }

        public If<T> ElseIf(Func<bool> predicate, Func<T> resultFunction) =>
            new If<T>(_maybeResultFunction.OrElse(() =>
                predicate()
                    ? Option.Some(resultFunction)
                    : Option.None<Func<T>>()));

        public T Else(Func<T> resultFunction) =>
            _maybeResultFunction.GetOrElse(resultFunction)();

        public Option<T> ToOption() =>
            _maybeResultFunction.Map(resultFunction => resultFunction());
    }
}
