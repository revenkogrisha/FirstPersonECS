using System;
using UnityEngine;

[Serializable]
public struct MoveableComponent
{
    public CharacterController CharacterController;
    public float Speed;
    public Vector3 Velocity;
}
