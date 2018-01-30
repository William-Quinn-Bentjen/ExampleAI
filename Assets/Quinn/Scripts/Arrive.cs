using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour {
    public Transform Destination;
    public float slowDistance;
    public float speed;
    public float arrivedTolerence;
    [Tooltip("leave 1 for no change")]
    public float slowModifier = 1;
    Rigidbody rb;
    Vector3 desiredVelocity;
    public bool StopVelocityOnArrival;
    public bool arrived = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!arrived)
        {
            float distance = Vector3.Distance(transform.position, Destination.position);
            if (distance <= slowDistance)
            {
                float currentSpeed = speed * (distance / slowDistance);
                desiredVelocity = currentSpeed * (Destination.position - transform.position).normalized;
                if (distance / slowDistance < arrivedTolerence)
                {
                    if (StopVelocityOnArrival)
                    {
                        rb.velocity = new Vector3(0, 0, 0);
                    }
                    Debug.Log("Arrived");
                    arrived = true;
                }
                Debug.Log("Slowing");
                rb.AddForce(desiredVelocity - rb.velocity * slowModifier);
            }
            else
            {
                Debug.Log("traveling");
                desiredVelocity = speed * (Destination.position - transform.position).normalized;
                rb.AddForce(desiredVelocity - rb.velocity);
            }
        }
        //kobey
        //ignore y
        //Vector3 targetOffset = Destination.position - transform.position;
        //float dist = Vector3.Distance(transform.position, Destination.position);
        //float rampedSpeed = speed * (targetOffset.magnitude / dist);
        //float clippedSpeed = Mathf.Min(rampedSpeed, speed);
        //Vector3 desiredVelocty2 = (clippedSpeed / targetOffset.magnitude) * targetOffset;
        //rb.velocity = desiredVelocty2;
        //
	}
}
