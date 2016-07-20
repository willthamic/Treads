using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public GameObject Fragment;
	GameObject FragmentInstantiate;

	void Start () {
		Destroy (gameObject, 3);
	}
	
	void  OnCollisionEnter2D(){
		missileFragment ();
	}

	void missileFragment () {
		int fragmentCount = 10;
		for (float i = 0; i < fragmentCount; i++) {
			float angle = (i/fragmentCount)*360;
			fragmentLaunch(angle);
		}
		Destroy (gameObject);
	}

	void fragmentLaunch (float angle) {
		float compX = Mathf.Cos(angle);
		float compY = Mathf.Sin (angle);
		FragmentInstantiate = (GameObject)Instantiate (Fragment, transform.position + new Vector3(compX/2,compY/2,0) , Quaternion.Euler(0, 0, angle));
		FragmentInstantiate.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (compX*250, compY*250));
	}
}
