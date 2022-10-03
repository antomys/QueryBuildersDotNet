﻿using BoxingUnboxing.Benchmarks.Extensions;

namespace BoxingUnboxing.Benchmarks.Services;

/// <summary>
///     Enum getting name service for benchmarks and unit testing.
/// </summary>
public static class EnumNameService
{
    /// <summary>
    ///     Gets enum name by using default 'ToString' method.
    /// <para>
    ///     Note: Boxing allocation: inherited 'System.Object' virtual method call on value type instance.
    /// </para>
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static string DefaultToString(this TestEnum testEnum)
    {
        return testEnum.ToString();
    }

    /// <summary>
    ///     Gets enum name by using default extensions method of <see cref="Enum"/> class <see cref="Enum.GetName"/>
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static string? EnumGetName(this TestEnum testEnum)
    {
        return Enum.GetName(testEnum);
    }

    /// <summary>
    ///     Gets enum name by using custom-made method from <see cref="EnumExtensions"/>.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static string CustomGetName(this TestEnum testEnum)
    {
        return EnumExtensions.CustomGetName(testEnum);
    }
}
/// <summary>
///     Enum getting name service for benchmarks and unit testing.
/// </summary>
public static class NameEnumService
{
    /// <summary>
    ///     Gets enum name by using default 'ToString' method.
    /// <para>
    ///     Note: Boxing allocation: inherited 'System.Object' virtual method call on value type instance.
    /// </para>
    /// </summary>
    /// <param name="testStringEnum">string of <see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static TestEnum EnumTryParse(this string testStringEnum)
    {
        Enum.TryParse<TestEnum>(testStringEnum, false, out var testEnum);

        return testEnum;
    }
    
    /// <summary>
    ///     Gets enum name by using custom-made method from <see cref="EnumExtensions"/>.
    /// </summary>
    /// <param name="testStringEnum"> string of <see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static TestEnum CustomGetEnumFromName(this string testStringEnum)
    {
        return GetEnumNameInternal(testStringEnum);
    }
    private static TestEnum GetEnumNameInternal(this string testStringEnum)
    {
        return testStringEnum switch
        {
            nameof(TestEnum.Zero) => TestEnum.Zero,
            nameof(TestEnum.First) => TestEnum.First,
            nameof(TestEnum.Second) => TestEnum.Second,
            nameof(TestEnum.Third) => TestEnum.Third,
            nameof(TestEnum.Fourth) => TestEnum.Fourth,
            nameof(TestEnum.Fifth) => TestEnum.Fifth,
            nameof(TestEnum.Sixth) => TestEnum.Sixth,
            nameof(TestEnum.Seventh) => TestEnum.Seventh,
            nameof(TestEnum.Eighth) => TestEnum.Eighth,
            nameof(TestEnum.Ninth) => TestEnum.Ninth,
            nameof(TestEnum.Tenth) => TestEnum.Tenth,
            nameof(TestEnum.Eleventh) => TestEnum.Eleventh,
            nameof(TestEnum.Twelfth) => TestEnum.Twelfth,
            _ => throw new ArgumentOutOfRangeException(nameof(testStringEnum)),
        };
    }
}