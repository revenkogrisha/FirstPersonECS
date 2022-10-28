using Leopotam.Ecs;
using UnityEngine;

public sealed class PlayerInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, DirectionComponent> _filter = null;

    private float _moveX;
    private float _moveZ;

    public void Run()
    {
        SetDirection();

        foreach (var i in _filter)
        {
            ref var directionComponent = ref _filter.Get2(i);
            ref var direction = ref directionComponent.Direction;

            direction.x = _moveX;
            direction.z = _moveZ;
        }
    }

    private void SetDirection()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");
    }
}
