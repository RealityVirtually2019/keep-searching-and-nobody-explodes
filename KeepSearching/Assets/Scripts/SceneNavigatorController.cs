using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.MagicLeap;

[RequireComponent(typeof(ControllerConnectionHandler))]
public class SceneNavigatorController : MonoBehaviour
{

    public string NextScene;
    public string PreviousScene;
    public string AlternativeScene;

    private ControllerConnectionHandler _controllerConnectionHandler;

    void Start () {
        _controllerConnectionHandler = GetComponent<ControllerConnectionHandler>();
        MLInput.OnTriggerDown += HandleOnTriggerDown;
        MLInput.OnControllerButtonDown += HandleOnButtonDown;
    }

    /// <summary>
    /// Handles the event for trigger down.
    /// </summary>
    /// <param name="controllerId">The id of the controller.</param>
    /// <param name="value">The value of the trigger button.</param>
    private void HandleOnTriggerDown(byte controllerId, float value)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && controller.Id == controllerId && !string.IsNullOrEmpty(NextScene)) {
            SceneManager.LoadScene(NextScene);
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
            if (button == MLInputControllerButton.HomeTap && !string.IsNullOrEmpty(PreviousScene)) {
                SceneManager.LoadScene(PreviousScene);
            }
            if (button == MLInputControllerButton.Bumper && !string.IsNullOrEmpty(AlternativeScene)) {
                SceneManager.LoadScene(AlternativeScene);
            }
        }
    }
}
