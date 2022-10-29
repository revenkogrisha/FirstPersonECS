using UnityEngine;
using Leopotam.Ecs;

public class PlayerLookSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag> _playerFilter = null;
    private readonly EcsFilter<ModelComponent, MouseLookComponent> _filter = null;

    private Quaternion _startRotation;

    public void Init()
    {
        foreach (var i in _playerFilter)
        {
            var entity = _filter.GetEntity(i);
            var modelComponent = entity.Get<ModelComponent>();
            var transform = modelComponent.ModelTransform;
            _startRotation = transform.rotation;
        }
    }

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var modelComponent = ref _filter.Get1(i);
            ref var mouseLookComponent = ref _filter.Get2(i);

            var axisX = mouseLookComponent.Direction.x;
            var axisY = mouseLookComponent.Direction.y;

            var sensitivity = mouseLookComponent.Sensitivity;
            var rotateX = 
                Quaternion.AngleAxis(axisX, Vector3.up * sensitivity * Time.deltaTime);
            var rotateY = 
                Quaternion.AngleAxis(axisY, Vector3.right * sensitivity * Time.deltaTime);

            modelComponent.ModelTransform.rotation = _startRotation * rotateX;
            mouseLookComponent.CameraTransform.rotation = modelComponent.ModelTransform.rotation * rotateY;
        }
    }
}
