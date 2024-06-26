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
    /// Generate an event message for an object.
    /// </summary>
    [Serializable]
    public class ArenaEventJson
    {
        [JsonIgnore]
        public readonly string componentName = "event";

        // event member-fields

        private static string defSource = null;
        [JsonProperty(PropertyName = "source")]
        [Tooltip("The `object_id` of event origination. e.g camera or client program connection id.")]
        public string Source = defSource;
        public bool ShouldSerializeSource()
        {
            return true; // required in json schema
        }

        private static ArenaVector3Json defPosition = null;
        [JsonProperty(PropertyName = "position")]
        [Tooltip("The event destination position in 3D.")]
        public ArenaVector3Json Position = defPosition;
        public bool ShouldSerializePosition()
        {
            return true; // required in json schema
        }

        private static ArenaVector3Json defClickPos = JsonConvert.DeserializeObject<ArenaVector3Json>("{'x': 0, 'y': 1.6, 'z': 0}");
        [JsonProperty(PropertyName = "clickPos")]
        [Tooltip("The event origination position in 3D.")]
        public ArenaVector3Json ClickPos = defClickPos;
        public bool ShouldSerializeClickPos()
        {
            // clickPos
            return (ClickPos != defClickPos);
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
