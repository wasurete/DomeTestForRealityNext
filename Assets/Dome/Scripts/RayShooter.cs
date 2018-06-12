using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RayShooter : MonoBehaviour
{
    public float distance = 4;
    DrawerSwitch dSwitch;   //to keep DrawerSwitch out of switch objects
    PickableObj pObj;       //to keep PickableObj out of pickable objects
    GameObject obj;         //object been hit by Raycast
    public GameObject holder;
    public bool isHolding;
    public LayerMask rayLayermask;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.up * distance);
        RaycastHit hit = new RaycastHit();
        Debug.DrawRay(transform.position, transform.up * distance);
        //Fire1 down
        if (Input.GetButton("Fire1"))
        {
            GetComponent<LineRenderer>().enabled = true;
            if (Physics.Raycast(ray, out hit, distance,rayLayermask))
            {
                //checking if ray is hitting a new object
                if (obj != null && obj != hit.collider.gameObject)
                {
                    if (obj.tag == "ButtonR" || obj.tag == "buttonL") //unselect buttons
                    {
                        if (dSwitch != null)
                            dSwitch.Unselect();
                    }
                    if (obj.tag == "Pickable")  //focus off pickable object
                    {
                        if (pObj != null)
                        {
                            pObj.FocusOff();
                            pObj = null;
                        }
                    }
                }
                //updating the current object been hit by the ray
                obj = hit.collider.gameObject;
                DrawerSwitch drawerSwitch = obj.GetComponent<DrawerSwitch>();
                //if it's the button
                if (obj.tag == "ButtonR" || obj.tag == "ButtonL")
                {
                    if (obj.tag == "ButtonR")   //buttonR
                    {
                        drawerSwitch.TurnRight();
                        dSwitch = drawerSwitch;
                    }
                    if (obj.tag == "ButtonL")   //buttonL
                    {
                        drawerSwitch.TurnLeft();
                        dSwitch = drawerSwitch;
                    }
                }
                // if it's not the button and DrawerSwitch is set
                else if (dSwitch != null)
                {
                    dSwitch.Unselect();
                }
                //if ray is hitting pickable
                if (obj.tag == "Pickable")
                {
                    PickableObj pickableObj = obj.GetComponent<PickableObj>();
                    if (pickableObj == null)
                    {
                        pickableObj = obj.GetComponent<PickableObj>();
                    }
                    pObj = pickableObj;
                    pickableObj.FocusOn();
                }
                //tag is not pickable and PickableObj is set (different object) : this may not needed
                else if (pObj != null)
                {
                    pObj.FocusOff();
                }
            }
            //Raycast is out and unselect
            else
            {
                if (dSwitch != null)
                    dSwitch.Unselect();
                if (pObj != null)
                {
                    pObj.FocusOff();
                    pObj = null;
                }
            }
        }
        //Fire1 up
        if (Input.GetButtonUp("Fire1"))
        {
            GetComponent<LineRenderer>().enabled = false;
            if (dSwitch != null)
                dSwitch.Unselect();
            if (pObj != null)
            {
                pObj.FocusOff();
                if (!isHolding)
                {
                    pObj.Grab();
                    pObj = null;
                    isHolding = true;
                }
            }
        }
        if (isHolding)
        {
            //Fire2 down
            if (Input.GetButton("Fire2"))
            {
                foreach (Transform child in holder.transform)
                {
                    child.GetComponent<Rigidbody>().isKinematic = false;
                    child.GetComponent<Rigidbody>().useGravity = true;
                    child.transform.parent = null;
                }
            }
            //Fire2 up
            if (Input.GetButtonUp("Fire2"))
            {
                Debug.Log("release");
                isHolding = false;
            }
        }
        if (holder.transform.childCount == 0)
        {
            isHolding = false;
        }
    }
}
