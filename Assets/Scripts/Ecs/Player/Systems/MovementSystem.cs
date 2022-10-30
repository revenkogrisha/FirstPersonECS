using Leopotam.Ecs;
using UnityEngine;

public sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsFilter<ModelComponent, MoveableComponent, DirectionComponent> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            // Получение компонентов из фильтра
            ref var modelComponent = ref _filter.Get1(i);
            ref var moveableComponent = ref _filter.Get2(i);
            ref var directionComponent = ref _filter.Get3(i);

            // Получение полей из компонентов
            ref var direction = ref directionComponent.Direction;
            ref var transform = ref modelComponent.ModelTransform;
            ref var characterController = ref moveableComponent.CharacterController;
            ref var speed = ref moveableComponent.Speed;
            ref var velocity = ref moveableComponent.Velocity;

            // Логика передвижения
            var rawDirection = GetDirection(direction, transform);
            var movement = rawDirection * speed * Time.deltaTime;

            characterController.Move(movement);
            characterController.Move(velocity * Time.deltaTime);
        }
    }

    private Vector3 GetDirection(Vector3 direction, Transform transform) =>
        (transform.right * direction.x) + (transform.forward * direction.z);
}
