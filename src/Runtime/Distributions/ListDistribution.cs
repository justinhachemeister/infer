// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.ML.Probabilistic.Distributions
{
    using System;
    using System.Collections.Generic;

    using Automata;
    using Math;
    using Factors.Attributes;

    /// <summary>
    /// A base class for distributions over lists that use a weighted finite state automaton as the underlying weight function.
    /// </summary>
    /// <typeparam name="TList">The type of a list.</typeparam>
    /// <typeparam name="TElement">The type of a list element.</typeparam>
    /// <typeparam name="TElementDistribution">The type of a distribution over list elements.</typeparam>
    /// <typeparam name="TThis">The type of a concrete distribution class.</typeparam>
    [Serializable]
    [Quality(QualityBand.Experimental)]
    public abstract class ListDistribution<TList, TElement, TElementDistribution, TElementDistributionManipulator, TThis> :
        SequenceDistribution<TList, TElement, TElementDistribution, ListManipulator<TList, TElement>, TElementDistributionManipulator, ListAutomaton<TList, TElement, TElementDistribution, TElementDistributionManipulator>, TThis>
        where TList : class, IList<TElement>, new()
        where TElementDistribution : class, IDistribution<TElement>, SettableToProduct<TElementDistribution>, SettableToWeightedSumExact<TElementDistribution>, CanGetLogAverageOf<TElementDistribution>, SettableToPartialUniform<TElementDistribution>, Sampleable<TElement>, new()
        where TElementDistributionManipulator : IDistributionManipulator<TElement, TElementDistribution>, new()
        where TThis : ListDistribution<TList, TElement, TElementDistribution, TElementDistributionManipulator, TThis>, new()
    {
    }

    /// <summary>
    /// Represents a distribution over lists that use a weighted finite state automaton as the underlying weight function.
    /// </summary>
    /// <typeparam name="TList">The type of a list.</typeparam>
    /// <typeparam name="TElement">The type of a list element.</typeparam>
    /// <typeparam name="TElementDistribution">The type of a distribution over list elements.</typeparam>
    [Serializable]
    [Quality(QualityBand.Experimental)]
    public class ListDistribution<TList, TElement, TElementDistribution, TElementDistributionManipulator> :
        ListDistribution<TList, TElement, TElementDistribution, TElementDistributionManipulator, ListDistribution<TList, TElement, TElementDistribution, TElementDistributionManipulator>>
        where TList : class, IList<TElement>, new()
        where TElementDistribution : class, IDistribution<TElement>, SettableToProduct<TElementDistribution>, SettableToWeightedSumExact<TElementDistribution>, CanGetLogAverageOf<TElementDistribution>, SettableToPartialUniform<TElementDistribution>, Sampleable<TElement>, new()
        where TElementDistributionManipulator : IDistributionManipulator<TElement, TElementDistribution>, new()
    {
    }

    /// <summary>
    /// Represents a distribution over List&lt;T&gt; that use a weighted finite state automaton as the underlying weight function.
    /// </summary>
    /// <typeparam name="TElement">The type of a list element.</typeparam>
    /// <typeparam name="TElementDistribution">The type of a distribution over list elements.</typeparam>
    [Serializable]
    [Quality(QualityBand.Experimental)]
    public class ListDistribution<TElement, TElementDistribution, TElementDistributionManipulator> :
        SequenceDistribution<List<TElement>, TElement, TElementDistribution, ListManipulator<List<TElement>, TElement>, TElementDistributionManipulator, ListAutomaton<TElement, TElementDistribution, TElementDistributionManipulator>, ListDistribution<TElement, TElementDistribution, TElementDistributionManipulator>>
        where TElementDistribution : class, IDistribution<TElement>, SettableToProduct<TElementDistribution>, SettableToWeightedSumExact<TElementDistribution>, CanGetLogAverageOf<TElementDistribution>, SettableToPartialUniform<TElementDistribution>, Sampleable<TElement>, new()
        where TElementDistributionManipulator : IDistributionManipulator<TElement, TElementDistribution>, new()
    {
    }
}
