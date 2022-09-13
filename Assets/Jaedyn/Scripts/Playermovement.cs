using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed = 10f, jumpPower = 10f;


    Rigidbody body;
    [Header ("Ground Check")]
    private bool grounded;
    public float playerheight;
    public float groundeddrag;
    public LayerMask WhatIsGround;

    //public Action[] options;
    //Varibles
    [Header("Movement")]
    public float speed;
    public float jump;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SpeedControl();
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerheight * 0.5f * 0.2f, WhatIsGround);

        //handle drag
        if (grounded)
        {
            body.drag = groundeddrag;
        }
        else
        {
            body.drag = 0;
        }
      

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            body.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            moveSpeed = 15;
        }
    }

    void FixedUpdate()
    {

        body.AddForce(transform.right * horizontal * moveSpeed,ForceMode.Force);
        body.AddForce(transform.forward * vertical * moveSpeed,ForceMode.Force);

    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(body.velocity.x, 0f, body.velocity.z);

        //HumanLimit velocity if needed
        if (flatVel.magnitude > moveSpeed) 
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            body.velocity = new Vector3(limitedVel.x, body.velocity.y, limitedVel.z);
        }
    }
}
