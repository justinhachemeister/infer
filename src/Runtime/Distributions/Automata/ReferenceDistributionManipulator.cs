// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.ML.Probabilistic.Distributions.Automata
{
    /// <summary>
    /// Implementation of <see cref="IDistributionManipulator{T,TDistribution}"/>
    /// for all reference types. Represents null value as null reference.
    /// </summary>
    public sealed class ReferenceDistributionManipulator<T, TDistribution> : IDistributionManipulator<T, TDistribution>
        where TDistribution : class, IDistribution<T>, new()
    {
        /// <inheritdoc cref="IDistributionManipulator{T,TDistribution}.IsNull"/>
        public bool IsNull(TDistribution distribution) => distribution == null;

        /// <inheritdoc cref="IDistributionManipulator{T,TDistribution}.CreateNullDistribution"/>
        public TDistribution CreateNullDistribution() => null;
    }
}
