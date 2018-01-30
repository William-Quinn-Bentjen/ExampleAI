using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : MonoBehaviour {
    //   public float wanderDistance;
    //   public float wanderRadius;
    //   public float jitterAmount;
    //   //prev wander target
    //   Transform prev;

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {
    //       Vector3 target = Random.onUnitSphere;
    //       tar
    //}
    public float speed;
    public float raduis;
    public float jitter;
    public float distance;
    public Vector3 target;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        target = Vector3.zero;
        target = Random.insideUnitCircle.normalized * raduis;
        target = (Vector2)target + Random.insideUnitCircle * jitter;

        target.z = target.y;
        target += transform.position;
        target += transform.forward * distance;
        target.y = 0;

        Vector3 dir = (target - transform.position).normalized;
        Vector3 desiredVelocity = dir * speed;
        rb.AddForce(desiredVelocity - rb.velocity);
        transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Debug.DrawLine(transform.position, transform.position + (transform.forward * distance), Color.green);
        Debug.DrawLine(transform.position + (transform.forward * distance), target, Color.black);
    }
}
