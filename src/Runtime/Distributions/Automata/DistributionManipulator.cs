// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;

namespace Microsoft.ML.Probabilistic.Distributions.Automata
{
    using System;

    /// <summary>
    /// Helper class for obtaining <see cref="IDistributionManipulator{TElement,TDistribution}"/>
    /// compatible with some distribution.
    /// </summary>
    public static class DistributionManipulator<T, TDistribution>
        where TDistribution : IDistribution<T>, new()
    {
        /// <summary>
        /// Gets <see cref="IDistributionManipulator{TElement,TDistribution}"/> suitable for
        /// TElementDistribution.
        /// </summary>
        public static IDistributionManipulator<T, TDistribution> Instance { get; } = Create();

        /// <summary>
        /// Creates object implementing <see cref="IDistributionManipulator{TElement,TDistribution}"/>.
        /// </summary>
        private static IDistributionManipulator<T, TDistribution> Create()
        {
            return
                typeof(TDistribution).IsClass ? CreateReferenceDistributionManipulator() :
                typeof(TDistribution).IsValueType ? CreateStructDistributionManipulator() :
                throw new InvalidOperationException($"Can't create IDistributionManipulator for {typeof(TDistribution)}");
        }

        /// <summary>
        /// Creates <see cref="ReferenceDistributionManipulator{T,TDistribution}"/>.
        /// </summary>
        private static IDistributionManipulator<T, TDistribution> CreateReferenceDistributionManipulator()
        {
            // Can't create ReferenceDistributionManipulator directly, because TElementDistribution
            // doesn't have "class" constraint. Create via reflection 
            var genericType = typeof(ReferenceDistributionManipulator<,>);
            var type = genericType.MakeGenericType(new[] { typeof(T), typeof(TDistribution) });
            return (IDistributionManipulator<T, TDistribution>)Activator.CreateInstance(type);
        }

        /// <summary>
        /// Creates distribution manipulator for struct. Takes type of manipulator from
        /// <see cref="DistributionManipulatorAttribute"/>.
        /// </summary>
        private static IDistributionManipulator<T, TDistribution> CreateStructDistributionManipulator()
        {
            var attributes = typeof(TDistribution).GetCustomAttributes(typeof(DistributionManipulatorAttribute), true);
            if (attributes.Length != 1)
            {
                throw new InvalidOperationException("Structure must have 1 DistributionManipulator attribute");
            }

            var manipulatorType = ((DistributionManipulatorAttribute)attributes[0]).Type;
            var expectedType = typeof(IDistributionManipulator<T, TDistribution>);
            if (!expectedType.IsAssignableFrom(manipulatorType))
            {
                throw new InvalidOperationException(
                    $"Distribution manipulator from attribute ({manipulatorType}) is not compatible with request manipulator type ({expectedType}");
            }
            
            return (IDistributionManipulator<T, TDistribution>)Activator.CreateInstance(manipulatorType);
        }
    }
}
