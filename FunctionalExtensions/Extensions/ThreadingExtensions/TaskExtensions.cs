using System;
using System.Threading.Tasks;

namespace FunctionalExtensions.Extensions.ThreadingExtensions
{
    public static class TaskExtensions
    {
        public static async Task<T2> Map<T1, T2>(this Task<T1> task, Func<T1, T2> mapFunction)
        {
            var result = await task;
            return mapFunction(result);
        }

        public static async Task<T2> FlatMap<T1, T2>(this Task<T1> task, Func<T1, Task<T2>> mapFunction)
        {
            var result = await task;
            return await mapFunction(result);
        }

        public static async Task Foreach<T>(this Task<T> task, Func<T, Task> mapFunction)
        {
            var result = await task;
            await mapFunction(result);
        }
    }
}
