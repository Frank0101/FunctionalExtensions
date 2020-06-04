using System;
using FunctionalExtensions.Exceptions;

namespace FunctionalExtensions.DataTypes.TryDataTypes
{
    public class Success<T> : Try<T>
    {
        public override T Value { get; }

        public override Exception Error =>
            throw new TryIsSuccessException();

        public override bool IsSuccess => true;

        internal Success(T value)
        {
            Value = value;
        }

        public void Deconstruct(out T value)
        {
            value = Value;
        }
    }
}
