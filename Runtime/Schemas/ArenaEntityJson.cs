/**
 * Open source software under the terms in /LICENSE
 * Copyright (c) 2021-2023, Carnegie Mellon University. All rights reserved.
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
    /// Entities are the base of all objects in the scene. Entities are containers into which components can be attached.
    /// </summary>
    [Serializable]
    public class ArenaEntityJson
    {
        public readonly string object_type = "entity";

        // entity member-fields

        private static object defGeometry = JsonConvert.DeserializeObject("");
        [JsonProperty(PropertyName = "geometry")]
        [Tooltip("geometry")]
        public object Geometry = defGeometry;
        public bool ShouldSerializeGeometry()
        {
            // geometry
            return (Geometry != defGeometry);
        }

        private static object defPanel = JsonConvert.DeserializeObject("");
        [JsonProperty(PropertyName = "panel")]
        [Tooltip("The rounded UI panel primitive.")]
        public object Panel = defPanel;
        public bool ShouldSerializePanel()
        {
            // panel
            return (Panel != defPanel);
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