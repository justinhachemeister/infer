// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.ML.Probabilistic.Math;
using System.Collections.Generic;
namespace Microsoft.ML.Probabilistic.Distributions.Automata
{
    /// <summary>
    /// Represents a transducer defined on pairs of lists.
    /// </summary>
    public class ListTransducer<TList, TElement, TElementDist, TElementDistManipulator> :
        Transducer<TList, TElement, TElementDist, ListManipulator<TList, TElement>, TElementDistManipulator, ListAutomaton<TList, TElement, TElementDist, TElementDistManipulator>, ListTransducer<TList, TElement, TElementDist, TElementDistManipulator>>
        where TElementDist : class, IDistribution<TElement>, CanGetLogAverageOf<TElementDist>, SettableToProduct<TElementDist>, SettableToWeightedSumExact<TElementDist>, SettableToPartialUniform<TElementDist>, Sampleable<TElement>, new()
        where TList : class, IList<TElement>, new()
        where TElementDistManipulator : IDistributionManipulator<TElement, TElementDist>, new()
    {
    }

    /// <summary>
    /// Represents a transducer defined on pairs of lists.
    /// </summary>
    public class ListTransducer<TElement, TElementDist, TElementDistManipulator> :
        Transducer<List<TElement>, TElement, TElementDist, ListManipulator<List<TElement>, TElement>, TElementDistManipulator, ListAutomaton<TElement, TElementDist, TElementDistManipulator>, ListTransducer<TElement, TElementDist, TElementDistManipulator>>
        where TElementDist : class, IDistribution<TElement>, CanGetLogAverageOf<TElementDist>, SettableToProduct<TElementDist>, SettableToWeightedSumExact<TElementDist>, SettableToPartialUniform<TElementDist>, Sampleable<TElement>, new()
        where TElementDistManipulator : IDistributionManipulator<TElement, TElementDist>, new()
    {
    }
}