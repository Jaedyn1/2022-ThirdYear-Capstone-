using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    public Camera Cam;
    public float maximumLengeth;


    public Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        //Cam=GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;

            rayMouse = Cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumLengeth,LayerMask.GetMask("Default")))
            {
                RotateTowardsMouseDirection(gameObject, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint(maximumLengeth);
                RotateTowardsMouseDirection(gameObject, pos);
            }
        }
        else
        {
            Debug.Log("No Camera");
        }
    }
    void RotateTowardsMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;

        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}
