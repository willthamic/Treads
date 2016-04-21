using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour {

	private string name;
	private float ammoA;
	private float ammoB;
	private int count;

	public GameObject Bullet;
	GameObject BulletInstantiate;

	// Use this for initialization
	void Start () {
		name = transform.parent.name;
		name = name.Substring(name.Length-1, 1);
		count = 0;
	}
	
	void FixedUpdate () {
		float fireA = Input.GetAxis ("FireA" + name);
		float fireB = Input.GetAxis ("FireB" + name);
		if (count > 10) {
			count -= 10;
			if (fireA == 1) {
				BulletInstantiate = (GameObject)Instantiate (Bullet, transform.position , transform.rotation);
				BulletInstantiate.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (250, 0));
			}
		}
		count++;
	}
}
