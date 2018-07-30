using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerPositionController : MonoBehaviour {

    public GameObject newBlock;
    private float forceMultiplier = 5f;

	private void Start () {
		
	}
	
	private void Update () {
        TrackBlockPosition();
    }
    
    private void TrackBlockPosition()
    {
        if (newBlock == null) { return; }
        Vector3 newPosition = new Vector3(newBlock.transform.position.x, newBlock.transform.position.y + newBlock.transform.lossyScale.y / 2, newBlock.transform.position.z);
        transform.position = newPosition;
    }

    public void MoveBlockForward()
    {
        if (newBlock == null) { return; }
        Rigidbody rbd = newBlock.GetComponent<Rigidbody>();
        rbd.AddForce(transform.forward * forceMultiplier);
    }

    public void MoveBlockBackward()
    {
        if (newBlock == null) { return; }
        Rigidbody rbd = newBlock.GetComponent<Rigidbody>();
        rbd.AddForce(new Vector3(0, 0, -1) * forceMultiplier);
    }

    public void MoveBlockLeft()
    {
        if (newBlock == null) { return; }
        Rigidbody rbd = newBlock.GetComponent<Rigidbody>();
        rbd.AddForce(new Vector3(-1, 0, 0) * forceMultiplier);
    }

    public void MoveBlockRight()
    {
        if (newBlock == null) { return; }
        Rigidbody rbd = newBlock.GetComponent<Rigidbody>();
        rbd.AddForce(new Vector3(1, 0, 0) * forceMultiplier);
    }

    public void Teleport()
    {
        Vector3 newPosition = new Vector3(newBlock.transform.position.x, newBlock.transform.position.y + newBlock.transform.lossyScale.y/2, newBlock.transform.position.z);
        transform.position = newPosition;
    }
}
