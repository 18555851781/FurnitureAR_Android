#if  UNITY_ANDROID || UNITY_EDITOR 
//-----------------------------------------------------------------------
// <copyright file="LightEstimateApi.cs" company="Google">
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
//remove ArLightEstimate_getColorCorrection
//rename GoogleARCore to StandardAR to avoid conflict
//rename GoogleARCoreInternal to StandardARInternal to avoid conflict
//
//
// </copyright>
//-----------------------------------------------------------------------

namespace StandardARInternal
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using StandardAR;
    using UnityEngine;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
    Justification = "Internal")]
    public class LightEstimateApi
    {
        private NativeSession m_NativeSession;

        public LightEstimateApi(NativeSession nativeSession)
        {
            m_NativeSession = nativeSession;
        }

        public IntPtr Create()
        {
            IntPtr lightEstimateHandle = IntPtr.Zero;
            ExternApi.arIlluminationEstimateCreate(m_NativeSession.SessionHandle, ref lightEstimateHandle);
            return lightEstimateHandle;
        }

        public void Destroy(IntPtr lightEstimateHandle)
        {
            ExternApi.arIlluminationEstimateDestroy(lightEstimateHandle);
        }

        public LightEstimateState GetState(IntPtr lightEstimateHandle)
        {
            ApiLightEstimateState state = ApiLightEstimateState.NotValid;
            ExternApi.arIlluminationEstimateGetState(m_NativeSession.SessionHandle, lightEstimateHandle, ref state);
            return state.ToLightEstimateState();
        }

        public float GetPixelIntensity(IntPtr lightEstimateHandle)
        {
            float pixelIntensity = 0;
            ExternApi.arIlluminationEstimateGetPixelIntensity(m_NativeSession.SessionHandle,
                lightEstimateHandle, ref pixelIntensity);
            return pixelIntensity;
        }

        public Color GetColorCorrection(IntPtr lightEstimateHandle)
        {
            float[] colorCorrection = new float[4];
            ExternApi.arIlluminationEstimateGetColorCorrection(m_NativeSession.SessionHandle,
                                                               lightEstimateHandle, colorCorrection);
            return new Color(colorCorrection[0], colorCorrection[1], colorCorrection[2], colorCorrection[3]);
        }

        private struct ExternApi
        {
            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arIlluminationEstimateCreate(IntPtr sessionHandle,
                ref IntPtr lightEstimateHandle);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arIlluminationEstimateDestroy(IntPtr lightEstimateHandle);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arIlluminationEstimateGetState(IntPtr sessionHandle,
                IntPtr lightEstimateHandle, ref ApiLightEstimateState state);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arIlluminationEstimateGetPixelIntensity(IntPtr sessionHandle,
                IntPtr lightEstimateHandle, ref float pixelIntensity);

            [DllImport(ApiConstants.ARCoreNativeApi)]
            public static extern void arIlluminationEstimateGetColorCorrection(IntPtr sessionHandle,
                IntPtr lightEstimateHandle, float[] colorCorrection);
        }
    }
}

 #endif