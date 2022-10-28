using System;
using UnityEngine;

[Serializable]
public struct MouseLookComponent
{
    public Transform CameraTransform;
    public Vector3 Direction;
    public float Sensitivity;
}
