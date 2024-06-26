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
    /// Display an image on a plane. See guidance to store paths under <a href='https://docs.arenaxr.org/content/interface/filestore.html'>ARENA File Store, CDN, or DropBox</a>.
    /// </summary>
    [Serializable]
    public class ArenaImageJson
    {
        public readonly string object_type = "image";

        // image member-fields

        private static string defUrl = null;
        [JsonProperty(PropertyName = "url")]
        [Tooltip("Use File Store paths under 'store/users/username', see CDN and other storage options in the description above.")]
        public string Url = defUrl;
        public bool ShouldSerializeUrl()
        {
            return true; // required in json schema
        }

        private static float defHeight = 1f;
        [JsonProperty(PropertyName = "height")]
        [Tooltip("height")]
        public float Height = defHeight;
        public bool ShouldSerializeHeight()
        {
            return true; // required in json schema
        }

        private static int defSegmentsHeight = 1;
        [JsonProperty(PropertyName = "segmentsHeight")]
        [Tooltip("segments height")]
        public int SegmentsHeight = defSegmentsHeight;
        public bool ShouldSerializeSegmentsHeight()
        {
            // segmentsHeight
            return (SegmentsHeight != defSegmentsHeight);
        }

        private static int defSegmentsWidth = 1;
        [JsonProperty(PropertyName = "segmentsWidth")]
        [Tooltip("segments width")]
        public int SegmentsWidth = defSegmentsWidth;
        public bool ShouldSerializeSegmentsWidth()
        {
            // segmentsWidth
            return (SegmentsWidth != defSegmentsWidth);
        }

        private static float defWidth = 1f;
        [JsonProperty(PropertyName = "width")]
        [Tooltip("width")]
        public float Width = defWidth;
        public bool ShouldSerializeWidth()
        {
            return true; // required in json schema
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
