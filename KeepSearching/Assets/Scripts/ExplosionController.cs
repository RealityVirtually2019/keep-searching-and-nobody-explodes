using UnityEngine;
using UnityEngine.XR.MagicLeap;

[RequireComponent(typeof(ExplosionOne))]
public class ExplosionController : MonoBehaviour {

    private ControllerConnectionHandler _controllerConnectionHandler;

    // Use this for initialization
    void Start () {
        _controllerConnectionHandler = GetComponent<ControllerConnectionHandler>();
        //MLInput.OnTriggerUp += HandleOnTriggerDown;
        MLInput.OnControllerButtonDown += HandleOnButtonDown;

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightBracket)) {
            HandleExplosion();
        }
    }

    private void HandleOnButtonDown(byte controllerId, MLInputControllerButton button)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && controller.Id == controllerId)
        {
            if (button == MLInputControllerButton.Bumper)
            {
                HandleExplosion();
            }
        }

    }

    private void HandleExplosion()
    {
        GetComponent<ExplosionOne>().Explode();
    }


}
