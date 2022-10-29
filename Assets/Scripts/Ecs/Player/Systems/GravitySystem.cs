using Leopotam.Ecs;
using UnityEngine;

public class GravitySystem : IEcsRunSystem
{
    private readonly EcsFilter<MoveableComponent, GravityComponent> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            var gravity = Physics.gravity;

            ref var moveableComponent = ref _filter.Get1(i);
            ref var gravityComponent = ref _filter.Get2(i);

            gravityComponent.Gravity = gravity;

            moveableComponent.Velocity.y += gravity.y * Time.deltaTime;
        }
    }
}
