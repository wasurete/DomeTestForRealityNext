using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float mov=0.02f, rot=1f;
    Vector3 thrust;
    public Camera camera;
    void Update () {
        if (!Input.GetButton("Jump"))
        {
            camera.transform.eulerAngles += new Vector3(-Input.GetAxis("Vertical") * rot, 0, 0);
            transform.eulerAngles += new Vector3(0, Input.GetAxis("Horizontal") * rot, 0);
        }
        else
        {
            thrust = new Vector3(0, 0, Input.GetAxis("Vertical")*mov);
            transform.Translate(thrust);
            transform.Translate(Input.GetAxis("Horizontal")*mov, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Down");
            //transform.position -= new Vector3(0, 1.2f, 0);
            iTween.MoveAdd(this.gameObject, new Vector3(0, -1f, 0), 0.2f);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            iTween.MoveAdd(this.gameObject, new Vector3(0, 1f, 0), 0.4f);
        }
    }
}
