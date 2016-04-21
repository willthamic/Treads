using UnityEngine;
using System.Collections;

public class BulletDeletion : MonoBehaviour {

	void Start () {
		Destroy (gameObject, 3);
	}
	
	void  OnCollisionEnter2D(){
		Destroy (gameObject);
	}
}
