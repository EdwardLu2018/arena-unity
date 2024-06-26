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
    /// Animate and tween values. More properties at <a href='https://aframe.io/docs/1.5.0/components/animation.html'>A-Frame Animation</a> component. Easing properties are detailed at <a href='https://easings.net'>easings.net</a>.
    /// </summary>
    [Serializable]
    public class ArenaAnimationJson
    {
        [JsonIgnore]
        public readonly string componentName = "animation";

        // animation member-fields

        private static bool defAutoplay = true;
        [JsonProperty(PropertyName = "autoplay")]
        [Tooltip("Whether or not the animation should autoplay. Should be specified if the animation is defined for the animation-timeline component (currently not supported).")]
        public bool Autoplay = defAutoplay;
        public bool ShouldSerializeAutoplay()
        {
            // autoplay
            return (Autoplay != defAutoplay);
        }

        private static float defDelay = 0f;
        [JsonProperty(PropertyName = "delay")]
        [Tooltip("How long (milliseconds) to wait before starting.")]
        public float Delay = defDelay;
        public bool ShouldSerializeDelay()
        {
            // delay
            return (Delay != defDelay);
        }

        public enum DirType
        {
            [EnumMember(Value = "normal")]
            Normal,
            [EnumMember(Value = "alternate")]
            Alternate,
            [EnumMember(Value = "reverse")]
            Reverse,
        }
        private static DirType defDir = DirType.Normal;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "dir")]
        [Tooltip("Which dir to go from from to to.")]
        public DirType Dir = defDir;
        public bool ShouldSerializeDir()
        {
            // dir
            return (Dir != defDir);
        }

        private static float defDur = 1000f;
        [JsonProperty(PropertyName = "dur")]
        [Tooltip("How long (milliseconds) each cycle of the animation is.")]
        public float Dur = defDur;
        public bool ShouldSerializeDur()
        {
            // dur
            return (Dur != defDur);
        }

        public enum EasingType
        {
            [EnumMember(Value = "easeInQuad")]
            EaseInQuad,
            [EnumMember(Value = "easeInCubic")]
            EaseInCubic,
            [EnumMember(Value = "easeInQuart")]
            EaseInQuart,
            [EnumMember(Value = "easeInQuint")]
            EaseInQuint,
            [EnumMember(Value = "easeInSine")]
            EaseInSine,
            [EnumMember(Value = "easeInExpo")]
            EaseInExpo,
            [EnumMember(Value = "easeInCirc")]
            EaseInCirc,
            [EnumMember(Value = "easeInBack")]
            EaseInBack,
            [EnumMember(Value = "easeInElastic")]
            EaseInElastic,
            [EnumMember(Value = "easeOutQuad")]
            EaseOutQuad,
            [EnumMember(Value = "easeOutCubic")]
            EaseOutCubic,
            [EnumMember(Value = "easeOutQuart")]
            EaseOutQuart,
            [EnumMember(Value = "easeOutQuint")]
            EaseOutQuint,
            [EnumMember(Value = "easeOutSine")]
            EaseOutSine,
            [EnumMember(Value = "easeOutExpo")]
            EaseOutExpo,
            [EnumMember(Value = "easeOutCirc")]
            EaseOutCirc,
            [EnumMember(Value = "easeOutBack")]
            EaseOutBack,
            [EnumMember(Value = "easeOutElastic")]
            EaseOutElastic,
            [EnumMember(Value = "easeInOutQuad")]
            EaseInOutQuad,
            [EnumMember(Value = "easeInOutCubic")]
            EaseInOutCubic,
            [EnumMember(Value = "easeInOutQuart")]
            EaseInOutQuart,
            [EnumMember(Value = "easeInOutQuint")]
            EaseInOutQuint,
            [EnumMember(Value = "easeInOutSine")]
            EaseInOutSine,
            [EnumMember(Value = "easeInOutExpo")]
            EaseInOutExpo,
            [EnumMember(Value = "easeInOutCirc")]
            EaseInOutCirc,
            [EnumMember(Value = "easeInOutBack")]
            EaseInOutBack,
            [EnumMember(Value = "easeInOutElastic")]
            EaseInOutElastic,
            [EnumMember(Value = "linear")]
            Linear,
        }
        private static EasingType defEasing = EasingType.EaseInQuad;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "easing")]
        [Tooltip("Easing function of animation. To ease in, ease out, ease in and out. See easings.net for more.")]
        public EasingType Easing = defEasing;
        public bool ShouldSerializeEasing()
        {
            // easing
            return (Easing != defEasing);
        }

        private static float defElasticity = 400f;
        [JsonProperty(PropertyName = "elasticity")]
        [Tooltip("How much to bounce (higher is stronger).")]
        public float Elasticity = defElasticity;
        public bool ShouldSerializeElasticity()
        {
            // elasticity
            return (Elasticity != defElasticity);
        }

        private static bool defEnabled = true;
        [JsonProperty(PropertyName = "enabled")]
        [Tooltip("If disabled, animation will stop and startEvents will not trigger animation start.")]
        public bool Enabled = defEnabled;
        public bool ShouldSerializeEnabled()
        {
            // enabled
            return (Enabled != defEnabled);
        }

        private static string defFrom = "";
        [JsonConverter(typeof(string))] // TODO (mwfarb): remove explicit conversion to avoid walking errors
        [JsonProperty(PropertyName = "from")]
        [Tooltip("Initial value at start of animation. If not specified, the current property value of the entity will be used (will be sampled on each animation start). It is best to specify a from value when possible for stability.")]
        public string From = defFrom;
        public bool ShouldSerializeFrom()
        {
            // from
            return (From != defFrom);
        }

        private static bool defIsRawProperty = false;
        [JsonProperty(PropertyName = "isRawProperty")]
        [Tooltip("Flag to animate an arbitrary object property outside of A-Frame components for better performance. If set to true, for example, we can set property to like components.material.material.opacity. If property starts with components or object3D, this will be inferred to true.")]
        public bool IsRawProperty = defIsRawProperty;
        public bool ShouldSerializeIsRawProperty()
        {
            // isRawProperty
            return (IsRawProperty != defIsRawProperty);
        }

        private static string defLoop = "0";
        [JsonProperty(PropertyName = "loop")]
        [Tooltip("How many times the animation should repeat. If the value is true, the animation will repeat infinitely.")]
        public string Loop = defLoop;
        public bool ShouldSerializeLoop()
        {
            // loop
            return (Loop != defLoop);
        }

        private static string[] defPauseEvents = {  };
        [JsonProperty(PropertyName = "pauseEvents")]
        [Tooltip("Comma-separated list of events to listen to trigger pause. Can be resumed with resumeEvents.")]
        public string[] PauseEvents = defPauseEvents;
        public bool ShouldSerializePauseEvents()
        {
            // pauseEvents
            return (PauseEvents != defPauseEvents);
        }

        private static string defProperty = null;
        [JsonProperty(PropertyName = "property")]
        [Tooltip("Property to animate. Can be a component name, a dot-delimited property of a component (e.g., material.color), or a plain attribute.")]
        public string Property = defProperty;
        public bool ShouldSerializeProperty()
        {
            // property
            return (Property != defProperty);
        }

        private static string[] defResumeEvents = {  };
        [JsonProperty(PropertyName = "resumeEvents")]
        [Tooltip("Comma-separated list of events to listen to trigger resume after pausing.")]
        public string[] ResumeEvents = defResumeEvents;
        public bool ShouldSerializeResumeEvents()
        {
            // resumeEvents
            return (ResumeEvents != defResumeEvents);
        }

        private static bool defRound = false;
        [JsonProperty(PropertyName = "round")]
        [Tooltip("Whether to round values.")]
        public bool Round = defRound;
        public bool ShouldSerializeRound()
        {
            // round
            return (Round != defRound);
        }

        private static string[] defStartEvents = {  };
        [JsonProperty(PropertyName = "startEvents")]
        [Tooltip("Comma-separated list of events to listen to trigger a restart and play. Animation will not autoplay if specified. startEvents will restart the animation, use pauseEvents to resume it. If there are other animation components on the entity animating the same property, those animations will be automatically paused to not conflict.")]
        public string[] StartEvents = defStartEvents;
        public bool ShouldSerializeStartEvents()
        {
            // startEvents
            return (StartEvents != defStartEvents);
        }

        private static string defTo = "";
        [JsonConverter(typeof(string))] // TODO (mwfarb): remove explicit conversion to avoid walking errors
        [JsonProperty(PropertyName = "to")]
        [Tooltip("Target value at end of animation.")]
        public string To = defTo;
        public bool ShouldSerializeTo()
        {
            // to
            return (To != defTo);
        }

        private static string defType = "";
        [JsonProperty(PropertyName = "type")]
        [Tooltip("Right now only supports color for tweening isRawProperty color XYZ/RGB vector values.")]
        public string Type = defType;
        public bool ShouldSerializeType()
        {
            // type
            return (Type != defType);
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
