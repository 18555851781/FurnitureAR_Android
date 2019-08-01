#if  UNITY_ANDROID || UNITY_EDITOR 
//-----------------------------------------------------------------------
// <copyright file="ARCoreSessionConfig.cs" company="Google">
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
    using UnityEngine;
    using StandardARInternal;

    /// <summary>
    /// Holds settings that are used to configure the session.
    /// </summary>
    [CreateAssetMenu(fileName = "ARCoreSessionConfig", menuName = "StandardAR/SessionConfig", order = 1)]
    public class ARCoreSessionConfig : ScriptableObject
    {
        /// <summary>
        /// Toggles whether the rendering frame rate matches the background camera frame rate.
        /// Setting this to true will also set QualitySetting.vSyncCount to 0, which will make your entire app to run at the background camera frame rate (including animations, UI interaction, etc.).
        /// Setting this to false could incur extra power overhead due to rendering the same background more than once.
        /// </summary>
        [Tooltip("Toggles whether the rendering frame rate matches the background camera frame rate")]
        public bool MatchCameraFramerate = true;

        /// <summary>
        /// Toggles whether plane finding is enabled.
        /// </summary>
        [Tooltip("Toggles whether plane finding is enabled.")]
        public bool EnablePlaneFinding = true;

        /// <summary>
        /// Toggles whether light estimation is enabled.
        /// </summary>
        [Tooltip("Toggles whether light estimation is enabled.")]
        public bool EnableLightEstimation = true;

        /// <summary>
        /// Toggles whether SLAM algorithm is enabled.
        /// </summary>
        [Tooltip("Toggles whether SLAM algorithm is enabled.")]
        public ApiAlgorithmMode SLAMAlgorithmMode = ApiAlgorithmMode.Back_RGB;

        /// <summary>
        /// Toggles whether hand gesture algorithm enable mode.
        /// </summary>
        [Tooltip("Toggles whether SLAM algorithm is enabled.")]
        public ApiAlgorithmMode HandGestureAlgorithmMode = ApiAlgorithmMode.Disabled;

		/// <summary>
		/// Toggles whether light estimation is enabled.
		/// </summary>
		[Tooltip("Toggles whether cloud anchor is enabled.")]
		public bool EnableCloudAnchor = true;

    }
}

 #endif