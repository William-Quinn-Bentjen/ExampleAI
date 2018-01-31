using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnergyWander : MonoBehaviour
{
    NavMeshAgent agent;
    WanderBehavior wander;
    SeekBehavior seek;
    FleeBehavior flee;
    public States currentState = States.WanderState;
    public float Energy;
    public float maxEnergy = 100;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wander = GetComponent<WanderBehavior>();
        seek = GetComponent<SeekBehavior>();
        flee = GetComponent<FleeBehavior>();
        Energy = maxEnergy;
    }
    void switchStates()
    {
        Energy -= 1;
        if (Energy <= 0)
        {
            currentState = States.SeekState;
        }
        else
        {
            currentState = States.WanderState;
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
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
    public void SetEnergy(float value)
    {
        Energy = value;
        if (Energy > maxEnergy)
        {
            Energy = maxEnergy;
        }
    }
}
