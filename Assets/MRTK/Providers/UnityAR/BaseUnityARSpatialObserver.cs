// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.UnityAR
{
    /// <summary>
    /// Base class used by Unity AR Foundation based spatial observers.
    /// </summary>
    public class BaseUnityARSpatialObserver : BaseSpatialObserver
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="spatialAwarenessSystem">The service instance that receives data from this provider.</param>
        /// <param name="name">Friendly name of the service.</param>
        /// <param name="priority">Service priority. Used to determine order of instantiation.</param>
        /// <param name="profile">The service's configuration profile.</param>
        public BaseUnityARSpatialObserver(
            IMixedRealitySpatialAwarenessSystem spatialAwarenessSystem,
            string name = null,
            uint priority = DefaultPriority,
            BaseMixedRealityProfile profile = null) : base(spatialAwarenessSystem, name, priority, profile)
        { }

        // todo

        #region IMixedRealitySpatialAwarenessObserver

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

        #endregion IMixedRealitySpatialAwarenessObserver

        #region IMixedRealityDataProvider

        /// <inheritdoc />
        public override void Initialize()
        {
            base.Initialize();

            // todo
        }

        /// <inheritdoc />
        public override void Enable()
        {
            base.Enable();

            // todo
        }

        /// <inheritdoc />
        public override void Disable()
        {
            base.Disable();

            // todo
        }

        /// <inheritdoc />
        public override void Update()
        {
            base.Update();

            // todo
        }

        /// <inheritdoc />
        public override void Reset()
        {
            base.Reset();

            // todo
        }

        /// <inheritdoc />
        public override void Destroy()
        {
            // todo

            base.Destroy();
        }

        #endregion IMixedRealityDataProvider
    }
}
