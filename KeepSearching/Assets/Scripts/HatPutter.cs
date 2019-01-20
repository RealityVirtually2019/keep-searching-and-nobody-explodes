using UnityEngine;

public class HatPutter : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameStateManager.instance.BomberHatInstance) {
            Destroy(other.gameObject);
            GameStateManager.instance.currentGamePhase = GameStateManager.Phase.HIDING_CUTTERS;
        } else if (other.gameObject == GameStateManager.instance.DefuserHatInstance) {
            Destroy(other.gameObject);
            GameStateManager.instance.currentGamePhase = GameStateManager.Phase.FINDING_CUTTERS;
        }
    }
}
