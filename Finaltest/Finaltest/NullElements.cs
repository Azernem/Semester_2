// <copyright file="NullElements.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Finaltest;

/// <summary>
/// interface that checks element to null.
/// </summary>
/// <typeparam name="T">general type. </typeparam>
public interface IZeroChecker<T>
{
    /// <summary>
    /// method that checks element to null.
    /// </summary>
    /// <param name="item">element.</param>
    /// <returns>bool type.</returns>
    bool IsNull(T item);
}

/// <summary>
/// class that count zero elements of list.
/// </summary>
public static class NullElements
{
    /// <summary>
    /// method that count zero elements.
    /// </summary>
    /// <param name="list">list.</param>
    /// <param name="zeroChecker">object of IZeroChecker interface.</param>
    /// <typeparam name="T">general type.</typeparam>
    /// <returns>number of elements.</returns>
    public static int CountZeroElements<T>(List<T> list, IZeroChecker<T> zeroChecker)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(zeroChecker);
        var count = 0;

        foreach (var element in list)
        {
            if (zeroChecker.IsNull(element))
            {
                count++;
            }
        }

        return count;
    }
}