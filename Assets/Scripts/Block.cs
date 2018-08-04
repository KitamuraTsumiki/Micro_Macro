using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public int id { get; set; }

    private void Start()
    {
        Rigidbody rbd = GetComponent<Rigidbody>();
        if(rbd == null) { return; }
        rbd.mass = transform.lossyScale.x * transform.lossyScale.y * transform.lossyScale.z;
    }
}
