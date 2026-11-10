using System.Collections;

namespace SWalter.Core.Internal;

/// <inheritdoc />
/// <summary>
///     Interface to provide multi-threading execution.
///     Calls actions by processor count.
/// </summary>
public interface IMultiThreading : IRunFor2<IList, Action<Tuple<int, int>>>;