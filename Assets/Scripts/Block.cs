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
        float massAdjustVal = 15f;
        float minLength = 1f;
        float maxLength = 5f;
        rbd.mass = Mathf.Clamp(Mathf.InverseLerp(Mathf.Pow(minLength, 3), Mathf.Pow(maxLength, 3), mass) * massAdjustVal, 1f, 15f);
    }
}
