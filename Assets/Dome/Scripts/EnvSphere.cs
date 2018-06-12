using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvSphere : MonoBehaviour {
    public Material skyBoxMaterial;
    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //checking to collide with the DomeCover
        if (other.gameObject.name == "DomeCover")
        {
            RenderSettings.skybox = skyBoxMaterial;
            Destroy(this.gameObject);
        }
    }
}