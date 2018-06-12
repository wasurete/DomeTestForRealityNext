using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBin : MonoBehaviour {
    public ParticleSystem particle;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Pickable")
        {
            Destroy(collision.gameObject);
            Instantiate(particle, collision.transform.position, Quaternion.identity);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
