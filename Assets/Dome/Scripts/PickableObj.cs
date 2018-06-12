using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObj : MonoBehaviour
{
    public GameObject selectedObj;
    //public GameObject paretObj;
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
        if (selectedObj != null)
            selectedObj.SetActive(true);
    }
    public void FocusOff()
    {
        if (selectedObj != null)
            selectedObj.SetActive(false);
    }
    public void Grab()
    {
        GameObject item;
        //Duplicate and grab
        if (menuItem)
        {
            menuItem = false;
            item = Instantiate(this.gameObject, transform.position, transform.rotation);
            menuItem = true;
        }
        //Grab itself
        else
        {
            item = this.gameObject;
        }
        item.transform.parent = controller.transform;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        iTween.MoveTo(item.gameObject, controller.transform.position, grabTime);
    }
}