using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScaler : MonoBehaviour {

    [SerializeField]
    private float scaleFactor = 0.85f;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void ScaleDown () {
        transform.localScale = new Vector3(transform.localScale.x * scaleFactor, transform.localScale.y, transform.localScale.z * scaleFactor);
	}
	
	public void Reset () {
        transform.localScale = originalScale;
	}
}
