﻿#if  UNITY_ANDROID || UNITY_EDITOR 
//-----------------------------------------------------------------------
// <copyright file="ApiArStatus.cs" company="Google">
//
// Copyright 2016 Google Inc. All Rights Reserved.
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
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using UnityEngine;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
    Justification = "Internal")]
    public enum ApiArStatus
    {
        Success = 0,

        // Invalid argument handling: null pointers and invalid enums for void
        // functions are handled by logging and returning best-effort value.
        // Non-void functions additionally return AR_ERROR_INVALID_ARGUMENT.
        ErrorInvalidArgument = -1,
        ErrorFatal = -2,
        ErrorSessionPaused = -3,
        ErrorSessionNotPaused = -4,
        ErrorNotTracking = -5,
        ErrorTextureNotSet = -6,
        ErrorMissingGlContext = -7,
        ErrorUnsupportedConfiguration = -8,
        ErrorCameraPermissionNotGranted = -9,

        // Acquire failed because the object being acquired is already released.
        // This happens e.g. if the developer holds an old frame for too long, and
        // then tries to acquire a point cloud from it.
        ErrorDeadlineExceeded = -10,

        // Acquire failed because there are too many objects already acquired. For
        // example, the developer may acquire up to N point clouds.
        // N is determined by available resources, and is usually small, e.g. 8.
        // If the developer tries to acquire N+1 point clouds without releasing the
        // previously acquired ones, they will get this error.
        ErrorResourceExhausted = -11,

        // Acquire failed because the data isn't available yet for the current
        // frame. For example, acquire the image metadata may fail with this error
        // because the camera hasn't fully started.
        ErrorNotYetAvailable = -12,

		ErrorCloudAnchorsNotConfigured = -14,
		ErrorInternetPermissonNotGranted = -15,
		ErrorAnchorNotSupportedForHosting = -16,
		ErrorImageInsufficientQuality = -17,
		ErrorDataInvalidFormat = -18,
		ErrorDataUnsupportedVersion = -19,
		ErrorIllegalState = -20,

        UnavailableArCoreNotInstalled = -100,
        UnavailableDeviceNotCompatible = -101,
        UnavailableAndroidVersionNotSupported = -102,

        // The ARCore APK currently installed on device is too old and needs to be
        // updated. For example, SDK v2.0.0 when APK is v1.0.0.
        UnavailableApkTooOld = -103,

        // The ARCore APK currently installed no longer supports the sdk that the
        // app was built with. For example, SDK v1.0.0 when APK includes support for
        // v2.0.0+.
        UnavailableSdkTooOld = -104,
    }

    public enum ApiArAvailability
    {
        AR_AVAILABILITY_UNSUPPORTED_DEVICE_NOT_CAPABLE = 100,
        AR_AVAILABILITY_SUPPORTED_NOT_INSTALLED = 201,
        AR_AVAILABILITY_SUPPORTED_INSTALLED = 203,
    }

    public enum ApiArInstallStatus
    {
        AR_INSTALL_STATUS_INSTALLED = 0,
        AR_INSTALL_STATUS_INSTALL_REQUESTED = 1,
    }


}

 #endif