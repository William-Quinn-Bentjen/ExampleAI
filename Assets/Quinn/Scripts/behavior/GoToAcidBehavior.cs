using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToAcidBehavior : Behavior {

    public GameObject acid;
    public override void doBehavior(BehaviorManager manager)
    {
        manager.agent.destination = acid.transform.position;
    }
    public override bool checkBehavior(BehaviorManager manager)
    {
        if (manager.health < 25)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void updateBehavior(BehaviorManager manager)
    {
        if (checkBehavior(manager))
        {
            GoToHealthPack attempt = manager.thingThatHoldsBehaviors.GetComponent<GoToHealthPack>();
            //attempt.HealthPack = GameObject.Find("HealthPack");
            manager.behaviors.Push(attempt);
            //push get healthpack
        }
    }
}
