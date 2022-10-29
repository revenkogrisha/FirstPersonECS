using System;
using UnityEngine;

[Serializable]
public struct MouseLookComponent
{
    public Transform CameraTransform;
    [Range(0, 3)] public float Sensitivity;
    [HideInInspector] public Vector3 Direction;
}
