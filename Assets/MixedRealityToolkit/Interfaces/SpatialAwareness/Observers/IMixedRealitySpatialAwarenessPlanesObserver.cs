// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.MixedReality.Toolkit.SpatialAwareness
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMixedRealitySpatialAwarenessPlanesObserver
    {
        /// <summary>
        /// The type(s) of planes that should be detected.
        /// </summary>
        public PlaneType PlaneTypes { get; set; }

        // todo
    }
}
