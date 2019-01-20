using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class GrabController : MonoBehaviour {

    private ControllerConnectionHandler _controllerConnectionHandler;
    public bool triggerPressed;

    void Start()
    {
        _controllerConnectionHandler = GetComponent<ControllerConnectionHandler>();
        MLInput.OnTriggerDown += HandleOnTriggerDown;
        MLInput.OnTriggerUp += HandleOnTriggerDown;
        MLInput.OnControllerButtonDown += HandleOnButtonDown;
        // MLInput.TriggerDownThreshold = 0.5f;
        Debug.Log("Trigger Down Threshold: " + MLInput.TriggerDownThreshold);
        Debug.Log("Trigger Up Threshold: " + MLInput.TriggerUpThreshold);

    }

    /// <summary>
    /// Handles the event for trigger down.
    /// </summary>
    /// <param name="controllerId">The id of the controller.</param>
    /// <param name="value">The value of the trigger button.</param>
    private void HandleOnTriggerDown(byte controllerId, float value)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && controller.Id == controllerId)
        {

            if (value > 0.7f)
            {
                triggerPressed = true;
                Debug.Log("Trigger State: " + triggerPressed);
            }
            else
            {
                triggerPressed = false;
                Debug.Log("Trigger State: " + triggerPressed);
            }


        }
    }

    /// <summary>
    /// Handles the event for home button down.
    /// </summary>
    /// <param name="controllerId">The id of the controller.</param>
    /// <param name="button">The button that was pressed.</param>
    private void HandleOnButtonDown(byte controllerId, MLInputControllerButton button)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && controller.Id == controllerId)
        {

        }
    }


    /// <summary>
    /// Handles the event for trigger being released.
    /// </summary>
    /// <param name="controllerId">The id of the controller.</param>
    /// <param name="button">The button that was pressed.</param>
    private void HandleOnTriggerUp(byte controllerId, MLInputControllerButton button)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && controller.Id == controllerId)
        {
            triggerPressed = false;
            Debug.Log("Trigger State: " + triggerPressed);
        }
    }

    /// <summary>
    /// Stop input api and unregister callbacks.
    /// </summary>
    void OnDestroy()
    {
        if (MLInput.IsStarted)
        {
            MLInput.OnTriggerDown -= HandleOnTriggerDown;
            MLInput.OnControllerButtonDown -= HandleOnButtonDown;
        }
    }
}

