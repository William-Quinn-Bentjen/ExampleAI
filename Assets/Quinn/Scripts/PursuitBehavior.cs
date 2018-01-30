using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehavior : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody targetRB;
    Vector3 desiredVelocity;
    Vector3 projectedPos;
    public float projectedDistance;
    public float speed;
    public Transform target;
    float distance;
    public float acceptableDistance;
    public float burstSpeed;
    float currentSpeed;
    // Use this for initialization
    void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();
        targetRB = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if (distance >acceptableDistance)
        {
            //pursuit logic
            currentSpeed = speed;
            projectedPos = target.position + (targetRB.velocity.normalized * projectedDistance);
            desiredVelocity = currentSpeed * (target.position - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);

            Debug.DrawLine(transform.position, projectedPos, Color.red);
            Debug.DrawLine(transform.position, target.position, Color.blue);
            Debug.DrawLine(transform.position, desiredVelocity * 10, Color.green);
        }
        else
        {
            currentSpeed = burstSpeed;
            desiredVelocity = currentSpeed * (target.position - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);
        }
        
    }
}

