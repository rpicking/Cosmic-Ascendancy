﻿using UnityEngine;
using System.Collections;

namespace RTS
{
    public class RTSManager : MonoBehaviour
    {
        public static float ScrollSpeed { get { return 25; } }
        public static float RotateSpeed { get { return 100; } }
        public static float RotateAmount { get { return 10; } }
        public static int ScrollWidth { get { return 15; } }
        public static float MinCameraHeight { get { return 10; } }
        public static float MaxCameraHeight { get { return 40; } }
        private static Vector3 InvalidPosition = new Vector3(-99999, -99999, -99999);
        public static Vector3 invalidPosition { get { return invalidPosition; } }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}