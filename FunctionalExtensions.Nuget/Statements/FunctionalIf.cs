using System;
using FunctionalExtensions.Nuget.DataTypes.IfDataTypes;
using FunctionalExtensions.Nuget.DataTypes.OptionDataTypes;

namespace FunctionalExtensions.Nuget.Statements
{
    public static partial class Functional
    {
        public static If<T> If<T>(Func<bool> predicate, Func<T> resultFunction) =>
            new If<T>(predicate()
                ? Option.Some(resultFunction)
                : Option.None<Func<T>>());
    }
}
