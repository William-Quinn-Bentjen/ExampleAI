using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour {
    public string Area;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //tells the agent to look for a new destination
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            if (other.GetComponent<AgentPather>().target.gameObject == gameObject)
            {
                Debug.Log("patrol point reached");
                List<PatrolPoint> destinations = GetPatrolPoints(Area);
                if (destinations.Count >= 1)
                {
                    int rand = Random.Range(0, destinations.Count);
                    other.GetComponent<AgentPather>().UpdateDestination(destinations[rand].gameObject);
                    Debug.Log("destination updated " + rand + " " + destinations.Count);
                }
            }
            else
            {
                Debug.Log("passed through a patrol point on the way to the destination");
            }

        }
    }

    //gives the agent a list of patrol points that have the same area string
    List<PatrolPoint> GetPatrolPoints(string area)
    {
        List<PatrolPoint> RetValue = new List<PatrolPoint>();
        foreach (GameObject point in GameObject.FindGameObjectsWithTag("PatrolPoint"))
        {
            //Debug.Log(point.name);
            if (point.GetComponent<PatrolPoint>().Area == area && point != gameObject)
            {
                Debug.Log("added " + point.name);
                RetValue.Add(point.GetComponent<PatrolPoint>());
            }
        }
        return RetValue;
    }
}
