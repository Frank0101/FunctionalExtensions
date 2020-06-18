using System;
using System.Threading.Tasks;

namespace FunctionalExtensions.Extensions.ThreadingExtensions
{
    public static class ValueTaskExtensions
    {
        public static async ValueTask<T2> Map<T1, T2>(this ValueTask<T1> task, Func<T1, T2> mapFunction)
        {
            var result = await task;
            return mapFunction(result);
        }

        public static async ValueTask<T2> FlatMap<T1, T2>(this ValueTask<T1> task, Func<T1, ValueTask<T2>> mapFunction)
        {
            var result = await task;
            return await mapFunction(result);
        }

        public static async ValueTask Foreach<T>(this ValueTask<T> task, Func<T, ValueTask> mapFunction)
        {
            var result = await task;
            await mapFunction(result);
        }
    }
}
