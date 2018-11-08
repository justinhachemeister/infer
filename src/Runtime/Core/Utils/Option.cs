// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.ML.Probabilistic.Utilities
{
    using System;

    using Microsoft.ML.Probabilistic.Serialization;

    /// <summary>
    /// A version of <see cref="Nullable{T}"/> that can hold both reference and value types.
    /// </summary>
    public struct Option<T>
    {
        private readonly T value;

        [Construction("Value")]
        public Option(T value)
        {
            this.value = value;
            this.HasValue = value != null;
        }

        [Construction(UseWhen = "IsEmpty")]
        static public Option<T> Empty() => new Option<T>();

        /// <summary>
        /// Gets a value indicating whether this Option holds a value
        /// </summary>
        public bool HasValue { get; }

        public bool IsEmpty => !HasValue;

        /// <summary>
        /// Gets the value of 
        /// </summary>
        public T Value =>
            this.HasValue
                ? this.value
                : throw new InvalidOperationException("Can't get value of empty optinal");

        public bool TryGet(out T value)
        {
            if (!this.HasValue)
            {
                value = default(T);
                return false;
            }

            value = this.value;
            return true;
        }

        public static implicit operator Option<T>(T value) => new Option<T>(value);

        public static implicit operator Option<T>(Option.NoneType none) => new Option<T>();

        public static explicit operator T(Option<T> value) => value.value;

        public override bool Equals(object other) =>
            this.HasValue
                ? other != null && this.value.Equals(other)
                : other == null;

        public override int GetHashCode() => this.HasValue ? this.value.GetHashCode() : 0;

        public override string ToString() => this.HasValue ? this.value.ToString() : string.Empty;
    }

    public static class Option
    {
        public struct NoneType
        {
        }

        public static NoneType None => default(NoneType);

        public static Option<T> Some<T>(T value) => new Option<T>(value);
    }
}
