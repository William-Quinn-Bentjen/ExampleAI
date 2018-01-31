using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedState : MonoBehaviour {
    NavMeshAgent agent;
    SeekBehavior seek;
    FleeBehavior flee;
    float distance;
    public float MaxRange = 5;
    public float MinRange = 5;
    public GameObject target;
    public States currentState = States.WanderState;
    public GameObject bullet;
    // Use this for initialization
    void Start () {
        distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
        seek = gameObject.GetComponent<SeekBehavior>();
        flee = gameObject.GetComponent<FleeBehavior>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        updateState();
        if (currentState == States.SeekState)
        {
            agent.destination = seek.returnTargetPos();
        }
        else if (currentState == States.FleeState)
        {
            agent.destination = flee.returnFleeVector();
        }
        else
        {
            gameObject.transform.LookAt(target.transform);
            shoot();
        }
    }
    void updateState()
    {
        distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
        if (distance > MaxRange)
        {
            Debug.Log("out of range");
            currentState = States.SeekState;
        }
        else if (distance < MinRange)
        {
            Debug.Log("past minrange");
            currentState = States.FleeState;
        }
        else
        {
            Debug.Log("shooting");
            currentState = States.StartoverState;
        }
    }
    void shoot()
    {
        Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
    }
}
