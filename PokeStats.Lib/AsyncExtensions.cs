namespace PokeStats.Lib;

public static class AsyncExtensions
{
    public static async Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> tasks, CancellationToken cancellationToken = default) =>
        await Task.WhenAll(tasks);

    public static async Task<Option<U>> Bind<T, U>(this Task<Option<T>> task, Func<T, Option<U>> f) => (await task).Bind(f);
}