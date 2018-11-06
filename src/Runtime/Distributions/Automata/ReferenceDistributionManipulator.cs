// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.ML.Probabilistic.Distributions.Automata
{
    public class ReferenceDistributionManipulator<TElement, TElementDistribution> : IDistributionManipulator<TElement, TElementDistribution>
        where TElementDistribution : class, IDistribution<TElement>, new()
    {
        public bool IsNull(TElementDistribution elementDistribution) => elementDistribution == null;

        public TElementDistribution CreateNullElementDistribution() => null;
    }
}
