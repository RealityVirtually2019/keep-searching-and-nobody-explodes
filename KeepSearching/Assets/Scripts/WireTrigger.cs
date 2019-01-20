using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTrigger : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (GameStateManager.instance.currentGamePhase == GameStateManager.Phase.FINDING_CUTTERS) {
//			if (other.CompareTag("GameController")) {
				other.GetComponent<ExplosionOne>().Explode();
				GameStateManager.instance.currentGamePhase = GameStateManager.Phase.DEFUSED;
//			}
		}
	}
}
