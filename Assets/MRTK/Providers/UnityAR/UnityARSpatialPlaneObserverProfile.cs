// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Experimental.UnityAR
{
    /// <summary>
    /// Configuration profile for the AR Foundation spatial planes observer.
    /// </summary>
    [CreateAssetMenu(menuName = "Mixed Reality Toolkit/Providers/Unity AR/Spatial Planes Observer Profile", fileName = "DefaultUnityARSpatialPlanesObserverProfile", order = 100)]
    [MixedRealityServiceProfile(typeof(UnityARCameraSettings))]
    public class UnityARSpatialPlanesObserverProfile : BaseSpatialAwarenessObserverProfile
    {
        [SerializeField]
        [Tooltip("The type(s) of planes to be detected.")]
        private PlaneType planeTypes = (PlaneType)(-1);

        /// <summary>
        /// The type(s) of planes to be detected.
        /// </summary>
        public PlaneType PlaneTypes => planeTypes;

        //[SerializeField]
        //[Tooltip("The material to use when displaying horizontal planes.")]
        //private Material horizontalPlaneMaterial = null;

        ///// <summary>
        ///// The material to use when displaying horizontal planes.
        ///// </summary>
        //public Material HorizontalPlaneMaterial => horizontalPlaneMaterial;

        //[SerializeField]
        //[Tooltip("The material to use when displaying vertical planes.")]
        //private Material verticalPlaneMaterial = null;

        ///// <summary>
        ///// The material to use when displaying vertical planes.
        ///// </summary>
        //public Material VerticalPlaneMaterial => verticalPlaneMaterial;
    }
}
