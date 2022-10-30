using Leopotam.Ecs;
using UnityEngine;

public class PlayerJumpSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, GroundCheckComponent, JumpComponent, GravityComponent, JumpEvent>.
        Exclude<JumpBlockDuration> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);
            ref var moveableComponent = ref entity.Get<MoveableComponent>();
            ref var groundCheckComponent = ref _filter.Get2(i);
            ref var jumpComponent = ref _filter.Get3(i);
            ref var gravityComponent = ref _filter.Get4(i);

            ref var velocity = ref moveableComponent.Velocity;
            ref var force = ref jumpComponent.Force;
            ref var gravity = ref gravityComponent.Gravity.y;

            if (!groundCheckComponent.IsGrounded)
                continue;

            velocity.y = Mathf.Sqrt(force * -2 * gravity);

            entity.Get<JumpBlockDuration>().Timer = 3f;
        }
    }
}
