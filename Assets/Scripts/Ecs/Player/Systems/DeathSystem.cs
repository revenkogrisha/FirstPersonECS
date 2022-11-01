using Leopotam.Ecs;
using UnityEngine;

public class DeathSystem : IEcsRunSystem
{
    private readonly EcsFilter<ModelComponent, PerformDeathEvent> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);
            ref var modelComponent = ref _filter.Get1(i);

            //  Destroy
            var gameObject = modelComponent.ModelTransform.gameObject;
            Object.Destroy(gameObject);
            entity.Destroy();
        }
    }
}
