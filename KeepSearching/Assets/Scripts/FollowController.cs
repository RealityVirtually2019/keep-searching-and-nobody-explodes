using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    private float speed = 100.0f;
    public Rigidbody rb;
    public Transform controller;
    public Transform controllerBody;
    Vector3 controllerPosition;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        HoldObject();

    }

    void OnCollisionEnter(Collision collision)
    {
        {
            print("Points colliding: " + collision.contacts.Length);
            print("First normal of the point that collide: " + collision.contacts[0].normal);
        }
    }
    void HoldObject()
    {
        //Create Vector 3 for controller position that keeps object at certain distance from controller
        controllerPosition = controller.position;
        rb.AddForce((controllerPosition - transform.position) * speed);
        transform.LookAt(controllerBody);

    }
}