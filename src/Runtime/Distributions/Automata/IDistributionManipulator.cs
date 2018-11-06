// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.ML.Probabilistic.Distributions.Automata
{
    /// <summary>
    /// Interface for manipulating distributions implemented as classes and
    /// structs in uniform way.
    /// </summary>
    /// <remarks>
    /// Automaton uses "null" value of distribution to represent epsilon transition.
    /// Distributions implemented as structs don't have "null" value proved by
    /// language or runtime, instead we reserve special distribution value which
    /// can be treated as null. This interface provides  methods to operate over
    /// these fake null values.
    /// </remarks>
    /// <remarks>
    /// <see cref="IDistributionManipulator{T,TDistribution}"/> should be
    /// created using <see cref="DistributionManipulator{TElement,TElementDistribution}.Instance"/>.
    /// </remarks>
    /// <remarks>
    /// Doing simple reference comparisons through wrappers implementing this interface is
    /// perfectly fine even in hot code, because .NET jitter devirtualizes and inlines
    /// these method calls nicely.
    /// </remarks>
    public interface IDistributionManipulator<T, TDistribution>
        where TDistribution : IDistribution<T>, new()
    {
        /// <summary>
        /// Returns distribution which should be treated as null <see cref="IsNull"/>.
        /// </summary>
        /// <remarks>
        /// For distributions implemented as classes it should be null reference.
        /// For distributions implemented as structs it should be some special value
        /// (typically - default() but not necessarily).
        /// </remarks>
        TDistribution CreateNullDistribution();

        /// <summary>
        /// Checks whether given distribution should be treated as null value.
        /// </summary>
        /// <remarks>
        /// Should return true only for values equal to return value of
        /// <see cref="CreateNullDistribution"/>.
        /// </remarks>
        bool IsNull(TDistribution distribution);
    }
}
