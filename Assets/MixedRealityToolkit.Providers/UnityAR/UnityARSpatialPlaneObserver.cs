// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.Toolkit.Experimental.UnityAR;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.UnityAR
{
    /// <summary>
    /// Spatial awareness system observer which provides applications using Unity AR Foundation with 
    /// planar surfaces representing the environment.
    /// </summary>
    [MixedRealityDataProvider(
        typeof(IMixedRealitySpatialAwarenessSystem),
        SupportedPlatforms.Android | SupportedPlatforms.IOS,
        "Unity AR Spatial Planes Observer",
        "Profiles/DefaultMixedRealitySpatialPlanesObserverProfile.asset",
        "MixedRealityToolkit.SDK")]
    [HelpURL("https://microsoft.github.io/MixedRealityToolkit-Unity/Documentation/SpatialAwareness/SpatialAwarenessGettingStarted.html")]
    public class UnityARSpatialPlaneObserver :
        BaseSpatialObserver,
        IMixedRealityCapabilityCheck
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="spatialAwarenessSystem">The service instance that receives data from this provider.</param>
        /// <param name="name">Friendly name of the service.</param>
        /// <param name="priority">Service priority. Used to determine order of instantiation.</param>
        /// <param name="profile">The service's configuration profile.</param>
        public UnityARSpatialPlaneObserver(
            IMixedRealitySpatialAwarenessSystem spatialAwarenessSystem,
            string name = null,
            uint priority = DefaultPriority,
            BaseMixedRealityProfile profile = null) : base(spatialAwarenessSystem, name, priority, profile)
        { }

        /// <summary>
        /// Reads the contents of the configuration profile.
        /// </summary>
        private void ReadProfile()
        {
            if (ConfigurationProfile == null)
            {
                Debug.LogWarning("A profile was not specified for the Unity AR Spatial Planes observer.");
                return;
            }

            // todo
            // detection mode
            // horizontal plane material
            // vertical plane material
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public ArPlaneDetectionMode DetectionMode
        //{ get; set; }


        /// <summary>
        /// 
        /// </summary>
        public Material HorizontalPlaneMaterial
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Material VerticalPlaneMaterial
        { get; set; }

        #region IMixedRealitySpatialObserver

        /// <inheritdoc />
        public override void Resume()
        {
            base.Resume();
            // todo
        }

        /// <inheritdoc />
        public override void Suspend()
        {
            base.Suspend();
            // todo
        }

        #endregion IMixedRealitySpatialObserver

        #region IMixedRealityDataProvider

        public override void Initialize()
        {
            /// <inheritdoc />
            base.Initialize();
            ReadProfile();
        }

        /// <inheritdoc />
        public override void Disable()
        {
            base.Disable();
            // todo
        }

        /// <inheritdoc />
        public override void Enable()
        {
            base.Enable();
            // todo
        }

        #endregion IMixedRealityDataProvider

        #region IMixedRealityCapabilityCheck

        /// <inheritdoc />
        public bool CheckCapability(MixedRealityCapability capability)
        {
            bool isSupported = false;

    #if ARFOUNDATION_PRESENT
            isSupported = (capability == MixedRealityCapability.SpatialAwarenessPlane);
    #endif // ARFOUNDATION_PRESENT

            return isSupported;
        }

        #endregion IMixedRealityCapabilityCheck
    }
}
