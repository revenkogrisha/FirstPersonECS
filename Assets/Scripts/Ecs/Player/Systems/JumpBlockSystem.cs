using Leopotam.Ecs;
using UnityEngine;

public class JumpBlockSystem : IEcsRunSystem
{
    private readonly EcsFilter<JumpBlockDuration> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var jumpBlockDuration = ref _filter.Get1(i);
            ref var entity = ref _filter.GetEntity(i);

            ref var timer = ref jumpBlockDuration.Timer;

            timer -= Time.deltaTime;

            if (timer <= 0)
                entity.Del<JumpBlockDuration>();
        }
    }
}
