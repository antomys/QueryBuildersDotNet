﻿using System.Text;

namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="ZeroFormatter(string)"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class ZeroFormatterService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ZeroFormatter(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ZeroFormatter(string testString)
    {
        var testByteArray = Encoding.UTF8.GetBytes(testString);
        
        return global::ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="ZeroFormatter(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ZeroFormatter(byte[] testByteArray)
    {
        return global::ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="ZeroFormatter(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ZeroFormatter(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(testStream)!;
    }
}