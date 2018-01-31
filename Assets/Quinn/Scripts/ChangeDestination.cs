using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChangeDestination : MonoBehaviour
{
    public GameObject NewDestination;
    AgentPather Agent;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I collided");
        if (other.tag == "AI")
        {
            //Debug.Log("I destination updated");
            other.GetComponent<AgentPather>().UpdateDestination(NewDestination);
        }
    }
}