using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerSwitch : MonoBehaviour {
    //spin speed in sec
    public float speedS;
    //spin angle per touch
    public float unitAngle = 45f;
    //drawer object to spin
    public GameObject drawer;
    //Button object to activate when ray is hit (outlined object)
    public GameObject selection;
    void Start()
    {
        selection.SetActive(false);
    }
    //RayShooter activates to turn Right/Left/Unselect
    public void TurnRight()
    {
        selection.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        iTween.RotateAdd(drawer.gameObject, new Vector3(0, -unitAngle, 0), speedS);
    }
    public void TurnLeft()
    {
        selection.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        iTween.RotateAdd(drawer.gameObject, new Vector3(0, unitAngle, 0), speedS);
    }
    public void Unselect()
    {
        GetComponent<MeshRenderer>().enabled = true;
        selection.SetActive(false);
    }
}