﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.MixedReality.Toolkit.SpatialAwareness
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseSpatialPlanesObserver : BaseSpatialObserver, IMixedRealitySpatialAwarenessPlanesObserver
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="spatialAwarenessSystem">The <see cref="SpatialAwareness.IMixedRealitySpatialAwarenessSystem"/> to which the observer is providing data.</param>
        /// <param name="name">The friendly name of the data provider.</param>
        /// <param name="priority">The registration priority of the data provider.</param>
        /// <param name="profile">The configuration profile for the data provider.</param>
        public BaseSpatialPlanesObserver(
            IMixedRealitySpatialAwarenessSystem spatialAwarenessSystem,
            string name = null,
            uint priority = DefaultPriority,
            BaseMixedRealityProfile profile = null) : base(spatialAwarenessSystem, name, priority, profile)
        { }

        // todo
    }
}
