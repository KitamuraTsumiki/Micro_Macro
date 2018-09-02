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
    public bool isMovable { get; set; }
    private Vector3 lastPlayerPos;
    private Vector3 moveDir;
    public bool isEMAInitialized { get; set; }
    
    private void Update () {
        MoveHorizontally();
        TrackBlockPosition();
        EnableBlockGeneration();
    }
    
    private void TrackBlockPosition()
    {
        if (newBlock == null) { return; }
        // ISSUE: when the player is set at the center of the block, the block tends to go backward
        Vector3 newPosition = new Vector3(newBlock.transform.position.x, newBlock.transform.position.y + newBlock.transform.lossyScale.y / 2, newBlock.transform.position.z);
        transform.position = newPosition;
    }
    
    private void MoveHorizontally()
    {
        if(newBlock == null || !isMovable) { return; }

        Vector3 currentPlayerPos = playerHead.position;
        Vector3 standPosDir = currentPlayerPos - standingGuide.position;
        standPosDir.y = 0f;
        Vector3 horizontalMoveDir = lastPlayerPos == Vector3.zero ? Vector3.zero : currentPlayerPos - lastPlayerPos;
        horizontalMoveDir.y = 0f;

        /*
        bool isNotMoving = horizontalMoveDir.magnitude < 0.00025f;
        bool isMovingAgainstStandPosDir = Vector3.Dot(standPosDir.normalized, horizontalMoveDir.normalized) < 0.5f;

        if (isNotMoving || isMovingAgainstStandPosDir)
        {
            // calculate exponential moving average of previous moving directions
            if (!isEMAInitialized) { moveDir = horizontalMoveDir; }

            float alpha = 0.9f;
            moveDir = alpha * horizontalMoveDir + (1f - alpha) * moveDir;
            Debug.Log("moveDir.magnitude with EMA: " + moveDir.magnitude + " isNotMoving: " + isNotMoving);
        }
            
        
        isEMAInitialized = true;
        */

        float speedAdjuster = 0.06f;
        moveDir = standPosDir * speedAdjuster;

        // apply calculated moving direction for the position of the block
        newBlock.transform.position += moveDir;
        
        // cache current position and moving direction for the next frame
        lastPlayerPos = currentPlayerPos;
        moveDir = horizontalMoveDir;
    }

    private void EnableBlockGeneration()
    {
        if (isMovable) { return; }
        blockGenerateButton.InitButtonState();
    }
}
