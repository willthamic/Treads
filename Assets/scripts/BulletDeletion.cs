using UnityEngine;
using System.Collections;

public class BulletDeletion : MonoBehaviour {

	void Start () {
		Destroy (gameObject, 3);
	}

	void  OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag != "bullet")
			Destroy (gameObject);
	}

}
