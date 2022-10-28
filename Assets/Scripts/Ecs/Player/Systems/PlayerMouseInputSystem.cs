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
        _axisX -= Input.GetAxis("Mouse Y");
        Debug.Log(_axisX);
        Debug.Log(_axisY);
    }

    private void ClampAxis()
    {
        //_axisX = Mathf.Clamp(_axisX, 1, 2);
        //_axisY = Mathf.Clamp(_axisY, 1, 2);
    }
}
