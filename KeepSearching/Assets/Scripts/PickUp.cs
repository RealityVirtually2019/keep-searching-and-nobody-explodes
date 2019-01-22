﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {


    public Transform controller;
    public Transform controllerBody;
    public  GameObject objectInRange;
    private GameObject objectHeld;
    public GrabController grabControl;
    Vector3 controllerPosition;

        void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (objectHeld != null && !grabControl.triggerPressed
                && GameStateManager.instance.currentGamePhase != GameStateManager.Phase.DEFUSING)
        {
            ReleaseObject();
        }
        else if(objectInRange != null && grabControl.triggerPressed)
        {
            if (objectInRange.CompareTag("object"))
            {
                HoldObject(objectInRange);
            }
            if (objectInRange.CompareTag("cutters"))
            {
                objectInRange.transform.SetParent(controller);
                var rb = objectInRange.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;
                objectInRange.transform.position = controller.position;
                GameStateManager.instance.currentGamePhase = GameStateManager.Phase.DEFUSING;
                objectHeld = objectInRange;
            }
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        print("Collided object: " + collision.gameObject.name);
        //objectInRange = true;
        //objectHeld = collision.gameObject;
    }

   
     void OnTriggerEnter(Collider collision)
    {
        print("Trigger collided object: " + collision.gameObject.name);
        objectInRange = collision.gameObject;
        if (GameStateManager.instance.currentGamePhase == GameStateManager.Phase.HIDING_CUTTERS
                && collision.gameObject.CompareTag("GameController")) {
            collision.gameObject.GetComponent<ExplosionOne>().Explode();
            GameStateManager.instance.currentGamePhase = GameStateManager.Phase.ONBOARDING_P2;
        } else if ((GameStateManager.instance.currentGamePhase == GameStateManager.Phase.DEFUSING
                    && collision.gameObject.name.Equals("wire"))
                || GameStateManager.instance.currentGamePhase == GameStateManager.Phase.DEFUSED
                    && collision.gameObject.name.Equals("trigger")  ) {
            GetComponent<ExplosionOne>().Explode();
            GameStateManager.instance.currentGamePhase = GameStateManager.Phase.DEFUSED;
        }
    }

    //Checks if controller is separated from object
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject == objectInRange)
        {
            // TODO: handle multiple objects in range
            objectInRange = null;
            print("Trigger exited object: " + collision.gameObject.name);

        }
    }

    //Create Vector 3 for controller position that keeps object at certain distance from controller
    void HoldObject(GameObject obj)
    {
        if (GameStateManager.instance.currentGamePhase == GameStateManager.Phase.PLACING_BOMB) return;
        if (objectHeld == null)
        {
            objectHeld = obj;
        }
        Rigidbody rb  = objectHeld.GetComponent<Rigidbody>();
        float speed = 100.0f;
        rb.drag = 10f;
        rb.useGravity = false;
        rb.AddForce((controller.position - objectHeld.transform.position) * speed);
        objectHeld.transform.LookAt(controllerBody);

    }

    void ReleaseObject()
    {
        if (objectHeld != null)
        {
            Rigidbody rb = objectHeld.GetComponent<Rigidbody>();
            rb.useGravity = true;
            objectHeld = null;
        }
    }
}