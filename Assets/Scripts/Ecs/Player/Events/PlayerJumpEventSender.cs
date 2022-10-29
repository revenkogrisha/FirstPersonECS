using Leopotam.Ecs;
using UnityEngine;

public class PlayerJumpEventSender : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, JumpComponent> _filter = null;

    public void Run()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        foreach (var i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);

            //  ����� Get ����� ����� � �������� ���������, � ������ ��� ����������.
            //  � ���� ������ - OneFrame ���������, �.�. �����
            entity.Get<JumpEvent>();
        }
    }
}
