using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class controls whole game system
/// </summary>
public class GameSystemManager : MonoBehaviour {

    [SerializeField]
    BlockVisualization visualizer;
    [SerializeField]
    DeleteInstances deleteInstances;
    [SerializeField]
    CanvasGroup playingCanvas;
    [SerializeField]
    CanvasGroup gameOverCanvas;
    [SerializeField]
    GroundScaler groundScaler;
    [SerializeField]
    PlayerPositionController player;

    private void Start()
    {
        InitCanvas();
    }

    private void InitCanvas()
    {
        playingCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void ResetGame()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        Debug.Log("blocks: " + blocks.Length);
        foreach(Block block in blocks)
        {
            Destroy(block.gameObject);
        }

        visualizer.ResetObjectsList();

        gameOverCanvas.gameObject.SetActive(false);
        playingCanvas.gameObject.SetActive(true);
        groundScaler.Reset();
        player.transform.position = Vector3.zero;
    }

    /// <summary>
    /// CheckGameOver is called in DeleteInstance class
    /// to check whether the most recent collided block is the block which the player tracks
    /// </summary>
    /// <param name="_fellBlock"></param>
    public void CheckGameOver(GameObject _fallenBlock)
    {
        if(player.newBlock != _fallenBlock) { return; }
        gameOverCanvas.gameObject.SetActive(true);
        playingCanvas.gameObject.SetActive(false);
    }
}
