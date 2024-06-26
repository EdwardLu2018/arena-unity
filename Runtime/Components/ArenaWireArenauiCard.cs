﻿/**
 * Open source software under the terms in /LICENSE
 * Copyright (c) 2021-2023, Carnegie Mellon University. All rights reserved.
 */

using ArenaUnity.Components;
using ArenaUnity.Schemas;
using Newtonsoft.Json;
using UnityEngine;

namespace ArenaUnity
{
    public class ArenaWireArenauiCard : ArenaComponent
    {
        // ARENA arenaui-card component unity conversion status:
        // TODO: title
        // TODO: body
        // TODO: bodyAlign
        // TODO: img
        // TODO: imgCaption
        // TODO: imgDirection
        // TODO: imgSize
        // TODO: textImageRatio
        // TODO: fontSize
        // TODO: widthScale
        // TODO: closeButton
        // TODO: font
        // TODO: theme
        // TODO: materialSides

        public ArenaArenauiCardJson json = new ArenaArenauiCardJson();

        protected override void ApplyRender()
        {
            // TODO: Implement this component if needed, or note our reasons for not rendering or controlling here.
            Debug.Log("UI Card!");
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
