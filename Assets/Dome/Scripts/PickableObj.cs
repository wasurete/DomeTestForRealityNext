using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObj : MonoBehaviour
{
    public GameObject selectedObj;
    public GameObject paretObj;
    public GameObject controller;
    public float grabTime = 0.25f;
    public bool menuItem = true;
    //RayShooter activate to focus ON/OFF
    private void Awake()
    {
        controller = GameObject.Find("Holder");
    }
    public void FocusOn()
    {
        selectedObj.SetActive(true);
    }
    public void FocusOff()
    {
        selectedObj.SetActive(false);
    }
    //Duplicate to been grabbed
    public void Grab()
    {
        GameObject item;
        if (menuItem)
        {
            menuItem = false;
            item = Instantiate(paretObj, transform.position, Quaternion.identity);
            menuItem = true;
        }
        else
        {
            item = this.transform.parent.gameObject;
        }
        item.transform.parent = controller.transform;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        iTween.MoveTo(item.gameObject, controller.transform.position, grabTime);
    }
}
