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
        // Инициализация классов
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        // Конвертация для работы UniLeo
        _systems.ConvertScene();

        AddInjections();
        AddOneFrames();
        AddSystems();

        // Инициализация всех систем
        _systems.Init();
    }

    private void Update()
    {
        // Запускает все IEcsRunSystem системы
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

    }

    private void AddOneFrames()
    {
        _systems.OneFrame<JumpEvent>();
    }

    private void AddSystems()
    {
        //  !Соблюдать правильный порядок
        _systems.
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
