using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToNewBlock : MonoBehaviour {

    public GameObject newBlock;

	private void Start () {
		
	}
	
	private void Update () {
		
	}

    public void Teleport()
    {
        Vector3 newPosition = new Vector3(newBlock.transform.position.x, newBlock.transform.position.y + newBlock.transform.lossyScale.y/2, newBlock.transform.position.z);
        transform.position = newPosition;
        transform.SetParent(newBlock.transform, true);
    }
}
