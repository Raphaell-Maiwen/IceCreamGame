using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    float distance = 10;
    public GameObject cone;
    public Transform newParent;
    public Rigidbody rb;
    public GameObject spillZone;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = objectPos;
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Cone")
        {
            Debug.Log("Cone hit");
            transform.SetParent(newParent.transform);
            rb.isKinematic = true;
        }

        if (col.gameObject.tag == "Spill")
        {
            Debug.Log("Whoops");
            transform.parent = null;
            rb.isKinematic = false;
        }

        if (col.gameObject.tag == "Floor")
        {
            Debug.Log("Floor hit");
        }

        //switch (col.gameObject.tag)
        {
            //case "Cone":
            //    Debug.Log("Cone hit");
            //    Place();
            //    break;
            //case "Floor":
            //    Debug.Log("Floor hit");
            //    break;

        }
    }

    //Invoked when a button is clicked.
    public void Place(Transform newParent)
    {
        //Sets "newParent" as the new parent of the player GameObject.
        cone.transform.SetParent(newParent);

        //Same as above, except this makes the player keep its local orientation rather than its global orientation.
        //cone.transform.SetParent(newParent, false);
    }

}
