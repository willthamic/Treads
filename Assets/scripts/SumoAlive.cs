using UnityEngine;
using System.Collections;

public class SumoAlive : MonoBehaviour {
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "court")
			Destroy (gameObject);
	}
}
