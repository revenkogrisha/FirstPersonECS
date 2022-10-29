using System;
using UnityEngine;

[Serializable]
public struct GroundCheckComponent
{
    public LayerMask GroundMask;
    public Transform GroundCheckSphere;
    public float GroundDistance;
    [HideInInspector] public bool IsGrounded;
}
