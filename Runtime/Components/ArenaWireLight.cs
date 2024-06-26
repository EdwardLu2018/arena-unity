﻿/**
 * Open source software under the terms in /LICENSE
 * Copyright (c) 2021-2023, Carnegie Mellon University. All rights reserved.
 */

using ArenaUnity.Components;
using ArenaUnity.Schemas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace ArenaUnity
{
    public class ArenaWireLight : ArenaComponent
    {
        // ARENA light component unity conversion status:
        // DONE: angle
        // DONE: castShadow
        // DONE: color
        // TODO: decay
        // DONE: distance
        // TODO: envMap
        // TODO: groundColor
        // DONE: intensity
        // TODO: light
        // TODO: penumbra
        // TODO: shadowBias
        // TODO: shadowCameraBottom
        // TODO: shadowCameraFar
        // TODO: shadowCameraFov
        // TODO: shadowCameraLeft
        // TODO: shadowCameraNear
        // TODO: shadowCameraRight
        // TODO: shadowCameraTop
        // TODO: shadowCameraVisible
        // TODO: shadowMapHeight
        // TODO: shadowMapWidth
        // TODO: shadowRadius
        // TODO: target
        // DONE: type

        public ArenaLightJson json = new ArenaLightJson();

        protected override void ApplyRender()
        {
            // TODO: Implement this component if needed, or note our reasons for not rendering or controlling here.

            if (json.Type == ArenaLightJson.TypeType.Ambient)
            {
                RenderSettings.ambientMode = AmbientMode.Flat;
                RenderSettings.ambientIntensity = json.Intensity;
                if (json.Color != null)
                    RenderSettings.ambientLight = ArenaUnity.ToUnityColor(json.Color);
            }
            else
            {
                Light light = gameObject.GetComponent<Light>();
                if (light == null)
                    light = gameObject.AddComponent<Light>();
                switch (json.Type)
                {
                    case ArenaLightJson.TypeType.Directional:
                        light.type = LightType.Directional;
                        gameObject.transform.LookAt(new Vector3(0,0,0));
                        break;
                    case ArenaLightJson.TypeType.Point:
                        light.type = LightType.Point;
                        light.range = json.Distance;
                        break;
                    case ArenaLightJson.TypeType.Spot:
                        light.type = LightType.Spot;
                        light.range = json.Distance;
                        light.spotAngle = json.Angle;
                        break;
                }
                light.intensity = json.Intensity;
                if (json.Color != null)
                    light.color = ArenaUnity.ToUnityColor(json.Color);
                light.shadows = !json.CastShadow ? LightShadows.None : LightShadows.Soft;
            }
        }

        // light
        public static JObject ToArenaLight(GameObject gobj)
        {
            // TODO: translate from RenderSettings.ambientMode, may need centralized one-time publish
            var data = new ArenaLightJson();
            Light light = gobj.GetComponent<Light>();
            switch (light.type)
            {
                case LightType.Directional:
                    data.Type = ArenaLightJson.TypeType.Directional;
                    break;
                case LightType.Point:
                    data.Type = ArenaLightJson.TypeType.Point;
                    data.Distance = ArenaUnity.ArenaFloat(light.range);
                    break;
                case LightType.Spot:
                    data.Type = ArenaLightJson.TypeType.Spot;
                    data.Distance = ArenaUnity.ArenaFloat(light.range);
                    data.Angle = ArenaUnity.ArenaFloat(light.spotAngle);
                    break;
            }
            data.Intensity = ArenaUnity.ArenaFloat(light.intensity);
            data.Color = ArenaUnity.ToArenaColor(light.color);
            data.CastShadow = light.shadows != LightShadows.None;

            return data != null ? JObject.FromObject(data) : null;
        }

        public override void UpdateObject()
        {
            var newJson = JsonConvert.SerializeObject(json);
            if (updatedJson != newJson)
            {
                var aobj = GetComponent<ArenaObject>();
                if (aobj != null)
                {
                    aobj.PublishUpdate($"{newJson}");
                    apply = true;
                }
            }
            updatedJson = newJson;
        }
    }
}
