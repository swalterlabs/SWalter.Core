namespace SWalter.Core;

/// <inheritdoc cref="IWritableValue{T}" />
/// <inheritdoc cref="ICachedValue{T}" />
public interface ICachedWritableValue<T> : ICachedValue<T>, IWritableValue<T>;