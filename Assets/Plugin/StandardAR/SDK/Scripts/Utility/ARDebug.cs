#if  UNITY_ANDROID || UNITY_EDITOR 
//-----------------------------------------------------------------------
// <copyright file="ARDebug.cs" company="Google">
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
// modification list
// 1.add LogInfo
//rename GoogleARCore to StandardAR to avoid conflict
//rename GoogleARCoreInternal to StandardARInternal to avoid conflict
//
// </copyright>
//-----------------------------------------------------------------------

namespace StandardARInternal
{
    using System;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// A custom class similar to Unity's Debug.
    /// </summary>
    public class ARDebug
    {
        /// <summary>
        /// Logs an error with a stack trace.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void LogInfo(string message)
        {
            UnityEngine.Debug.Log("StandardAR :"+message);
        }

        /// <summary>
        /// Logs an error with a stack trace.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void LogError(object message)
        {
            UnityEngine.Debug.LogErrorFormat("StandardAR :" + message + "\n{0}", new StackTrace(1));
        }

        /// <summary>
        /// Logs an error with a stack trace.
        /// </summary>
        /// <param name="format">The string format.</param>
        /// <param name="args">The output arguments.</param>
        public static void LogErrorFormat(string format, params object[] args)
        {
            object[] newArgs = new object[args.Length + 1];
            Array.Copy(args, newArgs, args.Length);
            newArgs[args.Length] = new StackTrace(1);
            UnityEngine.Debug.LogErrorFormat("StandardAR :" + format + "\n{" + args.Length + "}", newArgs);
        }
    }
}
 #endif