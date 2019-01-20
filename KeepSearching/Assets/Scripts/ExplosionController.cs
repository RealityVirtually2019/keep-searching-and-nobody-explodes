using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ExplosionController : MonoBehaviour {

    private ControllerConnectionHandler _controllerConnectionHandler;
    public bool buttonPressed, bumperPressed;

    // Use this for initialization
    void Start () {
        _controllerConnectionHandler = GetComponent<ControllerConnectionHandler>();
        //MLInput.OnTriggerUp += HandleOnTriggerDown;
        MLInput.OnControllerButtonDown += HandleOnButtonDown;

    }

    private void HandleOnButtonDown(byte controllerId, MLInputControllerButton button)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && controller.Id == controllerId)
        {

            if (button == MLInputControllerButton.HomeTap)
            {
                buttonPressed = true;
            }
            if (button == MLInputControllerButton.Bumper)
            {
                bumperPressed = true;
            }
        }

    }


}
