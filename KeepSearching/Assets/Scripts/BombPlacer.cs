using UnityEngine;
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

        GameStateManager.instance.currentGamePhase = GameStateManager.Phase.PLACING_BOMB;
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
        if (controller != null && controller.Id == controllerId && Bomb != null
                && GameStateManager.instance.currentGamePhase == GameStateManager.Phase.PLACING_BOMB) {
            Bomb.transform.SetParent(MeshParent.transform);
            var rb = Bomb.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            GameStateManager.instance.currentGamePhase = GameStateManager.Phase.ONBOARDING_P1;
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
            if (button == MLInputControllerButton.HomeTap
                    && GameStateManager.instance.currentGamePhase == GameStateManager.Phase.ONBOARDING_P1) {
                Bomb.transform.SetParent(transform);
                var rb = Bomb.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.zero);
                rb.useGravity = false;
                rb.isKinematic = true;
                rb.constraints = RigidbodyConstraints.None;
                Bomb.transform.position = Bomb.transform.parent.position;
                GameStateManager.instance.currentGamePhase = GameStateManager.Phase.PLACING_BOMB;
            }
        }
    }
}
