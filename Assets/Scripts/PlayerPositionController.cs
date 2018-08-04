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
    private float forceMultiplier = 30f;
    private float speedAdjuster = 0.06f;
    public bool isMovable { get; set; }

    private void Start () {
		
	}
	
	private void Update () {
        MoveHorizontally();
        TrackBlockPosition();
        //MakeBlockStatic();
        Debug.Log("isMovable: " + isMovable);
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
        newBlock.transform.position += horizontalMoveDir * speedAdjuster;
    }

    private void MakeBlockStatic()
    {
        if (newBlock == null || !isMovable) { return; }
        Rigidbody rbd = newBlock.GetComponent<Rigidbody>();
        if(rbd.velocity.magnitude > 0f) { return; }
        isMovable = false;
    }
}
