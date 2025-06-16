// Copyright © Stefan Stolz, 2024

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace ShadowKit.Threading;

/// <summary>
/// A Collection of <see cref="Exception"/>s
/// </summary>
public sealed class ExceptionHistory : IReadOnlyList<Exception>
{
    private readonly List<Exception> exceptions = new();

    internal ExceptionHistory(IEnumerable<Exception> exceptions)
    {
        this.exceptions.AddRange(exceptions);
    }

    /// <summary>
    /// Gets a value indicating whether this Instance is Empty or not
    /// </summary>
    public bool IsEmpty => this.Count == 0;

    /// <inheritdoc />
    public IEnumerator<Exception> GetEnumerator()
    {
        return this.exceptions.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Gets the Number of Exceptions in the History
    /// </summary>
    public int Count => this.exceptions.Count;

    /// <inheritdoc />
    public Exception this[int index] => this.exceptions[index];

    /// <summary>
    /// Throws the Exceptions collected in this instance.
    /// </summary>
    /// <exception cref="AggregateException"></exception>
    public void Throw()
    {
        if (!this.IsEmpty)
        {
            if (this.Count == 1)
            {
                ExceptionDispatchInfo.Capture(this.exceptions.Single()).Throw();
            }
            else
            {
                throw new AggregateException(this.exceptions);
            }
        }
    }
}