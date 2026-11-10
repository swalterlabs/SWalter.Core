using System.Collections.Concurrent;

namespace SWalter.Core;

/// <summary>
///     Defines a contract for a concurrent stack of a specific type.
///     <see cref="ConcurrentStack{T}" />
/// </summary>
/// <typeparam name="T"></typeparam>
// ReSharper disable once UnusedType.Global
public interface IConcurrentStackOf<T> : IValue<ConcurrentStack<T>>;