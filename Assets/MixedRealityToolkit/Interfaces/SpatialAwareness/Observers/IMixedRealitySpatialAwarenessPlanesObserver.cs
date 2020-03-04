// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.SpatialAwareness
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMixedRealitySpatialAwarenessPlanesObserver
    {
        // todo
        // displayoption(s)

        /// <summary>
        /// 
        /// </summary>
        IReadOnlyDictionary<int, SpatialAwarenessPlanarObject> Planes { get; }

        /// <summary>
        /// The type(s) of planes that should be detected.
        /// </summary>
        PlaneType PlaneTypes { get; set; }

        /// <summary>
        /// Get or sets the desired Unity Physics Layer on which to set the spatial planes.
        /// </summary>
        /// <remarks>
        /// If not explicitly set, it is recommended that implementations return <see cref="IMixedRealitySpatialAwarenessObserver.DefaultPhysicsLayer"/>.
        /// </remarks>
        int PlanePhysicsLayer { get; set; }

        /// <summary>
        /// Gets the bit mask that corresponds to the value specified in <see cref="PlanePhysicsLayer"/>.
        /// </summary>
        int PlanePhysicsLayerMask { get; }

        /// <summary>
        /// Gets or sets the <see href="https://docs.unity3d.com/ScriptReference/Material.html">Material</see> to be used when spatial planes should occlude other objects.
        /// </summary>
        Material OcclusionMaterial { get; set; }

        // todo
        // visibile material(s) - dictionary<plane type, material>
    }
}
