using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteInstances : MonoBehaviour {

    [SerializeField]
    private LayerMask m_layerMask;

	public void Delete()
    {
        Vector3 deleteAreaScale = new Vector3(transform.lossyScale.x / 2, transform.lossyScale.y / 2, transform.lossyScale.z / 2);
        Collider[] colliders = Physics.OverlapBox(transform.position, deleteAreaScale, Quaternion.identity, m_layerMask);

        foreach(Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("environment")) { continue; }
            Destroy(collider.gameObject);
        }
    }
}
