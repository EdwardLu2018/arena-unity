/**
 * Open source software under the terms in /LICENSE
 * Copyright (c) 2021-2024, Carnegie Mellon University. All rights reserved.
 */

// CAUTION: This file is autogenerated from https://github.com/arenaxr/arena-schemas. Changes made here may be overwritten.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace ArenaUnity.Schemas
{
    /// <summary>
    /// When the object is created or deleted, it will animate in/out of the scene instead of appearing/disappearing instantly. Must have a geometric mesh.
    /// </summary>
    [Serializable]
    public class ArenaBlipJson
    {
        [JsonIgnore]
        public readonly string componentName = "blip";

        // blip member-fields

        private static bool defBlipin = true;
        [JsonProperty(PropertyName = "blipin")]
        [Tooltip("Animate in on create, set false to disable.")]
        public bool Blipin = defBlipin;
        public bool ShouldSerializeBlipin()
        {
            return true; // required in json schema
        }

        private static bool defBlipout = true;
        [JsonProperty(PropertyName = "blipout")]
        [Tooltip("Animate out on delete, set false to disable.")]
        public bool Blipout = defBlipout;
        public bool ShouldSerializeBlipout()
        {
            return true; // required in json schema
        }

        public enum GeometryType
        {
            [EnumMember(Value = "rect")]
            Rect,
            [EnumMember(Value = "disk")]
            Disk,
            [EnumMember(Value = "ring")]
            Ring,
        }
        private static GeometryType defGeometry = GeometryType.Rect;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "geometry")]
        [Tooltip("Geometry of the blipout plane.")]
        public GeometryType Geometry = defGeometry;
        public bool ShouldSerializeGeometry()
        {
            return true; // required in json schema
        }

        public enum PlanesType
        {
            [EnumMember(Value = "both")]
            Both,
            [EnumMember(Value = "top")]
            Top,
            [EnumMember(Value = "bottom")]
            Bottom,
        }
        private static PlanesType defPlanes = PlanesType.Both;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "planes")]
        [Tooltip("Which which clipping planes to use for effect. A top plane clips above it, bottom clips below it.")]
        public PlanesType Planes = defPlanes;
        public bool ShouldSerializePlanes()
        {
            return true; // required in json schema
        }

        private static float defDuration = 750f;
        [JsonProperty(PropertyName = "duration")]
        [Tooltip("Animation duration in milliseconds.")]
        public float Duration = defDuration;
        public bool ShouldSerializeDuration()
        {
            return true; // required in json schema
        }

        private static bool defApplyDescendants = false;
        [JsonProperty(PropertyName = "applyDescendants")]
        [Tooltip("Apply blipout effect to include all descendents. Does not work for blipin.")]
        public bool ApplyDescendants = defApplyDescendants;
        public bool ShouldSerializeApplyDescendants()
        {
            // applyDescendants
            return (ApplyDescendants != defApplyDescendants);
        }

        // General json object management
        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            Debug.LogWarning($"{errorContext.Error.Message}: {errorContext.OriginalObject}");
            errorContext.Handled = true;
        }

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;
    }
}
