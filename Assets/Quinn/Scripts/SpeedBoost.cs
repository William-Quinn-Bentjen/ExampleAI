using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpeedBoost : MonoBehaviour {
    public float NewSpeed = 1;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("I collided");
        if (other.tag == "AI")
        {
            Debug.Log("speed updated");
            other.GetComponent<NavMeshAgent>().speed = NewSpeed;
        }
    }
}
