using System;

namespace FunctionalExtensions.Nuget
{
    public struct Option<T>
    {
        private readonly T _value;
        private readonly bool _isDefined;

        private Option(T value, bool isDefined)
        {
            _value = value;
            _isDefined = isDefined;
        }

        public bool IsDefined => _isDefined;
        public bool IsEmpty => !_isDefined;

        public static Option<T> None => default;

        public static Option<T> Some(T value) =>
            value != null
                ? new Option<T>(value, true)
                : throw new ArgumentNullException();
    }
}
