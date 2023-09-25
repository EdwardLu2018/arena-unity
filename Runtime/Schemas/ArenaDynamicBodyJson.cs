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
    /// Physics type attached to the object. More properties at <a href='https://github.com/n5ro/aframe-physics-system#dynamic-body-and-static-body'>https://github.com/n5ro/aframe-physics-system#dynamic-body-and-static-body</a>
    /// </summary>
    [Serializable]
    public class ArenaDynamicBodyJson
    {
        [JsonIgnore]
        public readonly string componentName = "dynamic-body";

        // dynamic-body member-fields

        public enum TypeType
        {
            [EnumMember(Value = "static")]
            Static,
            [EnumMember(Value = "dynamic")]
            Dynamic,
        }
        private static TypeType defType = TypeType.Static;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type")]
        [Tooltip("type")]
        public TypeType Type = defType;
        public bool ShouldSerializeType()
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
