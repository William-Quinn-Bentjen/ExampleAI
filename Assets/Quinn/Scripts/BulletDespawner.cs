using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : MonoBehaviour {
    Rigidbody rb;
    public float force;
    public float lifetime = 5;
    float timer = 0;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        //Debug.Log("I'm a bullet");
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("I updated " + timer);
        timer += Time.deltaTime;
		if (timer > lifetime)
        {
            //Debug.Log("despawned bullet");
            Destroy(gameObject);
        }
	}
}
