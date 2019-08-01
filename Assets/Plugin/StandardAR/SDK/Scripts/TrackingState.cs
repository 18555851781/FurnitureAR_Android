﻿#if  UNITY_ANDROID || UNITY_EDITOR 
//-----------------------------------------------------------------------
// <copyright file="TrackingState.cs" company="Google">
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
//rename GoogleARCore to StandardAR to avoid conflict
//rename GoogleARCoreInternal to StandardARInternal to avoid conflict
//
// </copyright>
//-----------------------------------------------------------------------

namespace StandardAR
{
    /// <summary>
    /// Possible tracking states for ARCore.
    /// </summary>
    public enum TrackingState
    {
        /// <summary>
        /// The entity is actively being tracked.
        /// </summary>
        Tracking = 0,

        /// <summary>
        /// ARCore has paused tracking the entity but may resume tracking it in the future.
        /// </summary>
        Paused = 1,

        /// <summary>
        /// ARCore has stopped tracking the entity and will never resume tracking it.
        /// </summary>
        Stopped = 2,

        /// <summary>
        /// initializing SLAM
        /// </summary>
        Initializing = 10,
    }
}

 #endif