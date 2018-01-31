using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour {
    public Transform home;
    public Transform work;
    public Transform task1Location;
    public Transform task2Location;
    public States currentState = States.SeekState;
    public bool reachedWork;
    public bool task1;
    public bool task2;
    Rigidbody rb;
    NavMeshAgent agent;
    SeekBehavior seek;
    FleeBehavior flee;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        seek = GetComponent<SeekBehavior>();
        flee = GetComponent<FleeBehavior>();
        }
	
	// Update is called once per frame
	void Update () {
        updateState();
		switch(currentState)
        {
            case States.SeekState:
                agent.destination = seek.returnTargetPos();
                break;
            case States.StartoverState:
                agent.destination = home.position; 
                break;
            case States.FleeState:
                agent.destination = flee.returnFleeVector();
                break;
        }
        Debug.DrawLine(agent.destination, transform.position, Color.red);
	}
    void updateState()
    {
        if (!agent.pathPending)
        {
            if (agent.stoppingDistance >= agent.remainingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    //reached dest new task
                    if (agent.destination == work.position && reachedWork == false)
                    {
                        reachedWork = true;
                    }
                    else if (agent.destination == home.position)
                    {
                        reachedWork = false;
                        task1 = false;
                        task2 = false;
                    }
                    else if (task2 == false && task1 == false)
                    {
                        task1 = true;
                    }
                    else if (task2 == false && task1 == true)
                    {
                        task2 = true;
                    }
                }
            }
        }
        if (reachedWork != true)
        {
            currentState = States.SeekState;
            seek.target = work;
        }
        else if (task1 == false)
        {
            currentState = States.SeekState;
            seek.target = task1Location;
        }
        else if (task2 == false)
        {
            currentState = States.SeekState;
            seek.target = task2Location;
        }
        else if (task1 == true && task2 == true)
        {
            currentState = States.SeekState;
            seek.target = home;
        }
    }
}
