using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenEnergy : MonoBehaviour {
    public float regenAmount = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        EnergyWander temp = other.GetComponent<EnergyWander>();
        if (temp!= null)
        {
            temp.SetEnergy(temp.Energy + regenAmount);
        }
    }
}
