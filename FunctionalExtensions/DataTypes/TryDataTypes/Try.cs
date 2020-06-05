using System;

namespace FunctionalExtensions.DataTypes.TryDataTypes
{
    public static class Try
    {
        public static Try<T> Eval<T>(Func<T> tryFunction)
        {
            try
            {
                return Success(tryFunction());
            }
            catch (Exception error)
            {
                return Failure<T>(error);
            }
        }

        public static Try<T> Success<T>(T value) =>
            new Success<T>(value);

        public static Try<T> Failure<T>(Exception error) =>
            new Failure<T>(error);

        public static Try<T> From<T>(T value) => value;
        public static Try<T> From<T>(Exception error) => error;
    }

    public abstract class Try<T>
    {
        public static implicit operator Try<T>(T value) =>
            Try.Success(value);

        public static implicit operator Try<T>(Exception error) =>
            Try.Failure<T>(error);

        public abstract T Value { get; }
        public abstract Exception Error { get; }
        public abstract bool IsSuccess { get; }
    }
}
