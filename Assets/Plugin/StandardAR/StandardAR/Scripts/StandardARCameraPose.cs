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
//rename GoogleARCore to StandardAR to avoid conflict
//rename GoogleARCoreInternal to StandardARInternal to avoid conflict
//
// </copyright>
//-----------------------------------------------------------------------


namespace StandardAR{	
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using StandardARInternal;
	using System;
	using UnityEngine.UI;

	public class StandardARCameraPose : MonoBehaviour {

		private Camera m_Camera;

		// Use this for initialization
		void Start () {
			m_Camera = GetComponent<Camera> ();
		}
		
		// Update is called once per frame
		void Update () {
#if UNITY_EDITOR
#elif UNITY_ANDROID
//			getPose ();
//			SetPose ();
#endif
		}

		public void SetPose(Pose pose){
			m_Camera.transform.position = pose.position;
			m_Camera.transform.rotation = pose.rotation;
		}

	}
}
 #endif