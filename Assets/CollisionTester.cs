using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTester : MonoBehaviour {
    private Rigidbody rb;
    Vector3 _myPriorPosition;
    Vector3 _myVelocityVector;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Ball")
        {
            Debug.Log("Before Ball vel: " + col.gameObject.GetComponent<Rigidbody>().velocity);
            Debug.Log("Before Racket vel: " + (_myVelocityVector));
            Debug.Log("test: " + (_myVelocityVector.x + col.gameObject.GetComponent<Rigidbody>().velocity.x));
            col.gameObject.GetComponent<Rigidbody>().velocity += _myVelocityVector;
            Debug.Log("After " + col.gameObject.GetComponent<Rigidbody>().velocity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " was triggered by " + other.gameObject.name);
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        _myVelocityVector = (transform.position - _myPriorPosition) / Time.deltaTime;
        _myPriorPosition = transform.position;
    }
}
