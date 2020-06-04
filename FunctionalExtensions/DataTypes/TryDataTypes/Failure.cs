using System;
using FunctionalExtensions.Exceptions;

namespace FunctionalExtensions.DataTypes.TryDataTypes
{
    public class Failure<T> : Try<T>
    {
        public override T Value =>
            throw new TryIsFailureException();

        public override Exception Error { get; }

        public override bool IsSuccess => false;

        internal Failure(Exception error)
        {
            Error = error;
        }

        public void Deconstruct(out Exception error)
        {
            error = Error;
        }
    }
}
