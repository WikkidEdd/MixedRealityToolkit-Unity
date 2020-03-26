// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.UnityAR
{
    /// <summary>
    /// 
    /// </summary>
    [MixedRealityDataProvider(
        typeof(IMixedRealitySpatialAwarenessSystem),
        SupportedPlatforms.Android | SupportedPlatforms.IOS,
        "Unity AR Spatial Point Cloud Observer",
        "Profiles/DefaultMixedRealitySpatialPointCloudObserverProfile.asset",
        "MixedRealityToolkit.SDK")]
    [HelpURL("https://microsoft.github.io/MixedRealityToolkit-Unity/Documentation/SpatialAwareness/SpatialAwarenessGettingStarted.html")]
    public class UnityARSpatialPointCloudObserver :
        BaseSpatialObserver,    // todo: Create base point cloud observer?
        IMixedRealityCapabilityCheck
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="spatialAwarenessSystem">The service instance that receives data from this provider.</param>
        /// <param name="name">Friendly name of the service.</param>
        /// <param name="priority">Service priority. Used to determine order of instantiation.</param>
        /// <param name="profile">The service's configuration profile.</param>
        public UnityARSpatialPointCloudObserver(
            IMixedRealitySpatialAwarenessSystem spatialAwarenessSystem,
            string name = null,
            uint priority = DefaultPriority,
            BaseMixedRealityProfile profile = null) : base(spatialAwarenessSystem, name, priority, profile)
        {
            ReadProfile();
        }

        private void ReadProfile()
        {
            if (ConfigurationProfile == null)
            {
                // todo: Debug.LogWarning("A profile was not specified for the Unity AR Spatial Point Cloud observer.");
                return;
            }

            // todo
        }

        #region IMixedRealityCapabilityCheck

        /// <inheritdoc />
        public bool CheckCapability(MixedRealityCapability capability)
        {
            bool isSupported = false;

#if ARFOUNDATION_PRESENT
            isSupported = (capability == MixedRealityCapability.SpatialAwarenessPoint);
#endif // ARFOUNDATION_PRESENT

            return isSupported;
        }

        #endregion IMixedRealityCapabilityCheck
    }
}