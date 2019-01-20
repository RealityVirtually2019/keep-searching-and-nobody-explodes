using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTrigger : MonoBehaviour
{

	public ExplosionOne Exploder;

	private void OnTriggerEnter(Collider other)
	{
		if (GameStateManager.instance.currentGamePhase == GameStateManager.Phase.DEFUSING) {
//			if (other.CompareTag("GameController")) {
				Exploder.Explode();
				GameStateManager.instance.currentGamePhase = GameStateManager.Phase.DEFUSED;
//			}
		}
	}
}
