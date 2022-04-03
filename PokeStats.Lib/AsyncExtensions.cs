namespace PokeStats.Lib;

public static class AsyncExtensions
{
    public static async Task<IEnumerable<T>> WhenAll<T>(
        this IEnumerable<Task<T>> tasks, CancellationToken cancellationToken = default) =>
            await Task.WhenAll(tasks);
}