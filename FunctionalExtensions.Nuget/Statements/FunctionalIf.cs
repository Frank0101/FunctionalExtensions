namespace FunctionalExtensions.Nuget.Statements
{
    public static partial class Functional
    {
        /*
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IfResult<T> If<T>(Func<bool> predicate, Func<T> resultFunction) =>
            new IfResult<T>(
                predicate()
                    ? Option.Some(resultFunction)
                    : Option.None<Func<T>>());

        [Serializable]
        public struct IfResult<T>
        {
            private readonly Option<Func<T>> _maybeResultFunction;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal IfResult(Option<Func<T>> maybeResultFunction)
            {
                _maybeResultFunction = maybeResultFunction;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly IfResult<T> ElseIf(Func<bool> predicate, Func<T> resultFunction) =>
                new IfResult<T>(_maybeResultFunction.OrElse(() =>
                    predicate()
                        ? Option.Some(resultFunction)
                        : Option.None<Func<T>>()));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly T Else(Func<T> resultFunction) =>
                _maybeResultFunction.GetOrElse(resultFunction)();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Option<T> ToOption() =>
                _maybeResultFunction.Map(f => f());
        }
        */
    }
}
