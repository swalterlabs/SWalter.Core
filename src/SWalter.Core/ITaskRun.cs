namespace SWalter.Core;

/// <summary>
///     Task RunAsync();
/// </summary>
// ReSharper disable once UnusedType.Global
public interface ITaskRun
{
    /// <summary>
    ///     RunAsync
    /// </summary>
    Task RunAsync(CancellationToken cancellationToken = default);
}