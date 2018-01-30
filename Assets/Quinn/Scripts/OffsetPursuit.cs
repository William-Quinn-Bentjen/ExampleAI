using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursuit : MonoBehaviour {
    public Transform leader;
    Vector3 leaderOffset;
    public float speed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leaderOffset = transform.position - leader.transform.position;
    }
    void ArriveAtPoint(Vector3 targetPos)
    {
        Vector3 targetOnOurY = targetPos;
        targetOnOurY.y = transform.position.y;
        Vector3 targetOffset = targetOnOurY - transform.position;
        float dist = Vector3.Distance(transform.position, targetPos);
        float rampedSpeed = speed * (targetOffset.magnitude / dist);
        float clippedSpeed = Mathf.Min(rampedSpeed, speed);
        if(targetOffset.magnitude != 0)
        {
            Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
            rb.velocity = desiredVelocity;
        }
    }
    void Update()
    {
        //leaderOffset = transform.position - leader.position;
        ArriveAtPoint(leader.transform.position + leaderOffset);
        Debug.DrawLine(transform.position, transform.position + leaderOffset, Color.red);
    }
    //   public Transform Leader;
    //   public Vector3 offset;
    //   public float speed;
    //   Transform destination;
    //// Use this for initialization
    //void Start () {
    //       destination = Leader;
    //       destination.position += offset;
    //       destination.SetParent(Leader);
    //}

    //// Update is called once per frame
    //void Update () {
    //       ArriveAtPoint(destination.position);
    //       Debug.Log(destination.position);
    //       Debug.DrawLine(transform.position, destination.position);
    //   }
    //   void ArriveAtPoint(Vector3 targetPos)
    //   {
    //       Vector3 targetOnOurY = targetPos;
    //       targetOnOurY.y = transform.position.y;
    //       Vector3 targetOffset = targetOnOurY - transform.position;
    //       float dist = Vector3.Distance(transform.position, targetPos);
    //       float rampedSpeed = speed * (targetOffset.magnitude / dist);
    //       float clippedSpeed = Mathf.Min(rampedSpeed, speed);
    //       Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
    //       GetComponent<Rigidbody>().AddForce(desiredVelocity - GetComponent<Rigidbody>().velocity);
    //       //GetComponent<Rigidbody>().velocity = desiredVelocity;
    //   }
}
