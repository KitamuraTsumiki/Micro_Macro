using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVisualization : MonoBehaviour {
    [SerializeField]
    private float scale = 0.01f;
    [SerializeField]
    private GameObject visualizeBlock;

    public List<Block> blocks;
    private List<Block> visualizeBlocks;

    private void Start()
    {
        blocks = new List<Block>();
        visualizeBlocks = new List<Block>();
        transform.localScale = new Vector3(scale, scale, scale);
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
            visualizeBlocks[i].transform.localPosition = blocks[i].transform.localPosition;
            visualizeBlocks[i].transform.localRotation = blocks[i].transform.localRotation;
            visualizeBlocks[i].transform.localScale = blocks[i].transform.localScale;
        }
    }
}
