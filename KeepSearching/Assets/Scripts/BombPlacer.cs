﻿using UnityEngine;
using UnityEngine.XR.MagicLeap;

[RequireComponent(typeof(ControllerConnectionHandler))]
public class BombPlacer : MonoBehaviour
{

    public GameObject Bomb;
    public GameObject MeshParent;

    private ControllerConnectionHandler _controllerConnectionHandler;

    // Use this for initialization
    void Start () {
        _controllerConnectionHandler = GetComponent<ControllerConnectionHandler>();
        MLInput.OnTriggerDown += HandleOnTriggerDown;
        MLInput.OnControllerButtonDown += HandleOnButtonDown;
    }

    // Update is called once per frame
    void Update () {

    }

    /// <summary>
    /// Handles the event for trigger down.
    /// </summary>
    /// <param name="controllerId">The id of the controller.</param>
    /// <param name="value">The value of the trigger button.</param>
    private void HandleOnTriggerDown(byte controllerId, float value)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && controller.Id == controllerId && Bomb != null) {
            Bomb.transform.SetParent(MeshParent.transform);
            var rb = Bomb.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }
    }

    /// <summary>
    /// Handles the event for trigger down.
    /// </summary>
    /// <param name="controllerId">The id of the controller.</param>
    /// <param name="button">The button that was pressed.</param>
    private void HandleOnButtonDown(byte controllerId, MLInputControllerButton button)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && controller.Id == controllerId) {
            if (button == MLInputControllerButton.HomeTap) {
                Bomb.transform.SetParent(transform);
                var rb = Bomb.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.zero);
                rb.useGravity = false;
                rb.isKinematic = true;
                rb.constraints = RigidbodyConstraints.None;
                Bomb.transform.position = Bomb.transform.parent.position;
            }
//            if (button == MLInputControllerButton.Bumper && !string.IsNullOrEmpty(AlternativeScene)) {
//                SceneManager.LoadScene(AlternativeScene);
//            }
        }
    }
}