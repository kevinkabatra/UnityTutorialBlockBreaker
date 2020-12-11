using UnityEngine;
using UnityEngine.Events;

public class BlockExplosionEventHandler : MonoBehaviour
{
    Block thisBlock;

    // Start is called before the first frame update
    private void Start()
    {
        thisBlock = GetComponent<Block>();

        var explosionAction = new UnityAction(() => { DoExplosion(); });
        thisBlock.blockDestroyedEvent.AddListener(explosionAction);
    }

    private void DoExplosion()
    {
        var explosionPrefab = Resources.Load<GameObject>("Playspace/Explosion/Prefabs/BlockExplosion");
        var explosionInstance = Instantiate<GameObject>(explosionPrefab);
        explosionInstance.transform.position = gameObject.transform.position;
    }
}
