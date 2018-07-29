using UnityEngine;
using UnityEngine.Events;

public class RandamizeEmittion : MonoBehaviour {

    [SerializeField]
    private GameObject block;
    [SerializeField]
    private UnityEvent OnEmittion;
    [SerializeField]
    private TeleportToNewBlock teleport;

	public void Emit()
    {
        Vector3 emitPosition = new Vector3(Random.Range(-5f, 5f), transform.position.y, Random.Range(-5f, 5f));
        GameObject blockInstance = Instantiate(block, emitPosition, Quaternion.identity);
        float randomScale = Random.Range(1f, 5f);
        blockInstance.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        teleport.newBlock = blockInstance;
        OnEmittion.Invoke();
    }
}
