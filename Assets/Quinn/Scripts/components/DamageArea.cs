using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public float DamageAmount;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
        var attempt = other.GetComponent<IDamageable>();
        if (attempt != null)
        {
            Debug.Log("damaged");
            attempt.takeDamage(DamageAmount);
        }
    }
}

