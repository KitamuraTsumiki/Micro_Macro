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
        float massAdjustMul = 15f;
        rbd.mass = Mathf.Clamp(Mathf.Lerp(mass, 0f, 125f) * massAdjustMul, 2f, 15f);
    }
}
