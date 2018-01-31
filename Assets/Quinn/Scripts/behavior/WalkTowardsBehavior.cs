using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowardsBehavior : Behavior {
    public GameObject target;
    public bool goToSecondTarget = false;
    public override void doBehavior(BehaviorManager manager)
    {
        //logic
        manager.agent.destination = target.transform.position;
    }
    public override bool checkBehavior(BehaviorManager manager)
    {
        //Condition
        return pathComplete(manager);
    }
    public override void updateBehavior(BehaviorManager manager)
    {
        //if my path is complete pop the behavior 
        if (pathComplete(manager))
        {
            manager.behaviors.Pop();
            WalkTowardsBehavior newWalk = manager.thingThatHoldsBehaviors.GetComponent<WalkTowardsBehavior>();
            //if (goToSecondTarget)
            //{
            //    newWalk.target = manager.target2;
            //}
            //else
            //{
            //    newWalk.target = manager.target1;
            //}
            goToSecondTarget = !goToSecondTarget;
            manager.behaviors.Push(newWalk);
        }
    }
}
