/**
 * Open source software under the terms in /LICENSE
 * Copyright (c) 2021-2023, Carnegie Mellon University. All rights reserved.
 */

using System.Collections.Generic;
using System.Text.RegularExpressions;
using ArenaUnity.Schemas;
using Newtonsoft.Json;
using UnityEngine;

namespace ArenaUnity.Components
{
    public class ArenaSceneOptions : ArenaComponent
    {
        // ARENA scene-options component unity conversion status:
        // TODO: clickableOnlyEvents
        // TODO: distanceModel
        // TODO: sceneHeadModels
        // TODO: jitsiHost
        // TODO: maxAVDist
        // TODO: navMesh
        // TODO: networkedLocationSolver
        // TODO: privateScene
        // TODO: refDistance
        // TODO: rolloffFactor
        // TODO: screenshare
        // TODO: videoFrustumCulling
        // TODO: videoDistanceConstraints
        // TODO: videoDefaultResolutionConstraint
        // TODO: volume
        // TODO: physics
        // TODO: ar-hit-test

        public ArenaSceneOptionsJson json = new ArenaSceneOptionsJson();

        protected override void ApplyRender()
        {
            // TODO: Implement this component if needed, or note our reasons for not rendering or controlling here.
        }

        public override void UpdateObject()
        {
            var newJson = JsonConvert.SerializeObject(json);
            if (updatedJson != newJson)
            {
                var aobj = GetComponent<ArenaObject>();
                if (aobj != null)
                {
                    aobj.PublishUpdate($"{{\"{json.componentName}\":{newJson}}}");
                    apply = true;
                }
            }
            updatedJson = newJson;
        }
    }
}
