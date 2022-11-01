using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public sealed class EcsGameStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    #region MonoBehaviour

    private void Start()
    {
        // ������������� �������
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        // ����������� ��� ������ UniLeo
        _systems.ConvertScene();

        AddInjections();
        AddOneFrames();
        AddSystems();

        // ������������� ���� ������
        _systems.Init();
    }

    private void Update()
    {
        // ��������� ��� IEcsRunSystem �������
        _systems.Run();
    }

    private void OnDestroy()
    {
        // Clears all data
        if (_systems == null)
            return;

        _systems.Destroy();
        _systems = null;

        _world.Destroy();
        _world = null;
    }

    #endregion

    private void AddInjections()
    {
        //  _systems.Inject(...);
        //  ����� � �������� ������ �������� ���� ����� ������, readonly, = null
    }

    private void AddOneFrames()
    {
        _systems.
            OneFrame<PerformDeathEvent>().
            OneFrame<JumpEvent>().
            OneFrame<InitializeEntityRequest>();
    }

    private void AddSystems()
    {
        //  !��������� ���������� �������
        _systems.
            Add(new DeathSystem()).
            Add(new DebugSystem()).
            Add(new JumpBlockSystem()).
            Add(new PlayerJumpEventSender()).
            Add(new GravitySystem()).
            Add(new GroundCheckSystem()).
            Add(new CursorLockSystem()).
            Add(new PlayerInputSystem()).
            Add(new PlayerMouseInputSystem()).
            Add(new PlayerJumpSystem()).
            Add(new MovementSystem()).
            Add(new PlayerLookSystem());
    }
}
