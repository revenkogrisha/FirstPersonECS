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
}
