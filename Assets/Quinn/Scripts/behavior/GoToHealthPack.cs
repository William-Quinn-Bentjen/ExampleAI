using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHealthPack : Behavior {

    public GameObject HealthPack;
    public override void doBehavior(BehaviorManager manager)
    {
        manager.agent.destination = HealthPack.transform.position;
    }
    public override bool checkBehavior(BehaviorManager manager)
    {
        if (pathComplete(manager))
        {
            manager.health += 50;
            return true;
        }
        return false;
    }
    public override void updateBehavior(BehaviorManager manager)
    {
        if (checkBehavior(manager))
        {
            //push get healthpack
            manager.behaviors.Pop();
        }
    }
}
