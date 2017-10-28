using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollision : MonoBehaviour {
    private Rigidbody rb;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Table")
        {
            rb.AddForce(0, 2, 0);
        }
    }

        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rb = GetComponent<Rigidbody>();
    }
}
