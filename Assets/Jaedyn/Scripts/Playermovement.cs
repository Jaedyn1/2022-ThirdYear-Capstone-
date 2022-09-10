using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed = 10f, jumpPower = 10f;


    Rigidbody body;
    private bool isGrounded;
    float horizontal;
    float vertical;

    //public Action[] options;
    //Varibles
    public float speed;
    public float jump;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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

        body.AddForce(transform.right * horizontal * moveSpeed);
        body.AddForce(transform.forward * vertical * moveSpeed);

    }
}
