using UnityEngine;

public class BombTrigger : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (GameStateManager.instance.currentGamePhase == GameStateManager.Phase.HIDING_CUTTERS) {
            if (other.CompareTag("GameController")) {
                other.GetComponent<ExplosionOne>().Explode();
            }
        }
    }
}
