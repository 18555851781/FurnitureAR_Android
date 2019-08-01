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
	public enum ApiCloudAnchorState
	{
		None = 0,
		TaskInProgress = 1,
		Success = 2,
		ErrorInternal = -1,
		ErrorNotAuthorized = -2,
		ErrorServiceUnavailable = -3,
		ErrorResourceExhausted = -4,
		ErrorHostingDatasetProcessingFailed = -5,
		ErrorCloudIdNotFound = -6,
		ErrorResolvingLocalizationNoMatch = -7,
		ErrorResolvingSdkVersionTooOld = -8,
		ErrorResolvingSdkVersionTooNew = -9,
		ErrorResolvingSdkVersionUnknown = -11
	}


}

#endif

