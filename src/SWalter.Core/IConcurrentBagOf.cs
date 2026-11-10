using System.Collections.Concurrent;

namespace SWalter.Core;

/// <summary>
///     Defines a contract for a concurrent bag of a specific type.
///     <see cref="ConcurrentBag{T}" />
/// </summary>
/// <typeparam name="T"></typeparam>
// ReSharper disable once UnusedType.Global
public interface IConcurrentBagOf<T> : IValue<ConcurrentBag<T>>;