using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public int id { get; set; }

    private void Start()
    {
        Rigidbody rbd = GetComponent<Rigidbody>();
        if(rbd == null) { return; }
        float mass = transform.lossyScale.x * transform.lossyScale.y * transform.lossyScale.z;
        float massAdjustVal = 0.5f;
        rbd.mass = Mathf.Clamp(Mathf.Lerp(64f, 512f, mass) + massAdjustVal, 2f, 15f);
    }
}
