namespace SWalter.Core.Extensions;

/// <summary>
/// </summary>
public static class DirectoryInfoExtensions
{
    /// <summary>
    ///     Extension to get size of a directory.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="dir" /> is <see langword="null" />.</exception>
    // ReSharper disable once UnusedMember.Global
    public static double GetDirectorySize(this DirectoryInfo dir)
    {
        ArgumentNullException.ThrowIfNull(dir);

        var sum = dir.GetFiles().Aggregate<FileInfo, double>(0, (current, file) => current + file.Length);
        return dir.GetDirectories().Aggregate(sum, (current, dir1) => current + dir1.GetDirectorySize());
    }

    /// <summary>
    /// </summary>
    /// <param name="dirInfo"></param>
    /// <returns></returns>
    public static string GetProperDirectoryCapitalization([NotNull] this DirectoryInfo dirInfo)
    {
        ArgumentNullException.ThrowIfNull(dirInfo);

        var parentDirInfo = dirInfo.Parent;

        if (parentDirInfo is null)
        {
            return dirInfo.Name;
        }

        var matchingDirectory = parentDirInfo
            .EnumerateDirectories()
            .FirstOrDefault(directory => string.Equals(directory.Name, dirInfo.Name, StringComparison.OrdinalIgnoreCase));

        var directoryName = matchingDirectory?.Name ?? dirInfo.Name;
        return Path.Combine(parentDirInfo.GetProperDirectoryCapitalization(), directoryName).Trim();
    }

    /// <summary>
    ///     Extension to rename a directory.
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="name"></param>
    /// <exception cref="ArgumentNullException"><paramref name="dir" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException">New name cannot be null or blank</exception>
    // ReSharper disable once UnusedMember.Global
    public static void RenameTo(this DirectoryInfo dir, string name)
    {
        if (dir?.Parent is null)
        {
            throw new ArgumentNullException(nameof(dir), "Directory info to rename cannot be null");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("New name cannot be null or blank", nameof(name));
        }

        dir.MoveTo(Path.Combine(dir.Parent.FullName, name));
    }
}