using UnityEngine;
using Voody.UniLeo;

public class EcsTriggerChecker : MonoBehaviour
{
    [SerializeField] private string _targetTag = "Player";
    [SerializeField] private string _debugMessage = "Player entered!";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(_targetTag))
            return;

        var world = WorldHandler.GetWorld();
        var messageRequest = new DebugMessageRequest()
        {
            Message = _debugMessage
        };

        world.SendRequest(messageRequest);
    }
}
