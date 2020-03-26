// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.MixedReality.Toolkit.SpatialAwareness
{
    /// <summary>
    /// 
    /// </summary>
    [System.Flags]
    public enum PlaneType
    {
        /// <summary>
        /// 
        /// </summary>
        Horizontal = 1 << 0,    // 0x01 (1)

        /// <summary>
        /// 
        /// </summary>
        Vertical = 1 << 1,      // 0x02 (2)

        /// <summary>
        /// 
        /// </summary>
        Angled = 1 << 2         // 0x04 (4)
    }
}
