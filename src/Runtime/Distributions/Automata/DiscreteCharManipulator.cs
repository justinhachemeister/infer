// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.ML.Probabilistic.Distributions.Automata
{
    /// <summary>
    /// Implementation of <see cref="IDistributionManipulator{T,TDistribution}"/>
    /// for <see cref="DiscreteChar"/> distribution.
    /// </summary>
    public sealed class DiscreteCharManipulator : IDistributionManipulator<char, DiscreteChar>
    {
        /// <inheritdoc cref="IDistributionManipulator{T,TDistribution}.IsNull"/>
        public bool IsNull(DiscreteChar distribution) => distribution.IsNull;

        /// <inheritdoc cref="IDistributionManipulator{T,TDistribution}.CreateNullDistribution"/>
        public DiscreteChar CreateNullDistribution() => default(DiscreteChar);
    }
}
