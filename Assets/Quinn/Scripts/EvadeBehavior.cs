using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeBehavior : MonoBehaviour
{
    Rigidbody rb;
    Vector3 desiredVelocity;

    public float speed;
    public float burstSpeed;
    float currentSpeed;
    float distance;
    public float unacceptableDistance;
    public Transform target;


    // Use this for initialization
    void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if (distance <= unacceptableDistance)
        {
            currentSpeed = burstSpeed;
            desiredVelocity = -currentSpeed * (target.position - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);
        }
        else
        {
            currentSpeed = speed;
            desiredVelocity = -currentSpeed * (target.position - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);
        }
    }
}
