using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Spawner : Behavior {
    public GameObject target;
    public GameObject spawned;
    public bool hasObject = false;
    // Use this for initialization
    public override void doBehavior(BehaviorManager manager)
    {
        //logic
        if (hasObject)
        {
            manager.agent.destination = target.transform.position;
        }
        else
        {
            manager.agent.destination = spawned.transform.position;
        }
        
    }
    public override bool checkBehavior(BehaviorManager manager)
    {
        //Condition
        return pathComplete(manager);
    }
    public override void updateBehavior(BehaviorManager manager)
    {
        if (checkBehavior(manager))
        {
            //have object and at target
            if (hasObject)
            {
                //spawned.gameObject.
            }
            hasObject = !hasObject;
        }
    }
}
