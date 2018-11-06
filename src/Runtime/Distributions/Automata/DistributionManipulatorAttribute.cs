// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.ML.Probabilistic.Distributions.Automata
{
    using System;

    /// <summary>
    /// Attribute that can be attached to a struct implementing <see cref="IDistribution{T}"/>,
    /// to provide information about distribution manipulator
    /// (class implementing <see cref="IDistributionManipulator{TElement,TDistribution}"/>)
    /// which helps managing null values for this distribution in generic code.
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    public class DistributionManipulatorAttribute : Attribute
    {
        /// <summary>
        /// Type that implements <see cref="IDistributionManipulator{TElement,TDistribution}"/>
        /// for this struct.
        /// </summary>
        public Type Type { get; }

        public DistributionManipulatorAttribute(Type type)
        {
            Type = type;
        }
    }
}
