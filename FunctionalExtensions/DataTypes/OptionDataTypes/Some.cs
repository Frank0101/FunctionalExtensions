using System;
using System.Collections.Generic;
using FunctionalExtensions.Exceptions;

namespace FunctionalExtensions.DataTypes.OptionDataTypes
{
    public class Some<T> : Option<T>
    {
        public override T Value { get; }
        public override bool IsDefined => true;

        internal Some(T value)
        {
            Value = value switch
            {
                { } someValue => someValue,
                _ => throw new OptionValueNullException()
            };
        }

        public void Deconstruct(out T value)
        {
            value = Value;
        }

        public override Option<T> OrElse(Option<T> defaultOption) => this;
        public override Option<T> OrElse(Func<Option<T>> defaultFunction) => this;
        public override T GetOrElse(T defaultValue) => Value;
        public override T GetOrElse(Func<T> defaultFunction) => Value;

        public override T2 Fold<T2>(T2 defaultValue, Func<T, T2> mapFunction) =>
            mapFunction(Value);

        public override T2 Fold<T2>(Func<T2> defaultFunction, Func<T, T2> mapFunction) =>
            mapFunction(Value);

        public override Option<T2> Map<T2>(Func<T, T2> mapFunction) =>
            Option.Some(mapFunction(Value));

        public override Option<T2> FlatMap<T2>(Func<T, Option<T2>> mapFunction) =>
            mapFunction(Value);

        public override void Foreach(Action<T> action) => action(Value);

        public override Option<T2> Collect<T2>(Func<T, T2> mapFunction) =>
            mapFunction(Value);

        public override Option<T> Filter(Func<T, bool> predicate) =>
            predicate(Value)
                ? this
                : Option.None<T>();

        public override Option<T> FilterNot(Func<T, bool> predicate) =>
            !predicate(Value)
                ? this
                : Option.None<T>();

        public override bool Exists(Func<T, bool> predicate) =>
            predicate(Value);

        public override bool ForAll(Func<T, bool> predicate) =>
            Exists(predicate);

        public override bool Contains(T value) =>
            Value.Equals(value);

        public override Option<(T, T2)> Zip<T2>(Option<T2> otherOption) =>
            otherOption.Collect(otherValue => (Value, otherValue));

        public override List<T> ToList() => new List<T> { Value };
    }
}
