using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BehaviorManager : MonoBehaviour, IDamageable {
    public float health;
    public void takeDamage(float damage)
    {
        health -= damage;
    }
    public void die()
    {

    }
    [HideInInspector]
    public Stack<Behavior> behaviors;
    [HideInInspector]
    public NavMeshAgent agent;
    //public GameObject walkTarget;
    //WalkTowardsBehavior walkTowards;
    public GameObject thingThatHoldsBehaviors;
	// Use this for initialization
	void Start () {
        //walkTowards = GetComponent<WalkTowardsBehavior>();
        agent = GetComponent<NavMeshAgent>();
        behaviors = new Stack<Behavior>();
        GoToAcidBehavior attempt = thingThatHoldsBehaviors.GetComponent<GoToAcidBehavior>();
        behaviors.Push(attempt);

        //WalkTowardsBehavior attemptPush = thingThatHoldsBehaviors.GetComponent<WalkTowardsBehavior>();
        //behaviors.Push(attemptPush);
        //behaviors.Push(walkTowards);
        //WalkTowardsBehavior newWalkBehavior = new WalkTowardsBehavior();
        //newWalkBehavior.target = walkTarget;
        //behaviors.Push(newWalkBehavior);
	}
	
	// Update is called once per frame
	void Update () {
		if (behaviors.Count > 0)
        {
            behaviors.Peek().doBehavior(this);
            behaviors.Peek().updateBehavior(this);
        }
        else
        {
            Debug.Log("I have no behaviors");
        }
	}
}
