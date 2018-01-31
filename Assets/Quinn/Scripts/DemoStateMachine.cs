using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum States
{
    WanderState,   //0
    SeekState,   //1
    FleeState,     //2
    StartoverState //3
    //startoverstate = 4
}

public class DemoStateMachine : MonoBehaviour {
    NavMeshAgent agent;
    WanderBehavior wander;
    SeekBehavior seek;
    FleeBehavior flee;
    public States currentState;
    public float transitionTime;
    float timer;

	// Use this for initialization
	void Start () {
        timer = transitionTime;
        agent = GetComponent<NavMeshAgent>();
        wander = GetComponent<WanderBehavior>();
        seek = GetComponent<SeekBehavior>();
        flee = GetComponent<FleeBehavior>();

	}
    void switchStates()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            currentState++;
            if (currentState == States.StartoverState)
            {
                currentState = States.WanderState;
            }
            timer = transitionTime;
        }
    }	
	// Update is called once per frame
	void Update () {
        switch(currentState)
        {
            case States.WanderState:
                agent.destination = wander.returnWanderPoints();
                break;
            case States.FleeState:
                agent.destination = flee.returnFleeVector();
                break;
            case States.SeekState:
                agent.destination = seek.returnTargetPos();
                break;
            case States.StartoverState:
                Debug.Log("stuck in startover state");
                break;
        }
        switchStates();
	}
}
