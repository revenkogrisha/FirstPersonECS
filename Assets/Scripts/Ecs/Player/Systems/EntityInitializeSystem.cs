using Leopotam.Ecs;

public class EntityInitializeSystem : IEcsRunSystem
{
    private readonly EcsFilter<InitializeEntityRequest> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);
            ref var initializeRequest = ref _filter.Get1(i);
            ref var entityReference = ref initializeRequest.Reference;

            entityReference.Entity = entity;
        }
    }
}
