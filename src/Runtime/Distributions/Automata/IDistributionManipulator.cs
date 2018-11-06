// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.ML.Probabilistic.Distributions.Automata
{
    public interface IDistributionManipulator<TElement, TElementDistribution>
        where TElementDistribution : IDistribution<TElement>, new()
    {
        bool IsNull(TElementDistribution elementDistribution);

        TElementDistribution CreateNullElementDistribution();
    }
}
