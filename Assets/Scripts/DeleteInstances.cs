using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteInstances : MonoBehaviour {

    [SerializeField]
    private LayerMask m_layerMask;

    private List<GameObject> collideObjects;

    private void Start()
    {
        collideObjects = new List<GameObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collideObjects.Add(collision.gameObject);
    }

    public void Delete()
    {
        for(int i = 0; i < collideObjects.Count; i++)
        {
            if(collideObjects[i] == null) {
                collideObjects.RemoveAt(i);
                continue;
            }

            GameObject obj = collideObjects[i].gameObject;

            if (obj.CompareTag("environment")) { continue; }
            collideObjects.RemoveAt(i);
            Destroy(obj);
        }
    }
}
