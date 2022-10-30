using Leopotam.Ecs;
using UnityEngine;

public class GroundCheckSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, GroundCheckComponent> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var groundCheckComponent = ref _filter.Get2(i);

            groundCheckComponent.IsGrounded = Physics.CheckSphere(
                groundCheckComponent.GroundCheckSphere.position,
                groundCheckComponent.GroundDistance,
                groundCheckComponent.GroundMask);
            Debug.Log(groundCheckComponent.IsGrounded);
        }
    }
}
