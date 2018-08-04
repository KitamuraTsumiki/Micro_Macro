using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class controls the position of a block which is tracked by the player's camera rig
/// </summary>
public class PlayerPositionController : MonoBehaviour {

    public GameObject newBlock;
    [SerializeField]
    private Transform playerHead;
    [SerializeField]
    private Transform standingGuide;
    [SerializeField]
    private VRButton blockGenerateButton;
    private float forceMultiplier = 30f;
    private float speedAdjuster = 0.06f;
    public bool isMovable { get; set; }

    private void Update () {
        MoveHorizontally();
        TrackBlockPosition();
        EnableBlockGeneration();
    }
    
    private void TrackBlockPosition()
    {
        if (newBlock == null) { return; }
        Vector3 newPosition = new Vector3(newBlock.transform.position.x, newBlock.transform.position.y + newBlock.transform.lossyScale.y / 2, newBlock.transform.position.z);
        transform.position = newPosition;
    }
    
    private void MoveHorizontally()
    {
        if(newBlock == null || !isMovable) { return; }

        Vector3 currentPlayerPos = playerHead.position;
        Vector3 horizontalMoveDir = currentPlayerPos - standingGuide.position;
        horizontalMoveDir.y = 0f;
        Debug.Log("vel: " + horizontalMoveDir.magnitude);
        newBlock.GetComponent<Rigidbody>().AddForce(horizontalMoveDir * forceMultiplier);
        newBlock.transform.position += horizontalMoveDir * speedAdjuster;
    }

    private void EnableBlockGeneration()
    {
        if (isMovable) { return; }
        blockGenerateButton.InitButtonState();
    }
}
