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
    /// A location marker (such as an AprilTag, a lightAnchor, or an UWB tag), used to anchor scenes, or scene objects, in the real world.
    /// </summary>
    [Serializable]
    public class ArenaArmarkerJson
    {
        public const string componentName = "armarker";

        // armarker member-fields

        private static bool defPublish = false;
        [JsonProperty(PropertyName = "publish")]
        [Tooltip("Publish detections. Send detections to external agents (e.g. external builder script that places new markers in the scene). If dynamic=true and publish=true, object position is not updated (left up to external agent).")]
        public bool Publish = defPublish;
        public bool ShouldSerializePublish()
        {
            if (_token != null && _token.SelectToken("publish") != null) return true;
            return (Publish != defPublish);
        }

        private static bool defDynamic = false;
        [JsonProperty(PropertyName = "dynamic")]
        [Tooltip("Dynamic tag, not used for localization. E.g., to move object to which this ARMarker component is attached to. Requires permissions to update the scene (if dynamic=true).")]
        public bool Dynamic = defDynamic;
        public bool ShouldSerializeDynamic()
        {
            if (_token != null && _token.SelectToken("dynamic") != null) return true;
            return (Dynamic != defDynamic);
        }

        private static float defEle = 0f;
        [JsonProperty(PropertyName = "ele")]
        [Tooltip("Tag elevation in meters.")]
        public float Ele = defEle;
        public bool ShouldSerializeEle()
        {
            if (_token != null && _token.SelectToken("ele") != null) return true;
            return (Ele != defEle);
        }

        private static float defLat = 0f;
        [JsonProperty(PropertyName = "lat")]
        [Tooltip("Tag latitude.")]
        public float Lat = defLat;
        public bool ShouldSerializeLat()
        {
            if (_token != null && _token.SelectToken("lat") != null) return true;
            return (Lat != defLat);
        }

        private static float defLong = 0f;
        [JsonProperty(PropertyName = "long")]
        [Tooltip("Tag longitude.")]
        public float Long = defLong;
        public bool ShouldSerializeLong()
        {
            if (_token != null && _token.SelectToken("long") != null) return true;
            return (Long != defLong);
        }

        private static string defMarkerid = "0";
        [JsonProperty(PropertyName = "markerid")]
        [Tooltip("The marker id (e.g. for AprilTag 36h11 family, an integer in the range [0, 586])")]
        public string Markerid = defMarkerid;
        public bool ShouldSerializeMarkerid()
        {
            return true; // required in json schema 
        }

        public enum MarkertypeType
        {
            [EnumMember(Value = "apriltag_36h11")]
            Apriltag36h11,
            [EnumMember(Value = "lightanchor")]
            Lightanchor,
            [EnumMember(Value = "uwb")]
            Uwb,
        }
        private static MarkertypeType defMarkertype = MarkertypeType.Apriltag36h11;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "markertype")]
        [Tooltip("The marker type (apriltag_36h11, lightanchor, uwb)")]
        public MarkertypeType Markertype = defMarkertype;
        public bool ShouldSerializeMarkertype()
        {
            return true; // required in json schema 
        }

        private static float defSize = 150f;
        [JsonProperty(PropertyName = "size")]
        [Tooltip("Tag size in millimeters")]
        public float Size = defSize;
        public bool ShouldSerializeSize()
        {
            return true; // required in json schema 
        }

        private static string defUrl = "";
        [JsonProperty(PropertyName = "url")]
        [Tooltip("URL associated with the tag")]
        public string Url = defUrl;
        public bool ShouldSerializeUrl()
        {
            if (_token != null && _token.SelectToken("url") != null) return true;
            return (Url != defUrl);
        }

        // General json object management

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        private static JToken _token;

        public string SaveToString()
        {
            return Regex.Unescape(JsonConvert.SerializeObject(this));
        }

        public static ArenaArmarkerJson CreateFromJSON(string jsonString, JToken token)
        {
            _token = token; // save updated wire json
            return JsonConvert.DeserializeObject<ArenaArmarkerJson>(Regex.Unescape(jsonString));
        }
    }
}
