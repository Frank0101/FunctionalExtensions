using System;
using System.Collections.Generic;

namespace FunctionalExtensions.DataTypes.OptionDataTypes
{
    public static class Option
    {
        public static Option<T> Some<T>(T value) =>
            new Some<T>(value);

        public static Option<T> None<T>() => new None<T>();
        public static Option<T> From<T>(T value) => value;
    }

    public abstract class Option<T>
    {
        public static implicit operator Option<T>(T value) =>
            value switch
            {
                not null => Option.Some(value),
                _ => Option.None<T>()
            };

        public abstract T Value { get; }
        public abstract bool IsDefined { get; }

        public bool IsEmpty => !IsDefined;
        public bool NonEmpty => IsDefined;

        public abstract Option<T> OrElse(Option<T> defaultOption);
        public abstract Option<T> OrElse(Func<Option<T>> defaultFunction);
        public abstract T GetOrElse(T defaultValue);
        public abstract T GetOrElse(Func<T> defaultFunction);

        public T Get() => Value;

        public abstract T2 Fold<T2>(T2 defaultValue, Func<T, T2> mapFunction);
        public abstract T2 Fold<T2>(Func<T2> defaultFunction, Func<T, T2> mapFunction);
        public abstract Option<T2> Map<T2>(Func<T, T2> mapFunction);
        public abstract Option<T2> FlatMap<T2>(Func<T, Option<T2>> mapFunction);
        public abstract void Foreach(Action<T> action);
        public abstract Option<T2> Collect<T2>(Func<T, T2> mapFunction);
        public abstract Option<T> Filter(Func<T, bool> predicate);
        public abstract Option<T> FilterNot(Func<T, bool> predicate);
        public abstract bool Exists(Func<T, bool> predicate);
        public abstract bool ForAll(Func<T, bool> predicate);
        public abstract bool Contains(T value);
        public abstract Option<(T, T2)> Zip<T2>(Option<T2> otherOption);
        public abstract List<T> ToList();
    }
}
