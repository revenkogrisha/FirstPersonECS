using UnityEngine;
using UnityEngine;
using Leopotam.Ecs;

public class PlayerLookSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, ModelComponent, MouseLookComponent> _filter = null;

    private Quaternion _startRotation;

    public void Init()
    {
        var entity = _filter.GetEntity(0);
        var modelComponent = entity.Get<ModelComponent>();
        var transform = modelComponent.ModelTransform;
        _startRotation = transform.rotation;
    }

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var modelComponent = ref _filter.Get2(i);
            ref var mouseLookComponent = ref _filter.Get3(i);

            var axisX = mouseLookComponent.Direction.x;
            var axisY = mouseLookComponent.Direction.y;
        }
    }
}
