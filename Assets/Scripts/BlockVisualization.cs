using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVisualization : MonoBehaviour {
    [SerializeField]
    private float scale = 0.01f;
    [SerializeField]
    private GameObject[] environmentObjects;
    [SerializeField]
    private Material environmentVisualizeMaterial;
    [SerializeField]
    private GameObject visualizeBlock;

    public List<Block> blocks;
    private List<Block> visualizeBlocks;

    private void Start()
    {
        blocks = new List<Block>();
        visualizeBlocks = new List<Block>();
        transform.localScale = new Vector3(scale, scale, scale);
        InitEnvironmentVisualization();
    }

    private void InitEnvironmentVisualization()
    {
        for (int i = 0; i < environmentObjects.Length; i++)
        {
            GameObject envObjVisualization = Instantiate(environmentObjects[i], environmentObjects[i].transform.position, Quaternion.identity);
            envObjVisualization.transform.SetParent(transform);
            envObjVisualization.transform.localPosition = environmentObjects[i].transform.localPosition;
            envObjVisualization.transform.localRotation = environmentObjects[i].transform.localRotation;
            envObjVisualization.transform.localScale = environmentObjects[i].transform.localScale;

            envObjVisualization.GetComponent<Renderer>().material = environmentVisualizeMaterial;
        }
    }

    private void Update () {
        convertTransform();
    }

    public void AddLatestVisualizeBlock()
    {
        Block lastBlock = blocks[blocks.Count-1];

        GameObject newVisualizeBlock = Instantiate(visualizeBlock);
        newVisualizeBlock.transform.SetParent(transform);
        Block newVisualizeBlockComponent = newVisualizeBlock.GetComponent<Block>();
        newVisualizeBlockComponent.id = lastBlock.id;
        newVisualizeBlock.transform.localPosition = lastBlock.transform.localPosition;
        newVisualizeBlock.transform.localRotation = lastBlock.transform.localRotation;
        newVisualizeBlock.transform.localScale = lastBlock.transform.localScale;

        visualizeBlocks.Add(newVisualizeBlockComponent);
    }

    private void convertTransform()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            if(blocks[i] == null) {
                blocks.RemoveAt(i);

                GameObject destroyObj = visualizeBlocks[i].gameObject;
                visualizeBlocks.RemoveAt(i);
                Destroy(destroyObj);
                continue;
        }

            visualizeBlocks[i].transform.localPosition = blocks[i].transform.localPosition;
            visualizeBlocks[i].transform.localRotation = blocks[i].transform.localRotation;
            visualizeBlocks[i].transform.localScale = blocks[i].transform.localScale;
        }
    }
}
