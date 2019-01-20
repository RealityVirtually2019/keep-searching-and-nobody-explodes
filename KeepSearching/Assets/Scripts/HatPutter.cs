using UnityEngine;

public class HatPutter : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameStateManager.instance.bomberHat) {
            Destroy(other.gameObject);
            GameStateManager.instance.currentGamePhase = GameStateManager.Phase.HIDING_CUTTERS;
        }
    }
}
