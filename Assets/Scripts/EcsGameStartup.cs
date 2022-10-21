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
}
