using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerPositionController : MonoBehaviour {

    public GameObject newBlock;

	private void Start () {
		
	}
	
	private void Update () {
        ControlBlockPosition();
        TrackBlockPosition();
    }
    
    private void TrackBlockPosition()
    {
        if (newBlock == null) { return; }
        Vector3 newPosition = new Vector3(newBlock.transform.position.x, newBlock.transform.position.y + newBlock.transform.lossyScale.y / 2, newBlock.transform.position.z);
        transform.position = newPosition;
    }

    private void ControlBlockPosition()
    {

    }

    public void Teleport()
    {
        Vector3 newPosition = new Vector3(newBlock.transform.position.x, newBlock.transform.position.y + newBlock.transform.lossyScale.y/2, newBlock.transform.position.z);
        transform.position = newPosition;
    }
}
