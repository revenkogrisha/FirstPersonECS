using Leopotam.Ecs;
using UnityEngine;

public class DebugSystem : IEcsRunSystem
{
    private readonly EcsFilter<DebugMessageRequest> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);
            ref var debugRequest = ref _filter.Get1(i);
            ref var message = ref debugRequest.Message;

            Debug.Log(message);

            entity.Del<DebugMessageRequest>();
        }
    }
}
