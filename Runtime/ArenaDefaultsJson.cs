﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using ArenaUnity.Schemas;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace ArenaUnity
{
    [Serializable]
    public class ArenaDefaultsJson
    {
        public string realm { get; set; } // e.g. "realm"
        public int camUpdateIntervalMs { get; set; } // e.g. 100
        [JsonProperty(PropertyName = "namespace")]
        public string _namespace { get; set; } // e.g. "public"
        public string sceneName { get; set; } // e.g. "lobby"
        public string userName { get; set; } // e.g. "Anonymous"
        public ArenaVector3Json startCoords { get; set; } // e.g. {"x": 0, "y": 0, "z": 0}
        public float camHeight { get; set; } // e.g. 1.6
        public string mqttHost { get; set; } // e.g. "localhost"
        public string jitsiHost { get; set; } // e.g. "mr.andrew.cmu.edu"
        public string ATLASurl { get; set; } // e.g. "//atlas.conix.io"
        public string vioTopic { get; set; } // e.g. "/topic/vio/"
        public string graphTopic { get; set; } // e.g. "$NETWORK"
        public string latencyTopic { get; set; } // e.g. "$NETWORK/latency"
        public string[] mqttPath { get; set; } // e.g. [ "/mqtt/" ]
        public string persistHost { get; set; } // e.g. "localhost"
        public string persistPath { get; set; } // e.g. "/persist/"
        public bool devInstance { get; set; } // e.g. true
        public string headModelPath { get; set; } // e.g. "/static/models/avatars/robobit.glb"

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
