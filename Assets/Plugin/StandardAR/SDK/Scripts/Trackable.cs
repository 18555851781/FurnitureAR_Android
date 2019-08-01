﻿#if  UNITY_ANDROID || UNITY_EDITOR 
//-----------------------------------------------------------------------
// <copyright file="Trackable.cs" company="Google">
//
// Copyright 2017 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// modification
// 1.remove GetAllAnchors
//rename GoogleARCore to StandardAR to avoid conflict
//rename GoogleARCoreInternal to StandardARInternal to avoid conflict
//
// </copyright>
//-----------------------------------------------------------------------

namespace StandardAR
{
    using System;
    using System.Collections.Generic;
    using StandardARInternal;
    using UnityEngine;

    /// <summary>
    /// An object ARCore is tracking in the real world.
    /// </summary>
    public abstract class Trackable
    {
        //// @cond EXCLUDE_FROM_DOXYGEN

        /// <summary>
        /// A native handle for the ARCore trackable.
        /// </summary>
        protected IntPtr m_TrackableNativeHandle = IntPtr.Zero;

        /// <summary>
        /// The native api for ARCore.
        /// </summary>
        protected NativeSession m_NativeSession;

        /// <summary>
        /// Constructs a new ARCore Trackable.
        /// </summary>
        protected Trackable()
        {
        }

        /// <summary>
        /// Constructs a new ARCore Trackable.
        /// </summary>
        /// <param name="trackableNativeHandle">The native handle.</param>
        /// <param name="nativeSession">The native api.</param>
        protected Trackable(IntPtr trackableNativeHandle, NativeSession nativeSession)
        {
            m_TrackableNativeHandle = trackableNativeHandle;
            m_NativeSession = nativeSession;
        }

        ~Trackable()
        {
            m_NativeSession.TrackableApi.Release(m_TrackableNativeHandle);
        }

        //// @endcond

        /// <summary>
        /// Gets the tracking state of for the Trackable in the current frame.
        /// </summary>
        /// <returns>The tracking state of for the Trackable in the current frame.</returns>
        public virtual TrackingState TrackingState
        {
            get
            {
                return m_NativeSession.TrackableApi.GetTrackingState(m_TrackableNativeHandle);
            }
        }

        /// <summary>
        /// Creates an Anchor at the given <c>Pose</c> that is attached to the Trackable where semantics of the
        /// attachment relationship are defined by the subcass of Trackable (e.g. TrackedPlane).   Note that the
        /// relative offset between the Pose of multiple Anchors attached to the same Trackable may change
        /// over time as ARCore refines its understanding of the world.
        /// </summary>
        /// <param name="pose">The Pose of the location to create the anchor.</param>
        /// <returns>An Anchor attached to the Trackable at <c>Pose</c>.</returns>
        public virtual Anchor CreateAnchor(Pose pose)
        {
            IntPtr anchorHandle;
            if (!m_NativeSession.TrackableApi.AcquireNewAnchor(m_TrackableNativeHandle, pose, out anchorHandle))
            {
                Debug.Log("Failed to create anchor on trackable.");
                return null;
            }

            return Anchor.AnchorFactory(anchorHandle, m_NativeSession);
        }

    }
}

 #endif