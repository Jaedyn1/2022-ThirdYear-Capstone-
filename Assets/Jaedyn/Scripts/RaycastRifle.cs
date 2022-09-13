using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastRifle : MonoBehaviour
{
    public float distance = 100f;
    public Camera FpsCam;
    public int Power;

    //show ray
    // public Vector3 fwd = Vector3.;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            shoot_forward();
        }
    }
    void shoot_forward()
    {
        //varibles
        RaycastHit hit;
        var fwd = transform.TransformDirection(Vector3.forward);
        var power = Power;

        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hit, distance))
        {
            //Debug.Log(hit.transform.name);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(fwd * power, hit.point);
            }
            Debug.DrawRay(transform.position, fwd * 10, Color.green);
        }


    }
}
