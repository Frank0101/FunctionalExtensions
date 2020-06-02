using System;
using System.Collections.Generic;
using FunctionalExtensions.Nuget.Exceptions;

namespace FunctionalExtensions.Nuget.DataTypes.OptionDataTypes
{
    public class None<T> : Option<T>
    {
        public override T Value =>
            throw new OptionValueNullException();

        public override bool IsDefined => false;

        internal None()
        {
        }

        public override Option<T> OrElse(Option<T> defaultOption) =>
            defaultOption;

        public override Option<T> OrElse(Func<Option<T>> defaultFunction) =>
            defaultFunction();

        public override T GetOrElse(T defaultValue) => defaultValue;

        public override T2 Fold<T2>(T2 defaultValue, Func<T, T2> mapFunction) =>
            defaultValue;

        public override Option<T2> Map<T2>(Func<T, T2> mapFunction) =>
            Option.None<T2>();

        public override Option<T2> FlatMap<T2>(Func<T, Option<T2>> mapFunction) =>
            Option.None<T2>();

        public override void Foreach(Action<T> action)
        {
        }

        public override Option<T2> Collect<T2>(Func<T, T2> mapFunction) =>
            Option.None<T2>();

        public override Option<T> Filter(Func<T, bool> predicate) => this;
        public override Option<T> FilterNot(Func<T, bool> predicate) => this;
        public override bool Exists(Func<T, bool> predicate) => false;
        public override bool ForAll(Func<T, bool> predicate) => true;
        public override bool Contains(T value) => false;

        public override Option<(T, T2)> Zip<T2>(Option<T2> otherOption) =>
            Option.None<(T, T2)>();

        public override List<T> ToList() => new List<T>();
    }
}
