using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSet : MonoBehaviour {
    public float rotateUnit = 22.5f;
    static public float rotUnit;
    public GameObject[] pickableItems;
    GameObject drawerParent;
    GameObject itemPosition;
    GameObject[] itemPositions;
    public float unitAngle= 22.5f;
    float i = 0;
    void Start () {
        drawerParent = transform.Find("Drawer").gameObject;
        itemPosition = transform.Find("Drawer/ItemPosition").gameObject;
        //unitAngle = 360 / pickableItems.Length;
        //pupulate all pickableItems
        foreach (GameObject item in pickableItems)
        {
            GameObject obj = Instantiate(itemPosition, transform);
            obj.transform.parent = drawerParent.transform;
            obj.transform.localPosition = Vector3.zero;
            Instantiate(item, obj.transform.Find("Position"));
            item.transform.localPosition = Vector3.zero;
            item.transform.eulerAngles += new Vector3(0, 60, 0);
            obj.transform.eulerAngles += new Vector3(0, unitAngle * i, 0);
            i++;
            //item.transform.position = obj.transform.Find("Position").position;
        }
    }
	
	// Update is called once per frame
	void Update () {
        rotUnit = rotateUnit;
	}
}
