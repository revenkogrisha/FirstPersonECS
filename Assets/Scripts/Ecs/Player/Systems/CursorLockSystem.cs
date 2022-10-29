using Leopotam.Ecs;
using UnityEngine;

public class CursorLockSystem : IEcsInitSystem
{
    public void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
