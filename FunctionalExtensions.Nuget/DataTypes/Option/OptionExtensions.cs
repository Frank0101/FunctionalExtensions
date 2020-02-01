namespace FunctionalExtensions.Nuget.DataTypes.Option
{
    public static class OptionExtensions
    {
        public static (Option<T1>, Option<T2>) Unzip<T1, T2>(this Option<(T1, T2)> option) =>
            option.Fold((Option.None<T1>(), Option.None<T2>()), tuple =>
            {
                var (value1, value2) = tuple;
                return (Option.From(value1), Option.From(value2));
            });

        public static (Option<T1>, Option<T2>, Option<T3>) Unzip3<T1, T2, T3>(this Option<(T1, T2, T3)> option) =>
            option.Fold((Option.None<T1>(), Option.None<T2>(), Option.None<T3>()), tuple =>
            {
                var (value1, value2, value3) = tuple;
                return (Option.From(value1), Option.From(value2), Option.From(value3));
            });
    }
}
