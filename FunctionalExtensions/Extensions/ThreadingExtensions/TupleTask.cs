using System.Threading.Tasks;

namespace FunctionalExtensions.Extensions.ThreadingExtensions
{
    public static class TupleTask
    {
        public static async Task<(T1, T2)> WhenAll2<T1, T2>(Task<T1> task1, Task<T2> task2)
        {
            await Task.WhenAll(task1, task2);
            return (await task1, await task2);
        }

        public static async Task<(T1, T2, T3)> WhenAll3<T1, T2, T3>(Task<T1> task1, Task<T2> task2, Task<T3> task3)
        {
            await Task.WhenAll(task1, task2, task3);
            return (await task1, await task2, await task3);
        }
    }
}
