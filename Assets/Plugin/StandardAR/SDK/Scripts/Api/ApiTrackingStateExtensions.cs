﻿#if  UNITY_ANDROID || UNITY_EDITOR 
//-----------------------------------------------------------------------
// <copyright file="ApiTrackingStateExtensions.cs" company="Google">
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

namespace StandardARInternal
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using StandardAR;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
    Justification = "Internal")]
    public static class ApiTrackingStateExtensions
    {
        public static TrackingState ToTrackingState(this ApiTrackingState apiTrackingState)
        {
            switch (apiTrackingState)
            {
                case ApiTrackingState.Tracking:
                    return TrackingState.Tracking;
                case ApiTrackingState.Paused:
                    return TrackingState.Paused;
                case ApiTrackingState.Stopped:
                    return TrackingState.Stopped;
                case ApiTrackingState.Initializing:
                    return TrackingState.Initializing;
                default:
                    return TrackingState.Stopped;
            }
        }
    }
}

 #endif