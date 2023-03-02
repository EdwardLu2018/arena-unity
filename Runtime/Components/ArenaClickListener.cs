﻿/**
 * Open source software under the terms in /LICENSE
 * Copyright (c) 2021-2023, Carnegie Mellon University. All rights reserved.
 */

using System.Dynamic;
using Newtonsoft.Json;
using UnityEngine;

namespace ArenaUnity.Components
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    [HelpURL("https://docs.arenaxr.org/content/schemas/arena-aframe-components.html#click-listener")]
    [RequireComponent(typeof(ArenaObject))]
    public class ArenaClickListener : MonoBehaviour
    {
        private Camera _camera;
        private ArenaCamera _arenaCam;

        private bool meshAvailable = false;

        public delegate void ClientEventMessageDelegate(string event_type, string msg);
        public ClientEventMessageDelegate OnEventCallback = null; // null, until user instantiates.

        private void Start()
        {
            _camera = Camera.main;
            _arenaCam = _camera.GetComponent<ArenaCamera>();
            if (_arenaCam == null) _arenaCam = _camera.gameObject.AddComponent<ArenaCamera>();
        }

        private void Update()
        {
            if (!meshAvailable)
            {
                MeshFilter mf = GetComponent<MeshFilter>();
                if (mf != null)
                {
                    // primitive geometry
                    MeshCollider mc = gameObject.AddComponent<MeshCollider>();
                    mc.sharedMesh = mf.mesh;
                    mc.convex = true; // simplify collision mesh when possible
                    meshAvailable = true;
                }
                else
                {
                    // TODO: create combined mesh collider, test for "this arena object only"
                    // https://docs.unity3d.com/ScriptReference/Mesh.CombineMeshes.html

                    SkinnedMeshRenderer smr = GetComponentInChildren<SkinnedMeshRenderer>();
                    if (smr != null)
                    {
                        // gltf-model
                        MeshCollider mcChild = smr.transform.parent.gameObject.AddComponent<MeshCollider>();
                        if (mcChild != null)
                        {
                            mcChild.sharedMesh = smr.sharedMesh;
                            ArenaClickListenerModel aclm = smr.transform.parent.gameObject.AddComponent<ArenaClickListenerModel>();
                            meshAvailable = true;
                        }
                    }
                }
            }
        }

        internal void OnMouseDown()
        {
            PublishMouseEvent("mousedown");
        }
        internal void OnMouseUp()
        {
            PublishMouseEvent("mouseup");
        }
        internal void OnMouseEnter()
        {
            PublishMouseEvent("mouseenter");
        }
        internal void OnMouseExit()
        {
            PublishMouseEvent("mouseleave");
        }

        internal void PublishMouseEvent(string eventType)
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            Debug.Log($"Local '{name}' ({eventType})!"); // TODO: remove debug log

            Vector3 camPosition = _camera.transform.localPosition;
            string camName = _arenaCam.camid;

            dynamic data = new ExpandoObject();
            data.clickPos = ArenaUnity.ToArenaPosition(camPosition);
            data.position = ArenaUnity.ToArenaPosition(hit.point);
            data.source = camName;
            string payload = JsonConvert.SerializeObject(data);

            ArenaClientScene.Instance.PublishEvent(name, eventType, data.source, payload);
        }
    }
}