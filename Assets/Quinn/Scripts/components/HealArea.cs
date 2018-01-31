using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealArea : MonoBehaviour {
    public float HealAmount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Health>() != null)
        {
            other.GetComponent<Health>().IncrementHP(HealAmount);
        }
    }
}
