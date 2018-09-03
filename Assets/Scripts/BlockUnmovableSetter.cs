using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockUnmovableSetter : MonoBehaviour {

    public PlayerPositionController positionController;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == positionController.newBlock)
        {
            positionController.isMovable = false;
        }
    }
}
