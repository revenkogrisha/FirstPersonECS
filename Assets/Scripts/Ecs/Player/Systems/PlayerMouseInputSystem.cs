using Leopotam.Ecs;
using UnityEngine;

public class PlayerMouseInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, MouseLookComponent> _filter = null;

    private float _axisX;
    private float _axisY;

    public void Run()
    {
        GetAxis();
        ClampAxis();

        foreach(var i in _filter)
        {
            ref var lookComponent = ref _filter.Get2(i);

            lookComponent.Direction.x = _axisX;
            lookComponent.Direction.y = _axisY;
        }
    }

    private void GetAxis()
    {
        _axisX += Input.GetAxis("Mouse X");
        _axisY -= Input.GetAxis("Mouse Y");
    }

    private void ClampAxis()
    {
        _axisY = Mathf.Clamp(_axisY, -86, 75);
    }
}
