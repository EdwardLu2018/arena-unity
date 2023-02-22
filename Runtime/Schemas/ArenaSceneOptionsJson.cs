/**
 * Open source software under the terms in /LICENSE
 * Copyright (c) 2021-2023, Carnegie Mellon University. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace ArenaUnity.Schemas
{
    /// <summary>
    /// ARENA Scene Options
    /// </summary>
    [Serializable]
    public class ArenaSceneOptionsJson
    {
        public const string componentName = "scene-options";

        // scene-options member-fields

        private static bool defClickableOnlyEvents = true;
        [JsonProperty(PropertyName = "clickableOnlyEvents")]
        [Tooltip("true = publish only mouse events for objects with click-listeners; false = all objects publish mouse events")]
        public bool ClickableOnlyEvents = defClickableOnlyEvents;
        public bool ShouldSerializeClickableOnlyEvents()
        {
            return true; // required in json schema 
        }

        public enum DistanceModelType
        {
            [EnumMember(Value = "exponential")]
            Exponential,
            [EnumMember(Value = "inverse")]
            Inverse,
            [EnumMember(Value = "linear")]
            Linear,
        }
        private static DistanceModelType defDistanceModel = DistanceModelType.Inverse;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "distanceModel")]
        [Tooltip("Algorithm to use to reduce the volume of the audio source as it moves away from the listener")]
        public DistanceModelType DistanceModel = defDistanceModel;
        public bool ShouldSerializeDistanceModel()
        {
            if (_token != null && _token.SelectToken("distanceModel") != null) return true;
            return (DistanceModel != defDistanceModel);
        }

        private static string[] defSceneHeadModels = {};
        [JsonProperty(PropertyName = "sceneHeadModels")]
        [Tooltip("Define the default head model(s) for the scene in a list. Users may still choose from the ARENA default list of head models as well.")]
        public string[] SceneHeadModels = defSceneHeadModels;
        public bool ShouldSerializeSceneHeadModels()
        {
            if (_token != null && _token.SelectToken("sceneHeadModels") != null) return true;
            return (SceneHeadModels != defSceneHeadModels);
        }

        private static string defJitsiHost = "jitsi0.andrew.cmu.edu:8443";
        [JsonProperty(PropertyName = "jitsiHost")]
        [Tooltip("Jitsi host used for this scene.")]
        public string JitsiHost = defJitsiHost;
        public bool ShouldSerializeJitsiHost()
        {
            if (_token != null && _token.SelectToken("jitsiHost") != null) return true;
            return (JitsiHost != defJitsiHost);
        }

        private static float defMaxAVDist = 20f;
        [JsonProperty(PropertyName = "maxAVDist")]
        [Tooltip("Maximum distance between cameras/users until audio and video are cut off. For saving bandwidth on scenes with large amounts of user activity at once")]
        public float MaxAVDist = defMaxAVDist;
        public bool ShouldSerializeMaxAVDist()
        {
            return true; // required in json schema 
        }

        private static string defNavMesh = "";
        [JsonProperty(PropertyName = "navMesh")]
        [Tooltip("Navigation Mesh URL")]
        public string NavMesh = defNavMesh;
        public bool ShouldSerializeNavMesh()
        {
            if (_token != null && _token.SelectToken("navMesh") != null) return true;
            return (NavMesh != defNavMesh);
        }

        private static bool defNetworkedLocationSolver = false;
        [JsonProperty(PropertyName = "networkedLocationSolver")]
        [Tooltip("ARMarker location solver parameter. By default (networkedLocationSolver=false) clients solve camera location locally when a static marker is detected. When true, publishes marker detections (to realm/g/a/camera-name) and defers all tag solving of client camera to a solver sitting on pubsub.")]
        public bool NetworkedLocationSolver = defNetworkedLocationSolver;
        public bool ShouldSerializeNetworkedLocationSolver()
        {
            if (_token != null && _token.SelectToken("networkedLocationSolver") != null) return true;
            return (NetworkedLocationSolver != defNetworkedLocationSolver);
        }

        private static bool defPrivateScene = false;
        [JsonProperty(PropertyName = "privateScene")]
        [Tooltip("false = scene will be visible; true = scene will not show in listings")]
        public bool PrivateScene = defPrivateScene;
        public bool ShouldSerializePrivateScene()
        {
            return true; // required in json schema 
        }

        private static float defRefDistance = 1f;
        [JsonProperty(PropertyName = "refDistance")]
        [Tooltip("Distance at which the volume reduction starts taking effect")]
        public float RefDistance = defRefDistance;
        public bool ShouldSerializeRefDistance()
        {
            if (_token != null && _token.SelectToken("refDistance") != null) return true;
            return (RefDistance != defRefDistance);
        }

        private static float defRolloffFactor = 1f;
        [JsonProperty(PropertyName = "rolloffFactor")]
        [Tooltip("How quickly the volume is reduced as the source moves away from the listener")]
        public float RolloffFactor = defRolloffFactor;
        public bool ShouldSerializeRolloffFactor()
        {
            if (_token != null && _token.SelectToken("rolloffFactor") != null) return true;
            return (RolloffFactor != defRolloffFactor);
        }

        private static string defScreenshare = "screenshare";
        [JsonProperty(PropertyName = "screenshare")]
        [Tooltip("Name of the 3D object used when sharing desktop")]
        public string Screenshare = defScreenshare;
        public bool ShouldSerializeScreenshare()
        {
            if (_token != null && _token.SelectToken("screenshare") != null) return true;
            return (Screenshare != defScreenshare);
        }

        private static bool defVideoFrustumCulling = true;
        [JsonProperty(PropertyName = "videoFrustumCulling")]
        [Tooltip("If false, will disable video frustum culling (video frustum culling stops video from users outside of view)")]
        public bool VideoFrustumCulling = defVideoFrustumCulling;
        public bool ShouldSerializeVideoFrustumCulling()
        {
            return true; // required in json schema 
        }

        private static bool defVideoDistanceConstraints = true;
        [JsonProperty(PropertyName = "videoDistanceConstraints")]
        [Tooltip("If false, will disable video distance constraints (video resolution decreases with distance from users in view)")]
        public bool VideoDistanceConstraints = defVideoDistanceConstraints;
        public bool ShouldSerializeVideoDistanceConstraints()
        {
            return true; // required in json schema 
        }

        private static float defVideoDefaultResolutionConstraint = 180f;
        [JsonProperty(PropertyName = "videoDefaultResolutionConstraint")]
        [Tooltip("Sets the default max resolution for all users. Ignored when videoDistanceConstraints = true.")]
        public float VideoDefaultResolutionConstraint = defVideoDefaultResolutionConstraint;
        public bool ShouldSerializeVideoDefaultResolutionConstraint()
        {
            return true; // required in json schema 
        }

        private static float defVolume = 1f;
        [JsonProperty(PropertyName = "volume")]
        [Tooltip("Volume for users in a scene")]
        public float Volume = defVolume;
        public bool ShouldSerializeVolume()
        {
            if (_token != null && _token.SelectToken("volume") != null) return true;
            return (Volume != defVolume);
        }

        private static bool defPhysics = false;
        [JsonProperty(PropertyName = "physics")]
        [Tooltip("If true, will load the aframe-physics-system. Required for the following: `dynamic-body`, `impulse`, `collision-listener`.")]
        public bool Physics = defPhysics;
        public bool ShouldSerializePhysics()
        {
            return true; // required in json schema 
        }

        private static object defArHitTest = JsonConvert.DeserializeObject("");
        [JsonProperty(PropertyName = "ar-hit-test")]
        [Tooltip("A-Frame AR Hit Test Settings. More properties at <a href='https://aframe.io/docs/1.3.0/components/ar-hit-test.html'>https://aframe.io/docs/1.3.0/components/ar-hit-test.html</a>")]
        public object ArHitTest = defArHitTest;
        public bool ShouldSerializeArHitTest()
        {
            if (_token != null && _token.SelectToken("ar-hit-test") != null) return true;
            return (ArHitTest != defArHitTest);
        }

        // General json object management

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        private static JToken _token;

        public string SaveToString()
        {
            return Regex.Unescape(JsonConvert.SerializeObject(this));
        }

        public static ArenaSceneOptionsJson CreateFromJSON(string jsonString, JToken token)
        {
            _token = token; // save updated wire json
            return JsonConvert.DeserializeObject<ArenaSceneOptionsJson>(Regex.Unescape(jsonString));
        }
    }
}
