using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class GameLogic : MonoBehaviour
{
    public ControllerConnectionHandler _controllerConnectionHandler;

    void Start ()
    {
        Log("TriggerDownThreshold: {0}", MLInput.TriggerDownThreshold);
        MLInput.TriggerDownThreshold = 0.1f;
        Log("TriggerDownThreshold: {0}", MLInput.TriggerDownThreshold);
        MLInput.OnTriggerDown += HandleOnTriggerDown;
    }

    // Update is called once per frame
    void Update () {

    }

    /// <summary>
    /// Handles the event for trigger down.
    /// </summary>
    /// <param name="controller_id">The id of the controller.</param>
    /// <param name="value">The value of the trigger button.</param>
    private void HandleOnTriggerDown(byte controllerId, float value)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && controller.Id == controllerId)
        {
            Log("Trigger value: {0}", value);
        }
    }

    private void Log(string message, params object[] args)
    {
#if DEVELOPMENT_BUILD
        Debug.LogFormat(message, args);
#endif
    }
}
