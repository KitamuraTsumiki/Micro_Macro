using UnityEngine;
using UnityEngine.Events;

public class RandamizeEmittion : MonoBehaviour {

    [SerializeField]
    private GameObject block;
    [SerializeField]
    private UnityEvent OnBeforeEmittion;
    [SerializeField]
    private UnityEvent OnAfterEmittion;
    [SerializeField]
    private PlayerPositionController positionController;
    [SerializeField]
    private BlockVisualization blockVisualization;
    [SerializeField]
    private GameObject parentOfBlocks;

    private int nextBlockId = 0;

	public void Emit()
    {
        OnBeforeEmittion.Invoke();

        Vector3 emitPosition = new Vector3(Random.Range(-5f, 5f), transform.position.y, Random.Range(-5f, 5f));
        GameObject blockInstance = Instantiate(block, emitPosition, Quaternion.identity);
        float randomScale = Random.Range(0.5f, 8f); // stable
        //float randomScale = Random.Range(2f, 8f); // for set player inside of the block
        blockInstance.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        blockInstance.GetComponent<Collider>().enabled = true;

        if(parentOfBlocks != null)
        {
            blockInstance.transform.SetParent(parentOfBlocks.transform);
        }

        blockInstance.GetComponent<Block>().id = nextBlockId;
        nextBlockId++;

        positionController.newBlock = blockInstance;
        positionController.isMovable = true;
        blockInstance.GetComponent<BlockUnmovableSetter>().positionController = positionController;
        OnAfterEmittion.Invoke();

        if(blockVisualization == null) { return; }
        blockVisualization.blocks.Add(blockInstance.GetComponent<Block>());
        blockVisualization.AddLatestVisualizeBlock();
    }
}
