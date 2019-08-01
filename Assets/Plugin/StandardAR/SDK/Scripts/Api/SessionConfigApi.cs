#if  UNITY_ANDROID || UNITY_EDITOR 
//-----------------------------------------------------------------------
// <copyright file="SessionConfigApi.cs" company="Google">
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
//modification list
//modify variable name
//remove ArConfig_setUpdateMode
//rename GoogleARCore to StandardAR to avoid conflict
//rename GoogleARCoreInternal to StandardARInternal to avoid conflict
//
// </copyright>
//-----------------------------------------------------------------------

namespace StandardARInternal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using StandardAR;
    using UnityEngine;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
     Justification = "Internal")]
    public class SessionConfigApi
    {
        private NativeSession m_NativeSession;

        public SessionConfigApi(NativeSession nativeSession)
        {
            m_NativeSession = nativeSession;
        }

        public IntPtr Create()
        {
            IntPtr configHandle = IntPtr.Zero;
            ExternApi.arConfigCreate(ref configHandle);
            return configHandle;
        }

        public void Destroy(IntPtr configHandle)
        {
            ExternApi.arConfigDestroy(configHandle);
        }

        public void UpdateApiConfigWithArCoreSessionConfig(IntPtr configHandle, ARCoreSessionConfig arCoreSessionConfig)
        {
            var lightingMode = ApiLightEstimationMode.Disabled;
            if (arCoreSessionConfig.EnableLightEstimation)
            {
                lightingMode = ApiLightEstimationMode.AmbientIntensity;
            }

            ExternApi.arConfigSetIlluminationEstimateMode(configHandle, lightingMode);

            var planeFindingMode = ApiPlaneFindingMode.Disabled;
            if (arCoreSessionConfig.EnablePlaneFinding)
            {
                planeFindingMode = ApiPlaneFindingMode.Horizontal;
            }

            ExternApi.arConfigSetPlaneDetectingMode(configHandle, planeFindingMode);

            ExternApi.arConfigSetTrackingRunMode(configHandle, ApiTrackingRunMode.Auto);

            ExternApi.arConfigSetWorldAlignmentMode(configHandle, ApiWorldAlignmentMode.Gravity_Heading);

            ExternApi.arConfigSetAlgorithmMode(configHandle, ApiAlgorithmType.SLAM, arCoreSessionConfig.SLAMAlgorithmMode);
            ExternApi.arConfigSetAlgorithmMode(configHandle, ApiAlgorithmType.Hand_Gesture, arCoreSessionConfig.HandGestureAlgorithmMode);

			var cloudAnchorMode = ApiCloudAnchorMode.Disabled;
			if (arCoreSessionConfig.EnableCloudAnchor) 
			{
				cloudAnchorMode = ApiCloudAnchorMode.Enable;
			}

			ExternApi.arConfigSetCloudAnchorMode (m_NativeSession.SessionHandle, configHandle, cloudAnchorMode);

        }

        private struct ExternApi
        {
            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arConfigCreate(ref IntPtr out_config);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arConfigDestroy(IntPtr config);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arConfigSetIlluminationEstimateMode(IntPtr config,
                ApiLightEstimationMode light_estimation_mode);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arConfigSetPlaneDetectingMode(IntPtr config,
                ApiPlaneFindingMode plane_finding_mode);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arConfigSetTrackingRunMode(IntPtr config,
                ApiTrackingRunMode tracking_run_mode);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arConfigSetWorldAlignmentMode(IntPtr config,
                ApiWorldAlignmentMode world_alignment_mode);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arConfigSetAlgorithmMode(IntPtr config,
                ApiAlgorithmType algorithmType, ApiAlgorithmMode algorithm_mode);

			[DllImport(ApiConstants.ARCoreNativeApi)]
			public static extern void arConfigSetCloudAnchorMode(IntPtr session, IntPtr config,
				ApiCloudAnchorMode cloud_anchor_mode);
			
        }
    }
}

 #endif